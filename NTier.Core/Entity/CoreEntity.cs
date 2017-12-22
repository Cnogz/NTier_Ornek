using NTier.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Core.Entity
{
    public class CoreEntity:IEntity
    {
        public CoreEntity()
        {
            this.Status = Status.Active;
            this.CreatedDate = DateTime.Now;
            this.CreatedUserName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            this.CreatedComputerName = Environment.MachineName;
            this.CreatedIp = "123";
            this.CreatedBy = 1;
        }

        public int Id { get; set; }
        public int MasterId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedComputerName { get; set; }
        public string CreatedIp { get; set; }
        public string CreatedUserName { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedComputerName { get; set; }
        public string ModifiedIp { get; set; }
        public string ModifiedUserName { get; set; }
        public int? ModifiedBy { get; set; }
        public Status Status { get; set; }
    }



}
