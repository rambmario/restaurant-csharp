# Restaurant Management System

![Restaurant Management System](https://github.com/rambmario/restaurant-csharp/assets/33069691/345db265-c69d-436b-a466-c7a06aed5f99)

A desktop application built in C# and Windows Forms for managing restaurant operations end-to-end — from table assignments and order management to payment processing and fiscal printing.

## Tech Stack

- **Language:** C# (.NET Framework)
- **UI:** Windows Forms
- **Database:** SQL Server (stored procedures, relational schema)
- **Reporting:** Crystal Reports (fiscal receipts and kitchen tickets)

## Features

- **Cash Register** — open and manage daily cash sessions with transaction tracking
- **Table Management** — assign and monitor table status in real time
- **Order Management** — take, update, and fulfill customer orders
- **Payment Processing** — handle multiple payment methods at checkout
- **Fiscal Printing** — generate compliant fiscal receipts and invoices
- **Ticket Printing** — print kitchen tickets to streamline order preparation
- **Reservations** — manage bookings and optimize seating capacity

## Getting Started

### Prerequisites

- Windows OS
- .NET Framework 4.x
- SQL Server or SQL Server Express
- Crystal Reports runtime (included in `packages/`)

### Setup

1. Clone the repository
2. Run the SQL script in the `DB/` folder to create and seed the database
3. Update the connection string in `app.config` with your SQL Server instance
4. Open `Gestion_gastronomica.sln` in Visual Studio and build the solution
5. Run the application

## About

Built by [Mario Ramb](https://www.linkedin.com/in/marioramb/) — Systems Engineer with 18+ years of experience in enterprise .NET development.

[LinkedIn](https://www.linkedin.com/in/marioramb/) · [GitHub](https://github.com/rambmario)

## License

MIT License