namespace Fatura.Module.Web.Controllers
{
    partial class TransportViewController
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
            this.TransportViewController_CopyAction = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // TransportViewController_CopyAction
            // 
            this.TransportViewController_CopyAction.Caption = "Copy";
            this.TransportViewController_CopyAction.ConfirmationMessage = null;
            this.TransportViewController_CopyAction.Id = "TransportViewController_CopyAction";
            this.TransportViewController_CopyAction.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireMultipleObjects;
            this.TransportViewController_CopyAction.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.TransportViewController_CopyAction.ToolTip = null;
            this.TransportViewController_CopyAction.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
            this.TransportViewController_CopyAction.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.TransportViewController_CopyAction_Execute);
            // 
            // TransportViewController
            // 
            this.Actions.Add(this.TransportViewController_CopyAction);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction TransportViewController_CopyAction;
    }
}
