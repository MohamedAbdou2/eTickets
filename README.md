# eTickets

eTickets is a web application designed to allow users to purchase movie tickets for cinemas. The project features a complete ticket-buying experience, including managing actors, cinemas, movies, orders, a shopping cart, and producers. This application integrates PayPal for ticket purchases and implements robust authentication and authorization using ASP.NET Core Identity and cookies.

## Features

- **Movie Management**: Create, edit, and manage movie listings, including information about actors, cinemas, and producers.
- **Order Processing**: Users can place orders for movie tickets, which are managed through a shopping cart system.
- **PayPal Integration**: Secure payment processing for tickets through PayPal.
- **Authentication and Authorization**: User login and registration managed using ASP.NET Core Identity, with cookie-based authentication.
- **Responsive Design**: The UI is built using HTML, CSS, Bootstrap, and JavaScript, ensuring a responsive and user-friendly interface.

## Technologies Used

- **ASP.NET Core MVC**: The application is built using the MVC architectural pattern.
- **ASP.NET Core Identity**: For authentication and authorization.
- **PayPal**: Integrated for processing payments.
- **HTML/CSS/Bootstrap/JavaScript**: Frontend development to create responsive and interactive views.
- **Generic Repository Pattern**: To abstract the data layer and provide a clean separation of concerns.

## Getting Started

### Prerequisites

- [.NET Core SDK](https://dotnet.microsoft.com/download) 3.1 or later
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Visual Studio](https://visualstudio.microsoft.com/) (with ASP.NET and web development workload)

### Installation

1. Clone the repository:

    ```bash
    git clone https://github.com/MohamedAbdou2/eTickets.git
    ```

2. Navigate to the project directory:

    ```bash
    cd eTickets
    ```

3. Update the connection string in `appsettings.json` to point to your SQL Server instance.

4. Run the following commands to restore dependencies and build the project:

    ```bash
    dotnet restore
    dotnet build
    ```

5. Apply migrations and update the database:

    ```bash
    dotnet ef database update
    ```

6. Run the application:

    ```bash
    dotnet run
    ```

7. Open your browser and navigate to `https://localhost:5001` to view the application.

## Usage

- Register or log in to your account.
- Browse available movies and view details.
- Add movies to your shopping cart.
- Proceed to checkout and use PayPal for secure payment.
- View your order history and manage your account.

## Contributing

Contributions are welcome! Please fork the repository and create a pull request with your changes.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Acknowledgements

- [PayPal](https://developer.paypal.com/) for providing payment solutions.
- [ASP.NET Core Identity](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity) for user management.
- [Bootstrap](https://getbootstrap.com/) for frontend design.
