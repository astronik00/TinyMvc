using Data.Entities;

namespace Service;

/// <summary>
/// Сервис для работы с заказами
/// </summary>
public interface IOffersService
{
    /// <summary>
    /// Получение списка всех заказов, отсортированных по дате создания по убыванию
    /// </summary>
    /// <param name="token"></param>
    /// <returns> Коллекция заказов </returns>
    public Task<IEnumerable<OfferEntity>> GetOffers(CancellationToken token);
    
    /// <summary>
    /// Сохранение заказа
    /// </summary>
    /// <param name="offer"> Модель заказа </param>
    /// <param name="token"> Токен отмены </param>
    public Task Save(OfferEntity offer, CancellationToken token);
}