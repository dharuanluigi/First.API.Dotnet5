using First.API.Model;
using System.Collections.Generic;

namespace First.API.Repository
{
    public interface IBookRepository
    {
        List<Book> GetAll();
    }
}
