namespace Fatura.Module.Web.Controllers
{
    partial class WaybillListDetailDCViewController
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
            this.WaybillListDetailDCViewController_EditAction = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            this.WaybillListDetailDCViewController_DeleteAction = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // WaybillListDetailDCViewController_EditAction
            // 
            this.WaybillListDetailDCViewController_EditAction.Caption = "Düzelt";
            this.WaybillListDetailDCViewController_EditAction.ConfirmationMessage = null;
            this.WaybillListDetailDCViewController_EditAction.Id = "WaybillListDetailDCViewController_EditAction";
            this.WaybillListDetailDCViewController_EditAction.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireSingleObject;
            this.WaybillListDetailDCViewController_EditAction.ToolTip = null;
            this.WaybillListDetailDCViewController_EditAction.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.WaybillListDetailDCViewController_EditAction_Execute);
            // 
            // WaybillListDetailDCViewController_DeleteAction
            // 
            this.WaybillListDetailDCViewController_DeleteAction.Caption = "Sil";
            this.WaybillListDetailDCViewController_DeleteAction.ConfirmationMessage = "Silmek istediğine emin misin?";
            this.WaybillListDetailDCViewController_DeleteAction.Id = "WaybillListDetailDCViewController_DeleteAction";
            this.WaybillListDetailDCViewController_DeleteAction.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireSingleObject;
            this.WaybillListDetailDCViewController_DeleteAction.ToolTip = null;
            this.WaybillListDetailDCViewController_DeleteAction.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.WaybillListDetailDCViewController_DeleteAction_Execute);
            // 
            // WaybillListDetailDCViewController
            // 
            this.Actions.Add(this.WaybillListDetailDCViewController_EditAction);
            this.Actions.Add(this.WaybillListDetailDCViewController_DeleteAction);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction WaybillListDetailDCViewController_EditAction;
        private DevExpress.ExpressApp.Actions.SimpleAction WaybillListDetailDCViewController_DeleteAction;
    }
}
