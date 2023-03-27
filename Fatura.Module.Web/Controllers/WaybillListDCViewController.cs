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
using System.ComponentModel.Design;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web.Configuration;

namespace Fatura.Module.Web.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class WaybillListDCViewController : ViewController
    {
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public WaybillListDCViewController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.

            TargetObjectType = typeof(WaybillListDC);
            
                
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.

            if (View is DetailView)
            {
                if (((DetailView)View).CurrentObject == null)
                { 
                    ((DetailView)View).CurrentObject = ObjectSpace.CreateObject<WaybillListDC>();
                }

                ((DetailView)View).ViewEditMode = ViewEditMode.Edit;
            }

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

        private void WaybillListDCViewController_ListAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {

            var cobj = ((DetailView)View).CurrentObject as WaybillListDC;



            CompositeView dv = null;

            if (Frame is NestedFrame)
            {
                dv = ((NestedFrame)Frame).ViewItem.View;
            }

            if (!(dv is DashboardView))
            {
                //ObjectSpaceList(cobj);

                SQLList(cobj);


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

        private void ObjectSpaceList(WaybillListDC cobj)
        {
            IObjectSpace os = Application.CreateObjectSpace(typeof(Waybill));

            var co = CriteriaOperator.Parse("WaybillDate >= ? and WaybillDate <= ?", cobj.StartDate, cobj.EndDate);

            var wlist = os.GetObjects<Waybill>(co);

            cobj.Details.Clear();

            foreach (var item in wlist)
            {
                WaybillListDetailDC det = new WaybillListDetailDC();

                det.WaybillId = item.Id;
                det.WaybillNo = item.WaybillNo;
                det.Date = item.WaybillDate;


                if (item.Company != null)
                {
                    det.CompanyName = item.Company.Name;
                    cobj.Details.Add(det);
                }
            }
        }

        private void SQLList(WaybillListDC cobj)
        {
            IObjectSpace os = Application.CreateObjectSpace(typeof(Company));
            var cstr = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cstr))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    //cmd.CommandText = "GetWaybills";
                    //cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "GetWaybills";

                    cmd.Parameters.Add(new SqlParameter { ParameterName = "StartDate", DbType = System.Data.DbType.DateTime, Value = cobj.StartDate });
                    cmd.Parameters.Add(new SqlParameter { ParameterName = "EndDate", DbType = System.Data.DbType.DateTime, Value = cobj.EndDate });


                    //cmd.ExecuteNonQuery();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    cobj.Details.Clear();
                    while (rdr.Read())
                    {
                        //var name = rdr["WaybillNo"].ToString();
                        WaybillListDetailDC det = new WaybillListDetailDC();

                        det.WaybillNo = rdr["WaybillNo"].ToString();
                        det.WaybillId = (int)rdr["Id"];
                        det.Date = (DateTime)rdr["WaybillDate"];
                        
                        /*
                        var companyId = (int)rdr["CompanyId"];

                        var waybillCompany = os.GetObjectByKey<Company>(companyId);
                        if (waybillCompany != null)
                        {
                            det.CompanyName = waybillCompany.Name;
                        }
                        */

                        det.CompanyName = rdr["CompanyName"].ToString();
                        

                        cobj.Details.Add(det);
                        

                    }
                    rdr.Close();
                    
                }
                con.Close();
               
            }
            
        }
        
    }
}
