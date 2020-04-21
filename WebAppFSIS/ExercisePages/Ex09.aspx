<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ex09.aspx.cs" Inherits="WebAppFSIS.ExercisePages.Ex09" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Exercise 09&10 Dropdown List</h1>
    <br />  
    <asp:Label ID="PlayerLabel" runat="server" Text="Select a Player: "></asp:Label>&nbsp;&nbsp;   
    <asp:DropDownList ID="PlayerList" runat="server"></asp:DropDownList>&nbsp;&nbsp;            
    <asp:Button ID="EditButton" runat="server" Text="Edit Player" 
            CausesValidation="false" OnClick="Edit_Click"/>&nbsp;&nbsp;
    <asp:Button ID="AddButton" runat="server" Text="Add Player" CausesValidation="false" OnClick="Add_Click"/>
    <br />
    <br />
    <asp:Label ID="MessageLabel" runat="server" ForeColor="Red" ></asp:Label>
</asp:Content>

