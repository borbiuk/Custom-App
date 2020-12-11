using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomBL.Controller
{
    public class DatabaseDataSaver : IDataSaver
    {
        public void Save<T>(T item) where T : class
        {
            using (var db = new CustomApplicationContext())
            {
                db.Set<T>().Add(item);          
                db.SaveChanges();
            }
        }
    }
}
