using giftpicksapi.Models;

namespace giftpicksapi.Services;
public interface IFamilyService
{
    Family GetFamily(string familyName);
}