using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public class BEvent: IEvent
    {
        readonly IConfiguration _configuration;

        public BEvent(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public async Task<List<EEvent>> List(string search, int page, int pageSize)
        {
            return await new DEvent(_configuration).List(search, page, pageSize); 
        }

        public async Task<RESEvent> Maintenance(REvent maintenance)
        {
            return await new DEvent(_configuration).Maintenance(maintenance);
        }
    }
}
