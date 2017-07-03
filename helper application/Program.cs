using System;
using System.IO;
using System.Linq;

namespace helper_application
{
    class Program
    {
        static void Main(string[] args)
        {
            var filename = Environment.CurrentDirectory + "/sav.dat";
            var filename2 = Environment.CurrentDirectory + "/pokeprism.sav";

            var dat = hexArray(filename);
            var sav = hexArray(filename2);

            for(int i = 0; i <= hexToInt("7FF0"); i++)
            {
                dat[i] = sav[i];
            }

            File.WriteAllBytes("conv.dat", GetBytes(dat));
        }

        static string[] hexArray(string path)
        {
            byte[] data = File.ReadAllBytes(path);
            string hex = BitConverter.ToString(data);
            return hex.Split("-".ToCharArray()[0]);
        }

        static byte[] GetBytes(string[] strArray)
        {
            var str = String.Join("-", strArray);

           var array = str.Split('-').Select(b => Convert.ToByte(b, 16)).ToArray();

            return array;
        }

        static int hexToInt(string hexValue)
        {
            return int.Parse(hexValue, System.Globalization.NumberStyles.HexNumber);
        }
    }
}
