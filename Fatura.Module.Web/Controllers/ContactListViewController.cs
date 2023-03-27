using DevExpress.Data.Filtering;
using DevExpress.DataAccess.Sql;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Persistent.Validation;
using DevExpress.XtraRichEdit.Layout.Engine;
using Fatura.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web.Configuration;

namespace Fatura.Module.Web.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class ContactListViewController : ViewController
    {
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public ContactListViewController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
            TargetObjectType = typeof(ContactListDC);

        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.

            if(((DetailView)View).CurrentObject==null)
            {
                ((DetailView)View).CurrentObject = ObjectSpace.CreateObject<ContactListDC>();
            }
            ((DetailView)View).ViewEditMode= ViewEditMode.Edit;


        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }

        private void ContactListViewController_ListAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var cobj = ((DetailView)View).CurrentObject as ContactListDC;
            CompositeView dv = null;

            if (Frame is NestedFrame)
            {
                dv = ((NestedFrame)Frame).ViewItem.View;
            }

            if (!(dv is DashboardView))
            {
                //ObjectSpaceList(cobj);

                SqlList(cobj);


                View.Refresh();
            }
            else
            {
                //-- DashboardView ise

                var dvitem = dv.FindItem("ListItem");

                var co = CriteriaOperator.Parse("WaybillDate >= ? and WaybillDate <= ?", cobj.StartDate, cobj.EndDate);

                ((ListView)((DashboardViewItem)dvitem).InnerView).CollectionSource.Criteria["Filtre"] = co;

                ((DashboardViewItem)dvitem).Refresh();

            }
        }

        private void ObjectSpaceList(ContactListDC cobj)
        {
            IObjectSpace os = Application.CreateObjectSpace(typeof(Contact));

            var co = CriteriaOperator.Parse("Birthday >=? and Birthday <=?", cobj.StartDate, cobj.EndDate);
            var wlist = os.GetObjects<Person>(co);

            cobj.Details.Clear();

            foreach (var item in wlist)
            {
                ContactListDetailDC cdet = new ContactListDetailDC();
                cdet.Lastname=item.LastName;
                cdet.Email=item.Email;
                cdet.Name = item.FullName;
                cdet.Date = (DateTime)item.Birthday;
                
                cobj.Details.Add(cdet);
            }
            View.Refresh();
        }

        private void SqlList(ContactListDC cobj)
        {
            IObjectSpace os = Application.CreateObjectSpace(typeof(Contact));
            var cstr = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cstr))
            {
                con.Open();
                using(SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection= con;
                    cmd.CommandType=System.Data.CommandType.StoredProcedure;
                    cmd.CommandText= "GetParties";
                    

                    cmd.Parameters.Add(new SqlParameter { ParameterName = "StartDate", DbType = System.Data.DbType.DateTime, Value = cobj.StartDate });
                    cmd.Parameters.Add(new SqlParameter { ParameterName = "EndDate", DbType=System.Data.DbType.DateTime,Value = cobj.EndDate });

                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        ContactListDetailDC detailDC= new ContactListDetailDC();

                        detailDC.Name = rdr["FirstName"].ToString();
                        detailDC.Lastname = rdr["LastName"].ToString();
                        detailDC.Date = (DateTime)rdr["Birthday"];
                        detailDC.Email = rdr["Email"].ToString() ;
                        

                        
                        cobj.Details.Add(detailDC);
                    }
                    rdr.Close();
                }
                con.Close();
            }
        }
    }
}
