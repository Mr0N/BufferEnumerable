using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ext
{
    class Buffer<T> : IEnumerable<T>, IEnumerator<T>
    {
        public Buffer(IEnumerable<T> enumerable, bool bufferState = true, bool? state = null, bool saveBuffer = false)
        {
            if (state != null)
            {
                this.state = state.Value;
            }

            this.buffer = new List<T>();

            this.enumerable = enumerable;
            this.enumerator = enumerable.GetEnumerator();
            this.bufferState = bufferState;
            this.saveBuffer = saveBuffer;
        }
        int moveNext;
        int currentEnumerable;
        bool stateMoveNext;
        bool bufferState;
        bool state;
        bool? check = null;
        IEnumerable<T> enumerable;
        IEnumerator<T> enumerator;
        List<T> buffer;
        bool saveBuffer;
        public T Current
        {
            get
            {

                var current = this.enumerator.Current;
                if (stateMoveNext && buffer != null) buffer.Add(current);
                if (stateMoveNext)
                {
                    currentEnumerable++;
                    stateMoveNext = false;
                }
                return current;
            }
        }

        object IEnumerator.Current => this.Current;

        public IEnumerator<T> GetEnumerator()
        {
            try
            {
                if (saveBuffer) return this.enumerable.GetEnumerator(); 
                if (bufferState && currentEnumerable != moveNext)
                {
                    moveNext = 0;
                    currentEnumerable = 0;
                    stateMoveNext = false;
                    this.buffer = new List<T>();
                    this.Dispose();
                    this.enumerator = this.enumerable.GetEnumerator();
                    return this;
                }
                if (state == false)
                {
                    return this;
                }
                else return new Buffer<T>(this.buffer, true, true, true);
            }
            finally
            {
                this.moveNext = 0;
                this.currentEnumerable = 0;
            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public bool MoveNext()
        {

            stateMoveNext = true;
            check = this.enumerator.MoveNext();
            if (check.Value) moveNext++;
            return check.Value;
        }

        public void Reset()
        {
            throw new NotSupportedException();
        }

        public void Dispose()
        {
            this.enumerator.Dispose();
            this.state = true;
        }
    }
}
