using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Bot
{
    //[Serializable]
    class Serializator
    {
        private FileStream FS;

        public Serializator()
        {
        }

        /// <summary>
        /// Запись объекта в файл
        /// </summary>
        /// <param name="obj"></param>
        public void Serialize(object obj)
        {
            FS = new FileStream(obj.GetType().ToString(),
                FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(FS, obj);
            FS.Close();
        }

        /// <summary>
        /// Чтение объекта из файла
        /// </summary>
        /// <returns></returns>
        public object Deserialize(string filename)
        {
            object Obj=null;

            FS = new FileStream(filename,
                FileMode.Open, FileAccess.Read, FileShare.Read);
            BinaryFormatter bf = new BinaryFormatter();
            try
            {
                Obj = bf.Deserialize(FS);
            }
            catch { }
            FS.Close();

            return Obj;
        }
    }
}
