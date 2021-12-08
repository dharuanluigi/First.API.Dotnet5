using First.API.Dotnet5.Data.Converter.Contract;
using First.API.Dotnet5.Data.VO;
using First.API.Model;
using System.Collections.Generic;
using System.Linq;

namespace First.API.Dotnet5.Data.Converter.Implementations
{
    public class PersonConverter : IParser<VO.PersonVO, API.Model.Person>, IParser<API.Model.Person, VO.PersonVO>
    {
        public API.Model.Person Parser(VO.PersonVO origin)
        {
            if(origin is null)
            {
                return default;
            }
            else
            {
                return new API.Model.Person
                {
                    Id = origin.Id,
                    FirstName = origin.FirstName,
                    LastName = origin.LastName,
                    Gender = origin.Gender,
                    Address = origin.Address
                };
            }
        }

        public VO.PersonVO Parser(API.Model.Person origin)
        {
            if (origin is null)
            {
                return default;
            }
            else
            {
                return new VO.PersonVO
                {
                    Id = origin.Id,
                    FirstName = origin.FirstName,
                    LastName = origin.LastName,
                    Gender = origin.Gender,
                    Address = origin.Address
                };
            }
        }

        public List<API.Model.Person> Parser(List<VO.PersonVO> origin)
        {
            if(origin is null)
            {
                return default;
            }
            else
            {
                return origin.Select(item => Parser(item)).ToList();
            }
        }

        public List<VO.PersonVO> Parser(List<API.Model.Person> origin)
        {
            if(origin is null)
            {
                return default;
            }
            else
            {
                return origin.Select(item => Parser(item)).ToList();
            }
        }
    }
}
