using First.API.Model;
using System.Collections.Generic;

namespace First.API.Repository
{
    public interface IBookRepository
    {
        List<Book> GetAll();

        Book GetABookById(int id);

        Book AddBook(Book book);

        void DeleteABook(int id);

        Book UpdateBook(Book updatedBook);
    }
}
