
using giftpicksapi.Enums;
using giftpicksapi.Models;
using Microsoft.Extensions.ObjectPool;

namespace giftpicksapi.Services;
public class FamilyService : IFamilyService
{
    public Family GetFamily(string familyName)
    {
        var family = new Family();

        switch(familyName.ToLower())
        {
            case "adults":
                family.Members = GetAdults();
                break;
            case "kids":
                family.Members = GetKids();
                break;
            case "kremer":
                family.Members = GetKremerFamily();
                break;
            case "moen":
            default:
                family.Members = GetMoenFamily();
                break;
        }
        return family;
    }

    public Person GetFamilyMember(Family family, Members member) {
        return family.Members.Where(m => m.Name == member).First();
    }

    private List<Person> GetKids()
        {
            return new List<Person>()
            {
                new(Members.Quinn) 
                {
                    Spouse = Members.None,
                    Siblings = { Members.Liv }
                },
                new(Members.Garrett)
                {
                    Spouse = Members.None,
                    Siblings = { Members.Nicholas }
                },
                new(Members.Nicholas)
                {
                    Siblings = { Members.Garrett },
                    Spouse = Members.Lilly
                },
                new(Members.Liv)
                {
                    Spouse = Members.None,
                    Siblings = { Members.Quinn }
                },
                new(Members.Lilly) 
                {
                    Spouse = Members.Nicholas
                }
            };
        }   

    private List<Person> GetAdults()
        {
            return new List<Person>()
            {
                new(Members.Julie)
                {
                    Spouse = Members.Mark,
                    Children = { Members.Quinn, Members.Liv }
                },
                new(Members.Mark)
                {
                    Spouse = Members.Julie,
                    Children = { Members.Quinn, Members.Liv }
                },
                new(Members.Cindy)
                {
                    Spouse = Members.David,
                    Children = { Members.Garrett, Members.Nicholas }
                },
                new(Members.David)
                {
                    Spouse = Members.Cindy,
                    Children = { Members.Garrett, Members.Nicholas }
                },
                new(Members.Sally) 
                {
                    Spouse = Members.None
                },
            };
        }    

    private List<Person> GetMoenFamily()
        {
            return new List<Person>()
            {
                new(Members.Julie)
                {
                    Spouse = Members.Mark,
                    Children = { Members.Quinn, Members.Liv }
                },
                new(Members.Mark)
                {
                    Spouse = Members.Julie,
                    Children = { Members.Quinn, Members.Liv }
                },
                new(Members.Quinn) 
                {
                    Spouse = Members.None
                },
                new(Members.Cindy)
                {
                    Spouse = Members.David,
                    Children = { Members.Garrett, Members.Nicholas }
                },
                new(Members.David)
                {
                    Spouse = Members.Cindy,
                    Children = { Members.Garrett, Members.Nicholas }
                },
                new(Members.Garrett)
                {
                    Spouse = Members.None,
                    Siblings = { Members.Nicholas }
                },
                new(Members.Nicholas)
                {
                    Spouse = Members.None,
                    Siblings = { Members.Garrett }
                },
                new(Members.Sally) 
                {
                    Spouse = Members.None
                },
                new(Members.Liv)
                {
                    Spouse = Members.None
                },
                new(Members.Lilly) {
                    Spouse = Members.None
                }
            };
        }  
    private List<Person> GetKremerFamily()
        {
            return new List<Person>()
            {
                new(Members.Cari)
                {
                    Spouse = Members.Kevin,
                    Children = { Members.Aidan, Members.Thomas, Members.Cecelia }
                },
                new(Members.Kevin)
                {
                    Spouse = Members.Cari,
                    Children = { Members.Aidan, Members.Thomas, Members.Cecelia }
                },
                new(Members.Aidan)
                {
                    Spouse = Members.None,
                    Siblings = { Members.Thomas, Members.Cecelia }
                },
                new(Members.Cecelia)
                {
                    Spouse = Members.None,
                    Siblings = { Members.Aidan, Members.Thomas }
                },
                new(Members.Cindy)
                {
                    Spouse = Members.David,
                    Children = { Members.Garrett, Members.Nicholas }
                },
                new(Members.David)
                {
                    Spouse = Members.Cindy,
                    Children = { Members.Garrett, Members.Nicholas }
                },
                new(Members.Garrett)
                {
                    Spouse = Members.None,
                    Siblings = { Members.Nicholas }
                },
                new(Members.Nicholas)
                {
                    Spouse = Members.None,
                    Siblings = { Members.Garrett }
                },
                new(Members.Lorna)
                {
                    Spouse = Members.Jack,
                },
                new(Members.Jack)
                {
                    Spouse = Members.Lorna,
                }
            };   
        } 
}