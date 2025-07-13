# PersonalBudgetingAPI

PersonalBudgetingAPI is a backend service designed to help users manage and track their personal finances. It provides endpoints for managing budgets, expenses, incomes, and financial goals.

## Features

- User authentication and authorization
- CRUD operations for budgets, expenses, and incomes
- Financial goal tracking
- Reporting and analytics endpoints
- RESTful API design

## Getting Started

### Prerequisites

- [.NET 6+](https://dotnet.microsoft.com/)
- [SQL Server](https://www.microsoft.com/en-us/sql-server) or another supported database

### Installation

1. Clone the repository:
    ```bash
    git clone https://github.com/yourusername/PersonalBudgetingAPI.git
    cd PersonalBudgetingAPI
    ```
2. Restore dependencies:
    ```bash
    dotnet restore
    ```
3. Update `appsettings.json` with your database connection string.
4. Run database migrations:
    ```bash
    dotnet ef database update
    ```
5. Start the API:
    ```bash
    dotnet run
    ```

## API Documentation

API documentation is available via Swagger at `/swagger` when running the application.

## Contributing

Contributions are welcome! Please open issues or submit pull requests.

## License

This project is licensed under the MIT License.
