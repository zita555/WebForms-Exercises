<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Exercise09.aspx.cs" Inherits="WebAppFSIS.ExercisePages.Exercise09" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Exercise 09 Player Dropdown</h1>
    <div class="offset-2">
        <div class="row">
            <asp:Label ID="PlayerLabel" runat="server" Text="Select a Player: "></asp:Label>&nbsp;&nbsp;   
            <asp:DropDownList ID="PlayerList" runat="server"></asp:DropDownList>
            <br /><br />
        </div>
        <br />
        <div class="row">
            <asp:Button ID="AddButton" runat="server" Text="Add Player" 
                 CausesValidation="false" OnClick="Add_Click"/>&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="EditButton" runat="server" Text="Edit Player" 
                 CausesValidation="false" OnClick="Edit_Click"/>
        </div>
        <br /><br />
        <asp:Label ID="MessageLabel" runat="server" ></asp:Label>
        <br />
    </div>
</asp:Content>

