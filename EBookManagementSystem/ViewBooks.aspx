<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ViewBooks.aspx.cs" Inherits="EBookManagementSystem.ViewBooks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
 
     </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <div class="container">
        <div class="row">
            <div class="card">
                <div class="card-body">
                    <div class="row">
                        <div class="col">
                            <center>
                                <h4>Book Inventory List</h4>
                            </center>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col">
                            <center>
                                <hr />
                            </center>
                        </div>
                    </div>
                    <div class="row">
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString %>" SelectCommand="SELECT * FROM [book_master_tbl]"></asp:SqlDataSource>
                        <div class="col">
                            <asp:GridView ID="GridView1" class="table table-striped table-bordered" runat="server" AutoGenerateColumns="False" DataKeyNames="book_id" DataSourceID="SqlDataSource1">
                                <Columns>
                                    <asp:BoundField DataField="book_id" HeaderText="ID" ReadOnly="True" SortExpression="book_id">
                                        <ItemStyle Font-Bold="True" />
                                    </asp:BoundField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <div class="container-fluid">
                                                <div class="row">
                                                    <%-- book description --%>
                                                    <div class="col-lg-10">
                                                        <%-- it will go above if screen minimize --%>
                                                        <div class="row">
                                                            <div class="col-12">
                                                                <asp:Label ID="Label1" Font-Bold="true" Font-Size="X-Large" runat="server" Text='<%# Eval("book_name") %>'></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-12">
                                                                Author -
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Text='<%# Eval("author_name") %>' Font-Size="Small"></asp:Label>
                                                                &nbsp;| Genre -
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Text='<%# Eval("genre") %>' Font-Size="Small"></asp:Label>
                                                                &nbsp;| Language -
                <asp:Label ID="Label4" runat="server" Font-Bold="True" Text='<%# Eval("language") %>' Font-Size="Small"></asp:Label>

                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-12">
                                                                Publisher -
                <asp:Label ID="Label5" runat="server" Font-Bold="True" Text='<%# Eval("publisher_name") %>' Font-Size="Small"></asp:Label>
                                                                &nbsp;| Publisher Date -
                <asp:Label ID="Label6" runat="server" Font-Bold="True" Text='<%# Eval("publish_date") %>' Font-Size="Small"></asp:Label>
                                                                &nbsp;| Pages -
                <asp:Label ID="Label7" runat="server" Font-Bold="True" Text='<%# Eval("no_of_pages") %>' Font-Size="Small"></asp:Label>
                                                                &nbsp;| Edition -
                <asp:Label ID="Label8" runat="server" Font-Bold="True" Text='<%# Eval("edition") %>' Font-Size="Small"></asp:Label>

                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-12">
                                                                Cost -
                <asp:Label ID="Label9" runat="server" Font-Bold="True" Text='<%# Eval("book_cost") %>' Font-Size="Small"></asp:Label>
                                                                &nbsp;| Actual Stock -
                <asp:Label ID="Label10" runat="server" Font-Bold="True" Text='<%# Eval("actual_stock") %>' Font-Size="Small"></asp:Label>
                                                                &nbsp;| Available Stock -
                <asp:Label ID="Label11" runat="server" Font-Bold="True" Text='<%# Eval("current_stock") %>' Font-Size="Small"></asp:Label>

                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-12">
                                                                Description -
                <asp:Label ID="Label12" runat="server" Font-Bold="True" Text='<%# Eval("book_description") %>' Font-Italic="True" Font-Size="Smaller"></asp:Label>

                                                            </div>
                                                        </div>
                                                    </div>
                                                    <%-- for book img --%>
                                                    <div class="col-lg-2">
                                                        <%-- it will go down if screen minimize --%>

                                                        <asp:Image ID="Image1" CssClass="img-fluid p-2" runat="server" ImageUrl='<%# Eval("book_img_link") %>' />
                                                    </div>

                                                </div>

                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
