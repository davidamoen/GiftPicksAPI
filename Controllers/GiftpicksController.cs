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
    public Dictionary<string, string> Get([FromRoute] string familyname)
    {
        Console.WriteLine($"Starting a drawing for the {familyname} family.  ");
        var family = familyService.GetFamily(familyname);
        return Run(family);
    }

    private Dictionary<string, string> Run(Family family) 
    {
        var hat = randomizerService.GetRandomizedCopy(family.Members);
        var drawOrder = randomizerService.GetRandomizedCopy(family.Members);
        var picker = new PickerService(hat, new Random(DateTime.Now.Millisecond));
        var results = new Dictionary<string, string>();

        foreach(var personDrawing in drawOrder)
        {
            var drawCount = 0;
            var doneDrawing = false;

            while(!doneDrawing) 
            {
                Console.WriteLine($"{personDrawing.Name.ToString()} is drawing.");
                var personDrawn = picker.DrawFromHat(personDrawing);

                if (rulesService.PickOk(personDrawing, personDrawn)) 
                {
                    Console.WriteLine($"{personDrawing.Name} can give to {personDrawn.Name}.");
                    hat.Remove(personDrawn);
                    results.Add(personDrawing.Name.ToString(), personDrawn.Name.ToString());
                    doneDrawing = true;
                    drawCount = 0;
                }
                else 
                {
                    Console.WriteLine($"{personDrawing.Name} can NOT give to {personDrawn.Name}.");

                    if (drawCount > 5)
                    {
                        Console.WriteLine("Too many fails, starting over");
                        return Run(family);
                    }
                    drawCount++;
                }
            }
        }

        return results;
    }
}