using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.DTO.Systemsetting;
using TimeTracker.Service.Data;
using TimeTracker.Service.Services.IServices;


namespace TimeTracker.Service.Services
{
    public class ValidateIpService : IValidateIpService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ValidateIpService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> ValidateIpAddressAsync(string ipAddress)
        {
            var isValidIpAddress = await _context.SystemSettings
                .AnyAsync(s => s.IpAddress == ipAddress && s.IsActive == true);

            return isValidIpAddress;
        }


    }
}
