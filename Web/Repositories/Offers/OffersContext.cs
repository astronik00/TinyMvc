using Microsoft.EntityFrameworkCore;
using Web.Entities;

namespace Web.Repositories.Offers;

/// <summary>
/// Репозиторий для работы с БД заказов
/// </summary>
public sealed class OffersContext(IDbContextFactory<ApplicationContext> dbContextFactory) : IOffersContext
{
    /// <summary>
    /// Сохранение заказа
    /// </summary>
    /// <param name="offer"> Заказ </param>
    /// <param name="token"> Токен отмены </param>
    public async Task Save(OfferEntity offer, CancellationToken token)
    {
        await using var dbContext = await dbContextFactory.CreateDbContextAsync(token);
        await dbContext.Offers.AddAsync(offer, token);
        await dbContext.SaveChangesAsync(token);
    }
}