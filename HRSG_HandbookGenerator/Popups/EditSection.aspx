<%@ Page Title="Edit Section" Language="C#" MasterPageFile="~/Popup.Master" AutoEventWireup="true" CodeBehind="EditSection.aspx.cs" Inherits="HRSG_HandbookGenerator.Popups.EditSection" %>
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
            <h2>Edit Section</h2>
        </div>
        
        <table>
            <tr>
                <td>
                    <asp:Label runat="server" Font-Size="12pt" Text="Section Name: " ></asp:Label>
                </td>
                <td>
                    <telerik:RadTextBox runat="server" ID="txtbxSectionName" Width="250px" Font-Size="12pt" TextMode="SingleLine"></telerik:RadTextBox>
                </td>
            </tr>
         </table>

        <div style="margin: 10px 0px 0px 0px;" >
            <asp:Label runat="server" Font-Size="12pt" Text="Enter the Subsection content in the box below: " ></asp:Label>
            <telerik:RadTextBox runat="server" ID="txtbxSectionValue" Width="100%" Height="380px" Font-Size="12pt" TextMode="MultiLine" ></telerik:RadTextBox>
        </div>
        
        <table style="margin-top: 20px; width: 100%" >
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
