
using giftpicksapi.Models;

namespace giftpicksapi.Services;
public class PickerService : IPickerService
{
    private readonly List<Person> Hat;
    private readonly Random R;
    public PickerService(
        List<Person> hat, 
        Random r)
    {
        this.Hat = hat;
        this.R = r;
    }

    public Person DrawFromHat(Person personDrawing)
    {
        var idx = this.R.Next(0, this.Hat.Count);
        var personDrawnFromHat = this.Hat[idx];
        Console.WriteLine($"{personDrawing.Name} drew {personDrawnFromHat.Name}'s name from the hat.");
        return personDrawnFromHat;
    }
}