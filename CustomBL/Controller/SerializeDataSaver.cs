using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace CustomBL.Controller
{
    public class SerializeDataSaver : IDataSaver
    {
        public void Save<T>(T item) where T : class
        {
            var formatter = new BinaryFormatter();
            var fileName = typeof(T).Name;

            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, item);
            }
        }
    }
}
