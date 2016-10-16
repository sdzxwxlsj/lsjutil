﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lsj.Util.HtmlBuilder.Body;
using Lsj.Util.HtmlBuilder.Header;
using Lsj.Util.Logs;
using Lsj.Util.Text;

namespace Lsj.Util.HtmlBuilder
{
    /// <summary>
    /// HtmlParser
    /// </summary>
    public static class HtmlParser
    {
        /// <summary>
        /// ParsePage
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        unsafe public static HtmlPage ParsePage(string str)
        {
            var page = new HtmlPage();
            page = Parse(str) as HtmlPage;
            return page;
        }
        /// <summary>
        /// Parse
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        unsafe public static HtmlNode Parse(string str)
        {
            HtmlNode root = null;
            var length = str.Length;
            fixed (char* tmp = str)
            {
                var current = tmp;
                root = ParseNode(ref current, tmp + length);
            }
            return root;
        }

        unsafe static HtmlNode ParseNode(ref char* current, char* end)
        {
            HtmlNode node = null;
            char* start = null;
            string key = null;
            bool isnote = false;//是否为注释状态
            bool isparam = false;//是否为参数
            bool iswithoutend = false;
            bool isinchildren = false;
            bool ischeckend = false;
            bool indoctype = false;
            while (current < end)
            {
                if (isnote)
                {
                    if (*current == '-' && *(current + 1) == '-' && *(current + 1) == '>')
                    {
                        return new HtmlNote(StringHelper.ReadStringFromCharPoint(start + 3, current - start - 3));
                    }
                }
                else
                {
                    if (key == null)
                    {
                        if (indoctype)
                        {
                            if (*current == '>')
                            {
                                indoctype = false;
                            }
                        }
                        else
                        {
                            if (*current == '<' && !isnote)
                            {
                                start = current + 1;
                            }
                            else if (*current == '!' && current == start && *(current + 1) == '-' && *(current + 1) == '-')
                            {
                                isnote = true;
                                current = current + 2;
                            }
                            else if (*current == ' ' || *current == '>')
                            {
                                key = StringHelper.ReadStringFromCharPoint(start, current - start);
                                if (key != "!DOCTYPE")
                                {
                                    node = GetObject(key);
                                    iswithoutend = node is HtmlNodeWithoutEnd;
                                    start = current+1;
                                    if (*current == ' ')
                                    {
                                        isparam = true;
                                    }
                                }
                                else
                                {
                                    key = null;
                                    indoctype = true;
                                }
                            }
                        }
                        
                    }
                    else
                    {
                        if (isinchildren)
                        {
                            if (*current == '<')
                            {
                                if (*(current + 1) == '/')
                                {
                                    ischeckend = true;
                                    start = current + 2;
                                }
                                else
                                {
                                    var str = StringHelper.ReadStringFromCharPoint(start, current - start);
                                    str = str.Replace("\r", "").Replace("\n", "");
                                    if (str.Length > 0)
                                    {
                                        node.Add(new HtmlRawNode(str));
                                    }
                                    node.Add(ParseNode(ref current, end));
                                }
                            }
                            else if (*current == '>' && ischeckend)
                            {
                                var tmp = StringHelper.ReadStringFromCharPoint(start, current - start);
                                if (tmp == node.Name)
                                {
                                    break;
                                }
                            }
                        }
                        else
                        {
                            if (isparam)
                            {
                                if (*current == '"')
                                {
                                    var value = StringHelper.ReadStringFromCharPoint(start, current - start);
                                    node.Add(new HtmlParam
                                    {
                                        name = key,
                                        value = value
                                    });
                                    isparam = false;
                                }
                            }
                            else
                            {
                                if (*current == ' ')
                                {
                                    start = current + 1;
                                }
                                else if (*current == '>' || (*current == '/' && *(current + 1) == '>' && (current++) != null/*指针加1*/))
                                {
                                    if (iswithoutend)
                                    {
                                        break;//直接返回
                                    }
                                    else
                                    {
                                        isinchildren = true;
                                        start = current + 1;
                                    }
                                }
                                else if (*current == '=' && (*current + 1) == '"')
                                {
                                    key = StringHelper.ReadStringFromCharPoint(start, current - start);
                                    isparam = true;
                                    start = current + 2;
                                    current = current + 1;
                                }
                            }
                        }
                    }
                }
                current++;
            }
            return node;
        }

        public static HtmlNode GetObject(string type)
        {
            switch (type)
            {
                case "html":
                    return new HtmlPage();
                case "head":
                    return new head();
                case "meta":
                    return new meta();
                case "link":
                    return new link();
                case "title":
                    return new title();
                case "div":
                    return new div();
                case "section":
                    return new section();
                case "h1":
                    return new h1();
                case "h2":
                    return new h2();
                case "p":
                    return new p();
                case "a":
                    return new a();


                default:
                    LogProvider.Default.Warn("Unknown type: " + type);
                    return new unknown(type);
            }
        }


    }
}
