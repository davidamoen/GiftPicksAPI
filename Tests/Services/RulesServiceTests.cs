using giftpicksapi.Models;

namespace Tests;

public class RulesServiceTests : IClassFixture<RulesService>
{
    private readonly IRulesService rulesService;
    private readonly IFamilyService familyService;

    public RulesServiceTests()
    {
        rulesService = new RulesService();
        familyService = new FamilyService();
    }

    [Fact]
    public void IsSelf_returns_true_for_same_person()
    {
        // arrange
        var person1 = new Person(giftpicksapi.Enums.Members.David);
        var person2 = new Person(giftpicksapi.Enums.Members.David);

        // act 
        var result = rulesService.IsSelf(person1, person2);

        // assert
        Assert.True(result, "A person cannot give to themselves.");
    }

    [Fact]
    public void AreMarried_returns_true_for_spouses()
    {
        // arrange
        var person1 = new Person(giftpicksapi.Enums.Members.David);
        person1.Spouse = giftpicksapi.Enums.Members.Cindy;
        var person2 = new Person(giftpicksapi.Enums.Members.Cindy);

        // act 
        var result = rulesService.AreMarried(person1, person2);

        // assert
        Assert.True(result, "A person cannot give to spouse");
    }

    [Fact]
    public void AreMarried_returns_false_for_non_spouses()
    {
        // arrange
        var person1 = new Person(giftpicksapi.Enums.Members.David);
        person1.Spouse = giftpicksapi.Enums.Members.David;
        var person2 = new Person(giftpicksapi.Enums.Members.Cindy);

        // act 
        var result = rulesService.AreMarried(person1, person2);

        // assert
        Assert.False(result, "Persons are not spouses");
    }     

    [Fact]
    public void IsChild_returns_true_for_children()
    {
        // arrange
        var person1 = new Person(giftpicksapi.Enums.Members.Garrett);
        var person2 = new Person(giftpicksapi.Enums.Members.David);
        person2.Children.Add(giftpicksapi.Enums.Members.Garrett);

        // act 
        var result = rulesService.IsChild(person1, person2);

        // assert
        Assert.True(result, "Persons related");
    }

    [Fact]
    public void IsChild_returns_false_for_non_children()
    {
        // arrange
        var person1 = new Person(giftpicksapi.Enums.Members.Garrett);
        var person2 = new Person(giftpicksapi.Enums.Members.David);

        // act 
        var result = rulesService.IsChild(person1, person2);

        // assert
        Assert.False(result, "Not a child");
    }    

    [Fact]
    public void IsParent_returns_true_for_parent()
    {
        // arrange
        var person1 = new Person(giftpicksapi.Enums.Members.Garrett);
        var person2 = new Person(giftpicksapi.Enums.Members.David);
        person2.Children.Add(giftpicksapi.Enums.Members.Garrett);

        // act 
        var result = rulesService.IsParent(person2, person1);

        // assert
        Assert.True(result, "Persons related");
    }    

    [Fact]
    public void IsParent_returns_false_for_non_parent()
    {
        // arrange
        var person1 = new Person(giftpicksapi.Enums.Members.Garrett);
        var person2 = new Person(giftpicksapi.Enums.Members.David);

        // act 
        var result = rulesService.IsParent(person2, person1);

        // assert
        Assert.False(result, "Persons related");
    }   

    [Fact]
    public void IsSibling_returns_true_for_siblings()
    {
        // arrange
        var person1 = new Person(giftpicksapi.Enums.Members.Garrett);
        var person2 = new Person(giftpicksapi.Enums.Members.Nicholas);
        person1.Siblings.Add(giftpicksapi.Enums.Members.Nicholas);
        person2.Siblings.Add(giftpicksapi.Enums.Members.Garrett);

        // act 
        var result = rulesService.IsSibling(person1, person2);

        // assert
        Assert.True(result, "Persons related");
    }   

    [Fact]
    public void IsSibling_returns_false_for_non_siblings()
    {
        // arrange
        var person1 = new Person(giftpicksapi.Enums.Members.Garrett);
        var person2 = new Person(giftpicksapi.Enums.Members.Nicholas);

        // act 
        var result = rulesService.IsSibling(person1, person2);

        // assert
        Assert.False(result, "Persons not related");
    }       

    [Fact]
    public void PickOk_returns_true_correctly_dave_jack()
    {
        // arrange
        var kremerFamily = familyService.GetFamily("kremer");
        var dave = familyService.GetFamilyMember(kremerFamily, giftpicksapi.Enums.Members.David);
        var jack = familyService.GetFamilyMember(kremerFamily, giftpicksapi.Enums.Members.Jack);

        // act 
        var result = rulesService.PickOk(dave, jack);

        // assert
        Assert.True(result, "pick OK");
    }
    
    [Fact]
    public void PickOk_returns_true_correctly_dave_kevin()
    {
        // arrange
        var kremerFamily = familyService.GetFamily("kremer");
        var dave = familyService.GetFamilyMember(kremerFamily, giftpicksapi.Enums.Members.David);
        var kevin = familyService.GetFamilyMember(kremerFamily, giftpicksapi.Enums.Members.Kevin);

        // act 
        var result = rulesService.PickOk(dave, kevin);

        // assert
        Assert.True(result, "pick OK");
    }

    [Fact]
    public void PickOk_returns_true_correctly_cindy_lorna()
    {
        // arrange
        var kremerFamily = familyService.GetFamily("kremer");
        var cindy = familyService.GetFamilyMember(kremerFamily, giftpicksapi.Enums.Members.Cindy);
        var lorna = familyService.GetFamilyMember(kremerFamily, giftpicksapi.Enums.Members.Lorna);

        // act 
        var result = rulesService.PickOk(cindy, lorna);

        // assert
        Assert.True(result, "pick OK");
    }    
    
        [Fact]
    public void PickOk_returns_true_correctly_cecilia_lorna()
    {
        // arrange
        var kremerFamily = familyService.GetFamily("kremer");
        var cecilia = familyService.GetFamilyMember(kremerFamily, giftpicksapi.Enums.Members.Vincent);
        var lorna = familyService.GetFamilyMember(kremerFamily, giftpicksapi.Enums.Members.Lorna);

        // act 
        var result = rulesService.PickOk(cecilia, lorna);

        // assert
        Assert.True(result, "pick OK");
    }   


    [Fact]
    public void PickOk_returns_false_correctly_dave_cindy()
    {
        // arrange
        var kremerFamily = familyService.GetFamily("kremer");
        var dave = familyService.GetFamilyMember(kremerFamily, giftpicksapi.Enums.Members.David);
        var cindy = familyService.GetFamilyMember(kremerFamily, giftpicksapi.Enums.Members.Cindy);

        // act 
        var result = rulesService.PickOk(dave, cindy);

        // assert
        Assert.False(result, "pick OK");
    }

    [Fact]
    public void PickOk_returns_false_correctly_dave_garrett()
    {
        // arrange
        var kremerFamily = familyService.GetFamily("kremer");
        var dave = familyService.GetFamilyMember(kremerFamily, giftpicksapi.Enums.Members.David);
        var garrett = familyService.GetFamilyMember(kremerFamily, giftpicksapi.Enums.Members.Garrett);

        // act 
        var result = rulesService.PickOk(dave, garrett);

        // assert
        Assert.False(result, "pick OK");
    }

    [Fact]
    public void PickOk_returns_false_correctly_nicholas_garrett()
    {
        // arrange
        var kremerFamily = familyService.GetFamily("kremer");
        var nicholas = familyService.GetFamilyMember(kremerFamily, giftpicksapi.Enums.Members.Nicholas);
        var garrett = familyService.GetFamilyMember(kremerFamily, giftpicksapi.Enums.Members.Garrett);

        // act 
        var result = rulesService.PickOk(nicholas, garrett);

        // assert
        Assert.False(result, "pick OK");
    }

    [Fact]
    public void PickOk_returns_false_correctly_cindy_nicholas()
    {
        // arrange
        var moenFamily = familyService.GetFamily("moen");
        var cindy = familyService.GetFamilyMember(moenFamily, giftpicksapi.Enums.Members.Cindy);
        var nicholas = familyService.GetFamilyMember(moenFamily, giftpicksapi.Enums.Members.Nicholas);

        // act 
        var result = rulesService.PickOk(cindy, nicholas);

        // assert
        Assert.False(result, "pick OK");
    }        

    [Fact]
    public void PickOk_returns_true_correctly_sally_nicholas()
    {
        // arrange
        var moenFamily = familyService.GetFamily("moen");
        var cindy = familyService.GetFamilyMember(moenFamily, giftpicksapi.Enums.Members.Sally);
        var nicholas = familyService.GetFamilyMember(moenFamily, giftpicksapi.Enums.Members.Nicholas);

        // act 
        var result = rulesService.PickOk(cindy, nicholas);

        // assert
        Assert.True(result, "pick OK");
    }    

}