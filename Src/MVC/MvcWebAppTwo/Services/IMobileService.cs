using MvcWebAppTwo.Models;

namespace MvcWebAppTwo.Services
{
    public interface IMobileService
    {
        IEnumerable<Mobile> GetAll();
        Mobile Add(Mobile mobile);
    }
}
