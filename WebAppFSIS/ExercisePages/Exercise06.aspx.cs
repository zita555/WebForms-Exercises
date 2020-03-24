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
    public partial class Exercise06 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MessageLabel.Text = "";
            if (!Page.IsPostBack)
            {
                BindList();
            }
        }

        protected void BindList()
        {
            try
            {
                TeamController teamController = new TeamController();
                List<Team> listOfTeams = null;
                listOfTeams = teamController.List();
                listOfTeams.Sort((x, y) => x.TeamName.CompareTo(y.TeamName));
                TeamList.DataSource = listOfTeams;
                TeamList.DataTextField = nameof(Team.TeamName);
                TeamList.DataValueField = nameof(Team.TeamID);
                TeamList.DataBind();
                TeamList.Items.Insert(0, "Select a Team");
            }
            catch (Exception ex)
            {
                MessageLabel.Text = ex.Message;
            }
        }

        protected void Fetch_Click(object sender, EventArgs e)
        {
            if (TeamList.SelectedIndex == 0)
            {
                MessageLabel.Text = "Select a team to view its players.";
            }
            else
            {
                try
                {
                    PlayerController playerController = new PlayerController();
                    List<Player> listOfPlayers = null;
                    listOfPlayers = playerController.FindByID(int.Parse(TeamList.SelectedValue));
                    listOfPlayers.Sort((x, y) => x.PlayerName.CompareTo(y.PlayerName));
                    PlayerList.DataSource = listOfPlayers;
                    PlayerList.DataBind();
                }
                catch (Exception ex)
                {
                    MessageLabel.Text = ex.Message;
                }
            }
        }
    }
}