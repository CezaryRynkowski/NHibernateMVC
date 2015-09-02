using System;
using System.Text;
using System.Collections.Generic;

namespace NHibernateMVC.Domain.JobHistory
{
    public class Position
    {
        public virtual int PositionId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Code { get; set; }

        public virtual List<Position> AllPositions { get; set; }
    }
}
