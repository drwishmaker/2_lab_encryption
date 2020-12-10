using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_lab_encryption
{
    public interface ICipher
    {
        string Encode(string inputText, string key);
        string Decode(string inputText, string key);
    }
}
