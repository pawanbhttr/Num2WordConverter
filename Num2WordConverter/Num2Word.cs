using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Num2WordConverter
{
    public class Num2Word
    {
        public string ConvertToWord(string number)
        {
            var words = new Dictionary<int, string>()
            {
                {0, ""},
                {1, "One"},
                {2, "Two"},
                {3, "Three"},
                {4, "Four"},
                {5, "Five"},
                {6, "Six"},
                {7, "Seven"},
                {8, "Eight"},
                {9, "Nine"},
                {10, "Ten"},
                {11, "Eleven"},
                {12, "Twelve"},
                {13, "Thirteen"},
                {14, "Fourteen"},
                {15, "Fifteen"},
                {16, "Sixteen"},
                {17, "Seventeen"},
                {18, "Eighteen"},
                {19, "Nineteen"},
                {20, "Twenty"},
                {30, "Thirty"},
                {40, "Forty"},
                {50, "Fifty"},
                {60, "Sixty"},
                {70, "Seventy"},
                {80, "Eighty" },
                {90, "Ninety" }
            };
            var digits = new string[] { "", "Hundred", "Thousand", "Lakh", "Crore", "Arba", "Kharba", "Neel", "Padma", "Sankha" };
            var arr = number.Split('.');
            var _number = Convert.ToInt32(arr[0].Length > 0 ? arr[0] : 0);
            var _decimal = Convert.ToInt32(arr.Length == 2 && arr[1].Length > 0 ? arr[1] : 0);
            int rem;
            int divider;
            int counter = 0;
            List<string> str = new List<string>();
            while (_number > 0)
            {
                divider = counter == 1 ? 10 : 100;
                rem = _number % divider;
                if (rem >= 21)
                    str.Add(words[rem / 10 * 10] + " " + words[rem % 10] + " " + digits[counter]);
                else
                    str.Add(words[rem] + " " + digits[counter] + (counter == 1 && !string.IsNullOrWhiteSpace(str[0]) ? " And" : ""));
                _number /= divider;
                counter++;
            }
            var decStr = _decimal > 9 ? words[_decimal / 10 * 10] + " " + words[_decimal % 10] : words[_decimal * 10];
            str.Reverse();
            return
                (str.Count > 0 ? string.Join(" ", str).Trim() + " Rupees" : "")
                +
                (str.Count > 0 && !string.IsNullOrWhiteSpace(decStr) ? " And " : "")
                +
                (string.IsNullOrWhiteSpace(decStr) ? "" : decStr.Trim() + " Paisa");
        }
    }
}
