using Web.Models;

namespace Web;

/// <summary>
/// Сервис для работы с заказами
/// </summary>
public interface IOffersService
{
    /// <summary>
    /// Сохранение заказа
    /// </summary>
    /// <param name="offer"> Модель заказа </param>
    /// <param name="token"> Токен отмены </param>
    public Task Save(OfferModel offer, CancellationToken token);
}