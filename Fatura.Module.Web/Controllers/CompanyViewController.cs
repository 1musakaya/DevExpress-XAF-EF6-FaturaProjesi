using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
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
    public partial class CompanyViewController : ViewController
    {
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public CompanyViewController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
            TargetObjectType = typeof(Company);
            TargetViewType = ViewType.ListView;
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
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

        private void CompanyViewController_CopyAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var obj = e.SelectedObjects[0] as Company;

            var newobje = ObjectSpace.CreateObject<Company>();

            newobje.Ulke=obj.Ulke;
            newobje.Name=obj.Name;
            newobje.PhoneNumber=obj.PhoneNumber+"*";
            newobje.Sehir=obj.Sehir;
            newobje.Address=obj.Address;
            newobje.Active=obj.Active;

            ObjectSpace.CommitChanges();
            ObjectSpace.Refresh();
        }

        private void CompanyViewController_TestAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var cstr = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cstr))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection= con;
                    /*
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "select * from Companies";
                    */

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "GetCompanies";
                    cmd.Parameters.Add(new SqlParameter {ParameterName = "Name", DbType = System.Data.DbType.String, Value = "Firma 2" });

                    //cmd.ExecuteNonQuery();

                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        var name = rdr["Name"].ToString();
                    }

                    rdr.Close();
                }

                con.Close();
            }
        }
    }
}
