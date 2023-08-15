using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserSupportSystem.Common.Enums;
using UserSupportSystem.Data.DataEntities;
using UserSupportSystem.Data.DB;
using UserSupportSystem.Data.DTO;
using UserSupportSystem.Data.Engines.Interfaces;

namespace UserSupportSystem.Data.Engines
{
    internal class RequestEngine : IRequestEngine
    {
        private AppDbContext _appDbContext;

        public RequestEngine(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<SupportRequestDTO> GetSupportRequestAsync()
        {
            var dto = new SupportRequestDTO();

            var dateTimeNow = DateTime.Now;
            var data = from agents in _appDbContext.AgentData 
                       where agents.Status == TeamStatus.Active.ToString() 
                       select new SupportRequestDTO
                       {
                           Agent = new Agent()
                           {
                               ActiveCount = agents.ActiveCount,
                               AgentType = agents.AgentType,
                               Id = agents.Id,
                               Name = agents.Name,
                               Status = agents.Status,
                               SupportTeam = agents.SupportTeam
                           },
                           Id = agents.Id,
                           requestType = RequestTypes.RequestSupport,
                           RequestTime = DateTime.Now,
                       };                   

            return data.OrderByDescending(i=>i.Agent.AgentType.AgentType).First();
        }
    }
}
