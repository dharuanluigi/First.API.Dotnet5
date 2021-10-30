using First.API.Dotnet5.Model.Base;
using First.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First.API.Dotnet5.Repository.Generics
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T item);
        T Update(T item);
        void Delete(long id);
        T FindById(long id);
        List<T> FindAll();
        bool Exists(long id);
    }
}
