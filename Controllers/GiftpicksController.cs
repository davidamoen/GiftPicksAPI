using giftpicksapi.Enums;
using giftpicksapi.Models;
using giftpicksapi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ObjectPool;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace giftpicksapi.Controllers;

[ApiController]
[Route("[controller]")]
public class GiftpicksController : Controller
{
    private readonly IFamilyService familyService;
    private readonly IRandomizerService randomizerService;
    private readonly IRulesService rulesService;
    private readonly ILogger<GiftpicksController> logger;

   public GiftpicksController(
    IFamilyService familyService,
    IRandomizerService randomizerService,
    IRulesService rulesService,
    ILogger<GiftpicksController> logger
    )
    {
        this.familyService = familyService;
        this.randomizerService = randomizerService;
        this.rulesService = rulesService;
        this.logger = logger;
    }

    [HttpGet("{familyname}", Name = "GetFamilyPicks")]
    public Person Get([FromRoute] string familyname)
    {
        var family = familyService.GetFamily(familyname);
        var hat = randomizerService.GetRandomizedCopy(family.Members);
        var drawOrder = randomizerService.GetRandomizedCopy(family.Members);
        var picker = new PickerService(hat, drawOrder, new Random(DateTime.Now.Millisecond));

        var personDrawn = picker.DrawFromHat();

        if (rulesService.PickOk(personDrawn, drawOrder.First())) {
            Console.WriteLine($"{drawOrder.First().Name} can give to {personDrawn.Name}.");
        }
        else {
            Console.WriteLine($"{drawOrder.First().Name} can NOT give to {personDrawn.Name}.");
        }

        return personDrawn; 

    }
}