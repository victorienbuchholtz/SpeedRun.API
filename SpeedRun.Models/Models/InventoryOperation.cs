using System;
using System.Collections.Generic;
using SpeedRun.Models.Enums;
using SpeedRun.Models.Interfaces;

namespace SpeedRun.Models.Models
{
    public class InventoryOperation : IIncludeObject
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public OperationType OperationType { get; set; }
        public List<string> IncludesNeeded()
        {
            return new List<string>();
        }
    }
}
