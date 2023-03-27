namespace Fatura.Module.Web.Controllers
{
    partial class WaybillDetailListViewController
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
            this.WaybillDetailListViewContoller_CopyAction = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // WaybillDetailListViewContoller_CopyAction
            // 
            this.WaybillDetailListViewContoller_CopyAction.Caption = "Copy ";
            this.WaybillDetailListViewContoller_CopyAction.ConfirmationMessage = null;
            this.WaybillDetailListViewContoller_CopyAction.Id = "WaybillDetailListViewContoller_CopyAction";
            this.WaybillDetailListViewContoller_CopyAction.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireSingleObject;
            this.WaybillDetailListViewContoller_CopyAction.ToolTip = null;
            this.WaybillDetailListViewContoller_CopyAction.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.WaybillDetailListViewContoller_CopyAction_Execute);
            // 
            // WaybillDetailListViewController
            // 
            this.Actions.Add(this.WaybillDetailListViewContoller_CopyAction);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction WaybillDetailListViewContoller_CopyAction;
    }
}
