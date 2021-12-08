using System.Collections.Generic;

namespace First.API.Dotnet5.Data.Converter.Contract
{
    public interface IParser<O, D>
    {
        D Parser(O origin);
        List<D> Parser(List<O> origin);
    }
}
