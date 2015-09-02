using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernateMVC.Domain.JobHistory;

namespace NHibernateMVC.Models.JobHistory
{
    public class PositionToModelMapper
    {
        public static PositionModel MapToPositionModel(List<Position> positions)
        {
            return new PositionModel
            {
                AllPositions = positions.ToList()
            };
        }
    }
}