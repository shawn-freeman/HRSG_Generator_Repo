<%@ Page Title="Add Industry" Language="C#" MasterPageFile="~/Popup.Master" AutoEventWireup="true" CodeBehind="AddIndustry.aspx.cs" Inherits="HRSG_HandbookGenerator.Popups.AddIndustry" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="Head" runat="server">
    <script type="text/javascript">
        function GetRadWindow() {
            var oWindow = null;
            if (window.radWindow) oWindow = window.radWindow;
            else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
            return oWindow;
        }

        function Close() {
            GetRadWindow().close();
        }


        function CloseAndSave() {
            GetRadWindow().close(1);
        }
    </script>
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="Main" runat="server">
    <div style="margin: 20px 20px 20px 20px;">
        <div style="margin: 0px 0px 10px 0px">
            <h2>Add Industry</h2>
        </div>
        
        <table>
            <tr>
                <td>
                    <asp:Label runat="server" Font-Size="12pt" Text="Industry Name: " ></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox runat="server" ID="txtbxIndustryName" Width="250px" Font-Size="12pt" TextMode="SingleLine"></telerik:RadTextBox>
                </td>
            </tr>
         </table>

        <table style="margin-top: 20px; width: 100%; vertical-align: bottom" >
            <tr>
                <td align="center">
                    <asp:Button runat="server" ID="btnSave" Width="100px" Font-Size="12pt" Text="SAVE" OnClick="btnSave_OnClick" />
                </td>
                <td align="center" >
                    <asp:Button runat="server" ID="btnCancel" Width="100px" Font-Size="12pt" Text="CANCEL" OnClientClick="Close(); return false;" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
