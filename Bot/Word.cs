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
        //List<NextStats> NW = new List<NextStats>();
        //int nexts = 0;//сколько всего раз после этого слова шло другое слово


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
            //nexts++;

            NextWords = NextWords.OrderByDescending(word => word.Value.wasNext).ToDictionary(word => word.Key, word => word.Value);

            ///////////

        }

        public List<string> Prediction()
        {
            List<string> Predicted = new List<string>();


            int num = Math.Min(48, NextWords.Count);

            List<NextStats> pretendents = new List<NextStats>();

            List<string> keys = NextWords.Keys.Take(num).ToList<string>();

            for (int i = 0; i < num; i++)
            {
                pretendents.Add(NextWords[keys.ElementAt(i)]);
                pretendents.Last().Word = keys.ElementAt(i);
            }


            Dictionary<int, List<string>> SortedNexts = new Dictionary<int, List<string>>();
            for (int i = 0; i < pretendents.Count; i++)
            {
                if(SortedNexts.ContainsKey(pretendents.ElementAt(i).wasNext))
                {
                    SortedNexts[pretendents.ElementAt(i).wasNext].Add(pretendents.ElementAt(i).Word);
                }
                else
                {
                    SortedNexts.Add(pretendents.ElementAt(i).wasNext, new List<string>());
                    SortedNexts[pretendents.ElementAt(i).wasNext].Add(pretendents.ElementAt(i).Word);
                }
            }

            Random r = new Random();

            num = Math.Min(6, NextWords.Count);

            for (int k = 0; k < num; k++)
            {
                int keySum = 0;
                foreach (int key in SortedNexts.Keys)
                {
                    keySum += key * SortedNexts[key].Count;
                }

                int randomNum = r.Next(keySum);

                int minDelta = keySum + 1;
                List<int> minDeltaGroup = new List<int>();

                foreach (int key in SortedNexts.Keys)
                {
                    int delta = randomNum - key * SortedNexts[key].Count;
                    if (delta < 0)
                    {
                        delta = -delta;
                    }

                    if (delta < minDelta)
                    {
                        minDelta = delta;
                        minDeltaGroup.Clear();
                        minDeltaGroup.Add(key);
                    }
                    else if (delta == minDelta)
                    {
                        minDeltaGroup.Add(key);
                    }
                }

                int keySelected = minDeltaGroup.ElementAt(r.Next(minDeltaGroup.Count));

                int wID = r.Next(SortedNexts[keySelected].Count);
                string selectedWord = SortedNexts[keySelected].ElementAt(wID); ///!
                SortedNexts[keySelected].RemoveAt(wID);
                if(SortedNexts[keySelected].Count==0)
                {
                    SortedNexts.Remove(keySelected);
                }

                Predicted.Add(selectedWord);
            }

            //Predicted = NextWords.Keys.Take(num).ToList<string>();

            return Predicted;
        }
    }
}
