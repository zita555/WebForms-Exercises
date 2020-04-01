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
    public partial class Exercise09b : System.Web.UI.Page
    {
        private static Player player = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string playerID = Request.QueryString["pid"];
                if (string.IsNullOrEmpty(playerID))
                {
                    Response.Redirect("Exercise09.aspx");
                }
                else
                {
                    MessageLabel.Text = "Player ID: " + playerID;
                    try
                    {
                        PlayerController playerController = new PlayerController();
                        player = playerController.FindByPlayerID(int.Parse(playerID));

                        TeamController teamController = new TeamController();
                        List<Team> teamList = null;
                        teamList = teamController.List();
                        teamList.Sort((x, y) => x.TeamName.CompareTo(y.TeamName));
                        TeamList.DataSource = teamList;
                        TeamList.DataTextField = nameof(Team.TeamName);
                        TeamList.DataValueField = nameof(Team.TeamID);
                        TeamList.DataBind();

                        GuardianController guardianController = new GuardianController();
                        List<Guardian> guardianList = null;
                        guardianList = guardianController.List();
                        guardianList.Sort((x, y) => x.GuardianName.CompareTo(y.GuardianName));
                        GuardianList.DataSource = guardianList;
                        GuardianList.DataTextField = nameof(Guardian.GuardianName);
                        GuardianList.DataValueField = nameof(Guardian.GuardianID);
                        GuardianList.DataBind();

                        PlayerID.Text = string.Format("{0}", player.PlayerID);
                        FirstName.Text = player.FirstName;
                        LastName.Text = player.LastName;
                        Age.Text = string.Format("{0}", player.Age);
                        Gender.Text = player.Gender;
                        AlbertaHealthCareNumber.Text = player.AlbertaHealthCareNumber;
                        MedicalAlertDetails.Text = player.MedicalAlertDetails;

                        TeamList.SelectedValue = string.Format("{0}", player.TeamID);
                        GuardianList.SelectedValue = string.Format("{0}", player.GuardianID);

                    }
                    catch (Exception ex)
                    {
                        MessageLabel.Text = ex.Message;
                    }
                }
            }
        }
        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Exercise09.aspx");
        }
        protected void Reset_Click(object sender, EventArgs e)
        {
            PlayerID.Text = string.Format("{0}", player.PlayerID);
            FirstName.Text = player.FirstName;
            LastName.Text = player.LastName;
            Age.Text = string.Format("{0}", player.Age);
            Gender.Text = player.Gender;
            AlbertaHealthCareNumber.Text = player.AlbertaHealthCareNumber;
            MedicalAlertDetails.Text = player.MedicalAlertDetails;

            TeamList.SelectedValue = string.Format("{0}", player.TeamID);
            GuardianList.SelectedValue = string.Format("{0}", player.GuardianID);
        }
        protected void Update_Click(object sender, EventArgs e)
        {
            PlayerController playerController = new PlayerController();
        }
        protected void Delete_Click(object sender, EventArgs e)
        {
            PlayerController playerController = new PlayerController();
        }
    }
}