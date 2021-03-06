using First.API.Dotnet5.Data.Converter.Contract;
using First.API.Dotnet5.Data.VO;
using First.API.Model;
using System.Collections.Generic;
using System.Linq;

namespace First.API.Dotnet5.Data.Converter.Implementations
{
    public class PersonConverter : IParser<PersonVO, Person>, IParser<Person, PersonVO>
    {
        public Person Parser(PersonVO origin)
        {
            if(origin is null)
            {
                return default;
            }
            else
            {
                return new Person
                {
                    Id = origin.Id,
                    FirstName = origin.FirstName,
                    LastName = origin.LastName,
                    Gender = origin.Gender,
                    Address = origin.Address
                };
            }
        }

        public PersonVO Parser(Person origin)
        {
            if (origin is null)
            {
                return default;
            }
            else
            {
                return new PersonVO
                {
                    Id = origin.Id,
                    FirstName = origin.FirstName,
                    LastName = origin.LastName,
                    Gender = origin.Gender,
                    Address = origin.Address
                };
            }
        }

        public List<Person> Parser(List<PersonVO> origin)
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

        public List<PersonVO> Parser(List<Person> origin)
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
