using System.ComponentModel.DataAnnotations.Schema;

namespace First.API.Dotnet5.Model.Base
{
    public class BaseEntity
    {
        [Column("id")]
        public int Id { get; set; }
    }
}
