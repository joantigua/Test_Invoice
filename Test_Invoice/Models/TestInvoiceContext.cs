using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Test_Invoice.Models;

namespace Test_Invoice.Models;

public partial class TestInvoiceContext : DbContext
{
    public TestInvoiceContext()
    {
    }

    public TestInvoiceContext(DbContextOptions<TestInvoiceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerType> CustomerTypes { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<InvoicesDetail> InvoicesDetails { get; set; }

    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("CUSTOMERS");

            entity.Property(e => e.CustomerId).HasColumnName("CUSTOMER_ID");
            entity.Property(e => e.CustomerAddress)
                .HasMaxLength(120)
                .IsFixedLength()
                .HasColumnName("CUSTOMER_ADDRESS");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(70)
                .HasColumnName("CUSTOMER_NAME");
            entity.Property(e => e.CustomerStatus)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasColumnName("CUSTOMER_STATUS");
            entity.Property(e => e.CustomerTypeId)
                .HasDefaultValueSql("((1))")
                .HasColumnName("CUSTOMER_TYPE_ID");

            entity.HasOne(d => d.CustomerType).WithMany(p => p.Customers)
                .HasForeignKey(d => d.CustomerTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Customers_CUSTOMER_TYPES");
        });

        modelBuilder.Entity<CustomerType>(entity =>
        {
            entity.ToTable("CUSTOMER_TYPES");

            entity.Property(e => e.CustomerTypeId).HasColumnName("CUSTOMER_TYPE_ID");
            entity.Property(e => e.CustomerTypeDescription)
                .HasMaxLength(70)
                .HasColumnName("CUSTOMER_TYPE_DESCRIPTION");
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.ToTable("INVOICES");

            entity.Property(e => e.InvoiceId).HasColumnName("INVOICE_ID");
            entity.Property(e => e.CustomerId).HasColumnName("CUSTOMER_ID");
            entity.Property(e => e.InvoiceSubtotal)
                .HasColumnType("money")
                .HasColumnName("INVOICE_SUBTOTAL");
            entity.Property(e => e.InvoiceTotal)
                .HasColumnType("money")
                .HasColumnName("INVOICE_TOTAL");
            entity.Property(e => e.InvoiceTotalItbis)
                .HasColumnType("money")
                .HasColumnName("INVOICE_TOTAL_ITBIS");

            entity.HasOne(d => d.Customer).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_INVOICES_Customers");
        });

        modelBuilder.Entity<InvoicesDetail>(entity =>
        {
            entity.HasKey(e => e.InvoiceDetailId);

            entity.ToTable("INVOICES_DETAILS");

            entity.Property(e => e.InvoiceDetailId).HasColumnName("INVOICE_DETAIL_ID");
            entity.Property(e => e.CustomerId).HasColumnName("CUSTOMER_ID");
            entity.Property(e => e.InvoiceDetailPrice)
                .HasColumnType("money")
                .HasColumnName("INVOICE_DETAIL_PRICE");
            entity.Property(e => e.InvoiceDetailQuantity).HasColumnName("INVOICE_DETAIL_QUANTITY");
            entity.Property(e => e.InvoiceDetailSubtotal)
                .HasColumnType("money")
                .HasColumnName("INVOICE_DETAIL_SUBTOTAL");
            entity.Property(e => e.InvoiceDetailTotal)
                .HasColumnType("money")
                .HasColumnName("INVOICE_DETAIL_TOTAL");
            entity.Property(e => e.InvoiceDetailTotalItbis)
                .HasColumnType("money")
                .HasColumnName("INVOICE_DETAIL_TOTAL_ITBIS");

            entity.HasOne(d => d.Customer).WithMany(p => p.InvoicesDetails)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_INVOICES_DETAILS_INVOICES");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
