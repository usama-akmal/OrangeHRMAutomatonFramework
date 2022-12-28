using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRMAutomatonFramework.Utils
{
    public class Utils
    {
        private static Random rnd = new Random();

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[rnd.Next(s.Length)]).ToArray());
        }

        public static string RandomNumberString(int length)
        {
            const string chars = "123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[rnd.Next(s.Length)]).ToArray());
        }
    }
}
