<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ex06Default.aspx.cs" Inherits="WebAppFSIS.ExercisePages.Ex06Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Exercise 06</h1>
    <br />
    <div>
        <asp:Label ID="TeamsLabel" runat="server" Text="Select a Team"></asp:Label>&nbsp;&nbsp;
        <asp:DropDownList ID="TeamList" runat="server"></asp:DropDownList>&nbsp;&nbsp;
        <asp:Button ID="Fetch" runat="server" Text="Fetch" CausesValidation="false" OnClick="Fetch_Click" />
        <br /><br />
        <asp:Label ID="MessageLabel" runat="server" ForeColor="Red"></asp:Label>
        <br />
        <asp:Panel id="TeamInfo" runat="server">
            <asp:Label runat="server" Text="Coach: "></asp:Label>&nbsp;&nbsp;
            <asp:Label id="Coach" runat="server"></asp:Label>
            <br />
            <asp:Label runat="server" Text="Assistant Coach: "></asp:Label>&nbsp;&nbsp;
            <asp:Label id="AssistantCoach" runat="server"></asp:Label>
            <br />
            <asp:Label runat="server" Text="Wins: "></asp:Label>&nbsp;&nbsp;
            <asp:Label id="Wins" runat="server"></asp:Label>
            <br />
            <asp:Label runat="server" Text="Losses: "></asp:Label>&nbsp;&nbsp;
            <asp:Label id="Losses" runat="server"></asp:Label>
        </asp:Panel>
        <br />
        <asp:GridView ID="PlayerList" runat="server"></asp:GridView>
    </div>
</asp:Content>

