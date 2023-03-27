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
using System.Linq;
using System.Text;

namespace Fatura.Module.Web.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class WayBillDetailViewController : ViewController
    {
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public WayBillDetailViewController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
            TargetObjectType = typeof(Waybill);
            TargetViewType = ViewType.DetailView;
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.

            var pe = ((DetailView)View).FindItem("Company");

            if (pe != null)
            {
                ((PropertyEditor)pe).ControlValueChanged += WayBillDetailViewController_ControlValueChanged;
            }
            

        }

        private void WayBillDetailViewController_ControlValueChanged(object sender, EventArgs e)
        {
            var cv = ((PropertyEditor)sender).ControlValue as Company;

            var obj=((DetailView)View).CurrentObject as Waybill;    
            if (cv != null)
            {
                obj.Address= cv.Address;
            }

        }

        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {


            var pe = ((DetailView)View).FindItem("Company");
            if (pe != null)
            {
                ((PropertyEditor)pe).ControlValueChanged -= WayBillDetailViewController_ControlValueChanged;
            }



            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }

        private void WayBillDetailController_Detail_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            /* var obj = e.SelectedObjects[0] as WaybillDetail;

            var id = obj.WaybillId;
            foreach (WaybillDetail item in e.SelectedObjects)
            {
                item.WaybillId.ToString();
            } */


            //var newcmp = ObjectSpace.CreateObject<Company>();
            //newcmp.Name = "İkinci Firma";

            //var newCompany = ObjectSpace.CreateObject<Company>();
            //newCompany.Name = "Yeni bir Firma";

            //var newObj = ObjectSpace.CreateObject<Waybill>();
            //newObj.WaybillNo = "Yeni bir irs.";
            //newObj.WaybillDate = DateTime.Now.Date;
            ////newObj.Company = ObjectSpace.GetObjectByKey<Company>(2);
            //newObj.Company = newCompany;

            //var det = ObjectSpace.CreateObject<WaybillDetail>();
            //det.Product = ObjectSpace.GetObjectByKey<WaybillProduct>(1);
            //det.Quantity = 10;
            //newObj.Details.Add(det);

            //var cmp = ObjectSpace.GetObjectByKey<Company>(3);
            //cmp.Address = "Yeni adres 3 ";
            //cmp.PhoneNumber = "321123";

            //var obje = ObjectSpace.CreateObject<WaybillProduct>();
            //obje.Name = "Laptop";

            //var product = ObjectSpace.CreateObject<WaybillProduct>();
            //product.Name = "Klavye";

            //var del = ObjectSpace.GetObjectByKey<Waybill>(8);
            //ObjectSpace.Delete(del);

            //var delete = ObjectSpace.GetObjectByKey<Company>(4);
            //if (delete !=null )
            //{
            //    ObjectSpace.Delete(delete);

            //    ObjectSpace.CommitChanges();
            //    View.Refresh()
            //    ObjectSpace.Refresh();
            //}




            //var comp = ObjectSpace.GetObjects<Waybill>(CriteriaOperator.Parse("Company=?", "ABC Firması"));

            ////var obje = ObjectSpace.GetObjects<Company>(CriteriaOperator.Parse("Name=?", "Yeni Firma"));
            //ObjectSpace.Delete(obje);

            //var obje = ObjectSpace.CreateObject<Company>();
            //obje.Name = "B Firması";

            //var obje = ObjectSpace.GetObjects<Company>(CriteriaOperator.Parse("Name=?", "A Firma"));
            //ObjectSpace.Delete(obje);

            var obje = ObjectSpace.GetObjectByKey<Company>(2);
            obje.Address = "qweqrt";
            obje.Name = "C Firma";
            obje.PhoneNumber = "123456";    
            

            ObjectSpace.CommitChanges();
            View.Refresh();
            ObjectSpace.Refresh();
        }
    }
}
