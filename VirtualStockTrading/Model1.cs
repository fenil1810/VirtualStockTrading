namespace VirtualStockTrading
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<AdminLogin> AdminLogins { get; set; }
        public virtual DbSet<BuyingTable> BuyingTables { get; set; }
        public virtual DbSet<OrderTable> OrderTables { get; set; }
        public virtual DbSet<Portfolio> Portfolios { get; set; }
        public virtual DbSet<SellingTable> SellingTables { get; set; }
        public virtual DbSet<StockData> StockDatas { get; set; }
        public virtual DbSet<StockPrice> StockPrices { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<UserInformation> UserInformations { get; set; }
        public virtual DbSet<UserLogin> UserLogins { get; set; }
        public virtual DbSet<Valuation> Valuations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminLogin>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<AdminLogin>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<BuyingTable>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<BuyingTable>()
                .Property(e => e.PriceType)
                .IsUnicode(false);

            modelBuilder.Entity<OrderTable>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<OrderTable>()
                .Property(e => e.TransactionType)
                .IsUnicode(false);

            modelBuilder.Entity<Portfolio>()
                .Property(e => e.StockName)
                .IsUnicode(false);

            modelBuilder.Entity<SellingTable>()
                .Property(e => e.TimeStamp)
                .IsFixedLength();

            modelBuilder.Entity<StockData>()
                .Property(e => e.MarketPrice)
                .HasPrecision(14, 4);

            modelBuilder.Entity<StockData>()
                .Property(e => e.TotalVolume)
                .HasPrecision(14, 4);

            modelBuilder.Entity<StockData>()
                .HasMany(e => e.BuyingTables)
                .WithRequired(e => e.StockData)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StockData>()
                .HasMany(e => e.OrderTables)
                .WithRequired(e => e.StockData)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StockData>()
                .HasMany(e => e.SellingTables)
                .WithRequired(e => e.StockData)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StockData>()
                .HasMany(e => e.StockPrices)
                .WithRequired(e => e.StockData)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserInformation>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<UserInformation>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<UserInformation>()
                .Property(e => e.HouseNo)
                .IsUnicode(false);

            modelBuilder.Entity<UserInformation>()
                .Property(e => e.Society)
                .IsUnicode(false);

            modelBuilder.Entity<UserInformation>()
                .Property(e => e.Landmark)
                .IsUnicode(false);

            modelBuilder.Entity<UserInformation>()
                .Property(e => e.Area)
                .IsUnicode(false);

            modelBuilder.Entity<UserInformation>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<UserInformation>()
                .Property(e => e.State)
                .IsUnicode(false);

            modelBuilder.Entity<UserInformation>()
                .Property(e => e.Mobile)
                .HasPrecision(10, 0);

            modelBuilder.Entity<UserInformation>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<UserInformation>()
                .Property(e => e.Gender)
                .IsUnicode(false);

            modelBuilder.Entity<UserInformation>()
                .HasMany(e => e.BuyingTables)
                .WithRequired(e => e.UserInformation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserInformation>()
                .HasMany(e => e.OrderTables)
                .WithRequired(e => e.UserInformation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserInformation>()
                .HasMany(e => e.Portfolios)
                .WithRequired(e => e.UserInformation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserInformation>()
                .HasMany(e => e.SellingTables)
                .WithRequired(e => e.UserInformation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserInformation>()
                .HasMany(e => e.Valuations)
                .WithRequired(e => e.UserInformation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserLogin>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<UserLogin>()
                .Property(e => e.Password)
                .IsUnicode(false);
        }
    }
}
