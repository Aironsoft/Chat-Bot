using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot
{
    /// <summary>
    /// Собеседник
    /// </summary>
    class Interlocutor
    {
        /// <summary>
        /// Словать знаний о собеседнике
        /// </summary>
        Dictionary<object, object> Knowledges = new Dictionary<object, object>();


        public Interlocutor()
        {
            Knowledges.Add("Имя", "Незнакомец");
        }

        public string Name = "Незнакомец";
    }
}
