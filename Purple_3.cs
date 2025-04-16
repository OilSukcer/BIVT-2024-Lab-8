using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Purple_3 : Purple
    {
        private string _output;
        private (string, char)[] _codes;
        public string Output => _output;

        public (string, char)[] Codes
        {
            get
            {
                if (_codes == null) return null;
                (string, char)[] codes = new (string, char)[_codes.Length];
                Array.Copy(_codes, codes, codes.Length);
                return codes;
            }
        }
        public Purple_3(string input) : base(input)
        {
            _codes = new (string, char)[0];
        }

        public override void Review()
        {
            if (Input == null) return;

            string[] pairs = new string[Input.Length - 1];
            
            for (int i = 0, k = 0; i <= pairs.Length - 1;i++)
            {

                    pairs[k] = String.Concat(Input[i], Input[i + 1]);
                    k++;
     
            }
            pairs = pairs.Where(x => Char.IsLetter(x[0]) && Char.IsLetter(x[1])).ToArray();
            var pairsDistinct = pairs.Distinct().ToArray();

            string[] pairsFrequent = SortFrequency(pairs, pairsDistinct).Take(5).ToArray();

            Array.Resize(ref  _codes, pairsFrequent.Length);
            for(int i = 32, k = 0; i < 127 && k < _codes.Length; i++)
            {
                if (!Input.Contains((char)i))
                {
                    _codes[k] = (pairsFrequent[k],(char)i);
                    k++;
                }
            }
            _output = Input;
            for (int i = 0; i < _codes.Length; i++)
            {
                _output = _output.Replace(_codes[i].Item1, _codes[i].Item2.ToString());
            }
        }
        private string[] SortFrequency(string[] pairs, string[] Dpairs)
        {
            if (pairs.Length == 0) return pairs;
            int[] freq = new int[Dpairs.Length];
            for (int i = 0;i < freq.Length;i++)
            {
                freq [i] = pairs.Count(x => x == Dpairs [i]);
            }

            for (int i = 1, j = 2; i < freq.Length;)
            {
                if (i == 0 || freq[i] <= freq[i - 1])
                {
                    i = j;
                    j++;
                }
                else
                {
                    var Ftemp = freq [i];
                    var Ptemp = Dpairs [i];
                    freq[i] = freq[i - 1];
                    freq[i - 1] = Ftemp;
                    Dpairs[i] = Dpairs [i - 1];
                    Dpairs[i-1] = Ptemp;
                    i--;
                }
            }
            return Dpairs;
        }
        public override string ToString()
        {
            return Output;
        }
    }
}
