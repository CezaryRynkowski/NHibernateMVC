using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernateMVC.Infrastructure.Query;
using NHibernateMVC.Models.JobHistory;

namespace NHibernateMVC.Domain.JobHistory
{
    public class GetPositionQuery : Query<PositionModel>
    {
        public override PositionModel Execute(ISession session)
        {
            var p = session.QueryOver<Position>()
                .Where(x => x.PositionId != null)
                .List<Position>().ToList();

            return PositionToModelMapper.MapToPositionModel(p);
        }
    }
}