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
                newPlayer.MedicalAlertDetails = MedicalAlertDetails.Text;
                newPlayer.TeamID = int.Parse(TeamList.SelectedValue);
                newPlayer.GuardianID = int.Parse(GuardianList.SelectedValue);
                return newPlayer;
            }
            catch (Exception ex)
            {
                MessageLabel.Text = ex.Message;
                //errormsgs.Add(GetInnerException(ex).ToString());
                //LoadMessageDisplay(errormsgs, "alert alert-danger");
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
            if (TeamList.SelectedIndex == 0 || GuardianList.SelectedIndex == 0)
            {
                if (TeamList.SelectedIndex == 0)
                {
                    MessageLabel.Text += "Select a Team.\n";
                }
                else if (GuardianList.SelectedIndex == 0)
                {
                    MessageLabel.Text += "Select a Guardian.\n";
                }
            }
            else
            {
                Player newPlayer = CreatePlayer();
                if (newPlayer != null)
                {
                    try
                    {
                        PlayerController playerController = new PlayerController();
                        playerController.Player_Add(newPlayer);

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

                        MessageLabel.Text = "New Player Added";
                    }
                    catch (Exception ex)
                    {
                        MessageLabel.Text += ex.Message;
                    }
                }
            }
        }
    }
}