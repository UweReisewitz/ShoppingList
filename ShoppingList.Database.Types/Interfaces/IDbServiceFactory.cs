namespace ShoppingList.Database
{
    public interface IDbServiceFactory
    {
        IDbService CreateNew();
    }
}
