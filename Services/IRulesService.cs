using giftpicksapi.Models;

namespace giftpicksapi.Services;
public interface IRulesService
{
    bool PickOk(Person person1, Person person2);
}