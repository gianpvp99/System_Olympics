using SystemOlympics_Entity;

namespace SystemOlympics_Contracts
{
    public interface ILogin
    {
        public Task<ELogin> Login(string user, string password);
    }
}
