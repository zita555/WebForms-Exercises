﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using FSISSystem.DAL;
using FSISSystem.ENTITIES;

namespace FSISSystem.BLL
{
    public class TeamController
    {
        public Team Teams_FindByID(int teamid)
        {
            using (var context = new FSISContext())
            {
                return context.Teams.Find(teamid);
            }
        }

        public List<Team> List()
        {
            using (var context = new FSISContext())
            {
                return context.Teams.ToList();
            }
        }

        public List<Team> GetTeams()
        {
            using (var context = new FSISContext())
            {
                IEnumerable<Team> results = context.Database.SqlQuery<Team>("Team_List");
                return results.ToList();
            }
        }
    }
}
