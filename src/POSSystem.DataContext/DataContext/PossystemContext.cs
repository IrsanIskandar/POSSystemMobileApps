using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace POSSystem.DataContext.DataContext;

public partial class PossystemContext : DbContext
{
    public PossystemContext()
    {
    }

    public PossystemContext(DbContextOptions<PossystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admindatasetup> Admindatasetups { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Lookupproductcategory> Lookupproductcategories { get; set; }

    public virtual DbSet<Lookupunit> Lookupunits { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<Mstproductcatalog> Mstproductcatalogs { get; set; }

    public virtual DbSet<Trxorder> Trxorders { get; set; }

    public virtual DbSet<Trxpayment> Trxpayments { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Userdetail> Userdetails { get; set; }

    public virtual DbSet<VwListdatastaff> VwListdatastaffs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admindatasetup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("admindatasetup_pk");

            entity.ToTable("admindatasetup");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Createdby)
                .HasMaxLength(50)
                .HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasDefaultValueSql("now()")
                .HasColumnName("createddate");
            entity.Property(e => e.Isactive)
                .HasDefaultValue(true)
                .HasColumnName("isactive");
            entity.Property(e => e.Isdeleted)
                .HasDefaultValue(false)
                .HasColumnName("isdeleted");
            entity.Property(e => e.Modifyby)
                .HasMaxLength(50)
                .HasColumnName("modifyby");
            entity.Property(e => e.Modifydate).HasColumnName("modifydate");
            entity.Property(e => e.Nameeng)
                .HasMaxLength(255)
                .HasColumnName("nameeng");
            entity.Property(e => e.Nameidn)
                .HasMaxLength(255)
                .HasColumnName("nameidn");
            entity.Property(e => e.Parentid).HasColumnName("parentid");
            entity.Property(e => e.Remarks)
                .HasMaxLength(500)
                .HasColumnName("remarks");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("customer_pk");

            entity.ToTable("customer");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(500)
                .HasColumnName("address");
            entity.Property(e => e.Createdby)
                .HasMaxLength(50)
                .HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasDefaultValueSql("now()")
                .HasColumnName("createddate");
            entity.Property(e => e.Customername)
                .HasMaxLength(150)
                .HasColumnName("customername");
            entity.Property(e => e.Genderid).HasColumnName("genderid");
            entity.Property(e => e.Isactive)
                .HasDefaultValue(true)
                .HasColumnName("isactive");
            entity.Property(e => e.Isdeleted)
                .HasDefaultValue(false)
                .HasColumnName("isdeleted");
            entity.Property(e => e.Mobilephone).HasColumnName("mobilephone");
            entity.Property(e => e.Modifyby)
                .HasMaxLength(50)
                .HasColumnName("modifyby");
            entity.Property(e => e.Modifydate).HasColumnName("modifydate");

            entity.HasOne(d => d.Gender).WithMany(p => p.Customers)
                .HasForeignKey(d => d.Genderid)
                .HasConstraintName("customer__genderid_fk");
        });

        modelBuilder.Entity<Lookupproductcategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("lookupproductcategory_pk");

            entity.ToTable("lookupproductcategory");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Categorycode)
                .HasMaxLength(50)
                .HasColumnName("categorycode");
            entity.Property(e => e.Categoryname)
                .HasMaxLength(150)
                .HasColumnName("categoryname");
            entity.Property(e => e.Createdby)
                .HasMaxLength(50)
                .HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasDefaultValueSql("now()")
                .HasColumnName("createddate");
            entity.Property(e => e.Isactive)
                .HasDefaultValue(true)
                .HasColumnName("isactive");
            entity.Property(e => e.Isdeleted)
                .HasDefaultValue(false)
                .HasColumnName("isdeleted");
        });

        modelBuilder.Entity<Lookupunit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("lookupunit_pk");

            entity.ToTable("lookupunit");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Createby)
                .HasMaxLength(50)
                .HasColumnName("createby");
            entity.Property(e => e.Createddate)
                .HasDefaultValueSql("now()")
                .HasColumnName("createddate");
            entity.Property(e => e.Isactive)
                .HasDefaultValue(true)
                .HasColumnName("isactive");
            entity.Property(e => e.Isdeleted)
                .HasDefaultValue(false)
                .HasColumnName("isdeleted");
            entity.Property(e => e.Unitname)
                .HasMaxLength(150)
                .HasColumnName("unitname");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("menu_pk");

            entity.ToTable("menu");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Createdby)
                .HasMaxLength(50)
                .HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasDefaultValueSql("now()")
                .HasColumnName("createddate");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("description");
            entity.Property(e => e.Isactive)
                .HasDefaultValue(true)
                .HasColumnName("isactive");
            entity.Property(e => e.Isdeleted)
                .HasDefaultValue(false)
                .HasColumnName("isdeleted");
            entity.Property(e => e.Menuname)
                .HasMaxLength(150)
                .HasColumnName("menuname");
            entity.Property(e => e.Modifyby)
                .HasMaxLength(50)
                .HasColumnName("modifyby");
            entity.Property(e => e.Modifydate).HasColumnName("modifydate");
            entity.Property(e => e.Price).HasColumnName("price");
        });

        modelBuilder.Entity<Mstproductcatalog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("mstproductcatalog_pk");

            entity.ToTable("mstproductcatalog");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("nextval('mstproductid_seq'::regclass)")
                .HasColumnName("id");
            entity.Property(e => e.Categoryid).HasColumnName("categoryid");
            entity.Property(e => e.Createdby)
                .HasMaxLength(50)
                .HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasDefaultValueSql("now()")
                .HasColumnName("createddate");
            entity.Property(e => e.Isactive)
                .HasDefaultValue(true)
                .HasColumnName("isactive");
            entity.Property(e => e.Isdeleted)
                .HasDefaultValue(false)
                .HasColumnName("isdeleted");
            entity.Property(e => e.Modifyby)
                .HasMaxLength(50)
                .HasColumnName("modifyby");
            entity.Property(e => e.Modifydate).HasColumnName("modifydate");
            entity.Property(e => e.Poductimagepath)
                .HasMaxLength(255)
                .HasColumnName("poductimagepath");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Productcode)
                .HasMaxLength(25)
                .HasColumnName("productcode");
            entity.Property(e => e.Productname)
                .HasMaxLength(150)
                .HasColumnName("productname");
            entity.Property(e => e.Remarks)
                .HasMaxLength(1500)
                .HasColumnName("remarks");
            entity.Property(e => e.Stockbalance).HasColumnName("stockbalance");
            entity.Property(e => e.Stockinitial).HasColumnName("stockinitial");
            entity.Property(e => e.Unitid).HasColumnName("unitid");

            entity.HasOne(d => d.Category).WithMany(p => p.Mstproductcatalogs)
                .HasForeignKey(d => d.Categoryid)
                .HasConstraintName("mstproduct__categoryid_fk");

            entity.HasOne(d => d.Unit).WithMany(p => p.Mstproductcatalogs)
                .HasForeignKey(d => d.Unitid)
                .HasConstraintName("mstproduct__unitid_fk");
        });

        modelBuilder.Entity<Trxorder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("trxorder_pk");

            entity.ToTable("trxorder");

            entity.HasIndex(e => e.Ordercode, "trxorder__ordercode_uq").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Customerid).HasColumnName("customerid");
            entity.Property(e => e.Menuid).HasColumnName("menuid");
            entity.Property(e => e.Ordercode)
                .HasMaxLength(50)
                .HasColumnName("ordercode");
            entity.Property(e => e.Orderdate).HasColumnName("orderdate");
            entity.Property(e => e.Orderstatusid).HasColumnName("orderstatusid");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.Customer).WithMany(p => p.Trxorders)
                .HasForeignKey(d => d.Customerid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("trxorder__customerid_fk");

            entity.HasOne(d => d.Menu).WithMany(p => p.Trxorders)
                .HasForeignKey(d => d.Menuid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("trxorder__menuid_fk");

            entity.HasOne(d => d.Orderstatus).WithMany(p => p.Trxorders)
                .HasForeignKey(d => d.Orderstatusid)
                .HasConstraintName("trxorder__orderstatusid_fk");

            entity.HasOne(d => d.User).WithMany(p => p.Trxorders)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("trxorder__userid_fk");
        });

        modelBuilder.Entity<Trxpayment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("trxpayment_pk");

            entity.ToTable("trxpayment");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Createdby)
                .HasMaxLength(50)
                .HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasDefaultValueSql("now()")
                .HasColumnName("createddate");
            entity.Property(e => e.Customerid).HasColumnName("customerid");
            entity.Property(e => e.Orderid).HasColumnName("orderid");
            entity.Property(e => e.Paymentdate).HasColumnName("paymentdate");
            entity.Property(e => e.Paymenttypeid).HasColumnName("paymenttypeid");
            entity.Property(e => e.Totalamount).HasColumnName("totalamount");

            entity.HasOne(d => d.Customer).WithMany(p => p.Trxpayments)
                .HasForeignKey(d => d.Customerid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("trxpayment__customerid_fk");

            entity.HasOne(d => d.Order).WithMany(p => p.Trxpayments)
                .HasForeignKey(d => d.Orderid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("trxpayment__orderid_fk");

            entity.HasOne(d => d.Paymenttype).WithMany(p => p.Trxpayments)
                .HasForeignKey(d => d.Paymenttypeid)
                .HasConstraintName("trxpayment__paymenttypeid_fk");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_pk");

            entity.ToTable("User");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Createdby)
                .HasMaxLength(50)
                .HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasDefaultValueSql("now()")
                .HasColumnName("createddate");
            entity.Property(e => e.Emailaddress)
                .HasMaxLength(100)
                .HasColumnName("emailaddress");
            entity.Property(e => e.Isactive)
                .HasDefaultValue(true)
                .HasColumnName("isactive");
            entity.Property(e => e.Isconfirmationaccount)
                .HasDefaultValue(false)
                .HasColumnName("isconfirmationaccount");
            entity.Property(e => e.Isdeleted)
                .HasDefaultValue(false)
                .HasColumnName("isdeleted");
            entity.Property(e => e.Lastlogindate).HasColumnName("lastlogindate");
            entity.Property(e => e.Modifyby)
                .HasMaxLength(50)
                .HasColumnName("modifyby");
            entity.Property(e => e.Modifydate).HasColumnName("modifydate");
            entity.Property(e => e.Password)
                .HasMaxLength(500)
                .HasColumnName("password");
            entity.Property(e => e.Salt)
                .HasMaxLength(500)
                .HasColumnName("salt");
            entity.Property(e => e.Username)
                .HasMaxLength(80)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Userdetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("userdetail_pk");

            entity.ToTable("userdetail");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Createdby)
                .HasMaxLength(50)
                .HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasDefaultValueSql("now()")
                .HasColumnName("createddate");
            entity.Property(e => e.Firstname)
                .HasMaxLength(150)
                .HasColumnName("firstname");
            entity.Property(e => e.Fulladdress)
                .HasMaxLength(500)
                .HasColumnName("fulladdress");
            entity.Property(e => e.Genderid).HasColumnName("genderid");
            entity.Property(e => e.Isdeleted)
                .HasDefaultValue(false)
                .HasColumnName("isdeleted");
            entity.Property(e => e.Lastname)
                .HasMaxLength(150)
                .HasColumnName("lastname");
            entity.Property(e => e.Mobilephone)
                .HasMaxLength(25)
                .HasColumnName("mobilephone");
            entity.Property(e => e.Modifyby)
                .HasMaxLength(50)
                .HasColumnName("modifyby");
            entity.Property(e => e.Modifydate).HasColumnName("modifydate");
            entity.Property(e => e.Nikorpassport)
                .HasMaxLength(50)
                .HasColumnName("nikorpassport");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.Gender).WithMany(p => p.Userdetails)
                .HasForeignKey(d => d.Genderid)
                .HasConstraintName("userdetail_genderid_fk");

            entity.HasOne(d => d.User).WithMany(p => p.Userdetails)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("userdetail_userid_fk");
        });

        modelBuilder.Entity<VwListdatastaff>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_listdatastaff");

            entity.Property(e => e.Createdby)
                .HasMaxLength(50)
                .HasColumnName("createdby");
            entity.Property(e => e.Createddate).HasColumnName("createddate");
            entity.Property(e => e.Emailaddress)
                .HasMaxLength(100)
                .HasColumnName("emailaddress");
            entity.Property(e => e.Firstname)
                .HasMaxLength(150)
                .HasColumnName("firstname");
            entity.Property(e => e.Fulladdress)
                .HasMaxLength(500)
                .HasColumnName("fulladdress");
            entity.Property(e => e.Genderid).HasColumnName("genderid");
            entity.Property(e => e.Gendername)
                .HasMaxLength(255)
                .HasColumnName("gendername");
            entity.Property(e => e.Isactive).HasColumnName("isactive");
            entity.Property(e => e.Isactivedesc).HasColumnName("isactivedesc");
            entity.Property(e => e.Isconfirmationaccount).HasColumnName("isconfirmationaccount");
            entity.Property(e => e.Isdeleted).HasColumnName("isdeleted");
            entity.Property(e => e.Isdeleteddesc).HasColumnName("isdeleteddesc");
            entity.Property(e => e.Lastlogindate).HasColumnName("lastlogindate");
            entity.Property(e => e.Lastname)
                .HasMaxLength(150)
                .HasColumnName("lastname");
            entity.Property(e => e.Mobilephone)
                .HasMaxLength(25)
                .HasColumnName("mobilephone");
            entity.Property(e => e.Modifiedby)
                .HasMaxLength(50)
                .HasColumnName("modifiedby");
            entity.Property(e => e.Modifieddate).HasColumnName("modifieddate");
            entity.Property(e => e.Password).HasMaxLength(500);
            entity.Property(e => e.Personalidentity)
                .HasMaxLength(50)
                .HasColumnName("personalidentity");
            entity.Property(e => e.Salt).HasMaxLength(500);
            entity.Property(e => e.Userid).HasColumnName("userid");
            entity.Property(e => e.Username)
                .HasMaxLength(80)
                .HasColumnName("username");
        });
        modelBuilder.HasSequence<int>("mstproductid_seq").IsCyclic();

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
