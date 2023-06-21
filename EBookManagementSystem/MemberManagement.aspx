<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MemberManagement.aspx.cs" Inherits="EBookManagementSystem.MemberManagement" %>

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
                        
                       <%-- Title --%>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Member Details</h4>
                                </center>
                            </div>
                        </div>
                        <%-- Image --%>
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
                                    <hr />
                                </center>
                            </div>
                        </div>

                        <%-- Details --%>
                        <%-- Row 1 --%>
                        <div class="row">
                             <%-- col 1 --%>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>User ID</label>
                                    <div class="input-group">
                                        <asp:TextBox ID="TextBox3" CssClass="form-control" placeholder= " User ID" runat="server"></asp:TextBox>
                                                 <asp:LinkButton ID="LinkButton5" runat="server" OnClick="LinkButton5_Click" CssClass="btn btn-success" ><i class="fa-solid fa-circle-check"></i></asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                            <%-- col 2--%>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>User Name</label>
                                    <asp:TextBox ID="TextBox2" CssClass="form-control" ReadOnly="true" placeholder="User Name" runat="server"></asp:TextBox>
                                </div>
                            </div>
                             <%-- col 3--%>
                            <div class="col-md-5">
                                <div class="form-group">
                                    <label>Account Status</label>
                                    <div class="input-group">
                                        <asp:TextBox ID="TextBox8" ReadOnly="true" CssClass="form-control" placeholder="Status" runat="server"></asp:TextBox>

                                        <asp:LinkButton ID="LinkButton2" runat="server"  CssClass="btn btn-success" OnClick="LinkButton2_Click" ><i class="fa-solid fa-circle-check"></i></asp:LinkButton>

                                          <asp:LinkButton ID="LinkButton3" runat="server" CssClass="btn btn-warning" OnClick="LinkButton3_Click" ><i class="fa-solid fa-pause"></i></asp:LinkButton>

                                          <asp:LinkButton ID="LinkButton4" runat="server"  CssClass="btn btn-danger" OnClick="LinkButton4_Click"><i class="fa-sharp fa-solid fa-circle-xmark"></i></asp:LinkButton>
                                    </div>
                                    </div>
                                </div>
                             </div>
                            </div>
                        
                        </div>

                        <%-- Row 2 --%>
                        <div class="row">
                            <%-- col 1--%>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>DOB</label>
                                    <asp:TextBox ID="TextBox1" CssClass="form-control" placeholder="DOB" ReadOnly="true" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <%-- col 2 --%>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Contact</label>
                                    <div class="input-group">
                                        <asp:TextBox ID="TextBox4" CssClass="form-control" ReadOnly="true" TextMode="Number" placeholder="Contact" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                             <%-- col 3 --%>
                            <div class="col-md-5">
                                <div class="form-group">
                                    <label>Email ID</label>
                                    <div class="input-group">
                                        <asp:TextBox ID="TextBox7" CssClass="form-control" ReadOnly="true" TextMode="Email" placeholder="Email ID" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <%-- Row 2 --%>
                        <div class="row">
                            <%-- col 1--%>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>State</label>
                                    <asp:TextBox ID="TextBox5" CssClass="form-control" placeholder="State" ReadOnly="true" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <%-- col 2 --%>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>City</label>
                                    <div class="input-group">
                                        <asp:TextBox ID="TextBox6" CssClass="form-control" ReadOnly="true" placeholder="City" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                             <%-- col 3 --%>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>Pincode</label>
                                    <div class="input-group">
                                        <asp:TextBox ID="TextBox9" CssClass="form-control" ReadOnly="true" TextMode="Number" placeholder="Pincode" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <%-- Row 4 --%>
                        <div class="row">
                            <%-- col 1 --%>
                            <div class="col-12">
                                 <div class="form-group">
                                    <label>Address</label>
                                    <asp:TextBox ID="TextBox10" CssClass="form-control" ReadOnly="true" placeholder="Address" TextMode="MultiLine" runat="server" Rows="2"></asp:TextBox>
                                </div>
                            </div>
                          
                        </div>
                        <%-- Row 5 --%>
                        <div class="row">
                            <%-- col 1 --%>
                            <div class="col-8 mx-auto">
                                <div class="form-group">
                                    <asp:Button ID="Button2" runat="server" Text="Delete User Permanently" CssClass="btn btn-danger btn-lg" Width="100%" OnClick="Button2_Click" />
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
                                    <h4>User List</h4>
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
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString %>" SelectCommand="SELECT * FROM [user_master_tbl]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView ID="GridView1" class="table table-striped table-bordered" runat="server" AutoGenerateColumns="False" DataKeyNames="user_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="user_id" HeaderText="User ID" SortExpression="user_id" ReadOnly="True" />
                                        <asp:BoundField DataField="full_name" HeaderText="Name" SortExpression="full_name" />
                                        <asp:BoundField DataField="account_status" HeaderText="Account Status" SortExpression="account_status" />
                                        <asp:BoundField DataField="contact_no" HeaderText="Contact" SortExpression="contact_no" />
                                        <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" />
                                        <asp:BoundField DataField="state" HeaderText="State" SortExpression="state" />
                                        <asp:BoundField DataField="city" HeaderText="City" SortExpression="city" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

                </div>

            </div>

          
            <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/HomePage.aspx"><< Back To Home</asp:LinkButton>
            <br />
            <br />
</asp:Content>
