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
        public Buffer(IEnumerable<T> enumerable, bool? state = null)
        {
            if (state != null)
            {
                this.state = state.Value;
            }
            else
            {
                this.buffer = new List<T>();
            }
            this.enumerable = enumerable;
            this.enumerator = enumerable.GetEnumerator();
        }
        bool state;
        IEnumerable<T> enumerable;
        IEnumerator<T> enumerator;
        List<T> buffer;
        public T Current
        {
            get
            {
                var current = this.enumerator.Current;
                if (buffer != null) buffer.Add(current);
                return current;
            }
        }

        object IEnumerator.Current => this.Current;

        public IEnumerator<T> GetEnumerator()
        {
            if (check != null && check == true)
            {
                return new Buffer<T>(this.enumerable);
            }
            if (state == false)
            {
                return this;
            }
            else return new Buffer<T>(this.buffer, this.state);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        bool? check = null;
        public bool MoveNext()
        {
            check = this.enumerator.MoveNext();
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
