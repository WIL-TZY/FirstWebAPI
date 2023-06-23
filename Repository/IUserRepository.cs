using FirstWebAPI.Model;

// Creating an interface to be implemented by the following class: UserRepository

/*
interface defines a contract that classes must adhere to, specifying the members they should implement. 

A class is a blueprint for creating objects and provides the implementation of those members. 
Classes can implement one or more interfaces, allowing them to fulfill the contracts defined by those interfaces.
*/
namespace FirstWebAPI.Repository
{
    public interface IUserRepository
    {
        // Calling asynch operation
        Task<IEnumerable<User>> SearchUsers(); // Search in the database of all users
        Task<User> SearchUser(int id); // Search for a single user based on Id
        void AddUser(User user); // Type: User, param: user
        void UpdateUser(User user);
        void DeleteUser(User user);
        Task<bool> SaveChangesAsync();
    }
}