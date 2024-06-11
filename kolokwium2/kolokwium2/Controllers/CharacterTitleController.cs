using kolokwium2.DTOs;
using kolokwium2.Services;
using Microsoft.AspNetCore.Mvc;

namespace kolokwium2.Controllers;

[ApiController]
[Route("api")]
public class CharacterTitleController :ControllerBase
{
    private IDataService _dataService;

    public CharacterTitleController(IDataService dataService)
    {
        _dataService = dataService;
    }


    [HttpGet]
    [Route("/characters/{idCharacter}")]
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
    
    
    
}