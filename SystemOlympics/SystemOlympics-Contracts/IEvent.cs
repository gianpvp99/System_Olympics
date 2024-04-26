﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemOlympics_Entity;
using SystemOlympics_Entity.EResponse;
using SystemOlympics_Entity.Request;

namespace SystemOlympics_Contracts
{
    public interface IEvent
    {
        public Task<List<EEvent>> List(string search, int page, int pageSize);
        public Task<RESEvent> Maintenance(REvent maintenance);

    }
}
