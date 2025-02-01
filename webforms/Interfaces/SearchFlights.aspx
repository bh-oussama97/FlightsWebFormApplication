<%@ Page Title="Flights" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchFlights.aspx.cs" Inherits="webforms.Interfaces.SearchFlights" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
            
    <div class="d-flex justify-content-between mb-3">
            <div id="search" class="d-flex gap-2 ">
         <asp:TextBox class="form-control"  ID="txtSearchMaster" runat="server"></asp:TextBox>
         <asp:Button  class="btn btn-dark" ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"  />
     </div>
    <asp:Button  class="btn btn-primary" ID="btnAdd" runat="server" Text="New Flight" OnClick="btnAdd_Click"  />
    </div>


    <main aria-labelledby="title">
<asp:GridView ID="gvFlights" runat="server" AutoGenerateColumns="False" CssClass="table" OnRowCommand="gvFlights_RowCommand">
    <Columns>
        <asp:BoundField DataField="Id" HeaderText="Id" />
        <asp:BoundField DataField="Airline" HeaderText="Airline" />
        <asp:BoundField DataField="Departure" HeaderText="Departure" />
        <asp:BoundField DataField="Arrival" HeaderText="Arrival" />
        <asp:BoundField DataField="Price" HeaderText="Price" />
        <asp:BoundField DataField="RemainingNumberOfSeats" HeaderText="Remaining Seats" />

        <asp:TemplateField HeaderText="Actions">
            <ItemTemplate>
                <asp:LinkButton ID="btnEdit" runat="server" CommandName="EditFlight" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-warning btn-sm">
                    <i class="fa fa-edit"></i>
                </asp:LinkButton>
                &nbsp;
                <asp:LinkButton ID="btnDelete" runat="server" CommandName="DeleteFlight" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-danger btn-sm" OnClientClick="return confirm('Are you sure you want to delete this flight?');">
                    <i class="fa fa-trash"></i>
                </asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>




    </main>
</asp:Content>
