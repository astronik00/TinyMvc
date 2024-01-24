using Data.Entities;

namespace Repository.Offers;

/// <summary>
/// Репозиторий для работы с БД заказов
/// </summary>
public interface IOffersContext
{
    /// <summary>
    /// Получение всех заказов
    /// </summary>
    /// <param name="token"> Токен отмены </param>
    /// <returns> Коллекция заказов </returns>
    Task<IEnumerable<OfferEntity>> GetOffers(CancellationToken token);
    
    /// <summary>
    /// Сохранение заказа
    /// </summary>
    /// <param name="offer"> Заказ </param>
    /// <param name="token"> Токен отмены </param>
    Task Save(OfferEntity offer, CancellationToken token);
}