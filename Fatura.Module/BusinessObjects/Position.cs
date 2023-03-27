﻿using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Persistent.Validation;
using DevExpress.Utils.Base;
using DevExpress.XtraPrinting.Native;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Contexts;
using System.Text;


namespace Fatura.Module.BusinessObjects
{
    [DefaultClassOptions]
    [DefaultProperty(nameof(Title))]

    [Appearance("TitleColoredInListView", AppearanceItemType = "ViewItem", TargetItems = "Title",
    Criteria = "Title = 'Developer'", Context = "ListView", FontColor = "Blue", Priority = 1)]

    [Appearance("TitleColoredInDetailView", AppearanceItemType = "LayoutItem",
         TargetItems = "Title", Criteria = "Title = 'Developer'", Context = "DetailView",
             FontColor = "Blue")]

    [Appearance("TitleGroupColoredInDetailView", AppearanceItemType = "LayoutItem",
    TargetItems = "Title", Criteria = "Title = 'Database Analyst'",
     Context = "Position_DetailView", FontColor = "Blue")]


    public class Position : IXafEntityObject, IObjectSpaceLink, INotifyPropertyChanged
    {
        
        public Position()
        {
            Contacts = new List<Contact>();
            Departments = new List<Department>();

        }
        [Browsable(false)]
        public int Id { get; protected set; }

        [RuleRequiredField(DefaultContexts.Save)]
        public string Title { get; set; }
        public virtual IList<Contact> Contacts { get; set; }

        public virtual IList<Department> Departments { get; set; }
        


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
