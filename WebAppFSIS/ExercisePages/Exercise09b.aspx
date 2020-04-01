<%@ Page Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Exercise09b.aspx.cs" Inherits="WebAppFSIS.ExercisePages.Exercise09b" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Exercise 09 CRUD</h1>
    <asp:Label ID="MessageLabel" runat="server"></asp:Label><br />
    <div class="row">
        <div class="col-md-12 alert alert-info">
            Players CRUD Page
        </div>
    </div>
    <div class="row">
        <%--<div class="col-md-12 text-left">
            <asp:RequiredFieldValidator ID="RequiredProductName" runat="server"
                ErrorMessage="Product name is required" Display="None" SetFocusOnError="true" ForeColor="Firebrick"
                ControlToValidate="ProductName"> 
            </asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareUnitPrice" runat="server"
                ErrorMessage="Unit Price must be 0.00 or greater" Display="None" SetFocusOnError="true" ForeColor="Firebrick"
                ControlToValidate="UnitPrice" Operator="GreaterThanEqual" ValueToCompare="0.00" Type="Double"> 
            </asp:CompareValidator>
            <asp:RangeValidator ID="RangeUnitsInStock" runat="server"
                ErrorMessage="Units in stock must be between 0 and 32767" Display="None" SetFocusOnError="true" ForeColor="Firebrick"
                ControlToValidate="UnitsInStock" MaximumValue="32767" MinimumValue="0" Type="Integer"> 
            </asp:RangeValidator>
            <asp:RangeValidator ID="RangeUnitsOnOrder" runat="server"
                ErrorMessage="Units on order must be between 0 and 32767" Display="None" SetFocusOnError="true" ForeColor="Firebrick"
                ControlToValidate="UnitsOnOrder" MaximumValue="32767" MinimumValue="0" Type="Integer"> 
            </asp:RangeValidator>
            <asp:RangeValidator ID="RangeReorderLevel" runat="server"
                ErrorMessage="Reorder levlel must be between 0 and 32767" Display="None" SetFocusOnError="true" ForeColor="Firebrick"
                ControlToValidate="ReorderLevel" MaximumValue="32767" MinimumValue="0" Type="Integer"> 
            </asp:RangeValidator>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                HeaderText="Address the following concerns with your entered data." />
        </div>--%>
    </div>

    <div class="row">
        <div class="col-md-4 text-right">
                <asp:Label ID="PlayerIDLabel" runat="server" Text="Player ID"
                     AssociatedControlID="PlayerID">
                </asp:Label>
        </div>
        <div class="col-md-4 text-left">
                <asp:TextBox ID="PlayerID" runat="server" readonly="true">
                </asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4 text-right">
                  <asp:Label ID="FirstNameLabel" runat="server" Text="First Name"
                     AssociatedControlID="FirstName"></asp:Label>
        </div>
        <div class="col-md-4 text-left">
                <asp:TextBox ID="FirstName" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4 text-right">
                  <asp:Label ID="LastNameLabel" runat="server" Text="Last Name"
                     AssociatedControlID="LastName"></asp:Label>
        </div>
        <div class="col-md-4 text-left">
                <asp:TextBox ID="LastName" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4 text-right">
                  <asp:Label ID="AgeLabel" runat="server" Text="Age"
                     AssociatedControlID="Age"></asp:Label>
        </div>
        <div class="col-md-4 text-left">
                <asp:TextBox ID="Age" runat="server"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4 text-right">
                  <asp:Label ID="GenderLabel" runat="server" Text="Gender"
                     AssociatedControlID="Gender"></asp:Label>
        </div>
        <div class="col-md-4 text-left">
                <asp:TextBox ID="Gender" runat="server" MaxLength="1" ></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4 text-right">
                <asp:Label ID="TeamListLabel" runat="server" Text="Team"
                     AssociatedControlID="TeamList">
                </asp:Label>
        </div>
        <div class="col-md-4 text-left">
                <asp:DropDownList ID="TeamList" runat="server" Width="350px" >
                </asp:DropDownList> 
        </div>
    </div>
    <div class="row">
        <div class="col-md-4 text-right">
                <asp:Label ID="GuardianListLabel" runat="server" Text="Guardian"
                     AssociatedControlID="GuardianList">
                </asp:Label>
        </div>
        <div class="col-md-4 text-left">
                <asp:DropDownList ID="GuardianList" runat="server" Width="350px" >
                </asp:DropDownList> 
        </div>
    </div>
    <div class="row">
        <div class="col-md-4 text-right">
                  <asp:Label ID="AlbertaHealthCareNumberLabel" runat="server" Text="Alberta Health Care Number"
                     AssociatedControlID="AlbertaHealthCareNumber">
                  </asp:Label>
        </div>
        <div class="col-md-4 text-left">
                <asp:TextBox ID="AlbertaHealthCareNumber" runat="server"> 
                </asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4 text-right">
                  <asp:Label ID="MedicalAlertDetailsLabel" runat="server" Text="Medical Alert Details"
                     AssociatedControlID="MedicalAlertDetails">
                  </asp:Label>
        </div>
        <div class="col-md-4 text-left">
                <asp:TextBox ID="MedicalAlertDetails" runat="server"> 
                </asp:TextBox>
        </div>
    </div>

    <div class="row">
        <div class="col-md-4">
        </div>
        <div class="col-md-6 text-left">
            <asp:Button ID="BackButton" runat="server" Text="Back" CausesValidation="false" OnClick="Back_Click" />&nbsp;&nbsp;
            <asp:Button ID="ResetButton" runat="server" OnClick="Reset_Click" Text="Reset" CausesValidation="false"/>&nbsp;&nbsp;
            <asp:Button ID="UpdateButton" runat="server" OnClick="Update_Click" Text="Update"/>&nbsp;&nbsp;            
            <asp:Button ID="DeleteButton" runat="server" OnClick="Delete_Click" Text="Delete"/>&nbsp;&nbsp;
        </div>
    </div>
</asp:Content>
