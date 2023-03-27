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
    public partial class WaybillViewController : ViewController
    {
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public WaybillViewController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.

            TargetObjectType = typeof(Waybill);
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

        private void WaybillViewController_TestAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {


            //var comp = ObjectSpace.GetObjects<Company>(CriteriaOperator.Parse("Name=?", "ABC Firması"));


            //var obj = ObjectSpace.GetObjectByKey<Waybill>(5); // ObjectSpace Verilere erişmek ve işlem yapmak için kullanılır.
            //if (obj != null)
            //{
            //    ObjectSpace.Delete(obj);

            //    ObjectSpace.CommitChanges();

            //    ObjectSpace.Refresh();
            //}





            //var obj = e.SelectedObjects[0] as Waybill;

            /*
            foreach (Waybill item in e.SelectedObjects)
            {
                //item.WaybillNo
            }
            */

            /*
            var obj = ObjectSpace.GetObjectByKey<Waybill>(4);

            obj.WaybillNo = "****";

            ObjectSpace.CommitChanges();
            */


            //var newCompany = ObjectSpace.CreateObject<Company>();
            //newCompany.Name = "Yeni Firma";

            //var newObj = ObjectSpace.CreateObject<Waybill>();
            //newObj.WaybillNo = "Yeni irs.";
            //newObj.WaybillDate = DateTime.Now.Date;
            ////newObj.Company = ObjectSpace.GetObjectByKey<Company>(2);
            //newObj.Company= newCompany;

            //var det = ObjectSpace.CreateObject<WaybillDetail>();
            //det.Product = ObjectSpace.GetObjectByKey<WaybillProduct>(1);
            //det.Quantity = 2;

            //newObj.Details.Add(det);


            //var obje = ObjectSpace.GetObjectByKey<Waybill>(10);
            //obje.Company.Name = "ABC Firması";
            //obje.WaybillNo = "123123";



            //var obje = ObjectSpace.GetObjects<Company>(CriteriaOperator.Parse("Name=?", "Yeni Firma"));
            //ObjectSpace.Delete(obje);

            //var obje = ObjectSpace.GetObjects<Company>(CriteriaOperator.Parse("Name=?", "B Firma"));
            //ObjectSpace.Delete(obje);

            //var obje = ObjectSpace.CreateObject<Company>();
            //obje.Name = "B Firma";
            //obje.Address = "Üsküdar";
            //obje.PhoneNumber= "0216";


            var obje = ObjectSpace.GetObjectByKey<Waybill>(10);
            if (obje != null)
            {
                obje.WaybillNo = "231321";
                obje.Company.Name = "D Firması";
            }

            //var obje = ObjectSpace.GetObjectByKey<Company>(7);
            //obje.Name= "Test2";
            //obje.Address = "Üsküdar";
            //obje.PhoneNumber = "789560";


            ObjectSpace.CommitChanges();
            View.Refresh();

            ObjectSpace.Refresh();


        }

        private void WaybillViewController_Test2Action_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            IObjectSpace os = Application.CreateObjectSpace(typeof(Company));


            /*
            var comp = os.CreateObject<Company>();

            comp.Name = "Test Firma 1";
            comp.PhoneNumber= "12345";
            comp.Address = "Ader 1";

            os.CommitChanges();
            */

            var comp = ObjectSpace.CreateObject<Company>();

            comp.Name = "Test Firma 2";
            comp.PhoneNumber = "12345";
            comp.Address = "Ader 2";

            //ObjectSpace.CommitChanges();

        }

        private void WaybillViewController_CopyAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var cobj = e.SelectedObjects[0] as Waybill;

            IObjectSpace os = Application.CreateObjectSpace(typeof(Waybill));

            var newobj = os.CreateObject<Waybill>();

            newobj.WaybillNo = cobj.WaybillNo + "*";
            newobj.WaybillDate = cobj.WaybillDate;
            newobj.Address = cobj.Address;
            newobj.Company = os.GetObject(cobj.Company);

            foreach (var item in cobj.Details)
            {
                var newdetail = os.CreateObject<WaybillDetail>();

                newdetail.Product = os.GetObject(item.Product);
                newdetail.Kdv = item.Kdv;
                newdetail.Quantity = item.Quantity;
                newdetail.Price = item.Price;
                newdetail.Total = item.Total;

                newobj.Details.Add(newdetail);
            }


            os.CommitChanges();


            ObjectSpace.Refresh();

        }
    }
}
