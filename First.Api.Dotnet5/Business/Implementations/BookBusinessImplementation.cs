using First.API.Dotnet5.Repository.Generics;
using First.API.Model;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace First.API.Business.Implementations
{
    public class BookBusinessImplementation : IBookBusiness
    {
        private readonly IRepository<Book> _repository;
        private readonly ILogger<BookBusinessImplementation> _looger;

        public BookBusinessImplementation(IRepository<Book> repository, ILogger<BookBusinessImplementation> logger)
        {
            _repository = repository;
            _looger = logger;
        }

        public Book Add(Book book)
        {
            return _repository.Create(book);
        }

        public Book GetABookById(int id)
        {
            return _repository.FindById(id);
        }

        public List<Book> GetAllBooks()
        {
            return _repository.FindAll();
        }

        public void Remove(int id)
        {
            _repository.Delete(id);
        }

        public Book Update(Book updatedBook)
        {
            return _repository.Update(updatedBook);
        }
    }
}
