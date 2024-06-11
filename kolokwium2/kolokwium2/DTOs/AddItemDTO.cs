using System.ComponentModel.DataAnnotations;

namespace kolokwium2.DTOs;

public class AddItemDTO
{
    public List<ItemsDTO>  ItemsDtos { get; set; }
        
}

public class ItemsDTO
{
    
    public int amount { get; set; }
    
   
    public int itemId { get; set; }
    
    
    public int characterId { get; set; }
}

public class AddToEq
{
    public int liczba1 { get; set; }
    public int liczba2 { get; set; }
}

public class MainToAdd
{
    public  List<AddToEq> addToEqs { get; set; }    
}


