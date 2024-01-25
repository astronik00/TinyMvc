using Repository.Utils;

namespace Service;

/// <summary>
/// Базовая реализация генератора номера заказа
/// </summary>
/// <param name="sequencesHelper"> Класс для работы с последовательностями </param>
public sealed class OrderNumGenerator(SequencesHelper sequencesHelper) : IOrderNumGenerator
{
    private const string SequenceName = "seq_order_num_2024";

    /// <summary>
    /// Генерация номера заказа на основе сквозного числа заказов за 2024 год, а также текущих месяца и года
    /// </summary>
    /// <param name="token"> Токен отмены </param>
    /// <returns> Номер заказа </returns>
    public async Task<string> Generate(CancellationToken token)
    {
        var nextSequenceValue = (await sequencesHelper.GetNextSequenceValue(SequenceName, token)).ToString();
        var date = DateTime.Today.ToString("MM'/'yy");
        var num = nextSequenceValue.Length < 2 ? "0" + nextSequenceValue : nextSequenceValue;

        return $"{num}/{date}";
    }
}