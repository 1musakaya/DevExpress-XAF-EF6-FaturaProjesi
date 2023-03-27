using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.ExpressApp.Web;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using Fatura.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Fatura.Module.Web.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class WaybillListDetailDCViewController : ViewController
    {
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public WaybillListDetailDCViewController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
            TargetObjectType = typeof(WaybillListDetailDC);
            
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

        private void WaybillListDetailDCViewController_EditAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {

            IObjectSpace os = Application.CreateObjectSpace(typeof(Waybill));


            var obj = os.GetObjectByKey<Waybill>(((WaybillListDetailDC)e.SelectedObjects[0]).WaybillId);

            DetailView dv = Application.CreateDetailView(os, obj);
            dv.ViewEditMode = ViewEditMode.Edit;

            //e.ShowViewParameters.CreatedView = dv;
            //e.ShowViewParameters.TargetWindow = TargetWindow.Current;

            var shortcut = dv.CreateShortcut();
            var queryString = ((WebApplication)Application).RequestManager.GetQueryString(shortcut);
            var fullViewURL = string.Format("{0}#{1}", HttpContext.Current.Request.Url.AbsoluteUri, queryString);
            WebWindow.CurrentRequestWindow.RegisterStartupScript("123456", string.Format("window.open('{0}','_blank');", fullViewURL));


        }

        private void WaybillListDetailDCViewController_DeleteAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            IObjectSpace os=Application.CreateObjectSpace(typeof(Waybill));

            var obj = os.GetObjectByKey<Waybill>(((WaybillListDetailDC)e.SelectedObjects[0]).WaybillId);

            if (obj != null)
            {
                os.Delete(obj);
                os.CommitChanges();
                
            }
            View.Refresh();
        }
    }
}
