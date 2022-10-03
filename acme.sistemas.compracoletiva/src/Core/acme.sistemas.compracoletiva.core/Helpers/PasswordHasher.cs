using System;
using System.Security.Cryptography;
using System.Text;

namespace acme.sistemas.compracoletiva.core.Helpers
{
    public static class PasswordHasher
    {
        private static string SHA512(string value)
        {
            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] HashValue, MessageBytes = UE.GetBytes(value);
            SHA512Managed SHhash = new SHA512Managed();
            string strHex = "";
            HashValue = SHhash.ComputeHash(MessageBytes);
            foreach (byte b in HashValue)
            {
                strHex += String.Format("{0:x2}", b);
            }
            return strHex;
        }

        private static string SHA256(string value)
        {
            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] HashValue, MessageBytes = UE.GetBytes(value);
            SHA256Managed SHhash = new SHA256Managed();
            string strHex = "";
            HashValue = SHhash.ComputeHash(MessageBytes);
            foreach (byte b in HashValue)
            {
                strHex += String.Format("{0:x2}", b);
            }
            return strHex;
        }

        private static string SHA384(string value)
        {
            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] HashValue, MessageBytes = UE.GetBytes(value);
            SHA384Managed SHhash = new SHA384Managed();
            string strHex = "";
            HashValue = SHhash.ComputeHash(MessageBytes);
            foreach (byte b in HashValue)
            {
                strHex += String.Format("{0:x2}", b);
            }
            return strHex;
        }

        private static string MD5(string value)
        {
            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] HashValue, MessageBytes = UE.GetBytes(value);
            HMACMD5 SHhash = new HMACMD5();
            string strHex = "";
            HashValue = SHhash.ComputeHash(MessageBytes);
            foreach (byte b in HashValue)
            {
                strHex += String.Format("{0:x2}", b);
            }
            return strHex;
        }

        public static string GenerateHash(string password) => SHA512(SHA384(SHA256(password)));
    }
}
