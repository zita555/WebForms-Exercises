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
    public partial class Ex09 : System.Web.UI.Page
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
                PlayerController playerController = new PlayerController();
                List<Player> listOfPlayers = null;
                listOfPlayers = playerController.Player_List();
                listOfPlayers.Sort((x, y) => x.PlayerName.CompareTo(y.PlayerName));
                PlayerList.DataSource = listOfPlayers;
                PlayerList.DataTextField = nameof(Player.PlayerName);
                PlayerList.DataValueField = nameof(Player.PlayerID);
                PlayerList.DataBind();
                PlayerList.Items.Insert(0, "Select a Player");
            }
            catch (Exception ex)
            {
                MessageLabel.Text = ex.Message;
            }
        }
        protected void Add_Click(object sender, EventArgs e)
        {
            try
            {
                string playerid = PlayerList.SelectedValue;
                Response.Redirect("Ex09Add.aspx");
                //MessageLabel.Text = "Redirect to Crud Page";
            }
            catch (Exception ex)
            {
                MessageLabel.Text = ex.Message;
            }
        }
        protected void Edit_Click(object sender, EventArgs e)
        {
            if (PlayerList.SelectedIndex == 0)
            {
                MessageLabel.Text = "Select a team to view its players.";
            }
            else
            {
                try
                {
                    string playerid = PlayerList.SelectedValue;
                    Response.Redirect("Ex09Edit.aspx?pid=" + playerid); 
                    //MessageLabel.Text = "Redirect to Crud Page";
                }
                catch (Exception ex)
                {
                    MessageLabel.Text = ex.Message;
                }
            }
        }
    }
}