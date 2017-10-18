using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBlock1
{
    class Block<T>
    {
        public int index;
        public string previousHash, hash;
        public T data;
        public DateTime date;

        public Block(int i, string prevHash, string hash, T data, DateTime date)
        {
            index = i;
            previousHash = prevHash;
            this.hash = hash;
            this.data = data;
            this.date = date;
        }
    }
}
