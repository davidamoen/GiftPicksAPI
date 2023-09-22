namespace giftpicksapi.Services;
public interface IPickerService
{
    List<string> GetPicks(string family);
}