using System;
using System.Data;
using System.Linq;
using System.Data.Entity;
using System.Data.Common;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.ComponentModel;
using DevExpress.ExpressApp.EF.Updating;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.ExpressApp.Design;
using DevExpress.ExpressApp.EF.DesignTime;
using DevExpress.Persistent.BaseImpl.EF.PermissionPolicy;
using Fatura.Module.BusinessObjects;

namespace Fatura.Module.BusinessObjects {
	
    public class FaturaDbContext : DbContext {

        
        
        public FaturaDbContext(): base("FaturaDbContext")
		{
			Database.SetInitializer(new MigrateDatabaseToLatestVersion<FaturaDbContext, Migrations.Configuration>());
		}

		public FaturaDbContext(String connectionString)
			: base(connectionString)
		{
		}
		public FaturaDbContext(DbConnection connection)
			: base(connection, false)
		{
		}
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			//Database.SetInitializer<FaturaDbContext>(null);
			base.OnModelCreating(modelBuilder);
		}

		public DbSet<ModuleInfo> ModulesInfo { get; set; }
		public DbSet<PermissionPolicyRole> Roles { get; set; }
		public DbSet<PermissionPolicyTypePermissionObject> TypePermissionObjects { get; set; }
		public DbSet<PermissionPolicyUser> Users { get; set; }
		public DbSet<FileData> FileData { get; set; }
		public DbSet<DashboardData> DashboardData { get; set; }
		public DbSet<Analysis> Analysis { get; set; }
		public DbSet<ReportDataV2> ReportDataV2 { get; set; }
		public DbSet<ModelDifference> ModelDifferences { get; set; }
		public DbSet<ModelDifferenceAspect> ModelDifferenceAspects { get; set; }

		
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Testimonial> Testimonials { get; set; }
		
        public DbSet<Waybill> Waybills { get; set; }
		public DbSet<WaybillProduct>WaybillProducts { get; set; }
		public DbSet<Position> Positions { get; set; }
		public DbSet<Event> Events { get; set; }
		public DbSet<Resource> Resources { get; set; }
		public DbSet<DemoTask> TrackedTasks { get; set; }
		public DbSet<Department> Departments { get; set; }

        public DbSet<Note> Notes { get; set; }
		public DbSet<Payment> Payments { get; set; }
		public DbSet<Resume> Resumes { get; set; }
        public DbSet<PortfolioFileData> PortfolioFileData { get; set; }
        public DbSet<FileAttachment> FileAttachments { get; set; }

		public DbSet<Ulke> Ulkeler { get; set; }
		public DbSet<City> Cities { get; set; }

		public DbSet<WaybillProductGroups> Grouplar { get; set; }

		public DbSet<ProductGroup> Gruplar { get; set; }

		public DbSet<Transport> Transports { get; set; }
		public DbSet<TransportAddress> TransportAddresses { get; set; }
		public DbSet<TransportCompany> TransportCompanys { get; set; }
		public DbSet<TransportIncomeExpense> transportIncomeExpenses { get; set; }
		public DbSet<TransportInvoice> TransportInvoices { get; set; }
		public DbSet<TransportInvoiceDetail> TransportInvoiceDetails { get; set; }
		public DbSet<TransportProduct> TransportProducts { get; set; }
		public DbSet<TransportService> TransportServices { get; set; }
        public DbSet<ArrivalAddress> ArrivalAddresses { get; set; }
        public DbSet<ExitAddress> ExitAddresses { get; set; }



    }

}
