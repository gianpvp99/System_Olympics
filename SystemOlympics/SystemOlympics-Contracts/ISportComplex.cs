using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemOlympics_Entity.EResponse;
using SystemOlympics_Entity.Request;
using SystemOlympics_Entity;

namespace SystemOlympics_Contracts
{
    public interface ISportComplex
    {
        public Task<List<ESportComplex>> List(string search, int page, int pageSize);
        public Task<RESSportComplex> Maintenance(RSportComplex maintenance);
    }
}
