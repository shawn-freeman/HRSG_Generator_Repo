<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HRSG_HandbookGenerator.Login" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="divLoginHeader">
        <h1>LOGIN PAGE</h1>
    </div>
    
    <div>
        <asp:Button runat="server" OnClick="OnClick" Text="Click to Generate Document."/>
    </div>
</asp:Content>
