namespace CachingSystem
{
    internal interface IMyService
    {
        void StoreSomeData<T>(string key, T myData);
        T RetrieveData<T>(string key);
        void DeleteData(string key);
    }
}