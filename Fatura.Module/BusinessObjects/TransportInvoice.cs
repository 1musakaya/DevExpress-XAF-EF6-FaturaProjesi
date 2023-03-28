using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Persistent.Validation;
using DevExpress.XtraRichEdit.Layout;
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
    public class TransportInvoice : IXafEntityObject, IObjectSpaceLink, INotifyPropertyChanged
    {
        public TransportInvoice()
        {
            Details=new List<TransportInvoiceDetail>(); 
        }
        [Browsable(false)]  // Hide the entity identifier from UI.
        public int Id { get; protected set; }
        [RuleRequiredField]
        public TransportIncomeExpenseTypes? Type { get; set; }
        [RuleRequiredField]
        public DateTime InvoiceDate { get; set; }
        [RuleRequiredField]
        public virtual TransportAddress InvoiceAddress { get; set; }
        [RuleRequiredField]
        public virtual TransportCompany TransportCompany { get; set; }

        public double Total 
        {
            get
            {
                double tot = 0;

                foreach (var item in Details)
                {
                    tot = tot + (item.Quantity * item.Price);
                }
                return tot;
            }
        }
        [RuleFromBoolProperty("CheckTotal", "Save", CustomMessageTemplate = "Toplam 500'den fazla olamaz!!")]
        public bool CheckTotal 
        { 
            get
            {
                bool end = true;

                double total = 0;

                foreach (var item in Details)
                {
                    total = total + (item.Quantity * item.Price);
                }

                if (total > 500)
                {
                    end= false;
                }

               return end;
            } 
           
        }


        [Aggregated]
        public virtual IList<TransportInvoiceDetail> Details { get; set; }

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
