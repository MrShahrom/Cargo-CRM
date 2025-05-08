using CargoCRM.Models;

namespace CargoCRM.Repositories;

public class UserRepository : IUserRepository
{
    private static readonly Dictionary<int, User> Users = [
        
    ];

    public IEnumerable<User> GetAll()
    {
        return Users.Values;
    }

    public User GetById(int id)
    {
        Users.TryGetValue(id, out var user);
        return user;
    }

    public void Add(User user)
    {
        Users.Add(user.Id, user);
    }

    public bool TryUpdate(int Id, User user)
    {
        if (!Users.ContainsKey(Id)) return false;
        Users[Id] = user;
        return true;
    }

    public User Delete(int id)
    {
        Users.TryGetValue(id, out var user);
        if (user is not null)
            Users.Remove(id);
        return user;
    }
}