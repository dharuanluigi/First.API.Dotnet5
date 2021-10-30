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

        public Book Add(Book book)
        {
            return _repository.AddBook(book);
        }

        public Book GetABookById(int id)
        {
            return _repository.GetABookById(id);
        }

        public List<Book> GetAllBooks()
        {
            return _repository.GetAll();
        }

        public void Remove(int id)
        {
            _repository.DeleteABook(id);
        }

        public Book Update(Book updatedBook)
        {
            return _repository.UpdateBook(updatedBook);
        }
    }
}
