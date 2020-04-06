<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Exercise09Add.aspx.cs" Inherits="WebAppFSIS.ExercisePages.Exercise09Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Exercise 09 CRUD</h1>
    <asp:Label ID="MessageLabel" runat="server"></asp:Label><br />
    <div class="row">
        <div class="col-md-12 alert alert-info">
            Players CRUD Page
        </div>
    </div>
    <div class="row">
        <%-- Validation --%>
        <div class="col-md-12 text-left">
            <%-- First Name --%>
            <asp:RequiredFieldValidator ID="RequiredFirstName" runat="server"
                ErrorMessage="First name is required" Display="None" SetFocusOnError="true" ForeColor="Firebrick"
                ControlToValidate="FirstName"> 
            </asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegExFirstName" runat="server"
                ErrorMessage="First name can be at most 50 characters" Display="None" SetFocusOnError="true" ForeColor="Firebrick" ControlToValidate="FirstName" ValidationExpression="[a-zA-Z]{0,50}">
            </asp:RegularExpressionValidator>

            <%-- Last Name --%>
            <asp:RequiredFieldValidator ID="RequiredLastName" runat="server"
                ErrorMessage="Last name is required" Display="None" SetFocusOnError="true" ForeColor="Firebrick"
                ControlToValidate="LastName"> 
            </asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegExLastName" runat="server"
                ErrorMessage="Last name can be at most 50 characters" Display="None" SetFocusOnError="true" ForeColor="Firebrick" ControlToValidate="LastName" ValidationExpression="^[a-zA-Z]{0,50}$">
            </asp:RegularExpressionValidator>
            
            <%-- Age --%>
            <asp:RequiredFieldValidator ID="RequiredAge" runat="server"
                ErrorMessage="Age is required" Display="None" SetFocusOnError="true" ForeColor="Firebrick"
                ControlToValidate="Age">
            </asp:RequiredFieldValidator>
            <asp:RangeValidator ID="RangeAge" runat="server"
                ErrorMessage="Age must be between 6 and 14" Display="None" SetFocusOnError="true" ForeColor="Firebrick"
                ControlToValidate="Age" MinimumValue="6" MaximumValue="14" Type="Integer">
            </asp:RangeValidator>

            <%-- Gender --%>
            <asp:RequiredFieldValidator ID="RequiredGender" runat="server"
                ErrorMessage="Gender is Required" Display="None" SetFocusOnError="true" ForeColor="Firebrick"
                ControlToValidate="Gender">
            </asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegExGender" runat="server"
                ErrorMessage="Gender can only be a single character" Display="None" SetFocusOnError="true" ForeColor="Firebrick" ControlToValidate="Gender" ValidationExpression="[a-zAZ]{1}">
            </asp:RegularExpressionValidator>

            <%-- Alberta Health Care Number --%>
            <asp:RequiredFieldValidator ID="RequiredAlbertaHealthCareNumber" runat="server"
                ErrorMessage="Alberta Health Care Number is required" Display="None" SetFocusOnError="true" ForeColor="Firebrick"
                ControlToValidate="AlbertaHealthCareNumber">
            </asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegExAlbertaHealthCareNumber" runat="server"
                ErrorMessage="Alberta Health Care Number must be 10 digits and cannot begin with 0" Display="None" SetFocusOnError="true" ForeColor="Firebrick"
                ControlToValidate="AlbertaHealthCareNumber" ValidationExpression="[1-9]{1}[0-9]{9}">
            </asp:RegularExpressionValidator>

            <%-- Medical Alert Details --%>
            <asp:RegularExpressionValidator ID="RegExMedicalAlertDetails" runat="server"
                ErrorMessage="Medical Alert Details can be at most 250 characters" Display="None" SetFocusOnError="true" ForeColor="Firebrick"
                ControlToValidate="MedicalAlertDetails" ValidationExpression="[a-zA-Z]{0,250}">
            </asp:RegularExpressionValidator>

            <%-- Team --%>
            <asp:RangeValidator ID="RangeTeamList" runat="server"
                ErrorMessage="A team must be selected" Display="None" SetFocusOnError="true" ForeColor="Firebrick"
                ControlToValidate="TeamList" MinimumValue="1" MaximumValue="2147483647" Type="Integer">
            </asp:RangeValidator>

            <%-- Guardian --%>
            <asp:RangeValidator ID="RangeGuardianList" runat="server"
                ErrorMessage="A guardian must be selected" Display="None" SetFocusOnError="true" ForeColor="Firebrick"
                ControlToValidate="GuardianList" MinimumValue="1" MaximumValue="2147483647" Type="Integer">
            </asp:RangeValidator>

            <asp:ValidationSummary ID="ValidationSummary1" runat="server"
                HeaderText="Address the following concerns with your entered data." />
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
            <asp:Button ID="ClearButton" runat="server" OnClick="Clear_Click" Text="Clear" CausesValidation="false"/>&nbsp;&nbsp;
            <asp:Button ID="AddButton" runat="server" OnClick="Add_Click" Text="Add"/>&nbsp;&nbsp;            
        </div>
    </div>
</asp:Content>
