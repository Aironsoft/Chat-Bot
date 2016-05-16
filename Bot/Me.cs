using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot
{
    [Serializable]
    class Me
    {
        //Serializator srz = new Serializator();

        /// <summary>
        /// Словарь запомненных событий и знаний
        /// </summary>
        Dictionary<object, object> Knowledges = new Dictionary<object, object>();

        /// <summary>
        /// Словарь известных понятий (слово - характеристики)
        /// </summary>
        public Dictionary<string, Word> Dictionary = new Dictionary<string, Word>();

        /// <summary>
        /// Словарь моих запомненных реакций
        /// </summary>
        Dictionary<string, object> MyRemReactions = new Dictionary<string, object>();

        /// <summary>
        /// Словарь запомненных реакций собеседника
        /// </summary>
        Dictionary<string, object> ItrRemReactions = new Dictionary<string, object>();

        public Dictionary<string, Word> AllReactions = new Dictionary<string, Word>();
        string MyLastReaction = "";
        string UserLastReaction = "";
        bool DoNotKnowReaction = false;

        /// <summary>
        /// Список неизвестных реакций
        /// </summary>
        List<string> UnkReactions = new List<string>();

        /// <summary>
        /// Свои параметры состояния
        /// </summary>
        Dictionary<string, object> Conditions = new Dictionary<string, object>();

        /// <summary>
        /// Разговор с пользователем
        /// </summary>
        List<object> Dialog = new List<object>();

        public string Name = "КИСА";


        public Me()
        {
            Knowledges.Add("Имя", "КИСА");
            Knowledges.Add("Собеседники", new List<object>());
        }


        /// <summary>
        /// Функция получения реакции на входящую строку
        /// </summary>
        /// <param name="obj">Объект, на который нужно прореагировать</param>
        /// <returns></returns>
        public string GetReactionOn(object obj)
        {
            if (AllReactions == null)
                AllReactions = new Dictionary<string, Word>();

            List<string> Phrases = Parsing(obj); //Разбиение пришедшей строки на фразы

            string userMessage = (obj as string);

            //string Reaction = Process(Phrases);
            string Reaction = Processing(userMessage);


            if (Reaction==null && (obj is string))//если обработать сообщение не удалось
            {
                //Reaction = GetRemReaction(obj as string);

                UserLastReaction = userMessage;

                List<string> predicts = AllReactions[userMessage].Prediction();
                if(predicts.Count>0)
                {
                    Reaction = predicts.First();
                }

                if (Reaction == null)
                {
                    DoNotKnowReaction = true;
                    Reaction = "Мне не известно, что на это нужно говорить.";
                }
            }

            Serializator srz = new Serializator();
            srz.Serialize(this);

            return Reaction;
        }


        /// <summary>
        /// Предсказывает следующие слова на основании указанного слова и предыдущих слов
        /// </summary>
        /// <param name="word">После какого слова предсказывать</param><param name="Previous">Предыдущие слова</param>
        /// <returns></returns>
        public List<string> Prediction(string word, List<string> Previous) //(string word, List<string> Previous)
        {
            List<string> Predicted = new List<string>();

            if (Dictionary.ContainsKey(word))
            {
                Predicted = Dictionary[word].Prediction();
            }

            return Predicted;
        }

        //public void Training(stri


        /// <summary>
        /// Сохраняет пришедшую информацию
        /// </summary>
        /// <param name="obj"></param>
        void Saving(object obj)
        {
            if(Conditions.ContainsKey("диалог"))
            {
                if (Conditions["диалог"] is bool)
                {
                    bool dialogOn = Convert.ToBoolean(Conditions["диалог"]);

                    if(dialogOn) //если сейчас бот ведёт диалог
                    {


                    }
                }
            }
        }

        /// <summary>
        /// Разбиение фразы по словам
        /// </summary>
        List<string> ParsingByWords(object obj)
        {
            List<string> Phrase = new List<string>();
            List<string> Words = new List<string>();

            try //попытка разбиения фразы на слова
            {
                Words = (obj as string).Split(' ').ToList<string>();
            }
            catch
            {
                return null;
            }


            string word = "";
            int i = -1;
            while(++i< Words.Count)//для каждого слова из всех слов во фразе
            {
                word = Words.ElementAt(i).ToLower();

                if (word.Length == 0)
                {
                    Words.Remove(Words.ElementAt(i));
                    break;
                }

                if (word.Substring(0, 1) != "*")
                {
                    if (!Dictionary.Keys.Contains(word)) //else //если этого слова в словаре ещё нет
                    {
                        Dictionary.Add(word, new Word(word));
                    }

                    if (i > 0) //если это не первое слово во фразе
                    {
                        if (Dictionary.Keys.Contains(Words.ElementAt(i - 1).ToLower())) //если словарь содержит предыдущее слово
                        {
                            Dictionary[Words.ElementAt(i - 1).ToLower()].AddNext(word); //увеличить количество раз, когда это слово идёт после предыдущего
                        }
                    }
                }
            }


            return Phrase;
        }


        /// <summary>
        /// Разбиение сказанного собеседником на фразы
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public List<string> Parsing(object obj)
        {
            List<string> Phrases = new List<string>();

            if(obj is string)
            {
                string Message = (obj as string);

                
                if(!AllReactions.ContainsKey(Message))
                {
                    AllReactions.Add(Message, new Word(Message));
                }
                if(MyLastReaction!="" && MyLastReaction !=null )
                {
                    if (AllReactions.ContainsKey(MyLastReaction))
                    {
                        AllReactions[MyLastReaction].AddNext(Message);
                    }
                }


                int i = -1;
                char s = '\0';
                string phrase = "";

                while (++i<Message.Length)//проход по каждому символу сообщения
                {

                    s = Message.ElementAt(i);//текущий просматриваемый символ

                    if(s=='.' || s == '?' || s == '!' || i== Message.Length-1)
                    {
                        phrase = Message.Substring(0, i+1);
                        Message = Message.Remove(0, i + 1);

                        Phrases.Add(phrase);

                        i = 0;
                    }
                    else //остальные символы не считаются модификаторами
                    {

                    }
                }
            }

            foreach(string phrase in Phrases)
            {
                ParsingByWords(phrase);
            }
            //List<string> phrases = ParsingByWords(Phrases[0]);

            return Phrases;
        }

        /// <summary>
        /// Обработка сказанного собеседником
        /// </summary>
        /// <param name="Phrases"></param>
        /// <returns></returns>
        string Process(List<string> Phrases)
        {
            string Reaction = null;

            int i = -1;
            char s = '\0';
            string word = "";

            foreach (object phrase in Phrases)
            {
                if (phrase is string)//если данная фраза является строкой
                {
                    string Phrase = (phrase as string);

                    while (++i < Phrase.Length)//проход по каждому символу сообщения
                    {

                        s = Phrase.ElementAt(i);//текущий просматриваемый символ

                        if (s == ' ' || i==Phrase.Length-1)
                        {
                            word = Phrase.Substring(0, i+1);
                            word = word.Trim();
                            Phrase = Phrase.Remove(0, i+1);
                            i = 0;

                            if (word.ToLower()== "*напиши" || word.ToLower() == "*скажи" || (word.Length>=3 && word.Substring(0, 3) == "\\:/"))//ord.Substring(0, 3) == "\\:/"
                            {
                                MyLastReaction = "";

                                try
                                {
                                    if(Conditions["Нет реакции"] is bool)
                                    {
                                        bool cnd = false;

                                        try
                                        {
                                            cnd = Convert.ToBoolean(Conditions["Нет реакции"]);
                                        }
                                        catch { }

                                        if (cnd == true)
                                        {
                                            string unknown = "";
                                            if(UnkReactions.Last() is string)
                                            {
                                                unknown = (UnkReactions.Last() as string);

                                                MyRemReactions.Add(unknown, Phrase);

                                                while (UnkReactions.Contains(unknown))
                                                {
                                                    UnkReactions.Remove(unknown);
                                                }

                                                Phrase = "";

                                                if (Reaction == null)
                                                    Reaction = GetReactionOn(unknown);
                                                else if(Reaction is string)
                                                {
                                                    Reaction+=" "+ GetReactionOn(unknown);
                                                }
                                            }
                                        }
                                    }
                                }
                                catch { }
                            }
                            else if((word.Length >= 3 && word.Substring(0, 3) == "\\*/"))//добавление варианта ответа
                            {
                                word = word.Substring(3);

                                string unknown = "";
                                if (UnkReactions.Last() is string)
                                {
                                    unknown = (UnkReactions.Last() as string);

                                    MyRemReactions.Add(unknown, Phrase);

                                    while (UnkReactions.Contains(unknown))
                                    {
                                        UnkReactions.Remove(unknown);
                                    }

                                    Phrase = "";

                                    if (Reaction == null)
                                        Reaction = GetReactionOn(unknown);
                                    else if (Reaction is string)
                                    {
                                        Reaction += " " + GetReactionOn(unknown);
                                    }
                                }
                            }
                            else if((word.Length >= 2 && word.Substring(0,2)=="/\\"))//указание того, что необходимо вернуть на последнюю фразу
                            {
                                word = word.Substring(2);

                                if(Dictionary.ContainsKey(word))
                                {
                                    //if (Reaction == null)
                                    //    Reaction = Dictionary[word];
                                    //else if (Reaction is string)
                                    //{
                                    //    Reaction += " " + Dictionary[word];
                                    //}

                                    string unknown = "";
                                    if (UnkReactions.Last() is string)
                                    {
                                        unknown = (UnkReactions.Last() as string);
                                    }
                                    MyRemReactions.Add(unknown, Dictionary[word]);
                                    while (UnkReactions.Contains(unknown))
                                    {
                                        UnkReactions.Remove(unknown);
                                    }
                                }
                            }
                        }
                        else //остальные символы не считаются модификаторами
                        {

                        }
                    }
                }
            }

            return Reaction;
        }



        string Processing(string Message)
        {
            string Reaction = null;

            if (Message.Length >= 6 && Message.Substring(0, 6) == "*скажи")
            {
                Message = Message.Substring(6);
                Message = Message.Trim();

                if (!AllReactions.ContainsKey(Message))
                {
                    AllReactions.Add(Message, new Word(Message));
                }

                Reaction = Message;

                if (DoNotKnowReaction)
                {
                    if (UserLastReaction != "" && UserLastReaction != null)
                    {
                        if (AllReactions.ContainsKey(UserLastReaction))
                        {
                            AllReactions[UserLastReaction].AddNext(Message);
                        }

                        DoNotKnowReaction = false;
                        UserLastReaction = "";
                        MyLastReaction = Message;
                    }
                }
            }
            else if (Message.Length>=7 && Message.Substring(0, 7) == "*добавь")
            {
                Message = Message.Substring(7);
                Message = Message.Trim();

                if (!AllReactions.ContainsKey(Message))
                {
                    AllReactions.Add(Message, new Word(Message));
                }

                Reaction = Message;

                if (UserLastReaction != "" && UserLastReaction != null)
                {
                    if (AllReactions.ContainsKey(UserLastReaction))
                    {
                        AllReactions[UserLastReaction].AddNext(Message);
                    }

                    //DoNotKnowReaction = false;
                    //UserLastReaction = "";
                    MyLastReaction = Message;
                }
            }
            else if (Message.Length >= 6 && Message.Substring(0, 6) == "*удали")
            {
                //Message = Message.Substring(6);
                //Message = Message.Trim();

                if (AllReactions.ContainsKey(MyLastReaction))
                {
                    AllReactions.Remove(MyLastReaction);
                }

                Reaction = "Удалено";

            }

            return Reaction;
        }



        /// <summary>
        /// Выбор реакции из запомненного набора
        /// </summary>
        /// <param name="Message"></param>
        /// <returns></returns>
        string GetRemReaction(string Message)
        {
            string Reaction = null;

            if(MyRemReactions==null)
                MyRemReactions = new Dictionary<string, object>();

            if (MyRemReactions.ContainsKey(Message))//если в памяти присутствует запомненная реакция на данное сообщение
            {
                object Variants = MyRemReactions[Message];

                if(Variants is string)//если реакцией на данное сообщение является строка
                {
                    Reaction = (Variants as string);
                }
                else if(Variants is List<string>)//если реакцией на данное сообщение является список строк
                {
                    Random Rndm = new Random();
                    int i = Rndm.Next((Variants as List<string>).Count -1);
                    Reaction = (Variants as List<string>).ElementAt(i);
                }
                /////TODO надо запоминать частоту совпадения реакций и на её основе определять вероятность выбора той или иной подходящей реакции
                /////TODO дата и авторы полученных реакций тоже не помешают
            }
            else if (Message.Substring(0,2)!="/\\")//если в памяти отсутствует запомненная реакция на данное сообщение
            {
                UnkReactions.Add(Message);//добавить сообщение собеседника в список тех, примеры реакций на которые не известны

                if (!Conditions.ContainsKey("Нет реакции"))
                    Conditions.Add("Нет реакции", true);
                else
                    Conditions["Нет реакции"] = true;
            }

            return Reaction;
        }

        /// <summary>
        /// Чтение себя из файла
        /// </summary>
        /// <returns></returns>
        public object Opening()
        {
            Serializator srz = new Serializator();
            object me = srz.Deserialize(typeof(Me).ToString());

            if(!(me is Me))
            {
                return this;
            }
            else
            {
                return me;
            }
        }
    }
}
