using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Web.Entities;

/// <summary>
/// Отображение для сущности БД
/// </summary>
public class OfferEntity : BaseEntity
{
    /// <summary>
    /// Человекочитаемый номер заказа
    /// </summary>
    [Column("order_num")]
    public string OrderNo { get; set; }

    /// <summary>
    /// Город отправления
    /// </summary>
    [Column("city_from")]
    public string CityFrom { get; set; }

    /// <summary>
    /// Город получения
    /// </summary>
    [Column("city_to")]
    public string CityTo { get; set; }

    /// <summary>
    ///  Адрес отправителя
    /// </summary>
    [Column("sender_addres")]
    public string SenderAddress { get; set; }

    /// <summary>
    /// Адрес получателя
    /// </summary>
    [Column("reciever_address")]
    public string RecieverAddress { get; set; }

    /// <summary>
    /// Вес груза
    /// </summary>
    [Column("weight")]
    [Precision(18,2)]
    public decimal Weight { get; set; }

    /// <summary>
    /// Дата забора груза
    /// </summary>
    [Column("recieve_date")]
    public DateTime CargoRecieveDate { get; init; }
}