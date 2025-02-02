<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditCountry.aspx.cs" Inherits="webforms.Interfaces.EditCountry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
         <div class="d-flex flex-column gap-3" >
          <asp:HiddenField ID="hfCountryId" runat="server" />
          <div class="form-floating ">
     <asp:TextBox  ID="txtName" runat="server" CssClass="form-control" placeholder="Enter country name" ></asp:TextBox>
     <label for="txtName">Enter country name</label>
 </div>

   <asp:Button  class="btn btn-success d-flex align-self-start" ID="btnSave" runat="server" Text="Update" OnClick="BtnUpdate_Click"  />
             </div>

</asp:Content>
