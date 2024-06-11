using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.JavaScript;

namespace kolokwium2.Models;
[Table("characters")]
public class Character
{
    [Key]
    public int id { get; set; }

    [MaxLength(50)] public String FirstName { get; set; } = String.Empty;

    [MaxLength(120)] public String LastName { get; set; } = String.Empty;
    
    public int CurrentWeight { get; set; }
    
    public int MaxWeight { get; set; }

    public ICollection<Backpack> Backpacks { get; set; } = new HashSet<Backpack>();
    public ICollection<CharacterTitle> CharacterTitles { get; set; } = new List<CharacterTitle>();


}