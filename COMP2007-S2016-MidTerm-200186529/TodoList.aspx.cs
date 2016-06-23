using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

using COMP2007_S2016_MidTerm_200186529.Models;

namespace COMP2007_S2016_MidTerm_200186529
{
    public partial class TodoList : System.Web.UI.Page
    {

          /**
         * <summary>
         * Page Load
         * </summary>
         * 
         * @method Page_Load
         * @return {void}
         */
        protected void Page_Load(object sender, EventArgs e)
        {
            this.GetTodos();
        }

        /**
         * <summary>
         * This method gets the Todos.
         * </summary>
         * 
         * @method GetTodos
         * @return {void}
         */
        protected void GetTodos()
        {
            // connect
            using (TodoConnection db = new TodoConnection())
            {
                // query the todos table
                var Todos = (from allTodos in db.Todos select allTodos);

                // bind the result to the DataList
                TodoDataList.DataSource = Todos.ToList();
                TodoDataList.DataBind();

                // total todo's counter
                var todoCount = (from allTodos in db.Todos select allTodos).Count();
                countLabel.Text = "# of Todo's ="+todoCount;
            }
        }

        /**
         * <summary>
         * This method processes the todo delete functionality.
         * </summary>
         * 
         * @method TodoDataList_DeleteCommand
         * @return {void}
         */
        protected void TodoDataList_DeleteCommand(object source, DataListCommandEventArgs e)
        {

            int TodoID = Convert.ToInt32(TodoDataList.DataKeys[e.Item.ItemIndex]);

            using (TodoConnection db = new TodoConnection())
            {
                // create object of the todo class and store the query string inside of it
                Todo deletedTodo = (from TodoRecords in db.Todos
                                          where TodoRecords.TodoID == TodoID
                                          select TodoRecords).FirstOrDefault();

                // remove the selected todo from the db
                db.Todos.Remove(deletedTodo);

                // save changes back to the db
                db.SaveChanges();

                // refresh
                this.GetTodos();
            }
        }
        

    }
}