using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Purple_2 : Purple
    {
        private string[] _output = null;
        public string[] Output
        {
            get
            {
                if (_output == null) return null;
                string[] output = new string[_output.Length];
                Array.Copy(_output, output, _output.Length);
                return output;
            }
        }
        public Purple_2(string input) : base(input) { }
        public override void Review()
        {
            if (Input == null) return;

            string[] parts = Input.Split(' ');
            string[] output = new string[0];
            string[] line = new string[0];
            int symbolCounter = 0;                                          //символы ТОЛЬКО в словах строки (без пробелов)

            for (int i = 0; i < parts.Length; i++)
            {
                if (symbolCounter + line.Length + parts[i].Length <= 50)    //символы в имеющихся словах +
                                                                                                    //мин. количество пробелов с учетом новго слова +
                                                                                                    //символы в новом слове
                {
                    Array.Resize(ref line, line.Length + 1);                //добавляем слово в строку
                    line[line.Length - 1] = parts[i];
                    symbolCounter += parts[i].Length;
                }
                else                                                       //не хватает места в строке для iго слова
                {
                    int[] spacesPlaces = GetSpacesNumbers(line.Length, symbolCounter);
                    string str = line[0];

                    for (int j = 0; j < spacesPlaces.Length; j++)
                    {
                        str += new string(' ', spacesPlaces[j]) + line[j + 1];  //нужное кол-во пробелов + слово
                    }

                    Array.Resize(ref output, output.Length + 1);
                    output[output.Length - 1] = str;
                    i--;                                                    //в следующем цикле начнём с невошедшего слова
                    line = new string[0];
                    symbolCounter = 0;                                      //очищаем всё для новой строки
                }
            }
            
            if (line.Length > 0)                                            //добавляем остатки строки
            {
                int[] spacesPlaces = GetSpacesNumbers(line.Length, symbolCounter);
                string str = line[0];

                for (int j = 0; j < spacesPlaces.Length; j++)
                {
                    str += new string(' ', spacesPlaces[j]) + line[j + 1];  
                }

                Array.Resize(ref output, output.Length + 1);
                output[output.Length - 1] = str;
            }
            _output = output;
        }
        private int[] GetSpacesNumbers (int wordsNumber, int wordsSymbols)
        {
            if (wordsNumber == 1 || wordsNumber == 0) return new int[0];
            int spacesSymbols = 50 - wordsSymbols;
            int[] spaces = new int[wordsNumber - 1];
            int cnt = 0, i = 0;
            while (cnt < spacesSymbols)
            {
                
                spaces[i++] += 1;
                cnt += 1;
                if (i == wordsNumber - 1) i = 0;
            }
            return spaces;
        }
        public override string ToString()
        {
            return String.Join(Environment.NewLine, _output);
        }
    }
}
