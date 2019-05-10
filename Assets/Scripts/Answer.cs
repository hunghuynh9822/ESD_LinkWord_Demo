using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public class Answer
    {
        private string answer;
        private string[] chars;

        public Answer(string word)
        {
            this.answer = word;
            List<string> temp = new List<string>();
            for (int i = 0; i < word.Length; i++)
            {
                temp.Add(word[i].ToString());
            }
            this.chars = temp.ToArray();
        }

        public string getAnswer()
        {
            return answer;
        }

        public string[] getChars()
        {
            return chars;
        }
    }
}
