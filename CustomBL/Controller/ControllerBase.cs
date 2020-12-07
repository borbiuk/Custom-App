using System;
using System.Collections.Generic;
using System.Text;

namespace CustomBL.Controller
{
    public abstract class ControllerBase
    {
        private readonly IDataSaver manager = new SerializeDataSaver();
        protected void Save<T>(T item) where T : class
        {
            manager.Save(item);
        }
        //protected T Load<T>() where T : class
        //{
        //    return manager.Load<T>();
        //}
    }
}
