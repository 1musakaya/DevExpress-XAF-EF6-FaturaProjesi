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
    public partial class TransportViewController : ViewController
    {
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public TransportViewController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
            TargetObjectType = typeof(Transport);
            //TargetViewType = ViewType.ListView;
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.

            if (View is DetailView)
            {
                var cobj = ((DetailView)View).CurrentObject as Transport;

                if (ObjectSpace.IsNewObject(cobj))
                {
                    cobj.TransportDate = DateTime.Now.Date;
                    cobj.RegisteredUser = SecuritySystem.CurrentUserName;
                }
            }
            View.ObjectSpace.Committing += ObjectSpace_Committing;

        }

        private void ObjectSpace_Committing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //var cobj = ((DetailView)View).CurrentObject as Transport;
            //if (cobj.TransportIncomeExpenseDetails.Count <= 1)
            //{
            //    e.Cancel = true;
            //}

            return;

            bool incomeExists = false;
            bool expenseExists = false;

            var cobj = ((DetailView)View).CurrentObject as Transport;
            foreach (var item in cobj.TransportIncomeExpenseDetails)
            {
                if ((item.Type != null) && (item.Type == TransportIncomeExpenseTypes.Income))
                {
                    incomeExists= true;
                }
                if ((item.Type != null) && (item.Type == TransportIncomeExpenseTypes.Expense))
                {
                    expenseExists = true;
                }
            }

            if (!incomeExists || !expenseExists)
            {
                e.Cancel = true;    
            }

            /*
            if (!(incomeExists && expenseExists))
            {
                e.Cancel= true; 
            }
            */

        }

        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            View.ObjectSpace.Committing -= ObjectSpace_Committing;
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }

        private void TransportViewController_CopyAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var obje = e.SelectedObjects[0] as Transport;
            var newobj = ObjectSpace.CreateObject<Transport>();

            newobj.Explanition = obje.Explanition + "*";
            newobj.TransportAddress = obje.TransportAddress;
            //newobj.TransportAddress.ExitAddress = obje.TransportAddress.ExitAddress;
            newobj.RegisteredUser= obje.RegisteredUser;
            newobj.TransportDate= obje.TransportDate;
            newobj.TransportCompany = obje.TransportCompany;
            newobj.Products= obje.Products;

            ObjectSpace.CommitChanges();
            ObjectSpace.Refresh();
        }

    }
}
