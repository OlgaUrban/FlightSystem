namespace FlightSystem.Data.Repository
{
    public abstract class BaseRepository
    {
        protected string ConnectionString;

        protected BaseRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}
