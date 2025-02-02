<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditFlight.aspx.cs" Inherits="webforms.Interfaces.EditFlight" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">
    <div class="d-flex flex-column  gap-3"> 
        <asp:HiddenField ID="hfFlightId" runat="server" />

        <asp:DropDownList ID="ddlAirlines" runat="server" CssClass="form-select"></asp:DropDownList>

        <asp:DropDownList ID="departuresList" runat="server" CssClass="form-select"></asp:DropDownList>

        <asp:DropDownList ID="arrivalList" runat="server" CssClass="form-select"></asp:DropDownList>

        <div class="form-floating">
<asp:TextBox ID="price" runat="server" CssClass="form-control" AutoPostBack="true" ></asp:TextBox>
            <label for="price">Price</label>
        </div>

        <div class="form-floating">
            <asp:TextBox TextMode="Number" ID="seatsEdit" runat="server" CssClass="form-control" placeholder="Enter number of seats"></asp:TextBox>
            <label for="seatsEdit">Number of Seats</label>
        </div>

        <asp:Button class="btn btn-primary d-flex align-self-start" ID="btnUpdate" runat="server" Text="Update" OnClick="BtnUpdate_Click" />
    </div>
</asp:Content>

