using DevExpress.Persistent.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.ExpressApp;
using DevExpress.Persistent.Validation;

namespace Fatura.Module.BusinessObjects
{
    [DefaultClassOptions, ImageName("BO_SaleItem")]
    public class Payment: IXafEntityObject
    {
        [Browsable(false)]
        public int Id { get; protected set; }
        public double Rate { get; set; }
        public double Hours { get; set; }

        [NotMapped]
        public double Amount
        {
            get { return Rate * Hours; }
            set { Rate = value; }
        }

        public double Total { get; set; }

        public void OnCreated()
        {
            
        }

        public void OnLoaded()
        {
           
        }

        public void OnSaving()
        {
            Total = Rate * Hours;
        }
        //[RuleFromBoolProperty("IsSaving","Save", CustomMessageTemplate =)]
        //public bool IsSaving 
        //{ 
        //    get
        //    {
        //        bool sonuc = true;


        //    } 
        //}
    }
}
