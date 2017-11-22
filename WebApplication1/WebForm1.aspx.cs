using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        List<string> list = new List<string> { "ok", "okok", "okokok" }; //DB objects
        protected void Page_Load(object sender, EventArgs e)
        {

            //Manually populate DT, use your db instead
            if (!IsPostBack)
            {
                DataTable dt = new DataTable();

                //Define the Columns
                dt.Columns.Add(new DataColumn("name", typeof(string)));
                dt.Columns.Add(new DataColumn("ddl1", typeof(string)));
                dt.Columns.Add(new DataColumn("ddl2", typeof(string)));

                foreach (string s in list)
                    dt.Rows.Add(s,"","");

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }


            //Always read viewstate onload if available
            if (ViewState["gvDS"] != null)
            {
                GridView1.DataSource = ViewState["gvDS"];
                GridView1.DataBind();
            }
                
        }


        //check for redundancy, runs everytime databound is run
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {    
                    
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddl1 = new DropDownList();
                ddl1.DataSource = GetDummyData();
                ddl1.SelectedIndexChanged += new EventHandler(DropDown_Changed);
                ddl1.AutoPostBack = true;
                ddl1.DataBind();
                DropDownList ddl2 = new DropDownList();
                e.Row.Cells[1].Controls.Add(ddl1);
                e.Row.Cells[2].Controls.Add(ddl2);
            }
        }

        private ArrayList GetDummyData()
        {
            ArrayList arr = new ArrayList();
            arr.Add(new ListItem("Item1", "1"));
            arr.Add(new ListItem("Item2", "2"));
            arr.Add(new ListItem("Item3", "3"));
            arr.Add(new ListItem("Item4", "4"));
            arr.Add(new ListItem("Item5", "5"));
            return arr;
        }

        private ArrayList GetOtherData()
        {
            ArrayList arr = new ArrayList();
            arr.Add(new ListItem("i1", "1"));
            arr.Add(new ListItem("i2", "2"));
            arr.Add(new ListItem("i3", "3"));
            return arr;
        }

        protected void DropDown_Changed(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            var p= (GridViewRow) ddl.NamingContainer;
            int ROWSELECTEDWHEEEE = p.RowIndex;
            var s = ddl.SelectedValue;

            if (s == "Item4"|| s =="Item2") //Do the filtering and repopulate 2nd ddl here
            {
                DropDownList ddl2 = new DropDownList();
                ddl2.DataSource = GetOtherData();
                ddl2.DataBind();
                GridView1.Rows[ROWSELECTEDWHEEEE].Cells[2].Controls.Clear();
                GridView1.Rows[ROWSELECTEDWHEEEE].Cells[2].Controls.Add(ddl2);
            } else
            {
                DropDownList ddl2 = new DropDownList();
                GridView1.Rows[ROWSELECTEDWHEEEE].Cells[2].Controls.Clear();
                GridView1.Rows[ROWSELECTEDWHEEEE].Cells[2].Controls.Add(ddl2);
            }
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            
        }

        // See life cycle at http://www.c-sharpcorner.com/UploadFile/8911c4/page-life-cycle-with-examples-in-Asp-Net/
        // Saves the datatable which consist of all the ddls and the saved values
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            ViewState["gvDS"] = GridView1.DataSource;
        }
    }
}