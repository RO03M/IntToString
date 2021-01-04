using System;

namespace IntToString {
    class Program {

        //protected string[] scales = new string[] {
        //    "mil", "milhões", "bilhões", "trilhões", "quatrilhões", "quintilhão", "sextilhão", "septilhão"
        //};

        protected string[] scales = new string[] {
            "thousand", "million", "billion", "trillion", "quadrillion", "quintillion", "sextillion", "septillion"
        };

        static void Main(string[] args) {
            Program main = new Program();
            Console.Write("Enter your number: ");
            long number = long.Parse(Console.ReadLine());
            string numberString = number.ToString("N").Split(".")[0];
            Console.WriteLine("Your number is {0}", main.TransformNumberToReadable(numberString));
        }

        private string TransformNumberToReadable(string numberString) {
            string result = "";
            string[] separator = numberString.Split(",");
            int maxScale = separator.Length - 2;
            for (int i = 0; i < separator.Length; i++) {
                if (separator[i].TrimStart('0').Length == 0) break;
                if (i != separator.Length - 1) result += separator[i].TrimStart('0') + " " + scales[maxScale] + " ";
                else {
                    if (separator[i].TrimStart('0').Length == 3) {
                        result += separator[i].TrimStart('0')[0] + " hundred and " + separator[i].TrimStart('0')[1].ToString() + separator[i].TrimStart('0')[2].ToString();
                    } else result += "and " + separator[i].TrimStart('0');
                }
                maxScale--;
            }
            return result;
        }

    }
}
