namespace MvcWebAppTwo.SingleInterfaceMultiInstances
{
    public class MongoService : IDatabaseService
    {
        public string GetName()
        {
            return "Mongo Bawa";
        }
    }
}
