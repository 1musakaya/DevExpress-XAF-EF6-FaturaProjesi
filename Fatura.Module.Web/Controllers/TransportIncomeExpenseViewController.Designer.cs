namespace Fatura.Module.Web.Controllers
{
    partial class TransportIncomeExpenseViewController
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
            this.TransportIncomeExpenseDetailViewController_CreateAction = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // TransportIncomeExpenseDetailViewController_CreateAction
            // 
            this.TransportIncomeExpenseDetailViewController_CreateAction.Caption = "Create Invoice";
            this.TransportIncomeExpenseDetailViewController_CreateAction.ConfirmationMessage = null;
            this.TransportIncomeExpenseDetailViewController_CreateAction.Id = "TransportIncomeExpenseDetailViewController_CreateAction";
            this.TransportIncomeExpenseDetailViewController_CreateAction.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireMultipleObjects;
            this.TransportIncomeExpenseDetailViewController_CreateAction.TargetViewType = DevExpress.ExpressApp.ViewType.ListView;
            this.TransportIncomeExpenseDetailViewController_CreateAction.ToolTip = null;
            this.TransportIncomeExpenseDetailViewController_CreateAction.TypeOfView = typeof(DevExpress.ExpressApp.ListView);
            this.TransportIncomeExpenseDetailViewController_CreateAction.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.TransportIncomeExpenseDetailViewController_CreateAction_Execute);
            // 
            // TransportIncomeExpenseViewController
            // 
            this.Actions.Add(this.TransportIncomeExpenseDetailViewController_CreateAction);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction TransportIncomeExpenseDetailViewController_CreateAction;
    }
}
