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
    public partial class Exercise09Edit : System.Web.UI.Page
    {
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
                    //MessageLabel.Text = "Player ID: " + playerID;
                    GetPlayer();
                    FirstName.Focus();
                }
            }
        }
        protected void GetPlayer()
        {
            string playerID = Request.QueryString["pid"];
            Player player = null;
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
        protected Player CreatePlayer()
        {

        }
        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Exercise09.aspx");
        }
        protected void Reset_Click(object sender, EventArgs e)
        {
            GetPlayer();
        }
        protected void Update_Click(object sender, EventArgs e)
        {
            try
            {
                //Player newPlayer = new Player(FirstName.Text, LastName.Text, Age.Text, Gender.Text, AlbertaHealthCareNumber.Text, MedicalAlertDetails.Text, TeamList.SelectedValue, GuardianList.SelectedValue);
                PlayerController playerController = new PlayerController();
                //playerController.UpdatePlayer(newPlayer);
            }
            catch (Exception ex)
            {
                MessageLabel.Text = ex.Message;
            }
        }
        protected void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                string playerID = Request.QueryString["pid"];
                PlayerController playerController = new PlayerController();
                //playerController.DeletePlayer(PlayerID);
                Response.Redirect("Exercise09.aspx");
            }
            catch (Exception ex)
            {
                MessageLabel.Text = ex.Message;
            }
        }
    }
}