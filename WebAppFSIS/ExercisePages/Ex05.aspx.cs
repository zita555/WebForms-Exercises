using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using FSISSystem.BLL;
using FSISSystem.ENTITIES;

namespace WebAppFSIS.ExercisePages
{
    public partial class Ex05 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MessageLabel.Text = "";
        }

        protected void Fetch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TeamIDArg.Text))
            {
                MessageLabel.Text = "Enter a team id value.";
            }
            else
            {
                int teamid = 0;
                if (int.TryParse(TeamIDArg.Text, out teamid))
                {
                    if (teamid > 0)
                    {
                        TeamController teamController = new TeamController();
                        Team team = null;
                        team = teamController.Teams_FindByID(teamid); //BLL controller method
                        if (team == null)
                        {
                            MessageLabel.Text = "Team ID not found";
                            TeamID.Text = "";
                            TeamDescription.Text = "";
                        }
                        else
                        {
                            TeamID.Text = team.TeamID.ToString();
                            TeamDescription.Text = team.TeamName;
                        }
                    }
                    else
                    {
                        MessageLabel.Text = "Team id must be greater than 0";
                    }
                }
                else
                {
                    double result;
                    if (double.TryParse(TeamIDArg.Text, out result))
                    {
                        MessageLabel.Text = "Team id must be an integer";
                    }
                    else
                    {
                        MessageLabel.Text = "Team id must be a number";
                    }
                }
            }
        }
    }
}