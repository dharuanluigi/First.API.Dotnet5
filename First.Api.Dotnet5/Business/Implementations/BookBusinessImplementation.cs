using First.API.Dotnet5.Data.Converter.Implementations;
using First.API.Dotnet5.Data.VO;
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
        private readonly BookConverter _converter;

        public BookBusinessImplementation(IRepository<Book> repository, ILogger<BookBusinessImplementation> logger)
        {
            _repository = repository;
            _looger = logger;
            _converter = new BookConverter();
        }

        public BookVO Add(BookVO book)
        {
            var bookEntity = _converter.Parser(book);
            return _converter.Parser(_repository.Create(bookEntity));
        }

        public BookVO GetABookById(int id)
        {
            return _converter.Parser(_repository.FindById(id));
        }

        public List<BookVO> GetAllBooks()
        {
            return _converter.Parser(_repository.FindAll());
        }

        public void Remove(int id)
        {
            _repository.Delete(id);
        }

        public BookVO Update(BookVO updatedBook)
        {
            var bookEntity = _converter.Parser(updatedBook);
            return _converter.Parser(_repository.Update(bookEntity));
        }
    }
}
