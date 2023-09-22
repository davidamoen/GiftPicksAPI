
namespace giftpicksapi.Services;
public class PickerService : IPickerService
{
    public List<string> GetPicks(string family)
    {
        return new List<string> { "This is a gift pick" };
    }
}