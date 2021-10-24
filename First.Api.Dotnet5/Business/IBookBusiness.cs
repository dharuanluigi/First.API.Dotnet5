using First.API.Model;
using System.Collections.Generic;

namespace First.API.Business
{
    public interface IBookBusiness
    {
        List<Book> GetAllBooks();
    }
}
