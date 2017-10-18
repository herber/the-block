using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Security.Cryptography;

namespace TheBlock1
{
    class BlockChain
    {
        public ArrayList Chain = new ArrayList();
        int current;
        public string firstHash;

        public BlockChain(string prevHash, string data, DateTime date)
        {
            current = 0;

            string hash = getHash(current, prevHash, data, date);
            firstHash = hash;
            Block<string> b = new Block<string>(current, prevHash, hash, data, date);
            Chain.Add(b);
            current++;
        }

        public Block<string> AddBlock(string prevHash, string data, DateTime date)
        {
            // Todo: add validation for prevHash
            string hash = getHash(current, prevHash, data, date);
            Block<string> b = new Block<string>(current, prevHash, hash, data, date);

            object o = Chain[current-1];

            if (validate((Block<string>)o, b))
            {
                Chain.Add(b);
                current++;
            }
            else
            {
                throw new Exception("Chain not valid");
            }

            return b;
        }

        public string getHash(int i, string prevHash, string data, DateTime date)
        {
            return getSHA(i.ToString() + prevHash + data + date.ToString());
        }

        string getSHA(string str)
        {
            SHA256Managed crypt = new SHA256Managed();
            StringBuilder hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(str), 0, Encoding.UTF8.GetByteCount(str));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }

        bool validate(Block<string> prevB, Block<string> newB)
        {
            bool valid = true;

            string newHash = getSHA(newB.index.ToString() + newB.previousHash + newB.data + newB.date.ToString());

            if (prevB.index + 1 != newB.index)
            {
                valid = false;
                throw new Exception("index");
            }

            if (prevB.hash != newB.previousHash)
            {
                valid = false;
                throw new Exception("index");
            }

            if (newHash != newB.hash)
            {
                valid = false;
                throw new Exception("index");
            }

            /*if (prevB.index + 1 != newB.index || prevB.hash != newB.previousHash || newHash != newB.hash)
            {
                valid = false;
            }*/

            return valid;
        }
    }
}
