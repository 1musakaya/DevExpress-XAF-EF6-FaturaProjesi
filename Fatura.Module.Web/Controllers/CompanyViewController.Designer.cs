namespace Fatura.Module.Web.Controllers
{
    partial class CompanyViewController
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
            this.CompanyViewController_CopyAction = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            this.CompanyViewController_TestAction = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // CompanyViewController_CopyAction
            // 
            this.CompanyViewController_CopyAction.Caption = "Copy";
            this.CompanyViewController_CopyAction.ConfirmationMessage = null;
            this.CompanyViewController_CopyAction.Id = "CompanyViewController_CopyAction";
            this.CompanyViewController_CopyAction.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireSingleObject;
            this.CompanyViewController_CopyAction.ToolTip = null;
            this.CompanyViewController_CopyAction.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.CompanyViewController_CopyAction_Execute);
            // 
            // CompanyViewController_TestAction
            // 
            this.CompanyViewController_TestAction.Caption = "Test";
            this.CompanyViewController_TestAction.ConfirmationMessage = null;
            this.CompanyViewController_TestAction.Id = "CompanyViewController_TestAction";
            this.CompanyViewController_TestAction.ToolTip = null;
            this.CompanyViewController_TestAction.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.CompanyViewController_TestAction_Execute);
            // 
            // CompanyViewController
            // 
            this.Actions.Add(this.CompanyViewController_CopyAction);
            this.Actions.Add(this.CompanyViewController_TestAction);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction CompanyViewController_CopyAction;
        private DevExpress.ExpressApp.Actions.SimpleAction CompanyViewController_TestAction;
    }
}
