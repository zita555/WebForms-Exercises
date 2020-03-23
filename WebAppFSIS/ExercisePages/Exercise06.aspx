<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Exercise06.aspx.cs" Inherits="WebAppFSIS.ExercisePages.Exercise06" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Exercise 6</h1>
    <div class="offset-2">
        <asp:Label ID="TeamsLabel" runat="server" Text="Select a Team"></asp:Label>&nbsp;&nbsp;
        <asp:DropDownList ID="TeamList" runat="server"></asp:DropDownList>&nbsp;&nbsp;
        <asp:Button ID="Fetch" runat="server" Text="Fetch" CausesValidation="false" OnClick="Fetch_Click" />
        <br /><br />
        <asp:Label ID="MessageLabel" runat="server"></asp:Label>
        <br />
        <asp:GridView ID="PlayerList" runat="server"></asp:GridView>
    </div>
</asp:Content>

