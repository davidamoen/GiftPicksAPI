using giftpicksapi.Models;

namespace giftpicksapi.Services;
public class RulesService : IRulesService
{
    public bool PickOk(Person person1, Person person2)
    {
        return  !IsSelf(person1, person2) &&
                !AreMarried(person1, person2) &&
                !IsChild(person1, person2) &&
                !IsParent(person1, person2) &&
                !IsSibling(person1, person2);
    }

    private bool IsSelf(Person person1, Person person2) {
        return person1.Name == person2.Name;
    }

    private bool AreMarried(Person person1, Person person2)
    {
        return person1.Spouse == person2.Name;
    }

    private bool IsChild(Person person1, Person person2)
    {
        return person2.Children.Contains(person1.Name);
    }

    private bool IsParent(Person person1, Person person2)
    {
        return person1.Children.Contains(person2.Name);
    }

    private bool IsSibling(Person person1, Person person2)
    {
        return person1.Siblings.Contains(person2.Name);
    }   
}