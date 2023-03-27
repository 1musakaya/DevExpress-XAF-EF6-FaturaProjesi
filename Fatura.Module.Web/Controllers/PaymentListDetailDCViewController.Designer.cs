namespace Fatura.Module.Web.Controllers
{
    partial class PaymentListDetailDCViewController
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
            this.PaymentListDetailDcViewController_EditAction = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // PaymentListDetailDcViewController_EditAction
            // 
            this.PaymentListDetailDcViewController_EditAction.Caption = "Düzenle";
            this.PaymentListDetailDcViewController_EditAction.ConfirmationMessage = null;
            this.PaymentListDetailDcViewController_EditAction.Id = "PaymentListDetailDcViewController_EditAction";
            this.PaymentListDetailDcViewController_EditAction.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireSingleObject;
            this.PaymentListDetailDcViewController_EditAction.ToolTip = null;
            this.PaymentListDetailDcViewController_EditAction.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.PaymentListDetailDcViewController_EditAction_Execute);
            // 
            // PaymentListDetailDCViewController
            // 
            this.Actions.Add(this.PaymentListDetailDcViewController_EditAction);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction PaymentListDetailDcViewController_EditAction;
    }
}
