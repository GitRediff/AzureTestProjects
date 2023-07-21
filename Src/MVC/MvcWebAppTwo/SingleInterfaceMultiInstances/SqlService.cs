namespace MvcWebAppTwo.SingleInterfaceMultiInstances
{
    public class SqlService : IDatabaseService
    {
        public string GetName()
        {
            return "Sql Bawa";
        }
    }
}
