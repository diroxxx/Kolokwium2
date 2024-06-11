using kolokwium2.Models;

namespace kolokwium2.Services;

public interface IDataService
{
    public Task<bool> DoesCharacterExist(int id);
    public Task<ICollection<Character>> GetCharacterData(int id);
}