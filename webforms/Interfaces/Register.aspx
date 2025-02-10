<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="webforms.Interfaces.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid d-flex flex-column align-items-center justify-content-center gap-3" >

        <div class="row col-3 form-floating">
            <input formcontrolname="email" placeholder="Email" class="form-control" type="text" />
            <label for="email">Email</label>
        </div>

            <div class="form-floating row col-3">

                <input class="form-control" type="text" id="firstName" placeholder="First Name" />
                <label class="form-label" for="firstName">First Name</label>
            </div>

            <div class="form-floating row col-3">

                <input placeholder="Last Name" class="form-control" id="lastName" type="text" />
                <label class="form-label" for="lastName">Last Name</label>


            </div>

            <div class="form-floating row col-3">
                <input placeholder="Username" type="text" class="form-control">
                <label for="" class="form-label">Username</label>
            </div>


            <div class="form-floating row col-3">
                <input type="password" placeholder="Password" class="form-control">
                <label for="" class="form-label">Password</label>
            </div>
            
            <div class="d-flex flex-column align-items-start gap-3">
                            <div>
                <input class="form-check-input" type="radio" id="female" name="gender" value="true" runat="server" />
                <label class="ms-2 form-check-label" for="female">Female</label>
            </div>
            <div>
                <input class="form-check-input" type="radio" id="male" name="gender" value="false" runat="server" />
                <label class="ms-2 form-check-label" for="male">Male</label>
            </div>
        <div class="d-flex justify-content-center center">
            <button onclick="btnRegister_Click" id="registerBtn" type="submit" class="btn btn-primary">Register</button>
        </div>
            </div>

    </div>
</asp:Content>
