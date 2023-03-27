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
using DevExpress.XtraRichEdit.Layout;
using Fatura.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            IObjectSpace ios = Application.CreateObjectSpace(typeof(Waybill));
            bool incomeExists = false;
            bool expenseExists = false;
            var cobj =ios.GetObjectByKey<Transport>(((TransportIncomeExpense)e.SelectedObjects[0]).Id);

            //var cobj = ((DetailView)View).CurrentObject as Transport;
            foreach (TransportIncomeExpense item in cobj.TransportIncomeExpenseDetails)
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
                if ((incomeExists && expenseExists))
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


                    foreach (TransportIncomeExpense item in e.SelectedObjects)
                    {
                        newobj.Type = os.GetObject(item.Type);

                    }

                    foreach (TransportIncomeExpense item in e.SelectedObjects)
                    {
                        var obj = os.CreateObject<TransportInvoiceDetail>();
                        obj.Price = item.Amount;
                        obj.Quantity = item.Quantity;
                        obj.TransportService = os.GetObject(item.TransportService);

                        newobj.Details.Add(obj);
                        os.CommitChanges();
                    }


                }
            
        }
    }
}
