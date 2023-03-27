using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fatura.Module.BusinessObjects
{
    [ImageName("BO_FileAttachment")]
    public class PortfolioFileData : FileAttachment
    {
        public PortfolioFileData(): base()
        {
            DocumentType = DocumentType.Unknown;
        }

        [Browsable(false)]
        public int DocumentType_Int { get; protected set; }
        [System.ComponentModel.DataAnnotations.Required]
        public virtual Resume Resume { get; set; }

        [NotMapped]
        public DocumentType DocumentType
        {
            get { return (DocumentType)DocumentType_Int; }
            set { DocumentType_Int = (int)value; }
        }
    }
    public enum DocumentType
    {
        SourceCode = 1, Tests = 2, Documentation = 3,
        Diagrams = 4, ScreenShots = 5, Unknown = 6
    };
}
