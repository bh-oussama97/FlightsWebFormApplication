<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="EditFlight.aspx.cs" Inherits="webforms.Interfaces.EditFlight" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">
    <div class="d-flex flex-column  gap-3 container-fluid justify-content-center align-items-center"
       >
        <asp:HiddenField ID="hfFlightId" runat="server" />

        <asp:DropDownList ID="ddlAirlines" runat="server" CssClass="form-select"></asp:DropDownList>

        <asp:DropDownList ID="departuresList" runat="server" CssClass="form-select"></asp:DropDownList>

        <asp:DropDownList ID="arrivalList" runat="server" CssClass="form-select"></asp:DropDownList>

        <asp:TextBox ID="price" runat="server" CssClass="form-control" AutoPostBack="true"></asp:TextBox>

        <asp:TextBox TextMode="Number" ID="seatsEdit" runat="server" CssClass="form-control"
            placeholder="Enter number of seats"></asp:TextBox>
        <asp:Button class="btn btn-primary" ID="btnUpdate" runat="server" Text="Update" OnClick="BtnUpdate_Click" />
    </div>
</asp:Content>

