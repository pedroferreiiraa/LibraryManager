namespace LibraryManager.Core.Entities;

public class User
{
    public User()
    {
            
    }
    public User(int modelId, string name, string email)
    {
        Name = name;
        Email = email;
    }

    public Guid Id { get; set; } = Guid.NewGuid(); // Gera um novo Guid automaticamente
    public string Name { get; private set; }
    public string Email { get; private set; }

    public void UpdateUser(string name, string email)
    {
        Name = name;
        Email = email;
    }
}
