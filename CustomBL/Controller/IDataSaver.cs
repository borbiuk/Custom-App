using System;
using System.Collections.Generic;
using System.Text;
using CustomBL.Model;


namespace CustomBL.Controller
{
    public interface IDataSaver
    {
        void Save<T>(T item) where T : class;

        //T Load<T>() where T : class;
    }
}
