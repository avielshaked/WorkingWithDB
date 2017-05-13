using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithDb
{
    class NbaDB
    {
        public void Working_With_Nba_DB()
        {
            using (NbaModel context = new NbaModel())
            {
                Player player = context.Players.Where(p => p.TeamID == 1).FirstOrDefault();
            }
        }
    }
}
