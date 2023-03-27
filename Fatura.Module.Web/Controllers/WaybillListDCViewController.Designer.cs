namespace Fatura.Module.Web.Controllers
{
    partial class WaybillListDCViewController
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
            this.WaybillListDCViewController_ListAction = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // WaybillListDCViewController_ListAction
            // 
            this.WaybillListDCViewController_ListAction.Caption = "List";
            this.WaybillListDCViewController_ListAction.Category = "WaybillListActionCategory";
            this.WaybillListDCViewController_ListAction.ConfirmationMessage = null;
            this.WaybillListDCViewController_ListAction.Id = "WaybillListDCViewController_ListAction";
            this.WaybillListDCViewController_ListAction.ToolTip = null;
            this.WaybillListDCViewController_ListAction.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.WaybillListDCViewController_ListAction_Execute);
            // 
            // WaybillListDCViewController
            // 
            this.Actions.Add(this.WaybillListDCViewController_ListAction);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction WaybillListDCViewController_ListAction;
    }
}
