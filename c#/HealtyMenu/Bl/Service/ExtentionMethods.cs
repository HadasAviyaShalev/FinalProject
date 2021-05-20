using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bl.Service
{
   
        static class EnumerableExtensions
        {
            public static T[] ToFixedLength<T>(this IEnumerable<T> source, int length)
            {
                var result = new T[length];
                var i = 0;
                foreach (var e in source)
                {
                    if (i < length)
                    {
                        result[i++] = e;
                    }
                }
                return result;
            }
        }
    }

