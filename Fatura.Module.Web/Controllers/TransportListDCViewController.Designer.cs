namespace Fatura.Module.Web.Controllers
{
    partial class TransportListDCViewController
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
            this.TransportListDCViewController_ListAction = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // TransportListDCViewController_ListAction
            // 
            this.TransportListDCViewController_ListAction.Caption = "List";
            this.TransportListDCViewController_ListAction.Category = "TransportListActionCategory";
            this.TransportListDCViewController_ListAction.ConfirmationMessage = null;
            this.TransportListDCViewController_ListAction.Id = "TransportListDCViewController_ListAction";
            this.TransportListDCViewController_ListAction.ToolTip = null;
            this.TransportListDCViewController_ListAction.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.TransportListDCViewController_ListAction_Execute);
            // 
            // TransportListDCViewController
            // 
            this.Actions.Add(this.TransportListDCViewController_ListAction);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction TransportListDCViewController_ListAction;
    }
}
