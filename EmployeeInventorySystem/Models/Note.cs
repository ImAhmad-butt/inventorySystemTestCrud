using System;
using System.Collections.Generic;

namespace EmployeeInventorySystem.Models
{
    public partial class Note
    {
        public string To { get; set; }
        public string From { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public int Id { get; set; }
    }
}
