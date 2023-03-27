using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using Fatura.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Fatura.Module.Web.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class WaybillDetailDetailViewController : ViewController
    {
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public WaybillDetailDetailViewController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
            TargetObjectType = typeof(WaybillDetail);
            TargetViewType = ViewType.DetailView;
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
            var pe = ((DetailView)View).FindItem("Quantity");
            if (pe != null)
            {
                ((PropertyEditor)pe).ControlValueChanged += WaybillDetailDetailViewController_QuantityControlValueChanged;
            }
            pe = ((DetailView)View).FindItem("Price");
            if (pe != null)
            {
                ((PropertyEditor)pe).ControlValueChanged += WaybillDetailDetailViewController_PriceControlValueChanged;
            }

            pe = ((DetailView)View).FindItem("Product");
            if (pe != null)
            {
                ((PropertyEditor)pe).ControlValueChanged += WaybillDetailDetailViewController_ProductControlValueChanged;
            }
          
            
        }

        
        
        private void WaybillDetailDetailViewController_ProductControlValueChanged(object sender, EventArgs e)
        {
            var cv = ((PropertyEditor)sender).ControlValue as WaybillProduct;

            var cobj = ((DetailView)View).CurrentObject as WaybillDetail;

            if (cv != null)
            {
                cobj.Kdv = cv.Kdv;
                cobj.Total = cobj.Quantity * cobj.Price * (1 + cv.Kdv / 100);

            }
        }

        private void WaybillDetailDetailViewController_PriceControlValueChanged(object sender, EventArgs e)
        {
            var cv = ((PropertyEditor)sender).ControlValue as double?;

            var cobj = ((DetailView)View).CurrentObject as WaybillDetail;

            if (cobj != null && cv != null)
            {
              
                cobj.Total = cobj.Quantity * (double)cv * (1+ cobj.Product.Kdv/100);
            }
        }

        private void WaybillDetailDetailViewController_QuantityControlValueChanged(object sender, EventArgs e)
        {
            var cv = ((PropertyEditor)sender).ControlValue as double?;

            var cobj = ((DetailView)View).CurrentObject as WaybillDetail;

            if (cobj != null && cv != null)
            {
                cobj.Total = cobj.Price * (double)cv * (1+ cobj.Product.Kdv / 100);

            }

        }

        protected override void OnViewControlsCreated()
        {
            
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            var pe = ((DetailView)View).FindItem("Quantity");
            if (pe != null)
            {
                ((PropertyEditor)pe).ControlValueChanged -= WaybillDetailDetailViewController_QuantityControlValueChanged;
            }
            pe = ((DetailView)View).FindItem("Price");
            if (pe != null)
            {
                ((PropertyEditor)pe).ControlValueChanged -= WaybillDetailDetailViewController_PriceControlValueChanged;
            }
            pe = ((DetailView)View).FindItem("Product");
            if (pe != null)
            {
                ((PropertyEditor)pe).ControlValueChanged -= WaybillDetailDetailViewController_ProductControlValueChanged;
            }
         

            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }

    }
}
