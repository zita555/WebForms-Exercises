<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Exercise09.aspx.cs" Inherits="WebAppFSIS.ExercisePages.Exercise09" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Exercise 09 Player Dropdown</h1>
    <div class="offset-2">
        <asp:Label ID="PlayerLabel" runat="server" Text="Select a Player: "></asp:Label>&nbsp;&nbsp;   
        <asp:DropDownList ID="PlayerList" runat="server"></asp:DropDownList>&nbsp;&nbsp;
        <asp:Button ID="Fetch" runat="server" Text="Fetch" 
             CausesValidation="false" OnClick="Fetch_Click"/>
        <br /><br />
        <asp:Label ID="MessageLabel" runat="server" ></asp:Label>
        <br />
    </div>
</asp:Content>

