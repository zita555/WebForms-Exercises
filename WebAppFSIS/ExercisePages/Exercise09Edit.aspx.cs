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
        protected readonly string[] GENDER_LIST = { "M", "F" };
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
            FirstName.Text = FirstName.Text.Trim();
            LastName.Text = LastName.Text.Trim();
            Age.Text = Age.Text.Trim();
            Gender.Text = Gender.Text.Trim().ToUpper();
            AlbertaHealthCareNumber.Text = AlbertaHealthCareNumber.Text.Trim();
            MedicalAlertDetails.Text = MedicalAlertDetails.Text.Trim();

            Validate(sender, e);
            if (errormsgs.Count > 0)
            {
                LoadMessageDisplay(errormsgs, "alert alert-info");
            }

            try
            {
                Player newPlayer = CreatePlayer();
                PlayerController playerController = new PlayerController();
                int rowCount = playerController.UpdatePlayer(newPlayer);
                if (rowCount > 0) { 
                    errormsgs.Add($"Player #{PlayerID.Text} - {newPlayer.PlayerName} was Updated");
                    LoadMessageDisplay(errormsgs, "alert alert-success");
                    LookUp_Click(sender, new EventArgs());
                }
                else
                {
                    errormsgs.Add("Player could not be updated");
                    LoadMessageDisplay(errormsgs, "alert alert-info");
                }
            }
            catch (Exception ex)
            {
                errormsgs.Add(GetInnerException(ex).ToString());
                LoadMessageDisplay(errormsgs, "alert alert-danger");
            }
        }
        protected void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                string playerID = Request.QueryString["pid"];
                PlayerController playerController = new PlayerController();

                int rowCount = playerController.DeletePlayer(int.Parse(playerID));
                if (rowCount > 0)
                {
                    PlayerID.Enabled = false;
                    FirstName.Enabled = false;
                    LastName.Enabled = false;
                    Age.Enabled = false;
                    Gender.Enabled = false;
                    AlbertaHealthCareNumber.Enabled = false;
                    MedicalAlertDetails.Enabled = false;

                    TeamList.Enabled = false;
                    GuardianList.Enabled = false;

                    UpdateButton.Enabled = false;
                    DeleteButton.Enabled = false;
                    ResetButton.Enabled = false;

                    LookUp_Click(sender, new EventArgs());

                    errormsgs.Add($"Player #{PlayerID.Text} - {FirstName.Text} {LastName.Text} was Deleted");
                    LoadMessageDisplay(errormsgs, "alert alert-success");
                }
                else
                {
                    errormsgs.Add("Product could not be found");
                    LoadMessageDisplay(errormsgs, "alert alert-warning");
                }
            }
            catch (Exception ex)
            {
                errormsgs.Add(GetInnerException(ex).ToString());
                LoadMessageDisplay(errormsgs, "alert alert-danger");
            }
        }
        protected void LookUp_Click(object sender, EventArgs e)
        {
            
                TeamController teamController = new TeamController();
                Team teamInfo = null;
                teamInfo = teamController.Teams_FindByID(int.Parse(TeamList.SelectedValue));
                try
                {
                    PlayerController playerController = new PlayerController();
                    List<Player> listOfPlayers = null;
                    listOfPlayers = playerController.FindByID(int.Parse(TeamList.SelectedValue));
                    listOfPlayers.Sort((x, y) => x.PlayerName.CompareTo(y.PlayerName));
                    PlayerList.DataSource = listOfPlayers;
                    PlayerList.DataBind();
                    PlayerListLabel.Text = TeamList.SelectedItem.Text;
                }
                catch (Exception ex)
                {
                    errormsgs.Add(GetInnerException(ex).ToString());
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
            
        }
        protected void PlayerList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            PlayerList.PageIndex = e.NewPageIndex;
            LookUp_Click(sender, new EventArgs());
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
        protected void Validate(object sender, EventArgs e)
        {
            //if (TeamList.SelectedIndex == 0)
            //{
            //    errormsgs.Add("A Team must be selected");
            //}
            //if (GuardianList.SelectedIndex == 0)
            //{
            //    errormsgs.Add("A Guardian must be selected");
            //}
            if (!GENDER_LIST.Contains(Gender.Text))
            {
                errormsgs.Add("Please select a valid gender");
            }
        }
    }
}