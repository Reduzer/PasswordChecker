using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Security.Cryptography;
using System.Diagnostics;

namespace PasswordChecker.Hashing
{
    internal class sha1
    {
        private SHA1 m_sha1Class;

        public sha1()
        {

        }

        public string getHash(string sUserinput)
        {
            return calcHash(sUserinput);
        }

        private string calcHash(string sUserInput)
        {
            string sReturnString = sUserInput;

            using (m_sha1Class = SHA1.Create())
            {
                byte[] bytes = m_sha1Class.ComputeHash(Encoding.UTF8.GetBytes(sUserInput));

                var sb = new StringBuilder();

                foreach (byte b in bytes)
                {
                    sb.Append(b.ToString("X2"));
                }

                sReturnString = sb.ToString();
                Debug.WriteLine("Calculated SHA1 Hash: " + "\n" + sReturnString);
            }

            return sReturnString;
        }
    }
}
