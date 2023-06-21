<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AuthorPage.aspx.cs" Inherits="EBookManagementSystem.AuthorPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

   <script type="text/javascript">
       $(document).ready(function () {

           $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
          
       });
   </script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <%-- Container --%>
     <div class="container">
        <div class="row">
         <%-- Left side  --%>
            <div class="col-md-5">
                <%-- card is class used make box container having curve border  --%>
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Author Details</h4>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="Images/imgs/writer.png" style="width: 100px" />
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
                            <%-- col 1 --%>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Author Id</label>
                                    <div class="input-group">

                                    <asp:TextBox ID="TextBox3" CssClass="form-control" placeholder="ID" runat="server"></asp:TextBox>
                                            <asp:Button ID="Button1" runat="server" Text="GO" CssClass="btn btn-primary" OnClick="Button1_Click"  />
                                    </div>
                                </div>
                            </div>
                            <%-- col 2--%>
                            <div class="col-md-8">
                                <div class="form-group">
                                    <label>Author Name</label>
                                    <asp:TextBox ID="TextBox2" CssClass="form-control" placeholder="Author Name"  runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <br />
                        <%-- Row 2 --%>
                        <div class="row">
                            <%-- col 1 --%>
                            <div class="col-md-4">
                                 <div class="form-group">
                                    <asp:Button ID="Button2" runat="server" Text="Add" CssClass="btn btn-success btn-lg" OnClick="Button2_Click" />
                                </div>
                            </div>
                            <%-- col 2--%>
                            <div class="col-md-4">
                                 <div class="form-group">
                                    <asp:Button ID="Button3" runat="server" Text="Update" CssClass="btn btn-primary btn-lg" OnClick="Button3_Click" />
                                </div>
                            </div>
                            <%-- col 3 --%>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Button ID="Button4" runat="server" Text="Delete" CssClass="btn btn-danger btn-lg" OnClick="Button4_Click" />
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
                                    <h4>Author List</h4>
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
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString %>" ProviderName="<%$ ConnectionStrings:elibraryDBConnectionString.ProviderName %>" SelectCommand="SELECT * FROM [author_master_tbl]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView ID="GridView1" class="table table-striped table-bordered" runat="server" AutoGenerateColumns="False" DataKeyNames="author_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="author_id" HeaderText="author_id" ReadOnly="True" SortExpression="author_id" />
                                        <asp:BoundField DataField="author_name" HeaderText="author_name" SortExpression="author_name" />
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
