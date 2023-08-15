using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserSupportSystem.Data.DataEntities;

namespace UserSupportSystem.Data.Engines.Interfaces
{
    public interface IRequestEngine
    {
        public Task<SupportRequestDTO> GetSupportRequestAsync();
    }
}
