using Data.Entities;
using Repository.Offers;

namespace Service;

/// <summary>
/// Базовая реализация сервиса для работы с заказами
/// </summary>
/// <param name="offersContext"> Репозиторий заказов </param>
/// <param name="orderNumGenerator"> Генератор номера заказа </param>
public sealed class OffersService(IOffersContext offersContext, IOrderNumGenerator orderNumGenerator) : IOffersService
{
    /// <summary>
    /// Получение списка всех заказов, отсортированных по дате создания по убыванию
    /// </summary>
    /// <param name="token"></param>
    /// <returns> Коллекция заказов </returns>
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
        offer.ModifyDate = DateTime.Now;
        await offersContext.Save(offer, token);
    }
}