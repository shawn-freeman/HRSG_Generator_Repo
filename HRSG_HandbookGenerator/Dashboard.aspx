<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="HRSG_HandbookGenerator.Dashboard" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="Head" runat="server" >
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
        <script type="text/javascript" >
            function ConfirmDeleteClient(id){
                return confirm('Are you sure you want to delete Client #' + id + " ?");
            }

            //Industry
            function ConfirmDeleteElement(id){
                return confirm('Are you sure you want to delete Element #' + id + " ?");
            }

            function OpenPopup(arg) {
                var popups = ["AddClient", "AddIndustry", "AddSection", "Subsection"];
                var windows = ["", "radwinAddIndustry", "radwinAddSection", "radwinAddSubsection"];

                if (!arg) {
                    alert("Popup ID not specified!");
                    return;
                }

                var oWnd = radopen("Popups/" + popups[arg] +".aspx?", windows[arg]);
            }

            function OnAddIndustryClose(oWnd, args) {
                var arg = args.get_argument();

                if (arg) {
                    var masterTable = window.$find('<%= rgIndustries.ClientID %>').get_masterTableView();
                    masterTable.rebind();
                }
            }

            //Section
            function ConfirmDeleteSection(id) {
                return confirm('Are you sure you want to delete Section #' + id + " ?");
            }

            function OpenAddSection() {
                var oWnd = radopen("Popups/AddSection.aspx?", "radwinAddSection");
            }

            function OpenEditSection(arg) {
                var oWnd = radopen("Popups/EditSection.aspx?ID=" + arg, "radwinEditSection");
                return false;
            }

            function OnAddEditSectionClose(oWnd, args) {
                var arg = args.get_argument();

                if (arg) {
                    var masterTable = window.$find('<%= rgSections.ClientID %>').get_masterTableView();
                    masterTable.rebind();
                }
            }

            //Subsection
            function ConfirmDeleteSubsection(id) {
                return confirm('Are you sure you want to delete Subsection #' + id + " ?");
            }

            function OpenAddSubsection() {
                var oWnd = radopen("Popups/AddSubSection.aspx?", "radwinAddSubsection");
            }

            function OpenEditSubSection(arg) {
                var oWnd = radopen("Popups/EditSubsection.aspx?ID=" + arg, "radwinEditSubsection");
                return false;
            }

            function OnAddEditSubsectionClose(oWnd, args) {
                var arg = args.get_argument();

                if (arg) {
                    var masterTable = window.$find('<%= rgSubsections.ClientID %>').get_masterTableView();
                    masterTable.rebind();
                }
            }
        </script>
    </telerik:RadScriptBlock>
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>

    <div class="row">
        <div class="col-md-8">
            <section id="loginForm">
                <div class="form-horizontal">
                    <telerik:RadTabStrip ID="rtsDashboard" runat="server" MultiPageID="rmpMain" EnableEmbeddedSkins="False" Style="position: relative; z-index: 1000" SelectedIndex="0">
                        <Tabs>
                            <telerik:RadTab Text="Clients" Selected="true" />
                            <telerik:RadTab Text="Industries" />
                            <telerik:RadTab Text="Sections" />
                            <telerik:RadTab Text="Subsections" />
                        </Tabs>
                    </telerik:RadTabStrip>

                    <telerik:RadMultiPage ID="rmpMain" runat="server" BorderColor="#454545" BorderStyle="Solid" BorderWidth="1px" SelectedIndex="0" Width="975px" >
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
                                <telerik:RadGrid ID="rgClients" runat="server" GridLines="None" AutoGenerateColumns="false" AllowPaging="true" PageSize="25" AllowSorting="False"
                                    OnNeedDataSource="rgClients_OnNeedDataSource" OnItemCommand="rgClients_OnItemCommand">
                                    <MasterTableView NoMasterRecordsText="No records exist.">
                                        <Columns>
                                            <telerik:GridBoundColumn HeaderText="ID" UniqueName="ID" DataField="ID" />

                                            <telerik:GridBoundColumn HeaderText="Modified" UniqueName="Modified" DataField="Modified" DataFormatString="{0:MM/dd/yy}"/>
                                            
                                            <telerik:GridBoundColumn HeaderText="Name" UniqueName="Name" DataField="Name" />

                                            <telerik:GridBoundColumn HeaderText="Industry Name" UniqueName="IndustryName" DataField="IndustryName" />

                                            <telerik:GridBoundColumn HeaderText="Company Size" UniqueName="EmployeeRange" DataField="EmployeeRange"/>
                                        
                                            <telerik:GridTemplateColumn HeaderText="Actions" HeaderStyle-Width="10%">
                                                <ItemTemplate>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:LinkButton ID="Edit" runat="server" CommandName="Edit" ToolTip="Edit" CommandArgument='<%# Eval("ID") %>' PostBackUrl="~/Default.aspx" Text="Edit"></asp:LinkButton>
                                                            </td>
                                                            <td>
                                                                <asp:LinkButton ID="DeleteLink" runat="server" CommandName="Delete" ToolTip="Delete" CommandArgument='<%# Eval("ID") %>' OnClientClick='<%# "return ConfirmDeleteClient(" + Eval("ID") + ")" %>' Text="Delete" ></asp:LinkButton>
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
                        
                        <telerik:RadPageView runat="server" ID="rpvIndustries">
                        <div style="background-color: #edeef2; width: 100%;min-height:550px;">
                        <div style="padding-top: 20px;padding-left: 20px; padding-right: 20px;">
                            <div style="padding-bottom: 15px">
                                <span class="sectionHeader"><h3>Industries</h3></span>
                        
                                <span style="padding-right: 10px;float:right; vertical-align:top">
                                    <span style="padding-right: 10px">&nbsp;</span>
                                    <asp:button CssClass="button-wide button-orange" id="btnAddIndustry" Text="Add Industry" runat="server" OnClientClick="OpenPopup(1);return false;" />
                                </span><br />

                                <div style="padding-top: 20px;padding-right: 10px;padding-bottom: 20px;vertical-align:top">
                                    <div style="float:left">
                                        You can add and remove Industries below
                                    </div>
                                </div>
                            </div>

                            <div style="padding-right: 10px;padding-bottom: 10px;">
                                <telerik:RadGrid ID="rgIndustries" runat="server" GridLines="None" AutoGenerateColumns="false" AllowPaging="true" PageSize="25" AllowSorting="False"
                                    OnNeedDataSource="rgIndustries_OnNeedDataSource" OnItemCommand="rgIndustries_OnItemCommand">
                                    <MasterTableView NoMasterRecordsText="No records exist.">
                                        <Columns>
                                            <telerik:GridBoundColumn HeaderText="ID" UniqueName="ID" DataField="ID" />

                                            <telerik:GridBoundColumn HeaderText="Modified" UniqueName="Modified" DataField="Modified" DataFormatString="{0:MM/dd/yy}"/>

                                            <telerik:GridBoundColumn HeaderText="Name" UniqueName="Name" DataField="Name" />
                                        
                                            <telerik:GridTemplateColumn HeaderText="Actions" HeaderStyle-Width="10%">
                                                <ItemTemplate>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:LinkButton ID="Edit" runat="server" CommandName="Edit" ToolTip="Edit" CommandArgument='<%# Eval("ID") %>' PostBackUrl="~/Default.aspx" Text="Edit"></asp:LinkButton>
                                                            </td>
                                                            <td>
                                                                <asp:LinkButton ID="DeleteLink" runat="server" CommandName="Delete" ToolTip="Delete" CommandArgument='<%# Eval("ID") %>' OnClientClick='<%# "return ConfirmDeleteElement(" + Eval("ID") + ")" %>' Text="Delete" ></asp:LinkButton>
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
                        
                        <telerik:RadPageView runat="server" ID="rpvSections">
                        <div style="background-color: #edeef2; width: 100%;min-height:550px;">
                        <div style="padding-top: 20px;padding-left: 20px; padding-right: 20px;">
                            <div style="padding-bottom: 15px">
                                <span class="sectionHeader"><h3>Sections</h3></span>
                        
                                <span style="padding-right: 10px;float:right; vertical-align:top">
                                    <span style="padding-right: 10px">&nbsp;</span>
                                    <asp:button CssClass="button-wide button-orange" id="btnAddSection" Text="Add Section" runat="server" OnClientClick="OpenAddSection();return false;" />
                                </span><br />

                                <div style="padding-top: 20px;padding-right: 10px;padding-bottom: 20px;vertical-align:top">
                                    <div style="float:left">
                                        You can add and remove Sections below
                                    </div>
                                </div>
                            </div>

                            <div style="padding-right: 10px;padding-bottom: 10px;">
                                <telerik:RadGrid ID="rgSections" runat="server" GridLines="None" AutoGenerateColumns="false" AllowPaging="true" PageSize="25" AllowSorting="False"
                                    OnNeedDataSource="rgSections_OnNeedDataSource" OnItemCommand="rgSections_OnItemCommand">
                                    <MasterTableView NoMasterRecordsText="No records exist.">
                                        <Columns>
                                            <telerik:GridBoundColumn HeaderText="ID" UniqueName="ID" DataField="ID" HeaderStyle-Width="5%" ItemStyle-Width="5%" />

                                            <telerik:GridBoundColumn HeaderText="Modified" UniqueName="Modified" DataField="Modified" DataFormatString="{0:MM/dd/yy}" HeaderStyle-Width="10%" ItemStyle-Width="10%" />
                                            
                                            <telerik:GridBoundColumn HeaderText="Description" UniqueName="Description" DataField="Description" HeaderStyle-Width="15%" ItemStyle-Width="15%" />

                                            <telerik:GridBoundColumn HeaderText="Value" UniqueName="Value" DataField="Value" HeaderStyle-Width="60%" ItemStyle-Width="60%" />
                                        
                                            <telerik:GridTemplateColumn HeaderText="Actions" HeaderStyle-Width="10%" ItemStyle-Width="10%">
                                                <ItemTemplate>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:LinkButton ID="Edit" runat="server" ToolTip="Edit" OnClientClick='<%# "return OpenEditSection(" + Eval("ID") + ")" %>' Text="Edit"></asp:LinkButton>
                                                            </td>
                                                            <td>
                                                                <asp:LinkButton ID="DeleteLink" runat="server" CommandName="Delete" ToolTip="Delete" CommandArgument='<%# Eval("ID") %>' OnClientClick='<%# "return ConfirmDeleteSection(" + Eval("ID") + ")" %>' Text="Delete" ></asp:LinkButton>
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
                        
                        <telerik:RadPageView runat="server" ID="rpvSubsections">
                        <div style="background-color: #edeef2; width: 100%;min-height:550px;">
                        <div style="padding-top: 20px;padding-left: 20px; padding-right: 20px;">
                            <div style="padding-bottom: 15px">
                                <span class="sectionHeader"><h3>Subsections</h3></span>
                        
                                <span style="padding-right: 10px;float:right; vertical-align:top">
                                    <span style="padding-right: 10px">&nbsp;</span>
                                    <asp:button CssClass="button-wide button-orange" id="btnAddSubSection" Text="Add Subsection" runat="server" OnClientClick="OpenAddSubsection();return false;" />
                                </span><br />

                                <div style="padding-top: 20px;padding-right: 10px;padding-bottom: 20px;vertical-align:top">
                                    <div style="float:left">
                                        You can add and remove Subsections below
                                    </div>
                                </div>
                            </div>

                            <div style="padding-right: 10px;padding-bottom: 10px;">
                                <telerik:RadGrid ID="rgSubsections" runat="server" GridLines="None" AutoGenerateColumns="false" AllowPaging="true" PageSize="25" AllowSorting="False"
                                    OnNeedDataSource="rgSubsections_OnNeedDataSource" OnItemCommand="rgSubsections_OnItemCommand">
                                    <MasterTableView NoMasterRecordsText="No records exist.">
                                        <Columns>
                                            <telerik:GridBoundColumn HeaderText="ID" UniqueName="ID" DataField="ID" HeaderStyle-Width="5%" ItemStyle-Width="5%" />

                                            <telerik:GridBoundColumn HeaderText="Modified" UniqueName="Modified" DataField="Modified" DataFormatString="{0:MM/dd/yy}" HeaderStyle-Width="10%" ItemStyle-Width="10%" />
                                            
                                            <telerik:GridBoundColumn HeaderText="Description" UniqueName="Description" DataField="Description" HeaderStyle-Width="15%" ItemStyle-Width="15%" />

                                            <telerik:GridBoundColumn HeaderText="Value" UniqueName="Value" DataField="Value" HeaderStyle-Width="60%" ItemStyle-Width="60%" />
                                        
                                            <telerik:GridTemplateColumn HeaderText="Actions" HeaderStyle-Width="10%" ItemStyle-Width="10%" >
                                                <ItemTemplate>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:LinkButton ID="Edit" runat="server" ToolTip="Edit" OnClientClick='<%# "return OpenEditSubSection(" + Eval("ID") + ")" %>' Text="Edit"></asp:LinkButton>
                                                            </td>
                                                            <td>
                                                                <asp:LinkButton ID="DeleteLink" runat="server" CommandName="Delete" ToolTip="Delete" CommandArgument='<%# Eval("ID") %>' OnClientClick='<%# "return ConfirmDeleteSubsection(" + Eval("ID") + ")" %>' Text="Delete" ></asp:LinkButton>
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
                    
            <telerik:RadWindowManager runat="server" ShowContentDuringLoad="False" VisibleStatusbar="False" Modal="True" ReloadOnShow="True" >
                <Windows>
                    <telerik:RadWindow runat="server" ID="radwinAddSubsection" Width="960" Height="640" Behaviors="Close"
                        OnClientClose="OnAddEditSubsectionClose" NavigateUrl="~/Popups/AddSubsection.aspx" />
                    <telerik:RadWindow runat="server" ID="radwinEditSubsection" Width="960" Height="640" Behaviors="Close"
                        OnClientClose="OnAddEditSubsectionClose" NavigateUrl="~/Popups/EditSubsection.aspx" />
                    
                    <telerik:RadWindow runat="server" ID="radwinAddSection" Width="960" Height="640" Behaviors="Close"
                        OnClientClose="OnAddEditSectionClose" NavigateUrl="~/Popups/AddSection.aspx" />
                    <telerik:RadWindow runat="server" ID="radwinEditSection" Width="960" Height="640" Behaviors="Close"
                        OnClientClose="OnAddEditSectionClose" NavigateUrl="~/Popups/EditSection.aspx" />
                    
                    <telerik:RadWindow runat="server" ID="radwinAddIndustry" Width="480" Height="240" Behaviors="Close"
                        OnClientClose="OnAddIndustryClose" NavigateUrl="~/Popups/AddIndustry.aspx" />
                </Windows>
            </telerik:RadWindowManager>

            </div>
            </section>
        </div>
        </div>
</asp:Content>
