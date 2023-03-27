namespace Fatura.Module.Web.Controllers
{
    partial class PaymentListDCViewController
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
            this.PaymenListDCViewController_ActionList = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // PaymenListDCViewController_ActionList
            // 
            this.PaymenListDCViewController_ActionList.Caption = "List";
            this.PaymenListDCViewController_ActionList.Category = "PaymentListActionCategory";
            this.PaymenListDCViewController_ActionList.Id = "PaymenListDCViewController_ActionList";
            this.PaymenListDCViewController_ActionList.ToolTip = null;
            this.PaymenListDCViewController_ActionList.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.PaymenListDCViewController_ActionList_Execute);
            // 
            // PaymentListDCViewController
            // 
            this.Actions.Add(this.PaymenListDCViewController_ActionList);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction PaymenListDCViewController_ActionList;
    }
}
