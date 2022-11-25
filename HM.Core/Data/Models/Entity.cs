using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HM.Core.Data.Models;

public interface IBaseEntity { }

public interface IEntity : IBaseEntity
{
    public int Id { get; set; }
}

public class Entity : IEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
}