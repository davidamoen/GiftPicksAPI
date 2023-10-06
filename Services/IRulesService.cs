using giftpicksapi.Models;

namespace giftpicksapi.Services;
public interface IRulesService
{
    bool PickOk(Person person1, Person person2);
    bool IsSelf(Person person1, Person person2);
    bool AreMarried(Person person1, Person person2);
    bool IsChild(Person person1, Person person2);
    bool IsParent(Person person1, Person person2);
    bool IsSibling(Person person1, Person person2);
}