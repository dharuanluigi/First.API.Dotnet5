using First.API.Dotnet5.Data.Converter.Implementations;
using First.API.Dotnet5.Data.VO;
using First.API.Dotnet5.Repository.Generics;
using First.API.Model;
using System.Collections.Generic;

namespace First.API.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        private readonly IRepository<Person> _repository;
        private readonly PersonConverter _converter;

        public PersonBusinessImplementation(IRepository<Person> repository)
        {
            _repository = repository;
            _converter = new PersonConverter();
        }

        public PersonVO Create(PersonVO person)
        {
            var personEntity = _converter.Parser(person);
            return _converter.Parser(_repository.Create(personEntity));
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<PersonVO> FindAll()
        {
            return _converter.Parser(_repository.FindAll());
        }

        public PersonVO FindById(long id)
        {
            return _converter.Parser(_repository.FindById(id));
        }

        public PersonVO Update(PersonVO person)
        {
            var personEntity = _converter.Parser(person);
            return _converter.Parser(_repository.Update(personEntity));
        }
    }
}
