using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemOlympics_Contracts;
using SystemOlympics_Data;
using SystemOlympics_Entity;
using SystemOlympics_Entity.EResponse;
using SystemOlympics_Entity.Request;

namespace SystemOlympics_Business
{
    public class BUser: IUser
    {
        readonly IConfiguration _configuration;
        public BUser(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public async Task<List<EUser>> List(string search, int page, int pageSize)
        {
            return await new DUser(_configuration).List(search, page, pageSize);
        }
        
        public async Task<RESUser> Maintenance(RUser maintenance)
        {
            return await new DUser(_configuration).Maintenance(maintenance);
        }
    }
}
