<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MiniProject._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
                        <h2>Electricity Board Billing Automation</h2>

 
        </section>

        <div class="row">
            <section class="col-md-4" aria-labelledby="gettingStartedTitle">
               <h3>Add Electricity Bill</h3>
               
                
                    <a href="AddBill.aspx" class="btn btn-primary">Add Bill</a>
                
            </section>
            <section class="col-md-4" aria-labelledby="librariesTitle">
              <h3>View Electricity Bill</h3>
                
                <p>
                    <a href="ViewBill.aspx" class="btn btn-success">View Bills</a>
                </p>
            </section>
            
        </div>
    </main>

</asp:Content>
