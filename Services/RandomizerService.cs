
using giftpicksapi.Models;

namespace giftpicksapi.Services;
public class RandomizerService : IRandomizerService
{
    public List<Person> GetRandomizedCopy(List<Person> list)
    {
        var r = new Random();
        var choices = new List<Person>(list);
        var newList = new List<Person>();
        while (choices.Count > 0)
        {
            var idx = r.Next(0, choices.Count);
            newList.Add(choices[idx]);
            choices.RemoveAt(idx);
        }
        return newList;
    }
}