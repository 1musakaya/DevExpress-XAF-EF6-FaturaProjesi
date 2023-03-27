using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Persistent.Validation;
using DevExpress.XtraPrinting.Native;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Contexts;
using System.Text;

namespace Fatura.Module.BusinessObjects
{
    [Appearance("PriceColor", AppearanceItemType = "ViewItem", TargetItems = "Price",
       Criteria = "Price>50", Context = "ListView", BackColor = "Red",
           FontColor = "Maroon", Priority = 2)]
    
    public class WaybillDetail : IXafEntityObject, IObjectSpaceLink, INotifyPropertyChanged
    {
        public WaybillDetail()
        {

        }

        [Browsable(false)]
        public int Id { get; protected set; }

        [Browsable(false)]
        public int? ProductId { get; set; }

        private WaybillProduct product;
        [RuleRequiredField]
        [ImmediatePostData]
        public virtual WaybillProduct Product 
        { 
            get { return product; }
            set { product = value; OnPropertyChanged("Product"); } 
        }
        [NotMapped]
        public double Kdv { get; set; }


        private double quantity;
        [RuleRequiredField]
        [ImmediatePostData]
        public double Quantity {
            get 
            { 
                return quantity; 
            }
            set 
            {
                quantity= value;
                OnPropertyChanged("Quantity");
            }
        }
        private double price;

        [RuleRequiredField]
        [ImmediatePostData]

        public double Price {
            get 
            { 
                return price;
            } 
            set 
            { 
                price = value;
                OnPropertyChanged("Price");
            }
                
            }



        public double Total { get; set; }

        public void OnCreated()
        {

        }
        
        public void OnLoaded()
        {

        }

        public void OnSaving()
        {
            //Total = Quantity * Price;
        }
        
        [Browsable(false)]
        public int? WaybillId { get; set; }
        public virtual Waybill Waybill { get; set; }



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
