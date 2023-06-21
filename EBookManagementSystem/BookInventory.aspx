<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="BookInventory.aspx.cs" Inherits="EBookManagementSystem.BookInventory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });

        //to change book img url  
        function readURL(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    //we setting attribute 'src' for id #imgview  
                    $('#imgview').attr('src', e.target.result);
                };

                reader.readAsDataURL(input.files[0]);//sets new url  
            }
        }

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
                                    <h4>Books Details</h4>
                                </center>
                            </div>
                        </div>
                        <%-- Image --%>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img id="imgview" src="Images/bookimg.png" style="width: 100px" />
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
                            <div class="col">
                                <center>
                                    <asp:FileUpload ID="FileUpload1" OnChange="readURL(this);" class="form-control" runat="server" />
                                </center>
                            </div>
                        </div>

                        <%-- Details --%>
                        <%-- Row 1 --%>
                        <div class="row">
                            <%-- col 1 --%>
                            <div class="col-md-4">
                                <label>Book ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="TextBox3" CssClass="form-control" placeholder="Book ID" runat="server"></asp:TextBox>
                                        <asp:Button ID="Button1" runat="server" class="btn btn-primary form-control" Text="GO" OnClick="Button1_Click" />
                                        <%--<asp:LinkButton ID="LinkButton5" runat="server" CssClass="btn btn-success" OnClick="LinkButton5_Click"><i class="fa-solid fa-circle-check"></i></asp:LinkButton>
                                        --%>
                                    </div>
                                </div>
                            </div>
                            <%-- col 2--%>
                            <div class="col-md-8">
                                <label>Book Name</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox2" CssClass="form-control" placeholder="Book Name" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>

                    <%-- Row 2 --%>
                    <div class="row">
                        <%-- col 1--%>
                        <div class="col-md-4">
                            <label>Language</label>
                            <div class="form-group">
                                <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                                    <asp:ListItem Text="English" Value="English" />
                                    <asp:ListItem Text="Hindi" Value="Hindi" />
                                    <asp:ListItem Text="Marathi" Value="Marathi" />
                                    <asp:ListItem Text="French" Value="French" />
                                    <asp:ListItem Text="German" Value="German" />
                                    <asp:ListItem Text="Urdu" Value="Urdu" />
                                </asp:DropDownList>
                            </div>
                            <label>Publisher Name</label>
                            <div class="form-group">
                                <asp:DropDownList class="form-control" ID="DropDownList2" runat="server">
                                    <asp:ListItem Text="Publisher 1" Value="Publisher 1" />
                                    <asp:ListItem Text="Publisher 2" Value="Publisher 2" />

                                </asp:DropDownList>
                            </div>
                        </div>
                        <%-- col 2 --%>
                        <div class="col-md-4">
                            <label>Author Name</label>
                            <div class="form-group">
                                <asp:DropDownList class="form-control" ID="DropDownList3" runat="server">
                                    <asp:ListItem Text="Publisher 1" Value="Author 1" />
                                    <asp:ListItem Text="Publisher 2" Value="Author 2" />

                                </asp:DropDownList>
                            </div>
                            <label>Publish Date</label>
                            <div class="form-group">
                                <div class="input-group">
                                    <asp:TextBox ID="TextBox1" CssClass="form-control" TextMode="Date" placeholder="Date" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <%-- col 3 --%>
                        <div class="col-md-4">
                            <label>Genre</label>
                            <div class="form-group">
                                <asp:ListBox CssClass="form-control" ID="ListBox1" runat="server" SelectionMode="Multiple" Rows="5">
                                    <asp:ListItem Text="Action" Value="Action" />
                                    <asp:ListItem Text="Adventure" Value="Adventure" />
                                    <asp:ListItem Text="Comic Book" Value="Comic Book" />
                                    <asp:ListItem Text="Self Help" Value="Self Help" />
                                    <asp:ListItem Text="Motivation" Value="Motivation" />
                                    <asp:ListItem Text="Healthy Living" Value="Healthy Living" />
                                    <asp:ListItem Text="Wellness" Value="Wellness" />
                                    <asp:ListItem Text="Crime" Value="Crime" />
                                    <asp:ListItem Text="Drama" Value="Drama" />
                                    <asp:ListItem Text="Fantasy" Value="Fantasy" />
                                    <asp:ListItem Text="Horror" Value="Horror" />
                                    <asp:ListItem Text="Poetry" Value="Poetry" />
                                    <asp:ListItem Text="Personal Development" Value="Personal Development" />
                                    <asp:ListItem Text="Romance" Value="Romance" />
                                    <asp:ListItem Text="Science Fiction" Value="Science Fiction" />
                                    <asp:ListItem Text="Suspense" Value="Suspense" />
                                    <asp:ListItem Text="Thriller" Value="Thriller" />
                                    <asp:ListItem Text="Art" Value="Art" />
                                    <asp:ListItem Text="Autobiography" Value="Autobiography" />
                                    <asp:ListItem Text="Encyclopedia" Value="Encyclopedia" />
                                    <asp:ListItem Text="Health" Value="Health" />
                                    <asp:ListItem Text="History" Value="History" />
                                    <asp:ListItem Text="Math" Value="Math" />
                                    <asp:ListItem Text="Textbook" Value="Textbook" />
                                    <asp:ListItem Text="Science" Value="Science" />
                                    <asp:ListItem Text="Travel" Value="Travel" />
                                </asp:ListBox>
                            </div>
                        </div>
                    </div>


                    <%-- Row 4 --%>
                    <div class="row">
                        <%-- col 1 --%>
                        <div class="col-4">
                            <label>Edition</label>
                            <div class="form-group">
                                <asp:TextBox ID="TextBox10" CssClass="form-control" placeholder="Edition" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <%-- col 2 --%>
                        <div class="col-4">
                            <label>Book Cost(per unit)</label>
                            <div class="form-group">
                                <asp:TextBox ID="TextBox5" TextMode="Number" CssClass="form-control" placeholder="Book Cost" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <%-- col 3 --%>
                        <div class="col-4">
                            <label>Pages</label>
                            <div class="form-group">
                                <asp:TextBox ID="TextBox6" CssClass="form-control" TextMode="Number" placeholder="Pages" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <%-- Row 5 --%>
                    <div class="row">
                        <%-- col 1 --%>
                        <div class="col-4">
                            <label>Actual Stocks</label>
                            <div class="form-group">
                                <asp:TextBox ID="TextBox7" CssClass="form-control" TextMode="Number" placeholder="Actual Stocks" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <%-- col 2 --%>
                        <div class="col-4">
                            <label>Current Stocks</label>
                            <div class="form-group">
                                <asp:TextBox ID="TextBox8" TextMode="Number" ReadOnly="true" CssClass="form-control" placeholder="Current Stocks" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <%-- col 3 --%>
                        <div class="col-4">
                            <label>Issued Books</label>
                            <div class="form-group">
                                <asp:TextBox ID="TextBox9" CssClass="form-control" TextMode="Number" ReadOnly="true" placeholder="Issued Books" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <%-- Row 6 --%>
                    <div class="row">
                        <%-- col 1 --%>
                        <div class="col-12">
                            <label>Book Description</label>
                            <div class="form-group">
                                <asp:TextBox ID="TextBox4" CssClass="form-control" placeholder="Description" TextMode="MultiLine" runat="server" Rows="2"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <br />
                    <%-- Row 7 --%>
                    <div class="row">
                        <%-- col 1 --%>
                        <div class="col-md-4">
                            <div class="form-group">
                                <asp:Button ID="Button2" runat="server" Text="Add" CssClass="btn btn-success btn-lg" Width="100%" OnClick="Button2_Click" />
                            </div>
                        </div>
                        <%-- col 2--%>
                        <div class="col-md-4">
                            <div class="form-group">
                                <asp:Button ID="Button3" runat="server" Text="Update" CssClass="btn btn-primary btn-lg" Width="100%" OnClick="Button3_Click" />
                            </div>
                        </div>
                        <%-- col 3 --%>
                        <div class="col-md-4">
                            <div class="form-group">
                                <asp:Button ID="Button4" runat="server" Text="Delete" CssClass="btn btn-danger btn-lg" Width="100%" OnClick="Button4_Click" />
                            </div>
                        </div>
                    </div>
                    <br />
                </div>
            </div>

            <%-- Right side  --%>
            <div class="col-md-7">
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
                                                        <div class="col-lg-9">
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
                                                        <div class="col-lg-3">
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

    </div>

</asp:Content>
