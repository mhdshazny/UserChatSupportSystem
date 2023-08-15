using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using UserSupportSystem.Common.Enums;

namespace UserSupportSystem.Data.DTO
{
    [Table("Agent")]
    public class Agent
    {
        public Agent()
        {
            AgentType = new AgentRole();
            SupportTeam = new SupportTeams();
        }
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public AgentRole AgentType { get; set; }
        public string Status { get; set; }
        public int ActiveCount { get; set; }
        public SupportTeams SupportTeam { get; set; }

    }

    [Table("Role")]
    public class AgentRole
    {
        [Key]
        public int Id { get; set; }
        public AgentType AgentType { get; set; }
        public int MaxHandleCount { get; set; }
    }

    [Table("SupportTeams")]
    public class SupportTeams
    {
        [Key]
        public int ID { get; set; }
        public TeamTypes TeamType { get; set; }
        public TeamStatus Status { get; set; }
    }

}
