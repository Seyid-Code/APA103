using System;
class InvalidUsernameException : Exception
{
    public InvalidUsernameException() : base("Username is invalid.") { }
    public InvalidUsernameException(string message) : base(message) { }
}

class InvalidPasswordException : Exception
{
    public InvalidPasswordException() : base("Password is invalid.") { }
    public InvalidPasswordException(string message) : base(message) { }
}

class UserNotFoundException : Exception
{
    public UserNotFoundException() : base("User not found.") { }
    public UserNotFoundException(string username) : base($"User '{username}' not found.") { }
}

class IncorrectPasswordException : Exception
{
    public int AttemptsLeft { get; }
    public IncorrectPasswordException(int attemptsLeft)
        : base($"Incorrect password! Attempts left: {attemptsLeft}")
    {
        AttemptsLeft = attemptsLeft;
    }
}

class AccountLockedException : Exception
{
    public AccountLockedException() : base("Account is locked. Contact admin!") { }
}
class User
{
    public string Username { get; set; }
    public string Password { get; set; }
    public bool IsLocked { get; set; }
    public int FailedAttempts { get; set; }

    public User(string username, string password)
    {
        Username = username;
        Password = password;
        IsLocked = false;
        FailedAttempts = 0;
    }
}
class LoginSystem
{
    private User[] users;
    private const int MaxAttempts = 3;

    public LoginSystem()
    {
        users = new User[3];
        users[0] = new User("admin", "admin123");
        users[1] = new User("student", "student123");
        users[2] = new User("teacher", "teacher123");
    }

    public void ValidateUsername(string username)
    {
        if (string.IsNullOrWhiteSpace(username) || username.Length < 3)
            throw new InvalidUsernameException("Username must be at least 3 characters and not empty.");
    }

    public void ValidatePassword(string password)
    {
        if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
            throw new InvalidPasswordException("Password must be at least 6 characters and not empty.");
    }

    private User FindUser(string username)
    {
        foreach (var user in users)
        {
            if (user.Username.ToLower() == username.ToLower())
                return user;
        }
        return null;
    }

    public bool Login(string username, string password)
    {
        ValidateUsername(username);
        ValidatePassword(password);

        User user = FindUser(username);

        if (user == null)
            throw new UserNotFoundException(username);

        if (user.IsLocked)
            throw new AccountLockedException();

        if (user.Password == password)
        {
            user.FailedAttempts = 0;
            Console.WriteLine($"Login successful! Welcome, {user.Username}!");
            return true;
        }
        else
        {
            user.FailedAttempts++;
            int attemptsLeft = MaxAttempts - user.FailedAttempts;

            if (attemptsLeft > 0)
                throw new IncorrectPasswordException(attemptsLeft);
            else
            {
                user.IsLocked = true;
                throw new AccountLockedException();
            }
        }
    }

    public void ShowAllUsers()
    {
        Console.WriteLine("Existing users:");
        foreach (var user in users)
            Console.WriteLine("- " + user.Username);
    }
}
class Program
{
    static void Main()
    {
        LoginSystem system = new LoginSystem();

        while (true)
        {
            Console.Write("\nUsername: ");
            string username = Console.ReadLine();

            Console.Write("Password: ");
            string password = Console.ReadLine();

            try
            {
                bool success = system.Login(username, password);
                if (success) break;
            }
            catch (InvalidUsernameException ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
            catch (InvalidPasswordException ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
            catch (UserNotFoundException ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
                system.ShowAllUsers();
            }
            catch (IncorrectPasswordException ex)
            {
                Console.WriteLine("WARNING: " + ex.Message);
            }
            catch (AccountLockedException ex)
            {
                Console.WriteLine("CRITICAL: " + ex.Message);
                break;
            }
            catch (Exception ex)
            {
                Console.WriteLine("UNEXPECTED ERROR: " + ex.Message);
            }
        }
    }
}