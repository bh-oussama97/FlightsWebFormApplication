<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddCountry.aspx.cs" Inherits="webforms.Interfaces.AddCountry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="d-flex flex-column gap-3" >
          <div class="form-floating ">
     <asp:TextBox  ID="txtName" runat="server" CssClass="form-control" placeholder="Enter country name" ></asp:TextBox>
     <label for="txtName">Enter country name</label>
 </div>

   <asp:Button  class="btn btn-success d-flex align-self-start" ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"  />

     </div>
</asp:Content>

