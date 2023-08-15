using System;
using System.Collections.Generic;
using System.Text;
using UserSupportSystem.Common.Enums;
using UserSupportSystem.Data.DTO;

namespace UserSupportSystem.Data.DataEntities
{
    public class SupportRequestDTO
    {
        public Guid Id { get; set; }
        public string User { get; set; }
        public string Message { get; set; }
        public RequestTypes requestType { get; set; }
        public Agent Agent { get; set; }
        public DateTime RequestTime { get; set; }
    }
}
