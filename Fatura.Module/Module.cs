using System;
using System.Text;
using System.Linq;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using System.Collections.Generic;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Model.Core;
using DevExpress.ExpressApp.Model.DomainLogics;
using DevExpress.ExpressApp.Model.NodeGenerators;
using System.Data.Entity;   
using Fatura.Module.BusinessObjects;
using DevExpress.ExpressApp.ReportsV2;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp.Validation;
using DevExpress.XtraReports.UI;


namespace Fatura.Module {
    // For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.ModuleBase.
    public sealed partial class FaturaModule : ModuleBase {
       
        static FaturaModule() {
            
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<FaturaDbContext>());      

            DevExpress.Data.Linq.CriteriaToEFExpressionConverter.SqlFunctionsType = typeof(System.Data.Entity.SqlServer.SqlFunctions);
			DevExpress.Data.Linq.CriteriaToEFExpressionConverter.EntityFunctionsType = typeof(System.Data.Entity.DbFunctions);
			DevExpress.ExpressApp.SystemModule.ResetViewSettingsController.DefaultAllowRecreateView = false;

        }
        public FaturaModule() {
            InitializeComponent();
			DevExpress.ExpressApp.Security.SecurityModule.UsedExportedTypes = DevExpress.Persistent.Base.UsedExportedTypes.Custom;
			AdditionalExportedTypes.Add(typeof(DevExpress.Persistent.BaseImpl.EF.FileData));
			AdditionalExportedTypes.Add(typeof(DevExpress.Persistent.BaseImpl.EF.FileAttachment));
			AdditionalExportedTypes.Add(typeof(DevExpress.Persistent.BaseImpl.EF.Analysis));
            AdditionalExportedTypes.Add(typeof(Event));
            AdditionalExportedTypes.Add(typeof(Resource));
            EnumProcessingHelper.RegisterEnum(typeof(Fatura.Module.BusinessObjects.Priority));
            RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.ReportsV2.ReportsModuleV2));
        }
        public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB) {
            ModuleUpdater updater = new DatabaseUpdate.Updater(objectSpace, versionFromDB);
            return new ModuleUpdater[] { updater, }; 
        }
        public override void Setup(XafApplication application) {
            base.Setup(application);
           
            // Manage various aspects of the application UI and behavior at the module level.
        }
        public override void Setup(ApplicationModulesManager moduleManager) {
            base.Setup(moduleManager);
			ReportsModuleV2 reportModule = moduleManager.Modules.FindModule<ReportsModuleV2>();
            reportModule.ReportDataType = typeof(DevExpress.Persistent.BaseImpl.EF.ReportDataV2);
		}
        //private void Application_SetupComplete(object sender, EventArgs e)
        //{
        //    Application.ObjectSpaceCreated += Application_ObjectSpaceCreated;
        //}
        //private void Application_ObjectSpaceCreated(object sender, ObjectSpaceCreatedEventArgs e)
        //{
        //    var nonPersistentObjectSpace = e.ObjectSpace as NonPersistentObjectSpace;
        //    if (nonPersistentObjectSpace != null)
        //    {
        //        nonPersistentObjectSpace.ObjectsGetting += ObjectSpace_ObjectsGetting;
        //    }
        //}
        //private void ObjectSpace_ObjectsGetting(Object sender, ObjectsGettingEventArgs e)
        //{
        //    if (e.ObjectType == typeof(InvoiceFilterDC))
        //    {
        //        BindingList<InvoiceFilterDC> objects = new BindingList<InvoiceFilterDC>();

        //        ((InvoiceFilterDC)objects).Company = "";
                
        //        e.Objects = objects;
        //    }
        //}

    }

}

