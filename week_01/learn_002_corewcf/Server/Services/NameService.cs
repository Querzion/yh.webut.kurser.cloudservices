using Contracts;

namespace Server.Services;

public class NameService : INameService
{
    private readonly List<string> _names = [];
    
    public void AddName(string name)
    {
        _names.Add(name);
    }

    public List<string> GetNames()
    {
        return _names;
    }
}