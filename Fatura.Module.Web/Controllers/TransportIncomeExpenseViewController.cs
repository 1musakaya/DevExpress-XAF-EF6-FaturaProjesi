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
using DevExpress.XtraRichEdit.Layout;
using Fatura.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Fatura.Module.Web.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class TransportIncomeExpenseViewController : ViewController
    {
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public TransportIncomeExpenseViewController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
            TargetObjectType = typeof(TransportIncomeExpense);
            //TargetViewType = ViewType.DetailView;
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
            //var pe = ((DetailView)View).FindItem("Quantity");
            //if (pe != null)
            //{
            //    ((PropertyEditor)pe).ControlValueChanged += TransportIncomeExpenseDetailDetailViewController_PriceControlValueChanged;
            //}
        }

        private void TransportIncomeExpenseDetailDetailViewController_PriceControlValueChanged(object sender, EventArgs e)
        {
            //var cv = ((PropertyEditor)sender).ControlValue as double?;
            //var cobj = ((DetailView)View).CurrentObject as TransportIncomeExpense;
            //if (cobj != null && cv != null)
            //{
            //    //cobj.Amount = ((double)cv * cobj.Income) - (double)cv * cobj.Expense;
            //}

        }

        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            //var pe = ((DetailView)View).FindItem("Quantity");
            //if (pe != null)
            //{
            //    ((PropertyEditor)pe).ControlValueChanged -= TransportIncomeExpenseDetailDetailViewController_PriceControlValueChanged;
            //}
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();

        }



        private void TransportIncomeExpenseDetailViewController_CreateAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {

            bool incomeExists = false;
            bool expenseExists = false;
            //var cobj = ((DetailView)View).CurrentObject as Transport;
            foreach (TransportIncomeExpense item in e.SelectedObjects)
            {
                if ((item.Type != null) && (item.Type == TransportIncomeExpenseTypes.Income))
                {
                    incomeExists = true;
                }
                if ((item.Type != null) && (item.Type == TransportIncomeExpenseTypes.Expense))
                {
                    expenseExists = true;
                }
            }

            if (incomeExists && expenseExists)
            {
            }
            else
            {
                IObjectSpace os = Application.CreateObjectSpace(typeof(TransportInvoice));

                var mobj = ((PropertyCollectionSource)((ListView)View).CollectionSource).MasterObject as Transport;

                var newobj = os.CreateObject<TransportInvoice>();

                newobj.InvoiceDate = mobj.TransportDate;

                newobj.InvoiceAddress = os.GetObject(mobj.TransportAddress);
                newobj.TransportCompany = os.GetObject(mobj.TransportCompany);


                /*
                foreach (TransportIncomeExpense item in e.SelectedObjects)
                {
                    newobj.Type = os.GetObject(item.Type);

                }
                */

                newobj.Type = ((TransportIncomeExpense)e.SelectedObjects[0]).Type;

                foreach (TransportIncomeExpense item in e.SelectedObjects)
                {
                    var obj = os.CreateObject<TransportInvoiceDetail>();
                    obj.Price = item.Amount;
                    obj.Quantity = item.Quantity;
                    obj.TransportService = os.GetObject(item.TransportService);

                    newobj.Details.Add(obj);
                    os.CommitChanges();
                }

                DetailView dv = Application.CreateDetailView(os,newobj);
                dv.ViewEditMode = ViewEditMode.Edit;

                e.ShowViewParameters.CreatedView = dv;
                e.ShowViewParameters.TargetWindow = TargetWindow.Default;

                //var shortcut = dv.CreateShortcut();
                //var queryString = ((WebApplication)Application).RequestManager.GetQueryString(shortcut);
                //var fullViewURL = string.Format("{0}#{1}", HttpContext.Current.Request.Url.AbsoluteUri, queryString);
                //WebWindow.CurrentRequestWindow.RegisterStartupScript("123456", string.Format("window.open('{0}','_blank');", fullViewURL));
            }
        }
    }
}
