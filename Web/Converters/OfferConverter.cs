using Data.Entities;
using Web.Models;

namespace Web.Converters;

/// <summary>
/// Конвертер между моделью и сущностью для работы с БД для заказа
/// </summary>
public static class OfferConverter
{
    /// <summary>
    /// Возвращает сущность БД
    /// </summary>
    /// <param name="offerModel"> Модель заказа <see cref="OfferModel"/> </param>
    /// <returns> Сущность БД <see cref="OfferEntity"/> </returns>
    public static OfferEntity ToEntity(this OfferModel offerModel) => new()
    {
        Id = offerModel.Id,
        OrderNo = offerModel.OrderNo,
        CityFrom = offerModel.CityFrom,
        CityTo = offerModel.CityTo,
        SenderAddress = offerModel.SenderAddress,
        RecieverAddress = offerModel.RecieverAddress,
        Weight = offerModel.Weight,
        CargoRecieveDate = offerModel.CargoRecieveDate,
        CreateDate = offerModel.CreateDate,
        ModifyDate = offerModel.ModifyDate
    };

    /// <summary>
    /// Возвращает модель
    /// </summary>
    /// <param name="offerEntity"> Сущность БД <see cref="OfferEntity"/></param>
    /// <returns> Модель <see cref="OfferModel"/></returns>
    public static OfferModel ToModel(this OfferEntity offerEntity) => new()
    {
        Id = offerEntity.Id,
        OrderNo = offerEntity.OrderNo,
        CityFrom = offerEntity.CityFrom,
        CityTo = offerEntity.CityTo,
        SenderAddress = offerEntity.SenderAddress,
        RecieverAddress = offerEntity.RecieverAddress,
        Weight = offerEntity.Weight,
        CargoRecieveDate = offerEntity.CargoRecieveDate,
        CreateDate = offerEntity.CreateDate,
        ModifyDate = offerEntity.ModifyDate
    };
}