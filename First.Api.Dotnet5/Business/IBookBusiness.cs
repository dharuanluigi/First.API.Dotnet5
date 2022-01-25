using First.API.Dotnet5.Data.VO;
using System.Collections.Generic;

namespace First.API.Business
{
    public interface IBookBusiness
    {
        List<BookVO> GetAllBooks();

        BookVO GetABookById(int id);

        BookVO Add(BookVO book);

        void Remove(int id);

        BookVO Update(BookVO updatedBook);
    }
}
