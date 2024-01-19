# Описание репозитория
Маленькое MVC приложение на C# для отображения списка заказов, а также их добавления.

# Технологии

- ASP.NET Core 8.0
- Entity Framework 8.0.0
- PostgreSQL 16
- Docker 4.26.1

# Инструкция для запуска

1. Поднять БД

В проекте используется PostgreSQL. Вы можете либо подтянуть образ и запустить БД из Docker-контейнера:

```
docker run --name app -p 5432:5432 -e POSTGRES_DB=appdb -e POSTGRES_USER=postgres -e POSTGRES_PASSWORD=MJjhehu38Jwrt -d postgres
```

либо использовать установленный сервер.

2. Если использовали команду из первого пункта, то этот пункт можно пропустить, иначе необходимо изменить файл конфигураций [dbsettings.json](/Web/dbsettings.json) на Ваши значения

3. Забилдить проект:

```
dotnet build
```

4. Запустить проект:
```
dotnet run --project Web/Web.csproj
```


