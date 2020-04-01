using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using FSISSystem.DAL;
using FSISSystem.ENTITIES;

namespace FSISSystem.BLL
{
    public class PlayerController
    {
        public List<Player> List()
        {
            using (var context = new FSISContext())
            {
                return context.Players.ToList();
            }
        }
        public List<Player> FindByID(int teamid)
        {
            using (var context = new FSISContext())
            {
                IEnumerable<Player> results = context.Database.SqlQuery<Player>("Player_GetByTeam @teamId", new SqlParameter("teamid", teamid));
                return results.ToList();
            }
        }

        public Player FindByPlayerID(int playerID)
        {
            using (var context = new FSISContext())
            {
                IEnumerable<Player> results = context.Database.SqlQuery<Player>("Player_Get @playerID", new SqlParameter("playerID", playerID));
                return results.ToList()[0];
            }
        }
    }
}
