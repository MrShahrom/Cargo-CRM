using CargoCRM.Models;

namespace CargoCRM.Repositories;

public interface IUserRepository
{
    IEnumerable<User> GetAll();
    
    User GetById(int id);
    
    void Add(User user);
    
    bool TryUpdate(int Id, User user);
    
    User Delete(int id);
    
}