using giftpicksapi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace giftpicksapi.Controllers;

[ApiController]
[Route("[controller]")]
public class GiftpicksController : Controller
{
    private readonly IPickerService _pickerService;
    private readonly ILogger<GiftpicksController> _logger;

   public GiftpicksController(
    ILogger<GiftpicksController> logger,
    IPickerService pickerService
    )
    {
        _logger = logger;
        _pickerService = pickerService;
    }

    [HttpGet(Name = "GetFamilyPicks")]
    public List<string> Get()
    {
        return _pickerService.GetPicks("moen");
    }
}