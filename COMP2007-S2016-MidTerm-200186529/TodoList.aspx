<%@ Page Title="Todo List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TodoList.aspx.cs" Inherits="COMP2007_S2016_MidTerm_200186529.TodoList" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
          <div class="container">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h1 class="panel-title"><i class="fa fa-th-large fa-lg"></i> To Do List</h1>
            </div>
            <div class="panel-body">
                <a href="/TodoDetails.aspx" class="btn btn-success btn-sm"><i class="fa fa-plus"></i> Add ToDo</a>
                <asp:DataList ID="TodoDataList"
                    RepeatDirection="Horizontal"
                    RepeatLayout="Flow"
                    RepeatColumns="0" runat="server" OnDeleteCommand="TodoDataList_DeleteCommand" DataKeyField="TodoID">
                    <ItemTemplate>
                        <table class="table">
                            <thead>
                                <tr>
                                <th>To Do Name</th>
                                <th>To Do Notes</th>
                                <th>Completed</th>
                                <th>Edit</th>
                                <th>Delte</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td><h2><%#Eval("ToDoName") %></h2></td>
                                    <td><h3><%#Eval("ToDoNotes") %></h3></td>
                                    <td><%#Eval("Completed") %></td>
                                    <td><a href='/TodoDetails.aspx?TodoID=<%#Eval("TodoID")%>' class="btn btn-primary btn-sm"><i class='fa fa-pencil-square-o fa-lg'></i>Edit</a></td>
                                    <td>
                                        <asp:LinkButton ID="DeleteButton" runat="server"
                                        Text="<i class='fa fa-trash fa-lg'></i> Delete"
                                        CommandName="delete" CssClass="btn btn-danger btn-sm delete" />
                                    </td>
                                </tr>               
                            </tbody>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
            </div>
        </div>
    </div>
</asp:Content>
