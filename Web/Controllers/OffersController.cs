using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Converters;
using Web.Models;
using Web.Repositories;

namespace Web.Controllers;

/// <summary>
/// Контроллер заказов.
/// </summary>
[Route("")]
public class OffersController(IOffersService offersService) : Controller
{
    /// <summary>
    /// Возвращает список всех заказов
    /// </summary>
    /// <param name="ctxFactory"> Контекст данных </param>
    /// <param name="token"> Токен отмены </param>
    /// <returns> Все заказы </returns>
    [HttpGet(""), HttpGet("/offers")]
    public async Task<IActionResult> GetOffers([FromServices] IDbContextFactory<ApplicationContext> ctxFactory,
        CancellationToken token)
    {
        await using var dbContext = await ctxFactory.CreateDbContextAsync(token);
        return View("Offers", await dbContext.Offers.Select(x => x.ToModel()).ToListAsync(token));
    }

    /// <summary>
    /// Сохраняет заказ и перенаправляет на список всех заказов
    /// </summary>
    /// <param name="offer"> Модель заказа <see cref="OfferModel"/> </param>
    /// <param name="token"> Токен отмены </param>
    /// <returns> Список всех заказов </returns>
    [HttpPost("/offers")]
    public async Task<IActionResult> Save(OfferModel offer, CancellationToken token)
    {
        if (string.IsNullOrEmpty(offer.RecieverAddress) ||
            string.IsNullOrEmpty(offer.SenderAddress) ||
            string.IsNullOrEmpty(offer.CityFrom) ||
            string.IsNullOrEmpty(offer.CityTo))
        {
            return BadRequest();
        }

        await offersService.Save(offer, token);
        return RedirectToAction("GetOffers");
    }
}