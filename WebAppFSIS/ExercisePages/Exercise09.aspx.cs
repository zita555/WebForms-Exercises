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
    public partial class Exercise09 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MessageLabel.Text = "";
            TeamInfo.Visible = false;
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
                TeamController teamController = new TeamController();
                Team teamInfo = null;
                teamInfo = teamController.Teams_FindByID(int.Parse(TeamList.SelectedValue));
                if (teamInfo == null)
                {
                    TeamInfo.Visible = false;
                    Coach.Text = "";
                    AssistantCoach.Text = "";
                    Wins.Text = "";
                    Losses.Text = "";
                }
                else
                {
                    TeamInfo.Visible = true;
                    Coach.Text = teamInfo.Coach;
                    AssistantCoach.Text = teamInfo.AssistantCoach;
                    Wins.Text = teamInfo.Wins.ToString();
                    Losses.Text = teamInfo.Losses.ToString();
                }

                try
                {
                    PlayerController playerController = new PlayerController();
                    List<Player> listOfPlayers = null;
                    listOfPlayers = playerController.FindByID(int.Parse(TeamList.SelectedValue));
                    listOfPlayers.Sort((x, y) => x.PlayerName.CompareTo(y.PlayerName));
                    PlayerList.DataSource = listOfPlayers;
                    PlayerList.DataBind();
                    //PlayerList.Columns[PlayerList.Columns.Count - 1].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageLabel.Text = ex.Message;
                }
            }
        }
        protected void PlayerList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            PlayerList.PageIndex = e.NewPageIndex;
            Fetch_Click(sender, new EventArgs());
        }

        protected void PlayerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow playerRow = PlayerList.Rows[PlayerList.SelectedIndex];
            string playerid = (playerRow.FindControl("PlayerID") as Label).Text;
            Response.Redirect("CRUDPage.aspx?pid=" + playerid);
        }
    }
}