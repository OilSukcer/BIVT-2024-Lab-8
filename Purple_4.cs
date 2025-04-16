using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Purple_4 : Purple
    {
        string _output;
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

        public Purple_4 (string input, (string, char)[] codes) : base(input)
        {
            _codes = codes;
        }

        public override void Review()
        {
            if (Input == null || _codes == null) return;

            _output = Input;
            for (int i = 0; i < _codes.Length; i++)
            {
                if (_codes[i].Item1 != null)
                    _output = _output.Replace(_codes[i].Item2.ToString(), _codes[i].Item1);
            }
        }
        public override string ToString()
        {
            return _output;
        }
    }
}
