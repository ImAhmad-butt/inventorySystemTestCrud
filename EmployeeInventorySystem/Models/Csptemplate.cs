using System;
using System.Collections.Generic;

namespace EmployeeInventorySystem.Models
{
    public partial class Csptemplate
    {
        public Csptemplate()
        {
            CspuserTemp = new HashSet<CspuserTemp>();
        }

        public int Id { get; set; }
        public string TempleteName { get; set; }
        public string CspxmlData { get; set; }

        public virtual ICollection<CspuserTemp> CspuserTemp { get; set; }
    }
}
