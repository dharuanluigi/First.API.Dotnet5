using First.API.Model;
using First.API.Repository;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace First.API.Business.Implementations
{
    public class BookBusinessImplementation : IBookBusiness
    {
        private readonly IBookRepository _repository;
        private readonly ILogger<BookBusinessImplementation> _looger;

        public BookBusinessImplementation(IBookRepository repository, ILogger<BookBusinessImplementation> logger)
        {
            _repository = repository;
            _looger = logger;
        }

        public List<Book> GetAllBooks()
        {
            return _repository.GetAll();
        }
    }
}
