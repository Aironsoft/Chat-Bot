using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot
{
    [Serializable]
    class Word
    {
        public string Value;
        public List<string> Descriptions;//описания данного слова

        Dictionary<string, NextStats> NextWords = new Dictionary<string, NextStats>();
        List<NextStats> NW = new List<NextStats>();
        int nexts = 0;//сколько всего раз после этого слова шло другое слово


        public List<string> Synonyms = new List<string>();//синонимы данного слова
        public List<string> Antonyms = new List<string>();//антонимы данного слова


        public Word(string value)
        {
            Value = value;
        }

        public void AddNext(string nextWord)
        {
            if(!NextWords.ContainsKey(nextWord))
            {
                NextWords.Add(nextWord, new NextStats());
            }

            NextWords[nextWord].wasNext++;
            nexts++;

            NextWords = NextWords.OrderByDescending(word => word.Value.wasNext).ToDictionary(word => word.Key, word => word.Value);

            ///////////

        }

        public List<string> Prediction()
        {
            List<string> Predicted = new List<string>();

            int num = Math.Min(3, NextWords.Count);
            Predicted = NextWords.Keys.Take(num).ToList<string>();

            return Predicted;
        }
    }
}
