namespace Fatura.Module.Web.Controllers
{
    partial class PaymentViewController
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
            this.PaymentViewController_CopyAction = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // PaymentViewController_CopyAction
            // 
            this.PaymentViewController_CopyAction.Caption = "Copy";
            this.PaymentViewController_CopyAction.ConfirmationMessage = null;
            this.PaymentViewController_CopyAction.Id = "PaymentViewController_CopyAction";
            this.PaymentViewController_CopyAction.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireSingleObject;
            this.PaymentViewController_CopyAction.ToolTip = null;
            this.PaymentViewController_CopyAction.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.PaymentViewController_CopyAction_Execute);
            // 
            // PaymentViewController
            // 
            this.Actions.Add(this.PaymentViewController_CopyAction);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction PaymentViewController_CopyAction;
    }
}
