using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernateMVC.Domain.JobHistory;

namespace NHibernateMVC.Models.JobHistory
{
    /// <summary>
    /// Map position to model instances
    /// </summary>
    public class PositionToModelMapper
    {
        /// <summary>
        /// Maps position entity to position form model
        /// </summary>
        /// <param name="positions"></param>
        /// <returns></returns>
        public static PositionModel MapToPositionModel(List<Position> positions)
        {
            return new PositionModel
            {
                AllPositions = positions.ToList()
            };
        }
    }
}