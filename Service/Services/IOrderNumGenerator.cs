namespace Service.Services;

/// <summary>
/// Генератор номера заказа
/// </summary>
public interface IOrderNumGenerator
{
    /// <summary>
    /// Генерация номера заказа
    /// </summary>
    /// <param name="token"> Токен отмены </param>
    /// <returns> Номер заказа </returns>
    public Task<string> Generate(CancellationToken token);
}