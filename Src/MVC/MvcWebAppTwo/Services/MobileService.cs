using MvcWebAppTwo.Models;


namespace MvcWebAppTwo.Services
{
    public class MobileService : IMobileService
    {
        private List<Mobile> _mobileList;

        public MobileService()
        {
            _mobileList = new List<Mobile>()
            {
                new Mobile() { id = 1, name = "Samsung", model="Note-10",    price="70,000" },
                new Mobile() { id = 2, name = "Nokia",   model="S6",         price="20,000" },
                new Mobile()  { id = 3, name = "Xiaomi",  model="Note-8",    price="21,999" }
            };
        }
        public Mobile Add(Mobile mobile)
        {
            mobile.id = _mobileList.Max(e => e.id) + 1;
            _mobileList.Add(mobile);
            return mobile;
        }
        public IEnumerable<Mobile> GetAll()
        {
            return _mobileList;
        }
    }
}
