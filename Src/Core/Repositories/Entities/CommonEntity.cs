using System.ComponentModel.DataAnnotations;

namespace MovieAppApi.Src.Core.Repositories.Entities;

public abstract class CommonEntity
{
  [Required] public required DateTime CreatedAt { get; set; }

  [Required] public required DateTime UpdatedAt { get; set; }
}
