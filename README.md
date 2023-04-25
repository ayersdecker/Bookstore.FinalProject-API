## NMAD262.FinalProject-API 
NMAD 262: Web Services &amp; Data Storage Tech. Final Project - API - BookStore Service

# Bookstore API
The Bookstore API is a web API designed to provide a platform for students to buy and sell books to one another. The API is designed with scalability in mind, utilizing MySQL for the database and Azure for cloud services. The API is built using C# and .NET, making it easily accessible to developers.

> ## Features

The Bookstore API includes the following features:

* User registration and authentication
* User profile management
* Book listing and management
* Patron management
* Payment processing with PayPal
* Filtering system for book search
* Image storage with cloud data storage providers such as AWS s3 bucket, Azure blob, etc.
* Documentation for the API with API documentation, endpoints, and parameters

> ## Requirements

To use the Bookstore API, you will need the following:
* MySQL database
* Azure account for cloud services
* PayPal account for payment processing

> ## Installation

To install the Bookstore API, follow these steps:

1.Clone the repository to your local machine

2. Open the project in your preferred IDE

3. Restore NuGet packages

4. Update the appsettings.json file with your database connection string, Azure storage account name and key, and PayPal account details

5. Build and run the project

> ## Usage

The Bookstore API provides the following endpoints:

### User Endpoints

POST /api/users/register: Register a new user.

POST /api/users/login: Log in an existing user.

GET /api/users/{id}: Get a user by ID.

PUT /api/users/{id}: Update a user's profile by ID.

### Book Endpoints

POST /api/books: Add a new book to the bookstore.

GET /api/books: Get a list of all books in the bookstore.

GET /api/books/{id}: Get a book by ID.

PUT /api/books/{id}: Update a book's details by ID.

DELETE /api/books/{id}: Remove a book from the bookstore by ID.

### Patron Endpoints

POST /api/patrons: Add a new patron to a book.

GET /api/patrons: Get a list of all patrons for a book.

GET /api/patrons/{id}: Get a patron by ID.

PUT /api/patrons/{id}: Update a patron's details by ID.

DELETE /api/patrons/{id}: Remove a patron from a book by ID.

### Transaction Endpoints

POST /api/transactions: Process a payment transaction for a book.

GET /api/transactions: Get a list of all transactions.

GET /api/transactions/{id}: Get a transaction by ID.


> ## Credits

The Bookstore API was developed by Decker Ayers.

> ## License

The Bookstore API is licensed under the MIT License.

