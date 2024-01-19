using Web.Entities;

namespace Web.Repositories.Offers;

/// <summary>
/// Репозиторий для работы с БД заказов
/// </summary>
public interface IOffersContext
{
    /// <summary>
    /// Сохранение заказа
    /// </summary>
    /// <param name="offer"> Заказ </param>
    /// <param name="token"> Токен отмены </param>
    Task Save(OfferEntity offer, CancellationToken token);
}