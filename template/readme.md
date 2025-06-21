Paczki do pobrania:
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.Tools

po zainicjalizowaniu modeli należy wyknać migracje oraz update:
- dotnet ef migrations add "Initial Migration"
- dotnet ef database update

Kolejność podejścia do zadania:
- Zdefiniowanie modeli
- Zdefiniowanie kontekstu bazy danych
- Zdefiniowanie DTO
- Zdefiniowanie serwisów
- Zdefiniowanie kontrolerów
