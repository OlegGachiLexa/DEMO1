namespace System_Machine_Tools
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

        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Авторизация> Авторизация { get; set; }
        public virtual DbSet<Бригады> Бригады { get; set; }
        public virtual DbSet<Виды_ремонта> Виды_ремонта { get; set; }
        public virtual DbSet<Виды_станков> Виды_станков { get; set; }
        public virtual DbSet<Заказы> Заказы { get; set; }
        public virtual DbSet<Клиенты> Клиенты { get; set; }
        public virtual DbSet<Производители> Производители { get; set; }
        public virtual DbSet<Станки> Станки { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Авторизация>()
                .Property(e => e.Код_доступа)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Бригады>()
                .HasMany(e => e.Заказы)
                .WithRequired(e => e.Бригады)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Виды_ремонта>()
                .Property(e => e.Вид_ремонта)
                .IsUnicode(false);

            modelBuilder.Entity<Виды_ремонта>()
                .Property(e => e.Стоимость__руб_)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Виды_ремонта>()
                .HasMany(e => e.Заказы)
                .WithRequired(e => e.Виды_ремонта)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Виды_станков>()
                .HasMany(e => e.Станки)
                .WithRequired(e => e.Виды_станков)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Заказы>()
                .Property(e => e.Вид_ремонта)
                .IsUnicode(false);

            modelBuilder.Entity<Заказы>()
                .Property(e => e.Статус_заказа)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Клиенты>()
                .Property(e => e.Телефон)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Клиенты>()
                .Property(e => e.Электронная_почта)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Клиенты>()
                .HasMany(e => e.Станки)
                .WithRequired(e => e.Клиенты)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Производители>()
                .HasMany(e => e.Станки)
                .WithRequired(e => e.Производители)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Станки>()
                .Property(e => e.Марка_станка)
                .IsUnicode(false);

            modelBuilder.Entity<Станки>()
                .HasMany(e => e.Заказы)
                .WithRequired(e => e.Станки)
                .WillCascadeOnDelete(false);
        }
    }
}
