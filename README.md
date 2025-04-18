НП „Обучение за ИТ кариера“ Екип: Даниел Бойчев и Николай Табальов Група: 08

# Документация на проекта RentACar

## Съдържание
1.  Описание на проекта
2.  Технологии
3.	Структура на проекта
4.	Основни функции
    - Регистрация на потребители
    - Вход и изход
    - Резервиране на автомобили
    - Управление на автомобили
    - Управление на резервации
    - Административен панел  
5.	Управление на потребители и роли
6.	Обработка на грешки
7.	Заключение
## Описание на проекта
Проектът RentACar е уеб приложение, което позволява на потребителите да резервират автомобили. Потребителите могат да се регистрират, да влизат в системата и да правят резервации. Администраторите имат допълнителни права за управление на автомобилите и резервациите.
## Технологии
•	ASP.NET Core: Платформа за разработка на уеб приложения.
•	Entity Framework Core: Инструмент за работа с бази данни.
•	SQL Server: Система за управление на релационни бази данни.
•	Razor Pages: Технология за динамични уеб страници.
•	Bootstrap: CSS фреймуърк за адаптивни интерфейси.
•	ASP.NET Identity: Система за управление на потребители и роли.
## Структура на проекта
### Проектът е организиран в следните основни компоненти:  
•	Controllers: Обработват HTTP заявките.  
•	Models: Представляват данните (например, Reservation и Car).  
•	Views: Определят визуализацията на данните.  
•	Data: Съдържа контекста на базата данни.  
## Основни функции
### Регистрация на потребители  
Потребителите могат да се регистрират, попълвайки форма с основна информация.  
### Вход и изход  
Потребителите влизат в системата с имейл и парола и могат да излизат, когато желаят.  
### Резервиране на автомобили  
Потребителите могат да преглеждат наличните автомобили и да правят резервации, като избират автомобил и въвеждат дати.  
### Управление на автомобили  
Администраторите могат да добавят, редактират и изтриват автомобили, задавайки информация за всеки автомобил.  
### Управление на резервации  
Администраторите преглеждат резервации, одобряват или отменят, и имат достъп до информация за потребителите и автомобилите.  
### Административен панел  
Администраторите имат достъп до управление на потребители и настройки на приложението.  
### Управление на потребители и роли  
Проектът използва ASP.NET Identity за управление на потребители и роли, позволявайки регистрация, вход и проверка на роли.  
### Обработка на грешки  
В приложението са реализирани механизми за валидация на входните данни, глобална обработка на грешки и логване на грешки.  
## Заключение
RentACar е интуитивно уеб приложение за управление на резервации на автомобили, проектирано да бъде лесно за използване и поддръжка.  

