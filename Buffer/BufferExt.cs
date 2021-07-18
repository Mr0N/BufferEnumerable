using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ext
{
   
    static class BufferExt
    {
        public static IEnumerable<T> ToBuffer<T>(this IEnumerable<T> enumerable, bool bufferState = true)
        {
            return new Buffer<T>(enumerable,bufferState);
        } 
    }
}
