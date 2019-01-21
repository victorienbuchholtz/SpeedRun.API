using System;
using SpeedRun.Models.Enums;

namespace SpeedRun.Models.Models
{
    public class InventoryOperation
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public OperationType OperationType { get; set; }
    }
}
