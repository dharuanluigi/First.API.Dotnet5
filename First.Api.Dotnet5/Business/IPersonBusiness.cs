using First.API.Model;
using System.Collections.Generic;

namespace First.API.Business
{
    public interface IPersonBusiness
    {
        Person Create(Person p);
        Person Update(Person p);
        void Delete(long id);
        Person FindById(long id);
        List<Person> FindAll();
    }
}
