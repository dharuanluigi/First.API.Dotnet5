using First.API.Dotnet5.Data.Converter.Contract;
using First.API.Dotnet5.Data.VO;
using First.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace First.API.Dotnet5.Data.Converter.Implementations
{
    public class BookConverter : IParser<BookVO, Book>, IParser<Book, BookVO>
    {
        public Book Parser(BookVO origin)
        {
            if(origin is null)
            {
                return default;
            }
            else
            {
                return new Book
                {
                    Title = origin.Title,
                    Author = origin.Author,
                    Price = origin.Price,
                    ReleaseDate = origin.ReleaseDate
                };
            }
        }

        public BookVO Parser(Book origin)
        {
            if (origin is null)
            {
                return default;
            }
            else
            {
                return new BookVO
                {
                    Title = origin.Title,
                    Author = origin.Author,
                    Price = origin.Price,
                    ReleaseDate = origin.ReleaseDate
                };
            }
        }

        public List<Book> Parser(List<BookVO> origin)
        {
            if(origin is null)
            {
                return default;
            }
            else
            {
                return origin.Select(item => Parser(item)).ToList();
            }
        }

        public List<BookVO> Parser(List<Book> origin)
        {
            if(origin is null)
            {
                return default;
            }
            else
            {
                return origin.Select(item => Parser(item)).ToList();
            }
        }
    }
}
