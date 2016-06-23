using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

using COMP2007_S2016_MidTerm_200186529.Models;

/**
 * @author:  Tim Harasym
 * @date: June 23 2016
 */
namespace COMP2007_S2016_MidTerm_200186529
{
    public partial class TodoDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            // if post back and querystring then run GetTodo.
            if ((!IsPostBack) && (Request.QueryString.Count > 0))
            {
                this.GetTodo();
            }
        }

        /**
         * <summary>
         * This method gets the Todos from the DB and handles edit functionality.
         * </summary>
         * 
         * @method GetTodo
         * @return {void}
         */
        protected void GetTodo()
        {
            // populate the form with existing data from the database
            int TodoID = Convert.ToInt32(Request.QueryString["TodoID"]);

            // connect to the EF DB
            using (TodoConnection db = new TodoConnection())
            {
                // populate a todo object instance with the todoID from the URL parameter
                Todo updatedTodo = (from todo in db.Todos
                                    where todo.TodoID == TodoID
                                    select todo).FirstOrDefault();

                // map the todo properties to the form controls
                if (updatedTodo != null)
                {
                    TodoNameTextBox.Text = updatedTodo.TodoName;
                    TodoNotesTextBox.Text = updatedTodo.TodoNotes;
                    // Checkbox

                }
            }
        }

        /**
         * <summary>
         * This method saves the todo on click
         * </summary>
         * 
         * @method SaveButton_Click
         * @return {void}
         */
        protected void SaveButton_Click(object sender, EventArgs e)
        {
            // connect to the server
            using (TodoConnection db = new TodoConnection())
            {
                // Use the todo model to create a new todo object and also save a new record
                Todo newTodo = new Todo();

                int TodoID = 0;

                if (Request.QueryString.Count > 0) // our URL has a TodoID in it
                {
                    // get the id from the URL
                    TodoID = Convert.ToInt32(Request.QueryString["TodoID"]);

                    // get the current todo from the database
                    newTodo = (from todo in db.Todos
                               where todo.TodoID == TodoID
                               select todo).FirstOrDefault();
                }

                // add data to the new todo record
                newTodo.TodoName = TodoNameTextBox.Text;
                newTodo.TodoNotes = TodoNotesTextBox.Text;
                //newTodo.Completed = todoCheckBox.Checked;

                // insert new todo into the database
                if (TodoID == 0)
                {
                    db.Todos.Add(newTodo);
                }

                // save our changes
                db.SaveChanges();

                // redirect back to the updated manage games page
                Response.Redirect("~/TodoList.aspx");
            }
        }           
    }
}