# OXG.PixelBattle
Многопользовательская браузерная игра "Пиксельная битва".

## Начало работы

- Перед запуском приложения необходимо определить размер игрового поля, изменив значения в циклах генерации двумерного массива в представлении "Home/Index.cshtml"
- Для изменения палитры используемых цветов, необходимо изменить значение свойства background на необходимые цвета у блоков div с классом ".fixedbut".
- Для сброса карты необходимо удалить базу данных "PIXELS.db" лежащую в корне приложения

## Для разработчиков
- Логика JS вынесена в файл site.js
- Стили вынесены в файл site.css
- Realtime взаимодействие организовано через библиотеку signalr.js
- Конечная точка хаба SignalR определена по адресу "/battle"
- Логика хаба определена в классе PixelBattleHub
- Ядро СУБД SQLite
- Контекст БД определён в классе PixelDbContext


### Используемые NuGet-пакеты (Список зависимостей)

* Microsoft.EntityFrameworkCore (3.1.4)
* Microsoft.EntityFrameworkCore.Sqlite (3.1.4)
* * Microsoft.EntityFrameworkCore.Sqlite.Core (3.1.4)
* Microsoft.VisualStudio.Web.CodeGeneration.Design (3.1.3)
