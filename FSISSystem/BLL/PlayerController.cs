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

        public Player Player_Find(int playerID)
        {
            using (var context = new FSISContext())
            {
                IEnumerable<Player> results = context.Database.SqlQuery<Player>("Player_Get @playerID", new SqlParameter("playerID", playerID));
                return results.ToList()[0];
            }
        }

        public int AddPlayer(Player newPlayer)
        {
            using (var context = new FSISContext())
            {
                context.Players.Add(newPlayer);
                context.SaveChanges();
                return newPlayer.PlayerID;
            }
        }
        public int UpdatePlayer(Player player)
        {
            using (var context = new FSISContext())
            {
                context.Entry(player).State = System.Data.Entity.EntityState.Modified;
                return context.SaveChanges();
            }
        }
        public int DeletePlayer(int playerID)
        {
            using (var context = new FSISContext())
            {
                Player player = context.Players.Find(playerID);
                if (player == null)
                {
                    throw new Exception("Player has already been removed from the database");
                }
                context.Players.Remove(player);
                return context.SaveChanges();
            }
        }
    }
}
