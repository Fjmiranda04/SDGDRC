﻿using GeneralLedger.SelfServiceCore.Data.Models;
using Microsoft.Extensions.Configuration;

namespace GeneralLedger.SelfServiceCore.Data.Repositories.Implements
{
    public class PQRSFPrioridadRepository : GenericRepository<PQRSFPrioridad>, IPQRSFPrioridadRepository
    {
        private readonly SelfServiceContext contex;
        private readonly IConfiguration configuration;

        public PQRSFPrioridadRepository(SelfServiceContext contex, IConfiguration configuration) : base(contex, configuration)
        {
            this.contex = contex;
            this.configuration = configuration;
        }
    }
}