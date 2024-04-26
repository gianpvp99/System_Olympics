using Microsoft.Extensions.Configuration;
using SystemOlympics_Contracts;
using SystemOlympics_Data;
using SystemOlympics_Entity;

namespace SystemOlympics_Business
{
    public class BLogin: ILogin
    {

        readonly IConfiguration _configuration;
        public BLogin(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public async Task<ELogin> Login(string user, string password)
        {
            return await new DLogin(_configuration).Login(user, password);
        }
    }
}
