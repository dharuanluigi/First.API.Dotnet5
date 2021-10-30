using First.API.Model;
using System.Collections.Generic;

namespace First.API.Business
{
    public interface IBookBusiness
    {
        List<Book> GetAllBooks();

        Book GetABookById(int id);

        Book Add(Book book);

        void Remove(int id);

        Book Update(Book updatedBook);
    }
}
