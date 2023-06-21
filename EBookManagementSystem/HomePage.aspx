<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="EBookManagementSystem.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <section>
         <%-- img-fluid used to make image responsive(changes size when wbpaage shrinks) --%>
        <img src="Images/imgs/home-bg.jpg" class="img-fluid"/>
    </section>
    <section>
        <div class="container">
            <%--for first row--%>
            <div class="row">
                <div class="col-12">
                    <center>
                    <h2>Our Features</h2>
                    <p><b>Our 3 Primary Fetures</b></p>
                    </center>
                </div>
            </div>
             <%--for second row we can divide row into 12 parts so 3 div col-md-4 fits in 1 row --%>
              <div class="row">
            <%-- for 1st Img, col-md-4 says that medium devicesize puts div below to one another for responsive purpose--%>
            <div class="col-md-4">
                <center>
                   <img src="Images/imgs/digital-inventory.png"style="width:150px;"/>
                  <h4>Digital Book Inventory</h4>
                  <p class="text-justify">Book inventory is the cost of inventory on hand, as stated in an organization's accounting records. This amount is compared to the actual inventory on hand to see if there are any discrepancies in the accounting records, which can indicate procedural or control problems that should be corrected.</p>
               </center>
                </div>
                   <%--for 2nd Img,--%>
            <div class="col-md-4">
                <center>
                    <img src="Images/imgs/search-online.png"style="width:150px;" />
                  <h4>Search Books</h4>
                  <p class="text-justify">Book inventory is the cost of inventory on hand, as stated in an organization's accounting records. This amount is compared to the actual inventory on hand to see if there are any discrepancies in the accounting records, which can indicate procedural or control problems that should be corrected.</p>
               </center>
                </div>
                         <%--for 3rd Img,--%>
            <div class="col-md-4">
                <center>
                    <img src="Images/imgs/defaulters-list.png" style="width:150px;"/>
                 <h4>Defaulter List</h4>
                  <p class="text-justify">Book inventory is the cost of inventory on hand, as stated in an organization's accounting records. This amount is compared to the actual inventory on hand to see if there are any discrepancies in the accounting records, which can indicate procedural or control problems that should be corrected.</p>
               </center>
                </div>
            </div>
        </div>
          
    </section>
       <section>
           <img src="Images/imgs/in-homepage-banner.jpg" class="img-fluid"/>
    </section>
        <section>
        <div class="container">
            <%--for first row--%>
            <div class="row">
                <div class="col-12">
                    <center>
                    <h2>Our Process</h2>
                    <p><b>We have a Simple 3 Step Process</b></p>
                    </center>
                </div>
            </div>
             <%--for second row we can divide row into 12 parts so 3 div col-md-4 fits in 1 row --%>
              <div class="row">
            <%-- for 1st Img, col-md-4 says that medium devicesize puts div below to one another for responsive purpose--%>
            <div class="col-md-4">
                <center>
                   <img src="Images/imgs/sign-up.png"style="width:150px;"/>
                  <h4>Sign Up</h4>
                  <p class="text-justify">Book inventory is the cost of inventory on hand, as stated in an organization's accounting records. This amount is compared to the actual inventory on hand to see if there are any discrepancies in the accounting records, which can indicate procedural or control problems that should be corrected.</p>
               </center>
                </div>
                   <%--for 2nd Img,--%>
            <div class="col-md-4">
                <center>
                    <img src="Images/imgs/search-online.png"style="width:150px;" />
                  <h4>Search Books</h4>
                  <p class="text-justify">Book inventory is the cost of inventory on hand, as stated in an organization's accounting records. This amount is compared to the actual inventory on hand to see if there are any discrepancies in the accounting records, which can indicate procedural or control problems that should be corrected.</p>
               </center>
                </div>
                         <%--for 3rd Img,--%>
            <div class="col-md-4">
                <center>
                    <img src="Images/imgs/library.png" style="width:150px;"/>
                 <h4>Visit Us</h4>
                  <p class="text-justify">Book inventory is the cost of inventory on hand, as stated in an organization's accounting records. This amount is compared to the actual inventory on hand to see if there are any discrepancies in the accounting records, which can indicate procedural or control problems that should be corrected.</p>
               </center>
                </div>
            </div>
        </div>
          
    </section>

</asp:Content>
