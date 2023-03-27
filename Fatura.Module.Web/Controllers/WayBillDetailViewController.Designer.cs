namespace Fatura.Module.Web.Controllers
{
    partial class WayBillDetailViewController
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
            this.WayBillDetailController_Detail = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // WayBillDetailController_Detail
            // 
            this.WayBillDetailController_Detail.Caption = "deneme2";
            this.WayBillDetailController_Detail.ConfirmationMessage = null;
            this.WayBillDetailController_Detail.Id = "WayBillDetailController_Detail";
            this.WayBillDetailController_Detail.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireMultipleObjects;
            this.WayBillDetailController_Detail.ToolTip = null;
            this.WayBillDetailController_Detail.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.WayBillDetailController_Detail_Execute);
            // 
            // WayBillDetailViewController
            // 
            this.Actions.Add(this.WayBillDetailController_Detail);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction WayBillDetailController_Detail;
    }
}
