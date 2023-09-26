using giftpicksapi.Models;

namespace giftpicksapi.Services;
public interface IRandomizerService
{
    List<Person> GetRandomizedCopy(List<Person> list);
}