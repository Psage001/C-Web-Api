namespace EcoPower_Logistics.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<bool>Exists(int id);
        Task<IEnumerable<T>>GetAll();
        Task<T>GetById(int id);

        //This changes the entries
        Task AddEntry(T  entity);
        Task UpdateEntry(T  entity);
        Task DeleteEntry(int id);
       
    }
}