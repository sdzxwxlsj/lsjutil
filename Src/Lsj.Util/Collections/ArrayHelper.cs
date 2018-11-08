﻿using System;
using System.Collections.Generic;

namespace Lsj.Util.Collections
{
    /// <summary>
    /// Array Helper
    /// </summary>
    public static class ArrayHelper
    {
#if NETSTANDARD
        /// <summary>
        /// Convert all item in the array
        /// </summary>
        /// <typeparam name="TInput"></typeparam>
        /// <typeparam name="TOutput"></typeparam>
        /// <param name="array"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        public static TOutput[] ConvertAll<TInput, TOutput>(TInput[] array, Func<TInput, TOutput> converter)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }
            var result = new TOutput[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                result[i] = converter(array[i]);
            }
            return result;
        }
#endif

        /// <summary>
        /// ConvertToThreeValueTuples
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <returns></returns>
        public static (T value, int row, int col)[] ToThreeValueTuples<T>(this T[][] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }
            var result = new List<ValueTuple<T, int, int>>();
            if (array != null)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    for (int j = 0; j < array[i].Length; j++)
                    {
                        if (!array[i][j].Equals(default(T)))
                        {
                            result.Add((array[i][j], i, j));
                        }
                    }
                }
            }
            return result.ToArray();
        }

        /// <summary>
        /// Transposition
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <returns></returns>
        public static T[,] Transposition<T>(this T[,] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }
            var lengthx = array.GetLength(0);
            var lengthy = array.GetLength(1);
            var result = new T[lengthy, lengthx];
            for (int i = 0; i < lengthx; i++)
            {
                for (int j = 0; j < lengthy; j++)
                {
                    result[j, i] = array[i, j];
                }
            }
            return result;
        }

        /// <summary>
        /// Transposition
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tuples"></param>
        /// <returns></returns>
        public static (T value, int row, int col)[] Transposition<T>(this (T value, int row, int col)[] tuples)
        {
            if (tuples == null)
            {
                throw new ArgumentNullException(nameof(tuples));
            }
            var result = new (T, int, int)[tuples.Length];
            for (int i = 0, x = 0; i < result.Length; i++)
            {
                for (int j = 0; j < tuples.Length; j++)
                {
                    if (tuples[j].row == i)
                    {
                        result[x] = (tuples[j].value, tuples[j].col, tuples[j].row);
                        x++;
                    }
                }
            }
            return result;
        }
    }

}

