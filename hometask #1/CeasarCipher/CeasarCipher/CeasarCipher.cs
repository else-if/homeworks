using System;
using System.Linq;

namespace Ceasar
{
    public class CeasarCipher
    {
        private static int MinCode { get; } = 33;
        private static int MaxCode { get; } = 126;

        // for EncryptDecrypt_WithRandomSting_ProducesTheSameResult test
        private readonly char[] _nonCryptingSymbols = {' '};

        private readonly int _offset;

        public CeasarCipher(int offset)
        {
            _offset = offset%(MaxCode - MinCode);
        }

        public string Encrypt(string word)
        {
            if (word == null) throw new ArgumentNullException();

            var result = "";
            foreach (var c in word)
            {
                if (_nonCryptingSymbols.Contains(c))
                    result += c;
                else
                    result += GetChar(c, _offset);
            }

            return result;
        }

        public string Decrypt(string word)
        {
            if (word == null) throw new ArgumentNullException();

            var result = "";
            foreach (var c in word)
            {
                if (_nonCryptingSymbols.Contains(c))
                    result += c;
                else
                    result += GetChar(c, -_offset);
            }

            return result;
        }

        private static char GetChar(int symbolCode, int offset)
        {
            if ((symbolCode < MinCode) || (symbolCode > MaxCode)) throw new ArgumentOutOfRangeException();

            var code = symbolCode + offset;

            var result = new char();
            if (code > MaxCode)
                result += (char) (MinCode + (code - MaxCode - 1));
            else if (code < MinCode)
                result += (char) (MaxCode - (MinCode - code - 1));
            else
                result += (char) code;

            return result;
        }
    }
}
