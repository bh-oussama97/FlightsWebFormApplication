<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="AddFlight.aspx.cs" Inherits="webforms.Interfaces.AddFlight" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="d-flex flex-column gap-3 container-fluid justify-content-center align-items-center"
        style="min-height: 69vh;">
        <asp:DropDownList ID="ddlAirlines" runat="server" CssClass="form-select "></asp:DropDownList>

        <asp:DropDownList ID="departuresList" runat="server" CssClass="form-select "></asp:DropDownList>
        <asp:DropDownList ID="arrivalList" runat="server" CssClass="form-select "></asp:DropDownList>

        <asp:TextBox TextMode="Number" ID="txtPrice" runat="server" CssClass="form-control"
            placeholder="Enter price"></asp:TextBox>
        <asp:TextBox TextMode="Number" ID="seats" runat="server" CssClass="form-control"
            placeholder="Enter number of seats"></asp:TextBox>

        <asp:Button class="btn btn-success " ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
    </div>
</asp:Content>
