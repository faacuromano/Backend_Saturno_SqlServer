using Microsoft.AspNetCore.Mvc;
namespace Saturno_Backend.Controllers;


[ApiController]
[Route("[controller]")]
public class NoCrudController : ControllerBase
{
    string[] randomPromotion = { "discount", "discount", "discount", "no discount",
                          "no discount", "no discount", "no discount", "discount",
                          "no discount", "no discount" };
    [HttpGet]
    [Route("list")]
    public dynamic showProfessional()
    {
        Random rnd = new Random();

    int mIndex = rnd.Next(randomPromotion.Length);

        

        return randomPromotion[mIndex];
    }


}