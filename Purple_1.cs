using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Purple_1 : Purple
    {
        private string _output = null;
        private static char[] _punctuation = { '.', '!', '?', ',', ':', '\"', ';', '–', '(', ')', '[', ']', '{', '}', '/' };
        public string Output => _output;
        public Purple_1(string input) : base(input)
        {

        }
        public override void Review()
        {
            if (Input == null) return;

            string[] output = new string[0];

            string separators = "";

            string[] parts = Input.Split(' ');

            for (int i = 0; i < parts.Length; i++)
            {
                if (string.IsNullOrEmpty(parts[i])) continue;
                if (parts[i].Any(Char.IsDigit))
                {
                    Array.Resize(ref output, output.Length + 1);
                    output[output.Length - 1] = parts[i];
                    continue;
                }

                string word = "";
                string firstP = "";
                string lastP = "";

                for (int j = 0; j < parts[i].Length; j++)
                {
                    if (_punctuation.Contains(parts[i][j]))
                    {
                        if (word == "")
                            firstP += parts[i][j];
                        else
                            lastP += parts[i][j];
                    }
                    else
                    {
                        word += parts[i][j];
                    }


                    if (j == parts[i].Length - 1)
                    {
                        Array.Resize(ref output, output.Length + 1);
                        output[output.Length - 1] = firstP + new string(word.Reverse().ToArray()) + lastP;
                    }

                }
                
            }
            _output = String.Join(" ", output) + separators.ToString();
            Console.WriteLine(_output);
        }
    
        public override string ToString()
        {
            return _output;
        }
    }
}
