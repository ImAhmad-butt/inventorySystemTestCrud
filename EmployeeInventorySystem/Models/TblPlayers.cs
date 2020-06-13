using System;
using System.Collections.Generic;

namespace EmployeeInventorySystem.Models
{
    public partial class TblPlayers
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public string BelongsTo { get; set; }
        public int? MatchPlayed { get; set; }
        public int? RunsMade { get; set; }
        public int? WicketsTaken { get; set; }
        public decimal? FeePerMatch { get; set; }
    }
}
