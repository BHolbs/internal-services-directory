﻿using MultCo_ISD_API.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace MultCo_ISD_API.V1.ControllerContexts
{
    public interface IServiceContext
    {
        Task<Service> GetByIdAsync(int id);
    }

    public class ServiceContext : IServiceContext
    {
        private readonly InternalServicesDirectoryV1Context _context;

        public ServiceContext(InternalServicesDirectoryV1Context context)
        {
            _context = context;
        }

        public async Task<Service> GetByIdAsync(int id)
        {
            var service = await _context.Service
                .Where(s => s.ServiceId == id)
                .Include(s => s.Contact)
                .Include(s => s.Department)
                .Include(s => s.Division)
                .Include(s => s.Program)
                .AsNoTracking()
                .SingleOrDefaultAsync();

            return service;
        }
    }
}
