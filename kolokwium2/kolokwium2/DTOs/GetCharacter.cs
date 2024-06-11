using System.Runtime.InteropServices.JavaScript;

namespace kolokwium2.DTOs;

public class GetCharacter
{
    public String firstName { get; set; }
    public String lastName { get; set; }
    public int currentWeight { get; set; }
    public int maxWeight { get; set; }
    public IEnumerable<backpackDto> BackpackItems { get; set; }
    public IEnumerable<titleDTo> titles { get; set; }
}


public class backpackDto
{
    public String itemName { get; set; }
    public int itemWeight { get; set; }
    public int amount { get; set; }
}

public class titleDTo
{
    public String title { get; set; }
    public DateTime aquiredAt { get; set; }
    
}




