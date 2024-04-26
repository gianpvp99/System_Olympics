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
    public  class BSportComplex: ISportComplex
    {
        readonly IConfiguration _configuration;
        public BSportComplex(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public async Task<List<ESportComplex>> List(string search, int page, int pageSize)
        {
            return await new DSportComplex(_configuration).List(search, page, pageSize);
        }

        public async Task<RESSportComplex> Maintenance(RSportComplex maintenance)
        {
            return await new DSportComplex(_configuration).Maintenance(maintenance);
        }
    }
}
