<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="EBookManagementSystem.UserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <script type="text/javascript">
$(document).ready(function () {

    $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
   
});
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-5">
                <%-- card is class used make box container having curve border  --%>
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="Images/imgs/generaluser.png" style="width: 100px" />
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Your Profile</h4>
                                    <span>Account Status - </span>
                                    <asp:Label ID="Label1" runat="server" class="badge badge-pill" style="background-color: #0d6efd" Text="Label"></asp:Label>
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
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Full Name</label>
                                    <asp:TextBox ID="TextBox3" CssClass="form-control" placeholder="Full Name" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <%-- col 2--%>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Date of Birth</label>
                                    <asp:TextBox ID="TextBox2" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <%-- Row 2 --%>
                        <div class="row">
                            <%-- col 1 --%>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Contact Number</label>
                                    <asp:TextBox ID="TextBox1" CssClass="form-control" placeholder="Contact Number" TextMode="Number" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <%-- col 2--%>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Email ID</label>
                                    <asp:TextBox ID="TextBox4" CssClass="form-control" placeholder="Email ID" TextMode="Email" runat="server"></asp:TextBox>
                                </div>
                            </div>

                        </div>

                        <%-- Row 3 --%>
                        <div class="row">
                            <%-- col 1 --%>
                            <div class="col-md-4">
                                <label>State</label>
                                <div class="form-group">
                                    <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server">
                                        <%-- State List --%>
                                        <asp:ListItem Text="Select" Value="select" />
                                        <asp:ListItem Text="Andhra Pradesh" Value="Andhra Pradesh" />
                                        <asp:ListItem Text="Arunachal Pradesh" Value="Arunachal Pradesh" />
                                        <asp:ListItem Text="Assam" Value="Assam" />
                                        <asp:ListItem Text="Bihar" Value="Bihar" />
                                        <asp:ListItem Text="Chhattisgarh" Value="Chhattisgarh" />
                                        <asp:ListItem Text="Rajasthan" Value="Rajasthan" />
                                        <asp:ListItem Text="Goa" Value="Goa" />
                                        <asp:ListItem Text="Gujarat" Value="Gujarat" />
                                        <asp:ListItem Text="Haryana" Value="Haryana" />
                                        <asp:ListItem Text="Himachal Pradesh" Value="Himachal Pradesh" />
                                        <asp:ListItem Text="Jammu and Kashmir" Value="Jammu and Kashmir" />
                                        <asp:ListItem Text="Jharkhand" Value="Jharkhand" />
                                        <asp:ListItem Text="Karnataka" Value="Karnataka" />
                                        <asp:ListItem Text="Kerala" Value="Kerala" />
                                        <asp:ListItem Text="Madhya Pradesh" Value="Madhya Pradesh" />
                                        <asp:ListItem Text="Maharashtra" Value="Maharashtra" />
                                        <asp:ListItem Text="Manipur" Value="Manipur" />
                                        <asp:ListItem Text="Meghalaya" Value="Meghalaya" />
                                        <asp:ListItem Text="Mizoram" Value="Mizoram" />
                                        <asp:ListItem Text="Nagaland" Value="Nagaland" />
                                        <asp:ListItem Text="Odisha" Value="Odisha" />
                                        <asp:ListItem Text="Punjab" Value="Punjab" />
                                        <asp:ListItem Text="Rajasthan" Value="Rajasthan" />
                                        <asp:ListItem Text="Sikkim" Value="Sikkim" />
                                        <asp:ListItem Text="Tamil Nadu" Value="Tamil Nadu" />
                                        <asp:ListItem Text="Telangana" Value="Telangana" />
                                        <asp:ListItem Text="Tripura" Value="Tripura" />
                                        <asp:ListItem Text="Uttar Pradesh" Value="Uttar Pradesh" />
                                        <asp:ListItem Text="Uttarakhand" Value="Uttarakhand" />
                                        <asp:ListItem Text="West Bengal" Value="West Bengal" />

                                    </asp:DropDownList>
                                </div>
                            </div>
                            <%-- col 2--%>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>City</label>
                                    <asp:TextBox ID="TextBox6" class="form-control" placeholder="City" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <%-- col 3--%>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Pincode</label>
                                    <asp:TextBox ID="TextBox7" CssClass="form-control" placeholder="Pincode" TextMode="Number" runat="server"></asp:TextBox>
                                </div>
                            </div>

                        </div>

                        <%-- Row 4 --%>
                        <div class="row">
                            <%-- col 1 --%>
                            <div class="col">
                                <div class="form-group">
                                    <label>Address</label>
                                    <asp:TextBox ID="TextBox5" CssClass="form-control" placeholder="Address" TextMode="MultiLine" runat="server" Rows="2"></asp:TextBox>
                                </div>
                            </div>

                        </div>
                        <br />
                        <div class="row">
                            <div class="col">
                                <center>
                                    <span class="badge badge-pill" style="background-color: #0d6efd">Login Credentials</span>
                                </center>

                            </div>
                        </div>
                        <%-- Row 5 --%>
                        <div class="row">
                            <%-- col 1 --%>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>User ID</label>
                                    <asp:TextBox ID="TextBox8" CssClass="form-control" ReadOnly="true" placeholder="User ID" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <%-- col 2--%>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Old Password</label>
                                    <asp:TextBox ID="TextBox9" CssClass="form-control" placeholder="Old Password" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <%-- col 1 --%>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>New Password</label>
                                    <asp:TextBox ID="TextBox10" CssClass="form-control" placeholder="New Password" TextMode="Password" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <br />
                        <div class="row">
                            <div class="col-8 mx-auto">
                                <div class="form-group" style="text-align: center">
                                    <asp:Button ID="Button1" runat="server" Text="Update" CssClass="btn btn-primary btn-lg" Width="50%" OnClick="Button1_Click" />
                                </div>
                            </div>
                        </div>

                    </div>
                </div>

            </div>
            <div class="col-md-7">
                <div class="card">
                    <div class="card-body">
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
                                    <h4>Your Issued Books</h4>

                                    <asp:Label ID="Label2" runat="server" class="badge badge-pill" Style="background-color: #0d6efd" Text="Your books info"></asp:Label>
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
                           <%-- <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString %>" SelectCommand="SELECT * FROM [book_issue_tbl]"></asp:SqlDataSource>--%>
                            <div class="col">
                                <asp:GridView ID="GridView1" class="table table-striped table-bordered" runat="server" OnRowDataBound="GridView1_RowDataBound" AutoGenerateColumns="True">
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
