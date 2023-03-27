﻿using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Persistent.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Fatura.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem(groupName: "Proje")]
    public class TransportIncomeExpense : IXafEntityObject, IObjectSpaceLink, INotifyPropertyChanged
    {
        public TransportIncomeExpense()
        {

        }
        [Browsable(false)]  // Hide the entity identifier from UI.
        public int Id { get; protected set; }
        [RuleRequiredField]
        public TransportIncomeExpenseTypes? Type { get; set; }
        [RuleRequiredField]
        public double Quantity { get; set; }

        [RuleRequiredField]
        public double Amount { get; set; }
        public virtual TransportService TransportService { get; set; }

        //[RuleFromBoolProperty("CheckType", "Save", CustomMessageTemplate = " Sadece bir kayıttan fatura oluşturabilirsiniz.")]
        //public bool CheckType

        //{
        //    get
        //    {
        //        bool result = true;

        //        bool incomeExists = false;
        //        bool expenseExists = false;


                
        //            if ((Type != null) && (Type == TransportIncomeExpenseTypes.Income))
        //            {
        //                incomeExists = true;
        //            }
        //            if ((Type != null) && (Type == TransportIncomeExpenseTypes.Expense))
        //            {
        //                expenseExists = true;
        //            }
                
        //        if (result = (incomeExists && expenseExists))
        //        {
        //            result = false;
        //        }

        //        return result;
        //    }
        //}

        public double TotalIncome
        {
            get
            {
                double GetTotalIncome = 0;


                GetTotalIncome = GetTotalIncome + (Amount * Quantity);
                
                return GetTotalIncome;
            }
        }
        public double TotalExpense
        {
            get
            {
                double GetTotalExpense = 0;

                GetTotalExpense = GetTotalExpense + (Quantity * Amount);


                return GetTotalExpense;
            }
        }
        public double TotalBalance
        {
            get
            {
                double GetTotalBalance = 0;
                
                GetTotalBalance = GetTotalBalance + (TotalIncome - TotalExpense);
                
                
                return GetTotalBalance;
            }
        }



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