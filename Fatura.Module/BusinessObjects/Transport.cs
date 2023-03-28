using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Security;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Persistent.Validation;
using DevExpress.XtraCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web.ModelBinding;
using System.Web.UI.WebControls;

namespace Fatura.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem(groupName: "Proje")]
    [DefaultProperty("TransportAddress")]
    public class Transport : IXafEntityObject, IObjectSpaceLink, INotifyPropertyChanged
    {
        public Transport()
        {
            TransportIncomeExpenseDetails = new List<TransportIncomeExpense>();
            Products = new List<ListProduct>();
        }
        [Browsable(false)]  // Hide the entity identifier from UI.
        public int Id { get; protected set; }
        
        public string RegisteredUser { get; set; }
        [RuleRequiredField]
        public DateTime TransportDate { get; set; }
        public string Explanition { get; set; }
        [Browsable(false)]
        public int? TransportCompanyId;
        [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
        [RuleRequiredField]
        public virtual TransportCompany TransportCompany { get; set; }

        public virtual TransportAddress TransportAddress { get; set; }

        //[RuleFromBoolProperty("CheckType", "Save", CustomMessageTemplate = "En az bir tane gelir ve gider kaydı olmalı!")]
        //public bool CheckType
        //{
        //    get
        //    {
        //        bool result = false;

        //        bool incomeExists = false;
        //        bool expenseExists = false;

        //        foreach (var item in TransportIncomeExpenseDetails)
        //        {
        //            if ((item.Type != null) && (item.Type == TransportIncomeExpenseTypes.Income))
        //            {
        //                incomeExists = true;
        //            }
        //            if ((item.Type != null) && (item.Type == TransportIncomeExpenseTypes.Expense))
        //            {
        //                expenseExists = true;
        //            }
        //        }

        //        result = (incomeExists && expenseExists);

        //        //return result;

        //        return true;
        //    }
        //}

        public double TotalIncomes 
        { 
            get
            {
                double total = 0;
                foreach (var item in TransportIncomeExpenseDetails)
                {
                    if (item.Type == TransportIncomeExpenseTypes.Income)
                    {
                        total += item.Quantity * item.Amount;
                    }
                }

                return total;
            }
         }
        
        public double TotalExpenses
        {
            get
            {
                double total = 0;
                foreach (var item in TransportIncomeExpenseDetails)
                {
                    if (item.Type == TransportIncomeExpenseTypes.Expense)
                    {
                        total += item.Quantity * item.Amount;
                    }
                    
                }
                return total;
            }
        }
        public double TotalBalances
        {
            get
            {
                /*
                double balance = 0;
                balance = (TotalIncomes - TotalBalances);
                return balance;
                */

                return (TotalIncomes - TotalExpenses);
            }
        }

        [Aggregated]
        public virtual IList<ListProduct> Products { get; set; }

        [Aggregated]
        public virtual IList<TransportIncomeExpense> TransportIncomeExpenseDetails { get; set; }


        #region IXafEntityObject members (see https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppIXafEntityObjecttopic.aspx)
        void IXafEntityObject.OnCreated()
        {
            // Place the entity initialization code here.
            // You can initialize reference properties using Object Space methods; e.g.:
            // this.Address = objectSpace.CreateObject<Address>();
        }
        void IXafEntityObject.OnLoaded()
        {
            // Place the code that is executed each time the entity is loaded here.
        }
        void IXafEntityObject.OnSaving()
        {
            // Place the code that is executed each time the entity is saved here.

        }
        #endregion

        #region IObjectSpaceLink members (see https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppIObjectSpaceLinktopic.aspx)
        // Use the Object Space to access other entities from IXafEntityObject methods (see https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113707.aspx).
        private IObjectSpace objectSpace;
        IObjectSpace IObjectSpaceLink.ObjectSpace
        {
            get { return objectSpace; }
            set { objectSpace = value; }
        }
        #endregion

        #region INotifyPropertyChanged members (see http://msdn.microsoft.com/en-us/library/system.componentmodel.inotifypropertychanged(v=vs.110).aspx)
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}
