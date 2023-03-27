namespace Fatura.Module.Web.Controllers
{
    partial class WaybillViewController
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.WaybillViewController_TestAction = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            this.WaybillViewController_Test2Action = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            this.WaybillViewController_CopyAction = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // WaybillViewController_TestAction
            // 
            this.WaybillViewController_TestAction.Caption = "Deneme";
            this.WaybillViewController_TestAction.ConfirmationMessage = null;
            this.WaybillViewController_TestAction.Id = "WaybillViewController_TestAction";
            this.WaybillViewController_TestAction.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireSingleObject;
            this.WaybillViewController_TestAction.ToolTip = null;
            this.WaybillViewController_TestAction.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.WaybillViewController_TestAction_Execute);
            // 
            // WaybillViewController_Test2Action
            // 
            this.WaybillViewController_Test2Action.Caption = "Test 2";
            this.WaybillViewController_Test2Action.ConfirmationMessage = null;
            this.WaybillViewController_Test2Action.Id = "WaybillViewController_Test2Action";
            this.WaybillViewController_Test2Action.ToolTip = null;
            this.WaybillViewController_Test2Action.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.WaybillViewController_Test2Action_Execute);
            // 
            // WaybillViewController_CopyAction
            // 
            this.WaybillViewController_CopyAction.Caption = "Copy";
            this.WaybillViewController_CopyAction.ConfirmationMessage = null;
            this.WaybillViewController_CopyAction.Id = "WaybillViewController_CopyAction";
            this.WaybillViewController_CopyAction.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireSingleObject;
            this.WaybillViewController_CopyAction.ToolTip = null;
            this.WaybillViewController_CopyAction.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.WaybillViewController_CopyAction_Execute);
            // 
            // WaybillViewController
            // 
            this.Actions.Add(this.WaybillViewController_TestAction);
            this.Actions.Add(this.WaybillViewController_Test2Action);
            this.Actions.Add(this.WaybillViewController_CopyAction);
            this.Tag = "ClearContactTasksController";
            this.TargetObjectType = typeof(Fatura.Module.BusinessObjects.Contact);
            this.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView;

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction WaybillViewController_TestAction;
        private DevExpress.ExpressApp.Actions.SimpleAction WaybillViewController_Test2Action;
        private DevExpress.ExpressApp.Actions.SimpleAction WaybillViewController_CopyAction;
    }
}
