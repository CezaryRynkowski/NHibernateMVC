﻿using System;
using System.Text;
using System.Collections.Generic;

namespace NHibernateMVC.Domain.JobHistory
{
    public class JobHistory
    {
        public virtual Guid JobHistoryId { get; set; }
        public virtual int PositionId { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime? StopDate { get; set; }
        public virtual string Salary { get; set; }
        public virtual Guid EmployeeId { get; set; }
    }
}