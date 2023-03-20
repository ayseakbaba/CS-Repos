using System;
using System.Collections.Generic;


namespace StudentInformation.DataAccess.Abstract
{//Kod tekrarını engellemek için interface' i generic tanımlıyoruz.
    public interface IRepository<T>
    {
        List<T> GetAll();
        T Get(string id);
        T Get(int id);
        string Delete(string id);//bilgi
        string Delete(int id);//bilgi
        T Update(T entity);//nesne
        T Add(T entity);//nesne
    }
}
