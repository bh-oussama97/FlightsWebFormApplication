<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="webforms.Interfaces.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server" >
      <div class="container-fluid d-flex flex-column align-items-center justify-content-center gap-3 " style="    min-height: 69vh;">
  
      <div class="form-floating row col-3">
        <input  formControlName="email" placeholder="name@example.com" class="form-control" type="text" />
        <label for="email">Email</label>
  
      </div>

      
      <div class="form-floating row col-3">
        <input formControlName="password" type="password" placeholder="Password"  class="form-control">
        <label for="" class="form-label">Password</label>
      </div>
      
      <div class="d-flex justify-content-start col-3">
        <button OnClick="loginBtn" type="submit" class="btn btn-primary">Login </button>
      </div>



    </div>
</asp:Content>
