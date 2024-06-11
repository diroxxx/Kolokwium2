using kolokwium2.Models;

namespace kolokwium2.Services;

public interface IDataService
{
    public Task<bool> DoesCharacterExist(int id);
    public Task<ICollection<Character>> GetCharacterData(int id);

    public Task<Character> GetCharacter(int idCharacter);
    public Task<Item?> DoesItemExist(int idItem);
    public Task<int> GetCharacterMaxWeight(int idCharacter);
    public Task<int> GetCharacterCurrentWeight(int idCharacter);

    public Task AddToEq(IEnumerable<Backpack> backpacks);
}