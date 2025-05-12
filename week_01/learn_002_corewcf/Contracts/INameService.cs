using CoreWCF;

namespace Contracts;

[ServiceContract]
public interface INameService
{
    [OperationContract]
    void AddName(string name);
    
    [OperationContract]
    List<string> GetNames();
}