using System.Collections.Generic;

namespace NHibernateMVC.Domain.JobHistory
{
    /// <summary>
    /// represents position
    /// </summary>
    public class Position
    {
        /// <summary>
        /// position id - int
        /// </summary>
        public virtual int PositionId { get; set; }
        /// <summary>
        /// position name eg.Developer
        /// </summary>
        public virtual string Name { get; set; }
        /// <summary>
        /// position Code /nullable
        /// </summary>
        public virtual string Code { get; set; }
        /// <summary>
        /// List of all position in db
        /// </summary>
        public virtual List<Position> AllPositions { get; set; }
    }
}
