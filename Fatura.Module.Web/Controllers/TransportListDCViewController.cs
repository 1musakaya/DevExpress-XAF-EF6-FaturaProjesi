using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.ExpressApp.Web.Editors;
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
    public partial class TransportListDCViewController : ViewController
    {
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public TransportListDCViewController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
            TargetObjectType = typeof(TransportListDC);
            TargetViewType = ViewType.DetailView;
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
            if (View is DetailView)
            {
                if (((DetailView)View).CurrentObject == null)
                {
                    ((DetailView)View).CurrentObject = ObjectSpace.CreateObject<TransportListDC>();
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

        private void TransportListDCViewController_ListAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var cobj =((DetailView)View).CurrentObject as TransportListDC;

            /*
            IObjectSpace os =Application.CreateObjectSpace(typeof(Transport));

            var co = CriteriaOperator.Parse("TransportDate>=? and TransportDate<=?",cobj.StartDate, cobj.EndDate);

            var tlist = os.GetObjects<Transport>(co);

            cobj.Details.Clear();
            foreach (var t in tlist)
            {
                TransportListDetailDC ttdc= new TransportListDetailDC();

                ttdc.RegisteredUser = t.RegisteredUser;
                ttdc.TransportDate = t.TransportDate;

                if (t.TransportCompany != null)
                {
                    ttdc.CompanyName = t.TransportCompany.Name;

                    cobj.Details.Add(ttdc);
                }
                View.Refresh();
            }
            */

            CompositeView dv = null;

            if (Frame is NestedFrame)
            {
                dv = ((NestedFrame)Frame).ViewItem.View;
            }

            var dvitem = dv.FindItem("ListItem");

            var co = CriteriaOperator.Parse("TransportDate >= ? and TransportDate <= ?", cobj.StartDate, cobj.EndDate);

            ((ListView)((DashboardViewItem)dvitem).InnerView).CollectionSource.Criteria["Filtre"] = co;

            ((DashboardViewItem)dvitem).Refresh();


        }

    }
}
