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
            using (var db = new ApplicationContext())
            {
                db.Set<T>().Add(item);          /// розібратися
                db.SaveChanges();
            }
        }

        //public T Load<T>() where T : class
        //{
        //    using (var db = new ApplicationContext())
        //    {
        //        T result = db.Set<T>(T);        
        //        return result ;          
        //    }
        //}
    }
}
