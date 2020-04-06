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

        public void Player_Add(Player newPlayer)
        {
            int playerID = newPlayer.PlayerID;
            string firstName = newPlayer.FirstName;
            string lastName = newPlayer.LastName;
            int age = newPlayer.Age;
            string gender = newPlayer.Gender;
            string albertaHealthCareNumber = newPlayer.AlbertaHealthCareNumber;
            string medicalAlertDetails = newPlayer.MedicalAlertDetails;
            int teamID = newPlayer.TeamID;
            int guardianID = newPlayer.GuardianID;


            using (var context = new FSISContext())
            {
                context.Database.ExecuteSqlCommand("Player_Add @guardianID, @teamID, @firstName, @lastName, @age, @gender, @albertaHealthCareNumber, @MedicalAlertDetails",
                    new SqlParameter("guardianID", guardianID),
                    new SqlParameter("teamID", teamID),
                    new SqlParameter("firstName", firstName),
                    new SqlParameter("lastName", lastName),
                    new SqlParameter("age", age),
                    new SqlParameter("gender", gender),
                    new SqlParameter("albertaHealthCareNumber", albertaHealthCareNumber),
                    new SqlParameter("medicalAlertDetails", medicalAlertDetails));
            }
        }
        public void Player_Update(Player player)
        {
            int playerID = player.PlayerID;
            string firstName = player.FirstName;
            string lastName = player.LastName;
            int age = player.Age;
            string gender = player.Gender;
            string albertaHealthCareNumber = player.AlbertaHealthCareNumber;
            string medicalAlertDetails = player.MedicalAlertDetails;
            int teamID = player.TeamID;
            int guardianID = player.GuardianID;

            using (var context = new FSISContext())
            {
                context.Database.ExecuteSqlCommand("Player_Update @playerID, @guardianID, @teamID, @firstName, @lastName, @age, @gender, @albertaHealthCareNumber, @MedicalAlertDetails",
                    new SqlParameter("playerID", playerID),
                    new SqlParameter("guardianID", guardianID),
                    new SqlParameter("teamID", teamID),
                    new SqlParameter("firstName", firstName),
                    new SqlParameter("lastName", lastName),
                    new SqlParameter("age", age),
                    new SqlParameter("gender", gender),
                    new SqlParameter("albertaHealthCareNumber", albertaHealthCareNumber),
                    new SqlParameter("medicalAlertDetails", medicalAlertDetails));
            }
        }
        public void Player_Delete(int playerID)
        {
            using (var context = new FSISContext())
            {
                context.Database.ExecuteSqlCommand("Player_Delete @playerID", new SqlParameter("playerID", playerID));
            }
        }
    }
}
