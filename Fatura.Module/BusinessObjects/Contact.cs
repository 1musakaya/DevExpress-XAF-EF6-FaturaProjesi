using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.XtraSpellChecker.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Fatura.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class Contact : Person
    {

        public Contact()
        {
            Tasks = new List<DemoTask>();
            Subordinates = new List<Contact>();
            Resumes = new List<Resume>();
        }
        public string WebPageAddress { get; set; }
        public string NickName { get; set; }
        public string SpouseName { get; set; }
        public TitleOfCourtesy TitleOfCourtesy { get; set; }
        public DateTime? Anniversary { get; set; }
        [FieldSize(4096)]
        public string Notes { get; set; }
        public virtual Position Position { get; set; }
        public virtual IList<DemoTask> Tasks { get; set; }  
        public virtual Department Department { get; set; }
        //[DataSourceProperty("Department.Contacts")]
        //[DataSourceCriteria("Position.Title = 'Manager'")]
        public virtual Contact Manager { get; set; }
        public virtual IList<Contact> Subordinates { get; set; }

        public virtual IList<Resume> Resumes { get; set; }

    }
    public enum TitleOfCourtesy { Dr, Miss, Mr, Mrs, Ms };
}
