using System.Transactions;
using kolokwium2.DTOs;
using kolokwium2.Models;
using kolokwium2.Services;
using Microsoft.AspNetCore.Mvc;

namespace kolokwium2.Controllers;

[ApiController]
[Route("api/[controller]/")]
public class CharactersController :ControllerBase
{
    private IDataService _dataService;

    public CharactersController(IDataService dataService)
    {
        _dataService = dataService;
    }


    [HttpGet]
    [Route("{idCharacter}")]
    public async Task<ActionResult> GetCharacter(int idCharacter)
    {

        if (! await _dataService.DoesCharacterExist(idCharacter))
        {
            return NotFound("Character with given id doesn't exist");
        }

        var character = await _dataService.GetCharacterData(idCharacter);
        
        
        
        return Ok( character.Select(e => new GetCharacter()
        {
            firstName = e.FirstName,
            lastName = e.LastName,
            currentWeight = e.CurrentWeight,
            maxWeight = e.MaxWeight,
            BackpackItems = e.Backpacks.Select(b => new backpackDto()
            {
                itemName = b.Item.Name,
                itemWeight = b.Item.Weight,
                amount = b.Amount
                
            }).ToList(),
            titles = e.CharacterTitles.Select(c => new titleDTo()
            {
                title = c.Title.Name,
                aquiredAt = c.AcquiredAt
            }).ToList()
        }));
    }

    [HttpPost]
    [Route("{characterId}/backpacks")]
    public async Task<ActionResult> AddItems(int characterId, MainToAdd mainToAdd)
    {

        var infoAboutItems = new AddItemDTO();
        
      
        
        var weight = 0;

        var character = await _dataService.GetCharacter(characterId);

        if (characterId == null)
        {
            return NotFound($"character with given id{characterId} doesn't exist");
        }
          
        
        List<Backpack> items = new List<Backpack>();
                
        foreach (var idItem in mainToAdd.addToEqs)
        {
            
            var item = await _dataService.DoesItemExist(idItem.liczba1);
            if (item == null)
            {
                return NotFound($"Item wit given id {idItem.liczba1} exist");
            }

            weight += item.Weight;
           infoAboutItems.ItemsDtos.Add(new ItemsDTO()
           {
               amount = idItem.liczba2,
               itemId = idItem.liczba1,
               characterId = character.id
           });
            items.Add(new Backpack()
            {
                CharacterId = character.id,
                ItemId = item.Id,
                Amount = idItem.liczba2
            });
        }

        if ( character.MaxWeight < weight + character.CurrentWeight)
        {
            return BadRequest("Character doesn't have enought space");
        }

        
      using  (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
      {
          
        await  _dataService.AddToEq(items);
        scope.Complete();
        }
      
        return Created( "api/items",   infoAboutItems);
    }
    
}