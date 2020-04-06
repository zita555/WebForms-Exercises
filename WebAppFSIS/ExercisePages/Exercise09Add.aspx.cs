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
    public partial class Exercise09Add : System.Web.UI.Page
    {
        protected readonly string[] GENDER_LIST = { "M", "F" };
        List<string> errormsgs = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FirstName.Focus();

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

                TeamList.Items.Insert(0, "Select a Team");
                GuardianList.Items.Insert(0, "Select a Guardian");
            }
        }
        protected Player CreatePlayer()
        {
            try
            {
                Player newPlayer = new Player();
                newPlayer.FirstName = FirstName.Text;
                newPlayer.LastName = LastName.Text;
                newPlayer.Age = int.Parse(Age.Text);
                newPlayer.Gender = Gender.Text;
                newPlayer.AlbertaHealthCareNumber = AlbertaHealthCareNumber.Text;
                newPlayer.MedicalAlertDetails = string.IsNullOrEmpty(MedicalAlertDetails.Text) ? null : MedicalAlertDetails.Text;
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
        protected void Clear_Click(object sender, EventArgs e)
        {
            FirstName.Text = "";
            LastName.Text = "";
            Age.Text = "";
            Gender.Text = "";
            AlbertaHealthCareNumber.Text = "";
            MedicalAlertDetails.Text = "";

            TeamList.SelectedIndex = 0;
            GuardianList.SelectedIndex = 0;
        }
        protected void Add_Click(object sender, EventArgs e)
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
                int playerID = playerController.AddPlayer(newPlayer);

                FirstName.Enabled = false;
                LastName.Enabled = false;
                Age.Enabled = false;
                Gender.Enabled = false;
                AlbertaHealthCareNumber.Enabled = false;
                MedicalAlertDetails.Enabled = false;

                TeamList.Enabled = false;
                GuardianList.Enabled = false;

                AddButton.Enabled = false;
                ClearButton.Enabled = false;

                errormsgs.Add($"Player #{playerID} - {newPlayer.PlayerName} added to {TeamList.SelectedItem.Text}");
                LoadMessageDisplay(errormsgs, "alert alert-success");
                LookUp_Click(sender, new EventArgs());

            }
            catch (Exception ex)
            {
                errormsgs.Add(GetInnerException(ex).ToString());
                LoadMessageDisplay(errormsgs, "alert alert-danger");
            }
        }

        protected void Validate(object sender, EventArgs e)
        {
            if (TeamList.SelectedIndex == 0)
            {
                errormsgs.Add("A Team must be selected");
            }
            if (GuardianList.SelectedIndex == 0)
            {
                errormsgs.Add("A Guardian must be selected");
            }
            if (!GENDER_LIST.Contains(Gender.Text))
            {
                errormsgs.Add("Please select a valid gender");
            }
        }

        protected void LookUp_Click(object sender, EventArgs e)
        {
            if (TeamList.SelectedIndex == 0)
            {
                errormsgs.Add("Select a team to view its players.");
                LoadMessageDisplay(errormsgs, "alert alert-danger");
            }
            else
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
    }
}