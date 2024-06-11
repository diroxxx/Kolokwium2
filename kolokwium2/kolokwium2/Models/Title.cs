using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kolokwium2.Models;
[Table("titles")]
public class Title
{
    [Key]
    public int Id { get; set; }

    [MaxLength(100)] public String Name { get; set; } = String.Empty;

    public ICollection<CharacterTitle> CharacterTitles { get; set; } = new HashSet<CharacterTitle>();
}