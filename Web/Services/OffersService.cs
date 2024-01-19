using Web.Converters;
using Web.Models;
using Web.Repositories.Offers;

namespace Web.Services;

/// <summary>
/// Базовая реализация сервиса для работы с заказами
/// </summary>
/// <param name="offersContext"> Репозиторий заказов </param>
/// <param name="orderNumGenerator"> Генератор номера заказа </param>
public sealed class OffersService(IOffersContext offersContext, IOrderNumGenerator orderNumGenerator) : IOffersService
{
    /// <summary>
    /// Сохранение заказа
    /// </summary>
    /// <param name="offer"> Модель заказа </param>
    /// <param name="token"> Токен отмены </param>
    public async Task Save(OfferModel offer, CancellationToken token)
    {
        var offerEntity = offer.ToEntity();
        offerEntity.OrderNo = await orderNumGenerator.Generate(token);
        await offersContext.Save(offerEntity, token);
    }
}