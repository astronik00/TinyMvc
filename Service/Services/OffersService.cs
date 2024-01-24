using Data.Entities;
using Repository.Offers;

namespace Service.Services;

/// <summary>
/// Базовая реализация сервиса для работы с заказами
/// </summary>
/// <param name="offersContext"> Репозиторий заказов </param>
/// <param name="orderNumGenerator"> Генератор номера заказа </param>
public sealed class OffersService(IOffersContext offersContext, IOrderNumGenerator orderNumGenerator) : IOffersService
{
    public async Task<IEnumerable<OfferEntity>> GetOffers(CancellationToken token)
    {
        var offers = await offersContext.GetOffers(token);
        return offers;
    }

    /// <summary>
    /// Сохранение заказа
    /// </summary>
    /// <param name="offer"> Модель заказа </param>
    /// <param name="token"> Токен отмены </param>
    public async Task Save(OfferEntity offer, CancellationToken token)
    {
        offer.OrderNo = await orderNumGenerator.Generate(token);
        offer.CreateDate = DateTime.Now;
        await offersContext.Save(offer, token);
    }
}