using giftpicksapi.Enums;
using giftpicksapi.Models;

namespace giftpicksapi.Services;
public interface IFamilyService
{
    Family GetFamily(string familyName);
    Person GetFamilyMember(Family family, Members member);
}