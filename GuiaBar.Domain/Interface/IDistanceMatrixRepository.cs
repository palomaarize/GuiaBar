using GuiaBar.Domain.Entities;

namespace GuiaBar.Domain.Interface
{
    public interface IDistanceMatrixRepository
    {
        Root GetRoute(string userAddress, string pubAddress); 
    }
}