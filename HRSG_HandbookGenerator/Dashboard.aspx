<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="HRSG_HandbookGenerator.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>

    <div class="row">
        <div class="col-md-8">
            <section id="loginForm">
                <div class="form-horizontal">
                    <telerik:RadMultiPage runat="server" BorderColor="#454545" BorderStyle="Solid" BorderWidth="1px" SelectedIndex="0" Width="975px" >
                        <telerik:RadPageView runat="server" ID="rpvClients">
                        <div style="background-color: #edeef2; width: 100%;min-height:550px;">
                        <div style="padding-top: 20px;padding-left: 20px; padding-right: 20px;">
                            <div style="padding-bottom: 15px">
                                <span class="sectionHeader"><h3>Clients</h3></span>
                        
                                <span style="padding-right: 10px;float:right; vertical-align:top">
                                    <span style="padding-right: 10px">&nbsp;</span>
                                    <asp:button CssClass="button-wide button-orange" id="btnAddClient" Text="Add Client" runat="server" />
                                </span><br />

                                <div style="padding-top: 20px;padding-right: 10px;padding-bottom: 20px;vertical-align:top">
                                    <div style="float:left">
                                        You can add and remove Clients below
                                    </div>
                                </div>
                            </div>

                            <div style="padding-right: 10px;padding-bottom: 10px;">
                                <telerik:RadGrid ID="rgClients" runat="server" GridLines="None" AutoGenerateColumns="false" AllowPaging="true" PageSize="25" AllowSorting="False">
                                    <MasterTableView NoMasterRecordsText="No records exist.">
                                        <Columns>
                                            <telerik:GridBoundColumn HeaderText="ID" UniqueName="ID" DataField="ID" />
                                            <telerik:GridBoundColumn HeaderText="Name" UniqueName="Name" DataField="Name" />

                                            <telerik:GridBoundColumn HeaderText="Modified" UniqueName="Modified" DataField="Modified" DataFormatString="{0:MM/dd/yy}"/>

                                            <telerik:GridBoundColumn HeaderText="Industry" UniqueName="Industry" DataField="Industry" />

                                            <telerik:GridBoundColumn HeaderText="Company Size" UniqueName="EmployeeSize" DataField="EmployeeSize"/>
                                        
                                            <telerik:GridTemplateColumn HeaderText="Actions" HeaderStyle-Width="10%">
                                                <ItemTemplate>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:LinkButton ID="Edit" runat="server" CommandName="Edit" ToolTip="Edit" PostBackUrl="~/Default.aspx" Text="Edit"></asp:LinkButton>
                                                            </td>
                                                            <td>
                                                                <asp:LinkButton ID="DeleteLink" runat="server" CommandName="Delete" ToolTip="Delete" CommandArgument='<%# Eval("ID") %>' Text="Delete" ></asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                    </table>                       
                                                </ItemTemplate>
                                                <ItemStyle Width="50px" />
                                            </telerik:GridTemplateColumn>                                      
                                        </Columns>
                                    </MasterTableView>
                                </telerik:RadGrid>
                            </div>
                        </div>
                    </div>
                </telerik:RadPageView>
            </telerik:RadMultiPage>

            </div>
            </section>
        </div>
        </div>
</asp:Content>
