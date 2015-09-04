using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernateMVC.Domain.JobHistory;

namespace NHibernateMVC.Models.JobHistory
{
    public class PositionModel
    {
        /// <summary>
        /// list of all position from db
        /// </summary>
        public List<Position> AllPositions { get; set; } 
    }
}