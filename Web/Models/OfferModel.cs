using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Web.Models;

/// <summary>
/// Отображение для модели заказов
/// </summary>
public class OfferModel
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public int Id { get; init; }

    /// <summary>
    /// Человекочитаемый номер заказа
    /// </summary>
    public string OrderNo { get; set; }

    /// <summary>
    /// Город отправления
    /// </summary>
    [Required]
    public string CityFrom { get; set; }

    /// <summary>
    /// Город получения
    /// </summary>
    [Required]
    public string CityTo { get; set; }

    /// <summary>
    ///  Адрес отправителя
    /// </summary>
    [Required]
    public string SenderAddress { get; set; }

    /// <summary>
    /// Адрес получателя
    /// </summary>
    [Required]
    public string RecieverAddress { get; set; }

    /// <summary>
    /// Вес груза
    /// </summary>
    [Required]
    [Precision(18,2)]
    public decimal Weight { get; set; }

    /// <summary>
    /// Дата забора груза
    /// </summary>
    [Required]
    public DateTime CargoRecieveDate { get; init; }
}