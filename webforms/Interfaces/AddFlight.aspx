<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddFlight.aspx.cs" Inherits="webforms.Interfaces.AddFlight" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

        <div class="d-flex flex-column gap-3" >
                         <asp:DropDownList ID="ddlAirlines" runat="server" CssClass="form-select "></asp:DropDownList>

                  <asp:DropDownList ID="departuresList" runat="server" CssClass="form-select "></asp:DropDownList>
                  <asp:DropDownList ID="arrivalList" runat="server" CssClass="form-select "></asp:DropDownList>

 <div class="form-floating ">
     <asp:TextBox TextMode="Number" ID="txtPrice" runat="server" CssClass="form-control" placeholder="Enter price" ></asp:TextBox>
     <label for="txtPrice">Price</label>
 </div>
    <div class="form-floating ">
        <asp:TextBox TextMode="Number" ID="seats" runat="server" CssClass="form-control" placeholder="Enter number of seats"></asp:TextBox>
        <label for="txtSeats">Number of Seats</label>
    </div>

        <asp:Button  class="btn btn-success d-flex align-self-start" ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click"  />
        </div>
</asp:Content>
