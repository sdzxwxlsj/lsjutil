﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Lsj.Util.Text;

namespace Lsj.Util.JSON
{
    /// <summary>
    /// JSON Parser
    /// </summary>
    public static class JSONParser
    {
        enum Status
        {
            wantStart,
            wantName,
            wantColon,
            wantValue,
            wantCommaOrEnd,
            End
        }
        enum ValueType
        {
            Bool,
            Number,
            String,
            Null,
        }
        /// <summary>
        /// Parse
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static dynamic Parse(string str)
        {
            if (str.IsNullOrEmpty())
            {
                return null;
            }
            unsafe
            {
                fixed (char* ptr = str)
                {
                    int index = 0;
                    int length = str.Length;
                    var result = ParseValue(ptr, ref index, length, null);
                    if (index != length)
                    {
                        char c = *(ptr + index);
                        while (Char.IsWhiteSpace(c))
                        {
                            index++;
                            c = *(ptr + index);
                        }
                        if (index != length - 1)
                        {
                            throw new InvalidDataException($"Error JSON string. Index = {index}");
                        }
                    }
                    return result;
                }
            }
        }
        /// <summary>
        /// Parse
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str"></param>
        /// <returns></returns>
        public static T Parse<T>(string str)
        {
            if (str.IsNullOrEmpty())
            {
                return default(T);
            }
            var length = str.Length;
            int index = 0;

            T result = default(T);
            unsafe
            {
                fixed (char* ptr = str)
                {
                    result = (T)(ParseValue(ptr, ref index, length, typeof(T)));
                    if (index != length)
                    {
                        char c = *(ptr + index);
                        while (Char.IsWhiteSpace(c))
                        {
                            index++;
                            c = *(ptr + index);
                        }
                        if (index != length - 1)
                        {
                            throw new InvalidDataException($"Error JSON string. Index = {index}");
                        }
                    }
                    return result;
                }
            }

        }

        private unsafe static object ParseValue(char* ptr, ref int index, int length, Type type)
        {
            char symbol = '\0';
            var status = Status.wantStart;
            bool isDynamic = true;
            bool isDic = false;
            dynamic result = null;
            PropertyInfo[] properties = null;
            Type listType = null;
            if (type != null)
            {
                isDic = type.GetInterfaces().Any(x => (x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IDictionary<,>)) || x == typeof(IDictionary));
                isDynamic = false;
                if (type != typeof(string))
                {
                    result = Activator.CreateInstance(type);
                    if (!isDic)
                    {
                        properties = type.GetProperties();
                    }
                }
            }


            string name = null;

            for (; index < length; index++)
            {
                var c = *(ptr + index);
                if (Char.IsWhiteSpace(c))
                {
                    continue;
                }
                else if (status == Status.wantStart)//起始字符
                {
                    if (c == '{')//object
                    {
                        symbol = c;
                        status = Status.wantName;
                        if (isDynamic)
                        {
                            result = new JSONObejct();
                        }
                    }
                    else if (c == '[')//list
                    {
                        symbol = c;
                        status = Status.wantValue;
                        if (isDynamic)
                        {
                            result = new JSONArray();
                        }
                        else
                        {
                            listType = type.GetInterfaces().Where(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IList<>)).FirstOrDefault();
                            if (listType == null)
                            {
                                throw new ArgumentException("Error Type. Json Array must be parsed to a IList<>.");
                            }
                        }
                    }
                    else if (c == '"')//字符串
                    {
                        var temp = GetString(ptr, ref index, length);
                        if (type != null && type.IsEnum)
                        {
                            result = Enum.Parse(type, temp);
                        }
                        else
                        {
                            result = temp;
                        }
                        status = Status.End;
                        break;
                    }
                    else if (c == 't' && length - index >= 4 && *(ptr + index + 1) == 'r' && *(ptr + index + 2) == 'u' && *(ptr + index + 3) == 'e')//true
                    {
                        index += 3;
                        return true;
                    }
                    else if (c == 'f' && length - index >= 5 && *(ptr + index + 1) == 'a' && *(ptr + index + 2) == 'l' && *(ptr + index + 3) == 's' && *(ptr + index + 4) == 'e')//false
                    {
                        index += 4;
                        return true;
                    }
                    else if (c == '-' || (c >= ASCIIChar.Num0 && c <= ASCIIChar.Num9))//decimal
                    {
                        result = GetDecimal(ptr, ref index, length);
                        status = Status.End;
                        break;
                    }
                    else if (c == 'n' && length - index >= 4 && *(ptr + index + 1) == 'u' && *(ptr + index + 2) == 'l' && *(ptr + index + 3) == 'l')//null
                    {
                        index += 3;
                        return null;
                    }
                    else
                    {
                        throw new InvalidDataException($"Error JSON string. Index = {index}");
                    }
                }
                else if (status == Status.wantName)//名称
                {
                    name = GetString(ptr, ref index, length);
                    status = Status.wantColon;
                }
                else if (status == Status.wantColon)//冒号
                {
                    if (c == ':')
                    {
                        status = Status.wantValue;
                    }
                    else
                    {
                        throw new InvalidDataException($"Error JSON string. Index = {index}");
                    }
                }
                else if (status == Status.wantValue)//值
                {
                    if (isDynamic)//动态
                    {
                        if (name != null)//JSONObject
                        {
                            var value = ParseValue(ptr, ref index, length, null);
                            result.Set(name, value);
                            status = Status.wantCommaOrEnd;
                        }
                        else//JSONArray
                        {
                            if (result.Count == 0 && c == ']')
                            {
                                status = Status.End;
                                break;
                            }
                            var value = ParseValue(ptr, ref index, length, null);
                            result.Add(value);
                            status = Status.wantCommaOrEnd;
                        }
                    }
                    else
                    {
                        if (name != null)
                        {
                            if (isDic)//Dic
                            {
                                var value = ParseValue(ptr, ref index, length, null);
                                type.GetMethod("Add").Invoke(result, new object[] { name, value });
                                status = Status.wantCommaOrEnd;
                            }
                            else//Object
                            {
                                var property = properties.Where(x => x.Name == name && !x.GetCustomAttributes(typeof(NotSerializeAttribute), true).Any()).FirstOrDefault();
                                if (property != null)
                                {
                                    var value = ParseValue(ptr, ref index, length, property.PropertyType);
                                    property.SetValue(result, value, null);
                                    status = Status.wantCommaOrEnd;
                                }
                                else
                                {
                                    throw new InvalidDataException($@"Error JSON String. Cannot Find Property ""{name}"".");
                                }
                            }
                        }
                        else//List
                        {
                            if (result.Count == 0 && c == ']')
                            {
                                status = Status.End;
                                break;
                            }
                            var value = ParseValue(ptr, ref index, length, listType.GetGenericArguments()[0]);
                            type.GetMethod("Add").Invoke(result, new object[] { value });
                            status = Status.wantCommaOrEnd;
                        }

                    }
                }
                else if (status == Status.wantCommaOrEnd)
                {
                    if (c == ',')
                    {
                        if (name != null)
                        {
                            status = Status.wantName;
                        }
                        else
                        {
                            status = Status.wantValue;
                        }
                    }
                    else if (symbol == '{' && c == '}')
                    {
                        status = Status.End;
                        break;
                    }
                    else if (symbol == '[' && c == ']')
                    {
                        status = Status.End;
                        break;
                    }
                    else
                    {
                        throw new InvalidDataException($"Error JSON string. Index = {index}");
                    }
                }
            }
            if (status != Status.End)
            {
                throw new InvalidDataException($@"Error JSON String. Not Complete.");
            }
            if (type != null && type.GetInterface("System.IConvertible") != null)
            {
                result = Convert.ChangeType(result, type);
            }
            return result;
        }




        private unsafe static string GetString(char* ptr, ref int index, int length)
        {
            if (*(ptr + index) != '"')
            {
                throw new ArgumentException("Internal Error");
            }
            index++;
            var sb = new StringBuilder();
            for (; index < length; index++)
            {
                var c = *(ptr + index);
                if (c == '"')
                {
                    return sb.ToString();
                }
                else if (c == '\\')
                {
                    index++;
                    if (index >= length)
                    {
                        break;
                    }
                    c = *(ptr + index);
                    if (c == '"' || c == '\\' || c == '/')
                    {
                        sb.Append(c);
                    }
                    else if (c == 'b')
                    {
                        sb.Append('\b');
                    }
                    else if (c == 'f')
                    {
                        sb.Append('\f');
                    }
                    else if (c == 'n')
                    {
                        sb.Append('\n');
                    }
                    else if (c == 'r')
                    {
                        sb.Append('\r');
                    }
                    else if (c == 't')
                    {
                        sb.Append('\t');
                    }
                    else if (c == 'u')
                    {
                        index += 4;
                        if (index >= length)
                        {
                            break;
                        }
                        var x = "" + *(ptr + index - 3) + *(ptr + index - 2) + *(ptr + index - 1) + *(ptr + index);
                        if (int.TryParse(x, NumberStyles.AllowHexSpecifier, null, out int result))
                        {
                            sb.Append((char)result);
                        }
                        else
                        {
                            throw new InvalidDataException($"Error JSON string. Index = {index}");
                        }
                    }
                }
                else
                {
                    sb.Append(c);
                }
            }
            throw new InvalidDataException("Error JSON String. Not Complete.");
        }


        private unsafe static decimal GetDecimal(char* ptr, ref int index, int length)
        {
            bool hasDot = false;
            bool hasNumber = false;
            int start = index;
            var sb = new StringBuilder();
            while (index < length)
            {
                var c = *(ptr + index);
                if (c == '.')
                {
                    if (hasNumber && !hasDot)
                    {
                        sb.Append(c);
                        index++;
                    }
                    else
                    {
                        throw new InvalidDataException($"Error JSON string. Index = {index}");
                    }
                }
                else if (c >= '0' && c <= '9')
                {
                    sb.Append(c);
                    hasNumber = true;
                    index++;
                }
                else if (c == '-')
                {
                    if (index != start)
                    {
                        throw new InvalidDataException($"Error JSON string. Index = {index}");
                    }
                    else
                    {
                        sb.Append(c);
                        index++;
                    }
                }
                else
                {
                    break;
                }
            }
            if (!hasNumber)
            {
                throw new InvalidDataException($"Error JSON string. Index = {index}");
            }
            if (decimal.TryParse(sb.ToString(), out decimal result))
            {
                index--;
                return result;
            }
            else
            {
                throw new InvalidDataException($"Error JSON string. Index = {index}");
            }
        }
    }
}