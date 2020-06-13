using System;
using System.Collections.Generic;

namespace EmployeeInventorySystem.Models
{
    public partial class CspuserTemp
    {
        public int Id { get; set; }
        public int CsptempId { get; set; }
        public string CspuserXmlData { get; set; }

        public virtual Csptemplate Csptemp { get; set; }
    }
}
