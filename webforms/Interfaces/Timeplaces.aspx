<%@ Page Title="Countries" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Timeplaces.aspx.cs" Inherits="webforms.Interfaces.Timeplaces" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="d-flex justify-content-between gap-2 container-fluid align-items-center"   >
    <asp:GridView ID="gvCountries" runat="server" 
     OnRowCommand="gvCountries_RowCommand"
        AutoGenerateColumns="False" CssClass="table" >
    <Columns>
         <asp:BoundField DataField="Id" HeaderText="Id" />
        <asp:BoundField DataField="Name" HeaderText="Name" />
        <asp:BoundField DataField="CreatedDate" HeaderText="Creation Date" DataFormatString="{0:dd-MM-yyyy}"/>

                <asp:TemplateField HeaderText="Actions">
            <ItemTemplate>
                <asp:LinkButton ID="btnEdit" runat="server" CommandName="EditCountry"
                    CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-warning btn-sm">
                    <i class="fa fa-edit"></i>
                </asp:LinkButton>
                &nbsp;
                <asp:LinkButton ID="btnDelete" runat="server" CommandName="DeleteCountry" CommandArgument='<%# Eval("Id") %>' 
                    CssClass="btn btn-danger btn-sm" 
                    OnClientClick="return confirm('Are you sure you want to delete this country?');">
                    <i class="fa fa-trash"></i>
                </asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
       </asp:GridView>
        <asp:Button class="btn btn-primary d-flex align-self-start" runat="server" Text="New Country" onClick="btn_AddCountry"/>

    </div>

</asp:Content>
