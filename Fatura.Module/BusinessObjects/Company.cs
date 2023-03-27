﻿using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Persistent.Validation;
using DevExpress.PivotGrid.CriteriaVisitors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Fatura.Module.BusinessObjects
{
    [DefaultClassOptions]
    [NavigationItem(groupName:"BenimMenu")]
    [RuleCriteria("RuleCriteria for Company", DefaultContexts.Save,
    "Address is not null", SkipNullOrEmptyValues = false)]
    public class Company : IXafEntityObject, IObjectSpaceLink, INotifyPropertyChanged
    {
        public Company()
        {
        }
        public int Id { get; protected set; }
        [RuleRequiredField]
        public string Name { get; set; }
        [RuleRequiredField("RuleRequiredField for Company.Address",DefaultContexts.Save)]        
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public bool Active { get; set; }

        private Ulke ulke;

        [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
        [ImmediatePostData]
        public virtual Ulke Ulke 
        { 
            get
            { 
                return ulke; 
            }
            set
            {
                ulke= value;
                OnPropertyChanged("Ulke");
            }
        }

        [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
        [DataSourceCriteria("Country='@Ulke'")]

        //[Appearance(null, Visibility = DevExpress.ExpressApp.Editors.ViewItemVisibility.Hide, Criteria = "Ulke.Name='Almanya'")]
        public virtual City Sehir { get; set; }



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
