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

    public async Task<Character> GetCharacter(int idCharacter)
    {
        return await _dataContext.Characters.FirstOrDefaultAsync(e => e.id == idCharacter);
    }

    public async Task<Item?> DoesItemExist(int idItem)
    {
        return await _dataContext.Items.FirstOrDefaultAsync(i => i.Id == idItem);
    }

    public async  Task<int> GetCharacterMaxWeight(int idCharacter)
    {
        throw new NotImplementedException();
        
    }

    public Task<int> GetCharacterCurrentWeight(int idCharacter)
    {
        throw new NotImplementedException();
    }

    public async Task AddToEq(IEnumerable<Backpack> backpacks)
    {
        await _dataContext.AddRangeAsync(backpacks);
        await _dataContext.SaveChangesAsync();
    }
}