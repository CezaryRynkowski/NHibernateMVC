using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernateMVC.Infrastructure.Query;
using NHibernateMVC.Models.JobHistory;

namespace NHibernateMVC.Domain.JobHistory
{
    /// <summary>
    /// loads list of All positons id db
    /// </summary>
    public class GetPositionQuery : Query<PositionModel>
    {
        /// <summary>
        /// Executes query
        /// </summary>
        /// <param name="session"></param>
        /// <returns>list of all positions</returns>
        public override PositionModel Execute(ISession session)
        {
            var p = session.QueryOver<Position>()
                .Where(x => x.PositionId != null)
                .List<Position>().ToList();

            return PositionToModelMapper.MapToPositionModel(p);
        }
    }
}