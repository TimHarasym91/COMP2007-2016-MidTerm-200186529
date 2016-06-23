<%@ Page Title="Todo Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TodoDetails.aspx.cs" Inherits="COMP2007_S2016_MidTerm_200186529.TodoDetails" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-offset-3 col-md-6">
                <h1>To Do Details</h1>
                <br />
                <div class="form-group">
                    <label class="control-label" for="TodoNameTextBox">To Do Name</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="TodoNameTextBox" placeholder="To Do Name" required="true"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="control-label" for="TodoNotesTextBox">To Do Notes</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="TodoNotesTextBox" placeholder="Notes" required="true"></asp:TextBox>
                </div>
                <div class="form-group">
                    <h4>Checkbox from hell goes here.</h4>
                </div>

                <div class="text-right">
                    <a href="/TodoList.aspx" class="btn btn-warning btn-lg">Cancel</a>
                    <asp:Button Text="Save" ID="SaveButton" CssClass="btn btn-primary btn-lg" runat="server" OnClick="SaveButton_Click"/>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
