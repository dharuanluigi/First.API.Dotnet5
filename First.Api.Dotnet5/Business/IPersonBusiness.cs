using First.API.Dotnet5.Data.VO;
using First.API.Model;
using System.Collections.Generic;

namespace First.API.Business
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO p);

        PersonVO Update(PersonVO p);
        
        void Delete(long id);
        
        PersonVO FindById(long id);
        
        List<PersonVO> FindAll();
    }
}
