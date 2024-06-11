using kolokwium2.Data;
using kolokwium2.Models;
using Microsoft.EntityFrameworkCore;

namespace kolokwium2.Services;

public class DataService: IDataService
{
    private readonly DataContext _dataContext;

    public DataService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<bool> DoesCharacterExist(int id)
    {
        return await _dataContext.Characters.AnyAsync(i => i.id == id);
    }

    public async Task<ICollection<Character>> GetCharacterData(int idCharacter)
    {
        var character = await _dataContext.Characters
            .Include(e => e.CharacterTitles)
            .ThenInclude(e => e.Title)
            .Include(e => e.Backpacks)
            .ThenInclude(e => e.Item)
            .Where(e => e.id == idCharacter)
            .ToListAsync();
        return character;
    }
    
    
}