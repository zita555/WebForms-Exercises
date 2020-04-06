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
        List<string> errormsgs = new List<string>();
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
                player = playerController.Player_Find(int.Parse(playerID));

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
                //MessageLabel.Text = ex.Message;
                errormsgs.Add(GetInnerException(ex).ToString());
                LoadMessageDisplay(errormsgs, "alert alert-danger");
            }
        }
        protected Player CreatePlayer()
        {
            try
            {
                Player newPlayer = new Player();
                newPlayer.PlayerID = int.Parse(PlayerID.Text);
                newPlayer.FirstName = FirstName.Text;
                newPlayer.LastName = LastName.Text;
                newPlayer.Age = int.Parse(Age.Text);
                newPlayer.Gender = Gender.Text;
                newPlayer.AlbertaHealthCareNumber = AlbertaHealthCareNumber.Text;
                newPlayer.MedicalAlertDetails = MedicalAlertDetails.Text;
                newPlayer.TeamID = int.Parse(TeamList.SelectedValue);
                newPlayer.GuardianID = int.Parse(GuardianList.SelectedValue);
                return newPlayer;
            }
            catch (Exception ex)
            {
                //MessageLabel.Text = ex.Message;
                errormsgs.Add(GetInnerException(ex).ToString());
                LoadMessageDisplay(errormsgs, "alert alert-danger");
                return null;
            }
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
            Player newPlayer = CreatePlayer();

            if (newPlayer != null)
            {
                try
                {
                    PlayerController playerController = new PlayerController();
                    playerController.Player_Update(newPlayer);
                }
                catch (Exception ex)
                {
                    //MessageLabel.Text = ex.Message;
                    errormsgs.Add(GetInnerException(ex).ToString());
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
            }
        }
        protected void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                string playerID = Request.QueryString["pid"];
                PlayerController playerController = new PlayerController();
                
                

                playerController.Player_Delete(int.Parse(playerID));
                Response.Redirect("Exercise09.aspx");
            }
            catch (Exception ex)
            {
                //MessageLabel.Text = ex.Message;
                errormsgs.Add(GetInnerException(ex).ToString());
                LoadMessageDisplay(errormsgs, "alert alert-danger");
            }
        }
        protected Exception GetInnerException(Exception ex)
        {
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            return ex;
        }
        protected void LoadMessageDisplay(List<string> errormsglist, string cssclass)
        {
            Message.CssClass = cssclass;
            Message.DataSource = errormsglist;
            Message.DataBind();
        }
    }
}