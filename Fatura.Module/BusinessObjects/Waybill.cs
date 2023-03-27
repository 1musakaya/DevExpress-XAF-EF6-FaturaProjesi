using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Persistent.Validation;
using DevExpress.Portable;
using DevExpress.Xpo.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Fatura.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem(GroupName = "BenimMenu")]
    public class Waybill : IXafEntityObject, IObjectSpaceLink, INotifyPropertyChanged
    {
        public Waybill()
        {
            Details = new List<WaybillDetail>();    
        }

        [VisibleInDetailView(false)]
        public int Id { get; protected set; }

        [RuleRequiredField] 
        public DateTime WaybillDate { get; set; }

        [RuleRequiredField] // Alanın null olamayacağını söyler.
        public string WaybillNo { get; set; }

        [Browsable(false)]  // Kullanıcı arayüzünde gorunmesini istemediğimiz alanları gizlemek için kullanırız.
        public int? CompanyId { get; set; }  // alanın null olabileceğini söyler. 

        private Company company;
        [ImmediatePostData]
        [RuleRequiredField]
        [DataSourceCriteria("Active=true")]
        //[LookupEditorMode(LookupEditorMode.Search)]
        [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
        public virtual Company Company
        {
            get{ return company; }
            set 
            { 
                company = value;
                OnPropertyChanged("Company");
            }
        }       
        public string Address { get; set; }


        [Aggregated] // Listeyle ilgili bir alan silinirse kayıt ilişkili olduğu her yerden silinir ve kulanılmazsa link gelir.
        public virtual IList<WaybillDetail> Details { get; set; }

 


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
