using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KronosDMS.Objects
{
    public struct RepairOrder
    {
        public int Number { get; set; }
        public DateTime CreationDate { get; set; }

        public RepairOrder(int number, DateTime creationDate)
        {
            Number = number;
            CreationDate = creationDate;
        }
    }
}
