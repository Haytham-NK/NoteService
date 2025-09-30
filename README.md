# NoteService
Простое приложение для заметок на ASP.NET Core Web API с использованием Entity Framework Core и SQL Server.
Можно запускать как с локальной базой данных, так и полностью в Docker.

## Запуск
Вариант № 1 - запуск с локальной базой данных.
Для этого варианта вам необходим sql server.
1. В файле `WebApi/appsettings.json` есть такая строка:
 ```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=NoteDB;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False;"
  }
}
```
В ней необходимо поменять имя сервера.
2. В терминале небходимо выполнить команду для миграции (для создания бд и таблицы).
```bash
dotnet ef database update --startup-project WebApi/WebApi.csproj --project DataAccess/DataAccess.csproj
```
После запустите сам проект.
```bash
dotnet run --project WebApi/WebApi.csproj
```
После введите в браузере
```bash
dotnet run --project WebApi/WebApi.csproj
```
После того как проект запустится в терминале должна выйти команда Now listening on: http://localhost:xxxx (на месте xxxx - будет порт). 
Далее в браузере необходимо написать http://localhost:xxxx/swagger (на месте xxxx - напишите тот порт, который был указан у вас в терминале).

Вариант № 2 - запуск в Docker.
Для этого варианта вам необходим сам docker.
1. В терминале необходимо собрать и запустить контейнеры.
```bash
docker-compose up --build
```
2. Далее вам необходимо перейти по адресу:
```bash
http://localhost:5000/swagger
```

## Использование
1. POST /Note - можно содавать замети и сохранять их в бд.
2. GET /Note{id} - поиск заметки по id.
3. PUT /Note{id} - для изменения ренее создайнной заметки с выбором заметки по id. 
4. DELETE /Note{id} - для удаления ранее создайнной заметки по id. 

