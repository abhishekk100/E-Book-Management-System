<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="BookIssuingPage.aspx.cs" Inherits="EBookManagementSystem.BookIssuingPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <script type="text/javascript">
    $(document).ready(function () {

        $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
       
    });
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

     <%-- Container --%>
 
     <div class="container-fluid">
        <div class="row">
         <%-- Left side  --%>
            <div class="col-md-5">
                <%-- card is class used make box container having curve border  --%>
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Book Issuing</h4>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="Images/bookimg.png" style="width: 100px" />
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
                        <%-- Row 1 --%>
                        <div class="row">
                            <%-- col 1--%>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>User ID</label>
                                    <asp:TextBox ID="TextBox2" CssClass="form-control" placeholder="User ID"  runat="server"></asp:TextBox>
                                </div>
                            </div>
                             <%-- col 2 --%>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Book ID</label>
                                    <div class="input-group">
                                    <asp:TextBox ID="TextBox3" CssClass="form-control" placeholder="Book ID" runat="server"></asp:TextBox>
                                            <asp:Button ID="Button1" runat="server" Text="GO" CssClass="btn btn-primary" OnClick="Button1_Click"  />
                                    </div>
                                </div>
                            </div>
                        </div>

                          <%-- Row 2 --%>
                         <div class="row">
                            <%-- col 1--%>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>User Name</label>
                                    <asp:TextBox ID="TextBox1" CssClass="form-control" ReadOnly="true" placeholder="User Name"  runat="server"></asp:TextBox>
                                </div>
                            </div>
                             <%-- col 2 --%>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Book Name</label>
                                    <div class="input-group">
                                    <asp:TextBox ID="TextBox4" CssClass="form-control" ReadOnly="true" placeholder="Book Name" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>

                         <%-- Row 3 --%>
                         <div class="row">
                            <%-- col 1--%>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Start Date</label>
                                    <asp:TextBox ID="TextBox5" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
                                </div>
                            </div>
                             <%-- col 2 --%>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>End Date</label>
                                    <div class="input-group">
                                    <asp:TextBox ID="TextBox6" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <br />
                        <%-- Row 4 --%>
                        <div class="row">
                            <%-- col 1 --%>
                            <div class="col-md-6">
                                 <div class="form-group">
                                    <asp:Button ID="Button2" runat="server" Text="Issue" CssClass="btn btn-primary btn-lg" Width="100%" OnClick="Button2_Click"/>
                                </div>
                            </div>
                            <%-- col 2--%>
                            <div class="col-md-6">
                                 <div class="form-group">
                                    <asp:Button ID="Button3" runat="server" Text="Return" CssClass="btn btn-success btn-lg" Width="100%" OnClick="Button3_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>

              <%-- Right side  --%>
            <div class="col-md-7">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Issue Book List</h4>
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
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString %>" SelectCommand="SELECT * FROM [book_issue_tbl]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView ID="GridView1" class="table table-striped table-bordered" runat="server" AutoGenerateColumns="False" DataKeyNames="user_id" DataSourceID="SqlDataSource1" OnRowDataBound="GridView1_RowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="user_id" HeaderText="User ID" ReadOnly="True" SortExpression="user_id" />
                                        <asp:BoundField DataField="user_name" HeaderText="User Name" SortExpression="user_name" />
                                        <asp:BoundField DataField="book_id" HeaderText="Book ID" SortExpression="book_id" />
                                        <asp:BoundField DataField="book_name" HeaderText="Book Name" SortExpression="book_name" />
                                        <asp:BoundField DataField="issue_date" HeaderText="Issue Date" SortExpression="issue_date" />
                                        <asp:BoundField DataField="due_date" HeaderText="Due Date" SortExpression="due_date" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/HomePage.aspx"><< Back To Home</asp:LinkButton>
            <br />
            <br />
        </div>
    </div>
</asp:Content>
