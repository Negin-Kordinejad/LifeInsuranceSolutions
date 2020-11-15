﻿<%@ Page Title="" Language="C#" MasterPageFile="~/InsuredAgentOrg/MasterPage.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="LifeInsWebApp.InsuredAgentOrg.Login.SignUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <!-- Sign Up -->
    <div class="container center-page">

        <label class="col-xs-11">Username</label>
        <div class="col-xs-11">
            <asp:TextBox ID="tbUname" runat="server" Class="form-control" placeholder="Usename"></asp:TextBox>
        </div>
        <label class="col-xs-11">Password</label>
        <div class="col-xs-11">
            <asp:TextBox ID="tbPass" runat="server" Class="form-control" placeholder="Password" TextMode="Password"></asp:TextBox>
        </div>

        <label class="col-xs-11">Confirm Password</label>
        <div class="col-xs-11">
            <asp:TextBox ID="tbCPass" runat="server" Class="form-control" placeholder="Confirm Password" TextMode="Password"></asp:TextBox>
        </div>

        <label class="col-xs-11">Name</label>
        <div class="col-xs-11">
            <asp:TextBox ID="tbName" runat="server" Class="form-control" placeholder="Name"></asp:TextBox>
        </div>

        <label class="col-xs-11">Email</label>
        <div class="col-xs-11">
            <asp:TextBox ID="tbEmail" runat="server" Class="form-control" placeholder="Email" TextMode="Email"></asp:TextBox>
        </div>

        <div class="col-xs-11 space-vert">
            <asp:Button ID="btSignup" runat="server" Class="btn btn-success" Text="Sign Up"  OnClick="btSignup_Click"/>
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
        </div>

    </div>
    <!-- Sign Up -->
</asp:Content>
