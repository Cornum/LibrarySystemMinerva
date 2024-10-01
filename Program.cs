using Npgsql;
using System;
using System.Net;

namespace LibraryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Host=localhost;Username=postgres;Password=********;Database=library";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                while (true)
                {
                    Console.WriteLine("\nLibrary system: ");
                    Console.WriteLine("Modules: ");
                    Console.WriteLine("book");
                    Console.WriteLine("customer");
                    Console.WriteLine("exit");
                    Console.Write("\nEnter command: ");

                    string input = Console.ReadLine();
                    switch (input.ToLower())
                    {
                        case "book":
                            Console.WriteLine("\nCommands:\n");
                            Console.WriteLine("add book");
                            Console.WriteLine("change book");
                            Console.WriteLine("remove book");
                            Console.WriteLine("issue book");
                            Console.WriteLine("return book");
                            Console.WriteLine("search book");
                            Console.WriteLine("book availability");
                            Console.WriteLine("book loan history");
                            Console.WriteLine("list books");
                            Console.WriteLine("unavailable book");
                            Console.WriteLine("return");
                            Console.Write("\nEnter command: ");
                            string bookInput = Console.ReadLine();

                            switch (bookInput.ToLower())
                            {
                                case "add book":
                                    try
                                    {
                                        Console.Write("Enter title: ");
                                        string add_title = Console.ReadLine();
                                        Console.Write("Enter author: ");
                                        string add_author = Console.ReadLine();
                                        Console.Write("Enter year: ");
                                        int add_year = int.Parse(Console.ReadLine());
                                        AddBook(conn, add_title, add_author, add_year);
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine($"Error: {ex.Message}");
                                    }
                                    break;
                                case "change book":
                                    try
                                    {
                                        Console.Write("Enter book id: ");
                                        int change_bookId = int.Parse(Console.ReadLine());
                                        Console.Write("Enter title: ");
                                        string change_title = Console.ReadLine();
                                        Console.Write("Enter author: ");
                                        string change_author = Console.ReadLine();
                                        Console.Write("Enter year: ");
                                        string change_year = Console.ReadLine();
                                        ChangeBook(conn, change_bookId, change_title, change_author, change_year);
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine($"Error: {ex.Message}");
                                    }
                                    break;
                                case "remove book":
                                    try
                                    {
                                        Console.Write("Enter book id: ");
                                        int remove_bookId = int.Parse(Console.ReadLine());
                                        RemoveBook(conn, remove_bookId);
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine($"Error: {ex.Message}");
                                    }
                                    break;
                                case "issue book":
                                    try
                                    {
                                        Console.Write("Enter book id: ");
                                        int issue_bookId = int.Parse(Console.ReadLine());
                                        Console.Write("Enter customer id: ");
                                        int issue_customerId = int.Parse(Console.ReadLine());
                                        IssueBook(conn, issue_bookId, issue_customerId);
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine($"Error: {ex.Message}");
                                    }
                                    break;
                                case "return book":
                                    try
                                    {
                                        Console.Write("Enter book id: ");
                                        int bookId = int.Parse(Console.ReadLine());
                                        ReturnBook(conn, bookId);
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine($"Error: {ex.Message}");
                                    }
                                    break;
                                case "search book":
                                    try
                                    {
                                        Console.Write("Enter title or author to search: ");
                                        string query = Console.ReadLine();
                                        SearchBook(conn, query);
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine($"Error: {ex.Message}");
                                    }
                                    break;
                                case "book availability":
                                    try
                                    {
                                        GetBookAvailability(conn);
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine($"Error: {ex.Message}");
                                    }
                                    break;
                                case "unavailable book":
                                    try
                                    {
                                        Console.Write("Enter title to search unavailable books: ");
                                        string unavailableTitle = Console.ReadLine();
                                        SearchUnavailableBooks(conn, unavailableTitle);
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine($"Error: {ex.Message}");
                                    }
                                    break;
                                case "book loan history":
                                    try
                                    {
                                        Console.Write("Enter book id: ");
                                        int history_bookId = int.Parse(Console.ReadLine());
                                        GetBookLoanHistory(conn, history_bookId);
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine($"Error: {ex.Message}");
                                    }
                                    break;
                                case "list books":
                                    try
                                    {
                                        GetAllBooks(conn);
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine($"Error: {ex.Message}");
                                    }
                                    break;
                                case "return":
                                    break;
                                default:
                                    Console.WriteLine("\nInvalid command");
                                    break;
                            }
                            break;
                        case "customer":
                            Console.WriteLine("\nCommands:\n");
                            Console.WriteLine("add customer");
                            Console.WriteLine("change customer");
                            Console.WriteLine("remove customer");
                            Console.WriteLine("customer loan history");
                            Console.WriteLine("remove customer loans");
                            Console.WriteLine("list customers");
                            Console.WriteLine("unavailable books (by customer)");
                            Console.WriteLine("return");
                            Console.Write("\nEnter command: ");
                            string customerInput = Console.ReadLine();

                            switch (customerInput.ToLower())
                            {
                                case "add customer":
                                    try
                                    {
                                        Console.Write("Enter name: ");
                                        string add_name = Console.ReadLine();
                                        Console.Write("Enter contact info: ");
                                        string add_info = Console.ReadLine();
                                        AddCustomer(conn, add_name, add_info);
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine($"Error: {ex.Message}");
                                    }
                                    break;
                                case "change customer":
                                    try
                                    {
                                        Console.WriteLine("Enter id: ");
                                        int change_id = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter new name: ");
                                        string change_new_name = Console.ReadLine();
                                        Console.WriteLine("Enter contact info: ");
                                        string change_info = Console.ReadLine();
                                        ChangeCustomer(conn, change_new_name, change_info, change_id);
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine($"Error: {ex.Message}");
                                    }
                                    break;
                                case "remove customer":
                                    try
                                    {
                                        Console.WriteLine("Enter name: ");
                                        string remove_name = Console.ReadLine();
                                        RemoveCustomer(conn, remove_name);
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine($"Error: {ex.Message}");
                                    }
                                    break;

                                case "customer loan history":
                                    try
                                    {
                                        Console.Write("Enter customer id: ");
                                        int customerId = int.Parse(Console.ReadLine());
                                        GetCustomerLoanHistory(conn, customerId);
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine($"Error: {ex.Message}");
                                    }
                                    break;

                                case "remove customer loans":
                                    try
                                    {
                                        Console.Write("Enter customer id: ");
                                        int remove_customerId = int.Parse(Console.ReadLine());
                                        RemoveCustomerLoans(conn, remove_customerId);
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine($"Error: {ex.Message}");
                                    }
                                    break;
                                case "unavailable books":
                                    try
                                    {
                                        Console.Write("Enter customer ID: ");
                                        int customerId = int.Parse(Console.ReadLine());
                                        SearchBooksByCustomer(conn, customerId);
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine($"Error: {ex.Message}");
                                    }
                                    break;
                                case "list customers":
                                    try
                                    {
                                        GetAllCustomers(conn);
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine($"Error: {ex.Message}");
                                    }
                                    break;
                                case "return":
                                    break;
                                default:
                                    Console.WriteLine("Invalid command");
                                    break;
                            }
                            break;
                        case "exit":
                            Console.WriteLine("Exiting...");
                            return;
                        default:
                            Console.WriteLine("\nInvalid command");
                            break;
                    }
                }
                conn.Close();
            }
        }

        #region functions
        static void AddBook(NpgsqlConnection conn, string title, string author, int year)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author) || year <= 0)
                {
                    Console.WriteLine("Invalid book details. Please check the input.");
                    return;
                }

                using (var checkCmd = new NpgsqlCommand("SELECT COUNT(*) FROM books WHERE title = @title AND author = @author AND year_of_publication = @year", conn))
                {
                    checkCmd.Parameters.AddWithValue("title", title);
                    checkCmd.Parameters.AddWithValue("author", author);
                    checkCmd.Parameters.AddWithValue("year", year);

                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                    if (count > 0)
                    {
                        Console.WriteLine("This book already exists.");
                        return;
                    }
                }

                using (var cmd = new NpgsqlCommand("INSERT INTO books (title, author, year_of_publication) VALUES (@title, @author, @year)", conn))
                {
                    cmd.Parameters.AddWithValue("title", title);
                    cmd.Parameters.AddWithValue("author", author);
                    cmd.Parameters.AddWithValue("year", year);
                    cmd.ExecuteNonQuery();
                }

                Console.WriteLine("Book added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding book: {ex.Message}");
            }
        }

        static void ChangeBook(NpgsqlConnection conn, int bookId, string title, string author, string year)
        {
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    throw new InvalidOperationException("Connection must be opened before executing commands.");
                }

                string prev_title, prev_author;
                int prev_year;

                using (var cmd = new NpgsqlCommand("SELECT title, author, year_of_publication FROM books WHERE id = @bookId", conn))
                {
                    cmd.Parameters.AddWithValue("bookId", bookId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            Console.WriteLine("Book not found");
                            return;
                        }

                        prev_title = reader.GetString(0);
                        prev_author = reader.GetString(1);
                        prev_year = reader.GetInt32(2);
                    }
                }
                int.TryParse(year, out int yearInt);
                if (title != prev_title || author != prev_author || yearInt != prev_year)
                {
                    using (var checkCmd = new NpgsqlCommand("SELECT COUNT(*) FROM books WHERE title = @title AND author = @author AND year_of_publication = @year AND id != @bookId", conn))
                    {
                        checkCmd.Parameters.AddWithValue("title", string.IsNullOrWhiteSpace(title) ? prev_title : title);
                        checkCmd.Parameters.AddWithValue("author", string.IsNullOrWhiteSpace(author) ? prev_author : author);
                        checkCmd.Parameters.AddWithValue("year", string.IsNullOrWhiteSpace(year) ? prev_year : yearInt);
                        checkCmd.Parameters.AddWithValue("bookId", bookId);

                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                        if (count > 0)
                        {
                            Console.WriteLine("Another book with the same details already exists.");
                            return;
                        }
                    }
                }

                using (var cmd = new NpgsqlCommand("UPDATE books SET title = @title, author = @author, year_of_publication = @year WHERE id = @bookId", conn))
                {
                    cmd.Parameters.AddWithValue("title", string.IsNullOrWhiteSpace(title) ? prev_title : title);
                    cmd.Parameters.AddWithValue("author", string.IsNullOrWhiteSpace(author) ? prev_author : author);
                    cmd.Parameters.AddWithValue("year", string.IsNullOrWhiteSpace(year) ? prev_year : yearInt);
                    cmd.Parameters.AddWithValue("bookId", bookId);
                    cmd.ExecuteNonQuery();
                }

                Console.WriteLine("Book details updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error changing book: {ex.Message}");
            }
        }

        static void RemoveBook(NpgsqlConnection conn, int bookId)
        {
            try
            {
                using (var checkCmd = new NpgsqlCommand("SELECT COUNT(*) FROM books WHERE id = @bookId", conn))
                {
                    checkCmd.Parameters.AddWithValue("bookId", bookId);
                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count == 0)
                    {
                        Console.WriteLine("Book not found. Unable to remove.");
                        return;
                    }
                }

                using (var cmd = new NpgsqlCommand("DELETE FROM books WHERE id = @bookId", conn))
                {
                    cmd.Parameters.AddWithValue("bookId", bookId);
                    cmd.ExecuteNonQuery();
                }

                Console.WriteLine("Book removed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error removing book: {ex.Message}");
            }
        }


        static void IssueBook(NpgsqlConnection conn, int bookId, int customerId)
        {
            try
            {
                using (var checkCmd = new NpgsqlCommand("SELECT COUNT(*) FROM books WHERE id = @bookId", conn))
                {
                    checkCmd.Parameters.AddWithValue("bookId", bookId);
                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count == 0)
                    {
                        Console.WriteLine("Book not found. Unable to issue.");
                        return;
                    }
                }
                using (var checkCmd = new NpgsqlCommand("SELECT available FROM books WHERE id = @bookId", conn))
                {
                    checkCmd.Parameters.AddWithValue("bookId", bookId);
                    bool isAvailable = (bool)checkCmd.ExecuteScalar();

                    if (!isAvailable)
                    {
                        Console.WriteLine("This book is already issued and not available.");
                        return; 
                    }
                }
                using (var cmd = new NpgsqlCommand("INSERT INTO loan_history (book_id, customer_id, loan_date) VALUES (@bookId, @customerId, @loanDate)", conn))
                {
                    cmd.Parameters.AddWithValue("bookId", bookId);
                    cmd.Parameters.AddWithValue("customerId", customerId);
                    cmd.Parameters.AddWithValue("loanDate", DateTime.Now);
                    cmd.ExecuteNonQuery();
                }
                using(var cmd = new NpgsqlCommand("UPDATE books SET available = FALSE WHERE id = @bookId", conn))
                {
                    cmd.Parameters.AddWithValue("bookId", bookId);
                    cmd.ExecuteNonQuery();
                }
                Console.WriteLine("Book issued successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error issuing book");
            }
        }

        static void ReturnBook(NpgsqlConnection conn, int bookId)
        {
            try
            {
                using (var checkCmd = new NpgsqlCommand("SELECT COUNT(*) FROM loan_history WHERE book_id = @bookId", conn))
                {
                    checkCmd.Parameters.AddWithValue("bookId", bookId);
                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count == 0)
                    {
                        Console.WriteLine("Loan record not found. Unable to update return date.");
                        return;
                    }
                }
                using (var cmd = new NpgsqlCommand("UPDATE books SET available = TRUE WHERE id = @bookId", conn))
                {
                    cmd.Parameters.AddWithValue("bookId", bookId);
                    cmd.ExecuteNonQuery();
                }
                using (var cmd = new NpgsqlCommand("UPDATE loan_history SET return_date = @returnDate, returned = TRUE WHERE book_id = @bookId", conn))
                {
                    cmd.Parameters.AddWithValue("returnDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("bookId", bookId);
                    cmd.ExecuteNonQuery();
                }

                Console.WriteLine("Book returned successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error returning book");
            }
        }

        static void SearchBook(NpgsqlConnection conn, string query)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(query))
                {
                    Console.WriteLine("Please provide a search term.");
                    return;
                }

                using (var cmd = new NpgsqlCommand("SELECT * FROM books WHERE title ILIKE @query OR author ILIKE @query", conn))
                {
                    cmd.Parameters.AddWithValue("query", "%" + query + "%");

                    using (var reader = cmd.ExecuteReader())
                    {
                        Console.WriteLine("Search Results:");
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("No books found.");
                        }
                        else
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine($"ID: {reader["id"]}, Title: {reader["title"]}, Author: {reader["author"]}, Year: {reader["year_of_publication"]}");
                            }
                        }
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine($"Database error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        static void SearchUnavailableBooks(NpgsqlConnection conn, string title)
        {
            try
            {
                using (var cmd = new NpgsqlCommand(@"
            SELECT b.id, b.title, b.author, b.year_of_publication, c.name 
            FROM books b 
            JOIN loan_history lh ON b.id = lh.book_id 
            JOIN customers c ON lh.customer_id = c.id 
            WHERE b.title ILIKE @title AND b.available = FALSE AND lh.returned = FALSE", conn))
                {
                    cmd.Parameters.AddWithValue("title", "%" + title + "%");

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("No unavailable books found.");
                            return;
                        }

                        Console.WriteLine("Unavailable Books:");
                        while (reader.Read())
                        {
                            Console.WriteLine($"ID: {reader["id"]}, Title: {reader["title"]}, Author: {reader["author"]}, Year: {reader["year_of_publication"]}, Borrower: {reader["name"]}");
                        }
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine("An error occurred while searching for unavailable books");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred");
            }
        }

        static void SearchBooksByCustomer(NpgsqlConnection conn, int customerId)
        {
            try
            {
                using (var cmd = new NpgsqlCommand("SELECT b.id, b.title, b.author, b.year_of_publication FROM loan_history lh " +
                    "JOIN books b ON lh.book_id = b.id WHERE lh.customer_id = @customerId AND lh.returned = FALSE", conn))
                {
                    cmd.Parameters.AddWithValue("customerId", customerId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("No books found for this customer.");
                            return;
                        }

                        Console.WriteLine($"Books currently loaned by customer ID {customerId}:");
                        while (reader.Read())
                        {
                            Console.WriteLine($"ID: {reader["id"]}, Title: {reader["title"]}, Author: {reader["author"]}, Year: {reader["year_of_publication"]}");
                        }
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine("An error occurred while searching for books by customer");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred");
            }
        }

        static void GetBookAvailability(NpgsqlConnection conn)
        {
            try
            {
                using (var cmd = new NpgsqlCommand("SELECT b.title, COUNT(l.id) AS loans FROM books b LEFT JOIN loan_history l ON b.id = l.book_id GROUP BY b.title", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        Console.WriteLine("Book Availability:");
                        while (reader.Read())
                        {
                            Console.WriteLine($"Title: {reader["title"]}, Loans: {reader["loans"]}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching book availability");
            }
        }

        static void GetBookLoanHistory(NpgsqlConnection conn, int bookId)
        {
            try
            {
                using (var cmd = new NpgsqlCommand("SELECT l.id, c.name, l.loan_date, l.returned FROM loan_history l JOIN customers c ON l.customer_id = c.id WHERE l.book_id = @bookId", conn))
                {
                    cmd.Parameters.AddWithValue("bookId", bookId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        Console.WriteLine("Loan History:");
                        while (reader.Read())
                        {
                            Console.WriteLine($"Loan ID: {reader["id"]}, Customer: {reader["name"]}, Loan Date: {reader["loan_date"]}, Returned: {reader["returned"]}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching book loan history");
            }
        }

        static void GetAllBooks(NpgsqlConnection conn)
        {
            try
            {
                using (var cmd = new NpgsqlCommand("SELECT * FROM books", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        Console.WriteLine("All Books:");
                        while (reader.Read())
                        {
                            Console.WriteLine($"ID: {reader["id"]}, Title: {reader["title"]}, Author: {reader["author"]}, Year: {reader["year_of_publication"]}, Avaliable: {reader["available"]}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching all books");
            }
        }

        static void AddCustomer(NpgsqlConnection conn, string name, string contactInfo)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(contactInfo))
                {
                    Console.WriteLine("Invalid customer details. Please check the input.");
                    return;
                }

                using (var checkCmd = new NpgsqlCommand("SELECT COUNT(*) FROM customers WHERE name = @name", conn))
                {
                    checkCmd.Parameters.AddWithValue("name", name);

                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                    if (count > 0)
                    {
                        Console.WriteLine("This customer already exists.");
                        return;
                    }
                }
                using (var cmd = new NpgsqlCommand("INSERT INTO customers (name, contact_info) VALUES (@name, @contactInfo)", conn))
                {
                    cmd.Parameters.AddWithValue("name", name);
                    cmd.Parameters.AddWithValue("contactInfo", contactInfo);
                    cmd.ExecuteNonQuery();
                }
                Console.WriteLine("Customer added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding customer");
            }
        }

        static void ChangeCustomer(NpgsqlConnection conn, string newName, string contactInfo, int customerId)
        {
            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    throw new InvalidOperationException("Connection must be opened before executing commands.");
                }

                string prev_name, prev_contactInfo;

                using (var cmd = new NpgsqlCommand("SELECT name, contactInfo FROM customers WHERE id = @customerId", conn))
                {
                    cmd.Parameters.AddWithValue("customerId", customerId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            Console.WriteLine("Person not found");
                            return;
                        }

                        prev_name = reader.GetString(0);
                        prev_contactInfo = reader.GetString(1);
                    }
                }
                if (newName != prev_name || contactInfo != prev_contactInfo)
                {
                    using (var checkCmd = new NpgsqlCommand("SELECT COUNT(*) FROM customers WHERE name = @name AND contactInfo = @contactInfo AND id != @customerId", conn))
                    {
                        checkCmd.Parameters.AddWithValue("name", string.IsNullOrWhiteSpace(newName) ? prev_name : newName);
                        checkCmd.Parameters.AddWithValue("author", string.IsNullOrWhiteSpace(contactInfo) ? prev_contactInfo : contactInfo);
                        checkCmd.Parameters.AddWithValue("customerId", customerId);

                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                        if (count > 0)
                        {
                            Console.WriteLine("Another Person with the same details already exists.");
                            return;
                        }
                    }
                }

                using (var cmd = new NpgsqlCommand("UPDATE customers SET name = @newName, contact_info = @contactInfo WHERE id = @", conn))
                {
                    cmd.Parameters.AddWithValue("newName", newName);
                    cmd.Parameters.AddWithValue("contactInfo", contactInfo);
                    cmd.Parameters.AddWithValue("customerId", customerId);
                    cmd.ExecuteNonQuery();
                }
                Console.WriteLine("Customer details updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error changing customer");
            }
        }

        static void RemoveCustomer(NpgsqlConnection conn, string name)
        {
            try
            {
                using (var cmd = new NpgsqlCommand("DELETE FROM customers WHERE name = @name", conn))
                {
                    cmd.Parameters.AddWithValue("name", name);
                    cmd.ExecuteNonQuery();
                }
                Console.WriteLine("Customer removed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error removing customer");
            }
        }

        static void GetCustomerLoanHistory(NpgsqlConnection conn, int customerId)
        {
            try
            {
                using (var cmd = new NpgsqlCommand("SELECT l.id, b.title, l.loan_date, l.returned FROM loan_history l JOIN books b ON l.book_id = b.id WHERE l.customer_id = @customerId", conn))
                {
                    cmd.Parameters.AddWithValue("customerId", customerId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        Console.WriteLine("Customer Loan History:");
                        while (reader.Read())
                        {
                            Console.WriteLine($"Loan ID: {reader["id"]}, Book Title: {reader["title"]}, Loan Date: {reader["loan_date"]}, Returned: {reader["returned"]}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching customer loan history");
            }
        }

        static void RemoveCustomerLoans(NpgsqlConnection conn, int customerId)
        {
            try
            {
                using (var cmd = new NpgsqlCommand("DELETE FROM loan_history WHERE customer_id = @customerId", conn))
                {
                    cmd.Parameters.AddWithValue("customerId", customerId);
                    cmd.ExecuteNonQuery();
                }
                Console.WriteLine("All loans for the customer have been removed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error removing customer loans");
            }
        }

        static void GetAllCustomers(NpgsqlConnection conn)
        {
            try
            {
                using (var cmd = new NpgsqlCommand("SELECT * FROM customers", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        Console.WriteLine("All Customers:");
                        while (reader.Read())
                        {
                            Console.WriteLine($"ID: {reader["id"]}, Name: {reader["name"]}, Contact Info: {reader["contact_info"]}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching all customers");
            }
        }
        #endregion
    }
}
