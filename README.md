# BookStore
## Description
This project is being developed using various .Net 7 technologies to create a **bookstore** that allows users to browse and buy books. 

## Use cases 
1. **Registration and Authorization**
   - Users can create accounts and log in.

2. **Browse Books**
   - Users can view a list of available books with descriptions and images.
   - They can filter and sort books by various criteria (title, author, genre, etc.).

3. **Detail book view**
   - Users can view detailed information about each book, including description, price, author, etc.

4. **Add to Cart**
   - Users can add books to their cart for future purchase.

6. **Administrator Panel**
   - Administrators have access to the admin panel where they can add, edit and delete books.
   - They can also manage orders and users.

7. **Authentication and Authorization**
   - Secure access to functionality, including the ability to edit books and manage orders.

8. **Architectural patterns and Optimization**
    - Use architectural patterns to improve code structure.
    - Optimization to improve performance and page loading speed.

9. **Testing**
    - Writing test cases to validate various aspects of the application, including shopping cart, ordering, and authentication functionality.

10. **SQL and Git**
    - Using SQL to create and manage a database.
    - Version control of the database.

## User roles
 **Users**
  
  They can browse, add books to the cart, and place orders.

 **Administrators**
   
   Have access to the administrative panel where they can manage books, orders, and users.

## Technologies
- ASP.NET Core MVC
- Entity Framework Core
- ASP.NET Core WebAPI
- SignalR
- IdentityServer
- Unit Testing
- Authentication/Authorization (IdentityServer)
- Architecture (overview, patterns)
- Concurrency/Async programming
- Application performance/Debugging
- SQL
- Git
  
##

# Database Structure 

Here is a description of the database structure of the BookStore project. The database is created using the Entity Framework and has the following structure:

## Table "Books"

Table "Books" contains information about the books available in the store.

### Table structure:

- **Id** `<int>` (int): The unique identifier of the book.
- **Title** `<string>` (varchar(255)): The title of the book.
- **Author** `<string>` (varchar(100)): The author of the book.
- **Description** `<string>` (varchar(1000)): The description of the book.
- **Price** `<decimal>` (decimal(18,2)): The price of the book.
- **Genre** `<string>` (nvarchar(max)): The genre of the book.
- **Image** `<string>` (nvarchar(max)): URL link to the book image.

## Table "Orders"

The Orders table contains information about orders placed by users.

### Table structure:

- **Id** `<int>` (int): Unique identifier of the order.
- **UserId** `<int>` (int): Unique identifier of the user who placed the order.
- **OrderDate** `<DateTime>` (datetime2): The date of the order.
- **TotalPrice** `<decimal>` (decimal(18,2)): The total price of the order.

## Table "Users"

The "Users" table contains information about users who have access to the store.

### Table structure:

- **Id** `<int>` (int): Unique identifier of the user.
- **UserName** `<string>` (nvarchar(max)): The name of the user.
- **Email** `<string>` (nvarchar(max)): Email of the user.
- **Password** `<string>` (nvarchar(max)): The user's password hash.
- **Role** `<int>` (int): User role (0 - Customer, 1 - Admin).

## Table "OrderItems"

The "OrderItems" table contains information about individual items in the order.

### Table structure:

- **Id** `<int>` (int): Unique identifier of the order item.
- **OrderId** `<int>` (int): Unique identifier of the order to which this item belongs.
- **BookId** `<int>` (int): Unique identifier of the book that is included in this item.
- **Quantity** `<int>` (int): The number of books of this edition in the item.
- **Price** `<decimal>` (decimal(18,2)): The price of the order item.

## Relationships and foreign keys

- The "Orders" table has a foreign key `UserId`, which refers to the `Id` field of the "Users" table.
- The "OrderItems" table has a foreign key `OrderId` that refers to the `Id` field of the "Orders" table.
- The "OrderItems" table has a foreign key `BookId`, which refers to the `Id` field of the "Books" table.


The overall structure of the database was designed to comply with the third normal form (<abbr title="Third Normal Form">NF3</abbr>) and ensure data integrity between tables.
