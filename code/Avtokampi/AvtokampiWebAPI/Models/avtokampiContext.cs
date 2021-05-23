using AvtokampiWebAPI.Models.AuthAggregate;
using AvtokampiWebAPI.Models.CampAggregate;
using AvtokampiWebAPI.Models.ReservationAggregate;
using AvtokampiWebAPI.Models.UserAggregate;
using Microsoft.EntityFrameworkCore;

namespace AvtokampiWebAPI.Models
{
    public partial class avtokampiContext : DbContext
    {
        public avtokampiContext()
        {
        }

        public avtokampiContext(DbContextOptions<avtokampiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Avtokampi> Avtokampi { get; set; }
        public virtual DbSet<Ceniki> Ceniki { get; set; }
        public virtual DbSet<Drzave> Drzave { get; set; }
        public virtual DbSet<KampirnaMesta> KampirnaMesta { get; set; }
        public virtual DbSet<Kategorije> Kategorije { get; set; }
        public virtual DbSet<KategorijeStoritev> KategorijeStoritev { get; set; }
        public virtual DbSet<Mnenja> Mnenja { get; set; }
        public virtual DbSet<Pravice> Pravice { get; set; }
        public virtual DbSet<Regije> Regije { get; set; }
        public virtual DbSet<Rezervacije> Rezervacije { get; set; }
        public virtual DbSet<Slike> Slike { get; set; }
        public virtual DbSet<SoritveCenikov> SoritveCenikov { get; set; }
        public virtual DbSet<StatusRezervacije> StatusRezervacije { get; set; }
        public virtual DbSet<Storitve> Storitve { get; set; }
        public virtual DbSet<StoritveKampirnihMest> StoritveKampirnihMest { get; set; }
        public virtual DbSet<Uporabniki> Uporabniki { get; set; }
        public virtual DbSet<VrstaKampiranja> VrstaKampiranja { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Avtokampi>(entity =>
            {
                entity.HasKey(e => e.AvtokampId)
                    .HasName("avtokampi_pkey");

                entity.ToTable("avtokampi");

                entity.HasIndex(e => e.Regija)
                    .HasName("fk_avtokampi_regije_idx");

                entity.Property(e => e.AvtokampId)
                    .HasColumnName("avtokamp_id")
                    .HasDefaultValueSql("nextval('avtokampi_seq'::regclass)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp(0) without time zone");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.KoordinataX)
                    .HasColumnName("koordinata_x")
                    .HasMaxLength(45);

                entity.Property(e => e.KoordinataY)
                    .HasColumnName("koordinata_y")
                    .HasMaxLength(45);

                entity.Property(e => e.Naslov)
                    .HasColumnName("naslov")
                    .HasMaxLength(100);

                entity.Property(e => e.Naziv)
                    .IsRequired()
                    .HasColumnName("naziv")
                    .HasMaxLength(100);

                entity.Property(e => e.NazivLokacije)
                    .HasColumnName("naziv_lokacije")
                    .HasMaxLength(45);

                entity.Property(e => e.Opis)
                    .HasColumnName("opis")
                    .HasMaxLength(1000);

                entity.Property(e => e.Regija).HasColumnName("regija");

                entity.Property(e => e.Telefon)
                    .HasColumnName("telefon")
                    .HasMaxLength(45);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp(0) without time zone");

                entity.HasOne(d => d.RegijaNavigation)
                    .WithMany(p => p.Avtokampi)
                    .HasForeignKey(d => d.Regija)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_avtokampi_regije");
            });

            modelBuilder.Entity<Ceniki>(entity =>
            {
                entity.HasKey(e => e.CenikId)
                    .HasName("ceniki_pkey");

                entity.ToTable("ceniki");

                entity.HasIndex(e => e.Avtokamp)
                    .HasName("fk_ceniki_avtokampi1_idx");

                entity.Property(e => e.CenikId)
                    .HasColumnName("cenik_id")
                    .HasDefaultValueSql("nextval('ceniki_seq'::regclass)");

                entity.Property(e => e.Avtokamp).HasColumnName("avtokamp");

                entity.Property(e => e.Cena)
                    .HasColumnName("cena")
                    .HasColumnType("numeric(10,0)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp(0) without time zone");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.Naziv)
                    .HasColumnName("naziv")
                    .HasMaxLength(45);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp(0) without time zone");

                entity.HasOne(d => d.AvtokampNavigation)
                    .WithMany(p => p.Ceniki)
                    .HasForeignKey(d => d.Avtokamp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ceniki_avtokampi1");
            });

            modelBuilder.Entity<Drzave>(entity =>
            {
                entity.HasKey(e => e.DrzavaId)
                    .HasName("drzave_pkey");

                entity.ToTable("drzave");

                entity.Property(e => e.DrzavaId)
                    .HasColumnName("drzava_id")
                    .HasDefaultValueSql("nextval('drzave_seq'::regclass)");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.Naziv)
                    .HasColumnName("naziv")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<KampirnaMesta>(entity =>
            {
                entity.HasKey(e => e.KampirnoMestoId)
                    .HasName("kampirna_mesta_pkey");

                entity.ToTable("kampirna_mesta");

                entity.HasIndex(e => e.Avtokamp)
                    .HasName("fk_kampirna_mesta_avtokampi1_idx");

                entity.HasIndex(e => e.Kategorija)
                    .HasName("fk_kampirna_mesta_kategorije1_idx");

                entity.Property(e => e.KampirnoMestoId)
                    .HasColumnName("kampirno_mesto_id")
                    .HasDefaultValueSql("nextval('kampirna_mesta_seq'::regclass)");

                entity.Property(e => e.Avtokamp).HasColumnName("avtokamp");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp(0) without time zone");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.Kategorija).HasColumnName("kategorija");

                entity.Property(e => e.Naziv)
                    .HasColumnName("naziv")
                    .HasMaxLength(45);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp(0) without time zone");

                entity.Property(e => e.Velikost)
                    .HasColumnName("velikost")
                    .HasMaxLength(45);

                entity.HasOne(d => d.AvtokampNavigation)
                    .WithMany(p => p.KampirnaMesta)
                    .HasForeignKey(d => d.Avtokamp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_kampirna_mesta_avtokampi1");

                entity.HasOne(d => d.KategorijaNavigation)
                    .WithMany(p => p.KampirnaMesta)
                    .HasForeignKey(d => d.Kategorija)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_kampirna_mesta_kategorije1");
            });

            modelBuilder.Entity<Kategorije>(entity =>
            {
                entity.HasKey(e => e.KategorijaId)
                    .HasName("kategorije_pkey");

                entity.ToTable("kategorije");

                entity.Property(e => e.KategorijaId)
                    .HasColumnName("kategorija_id")
                    .HasDefaultValueSql("nextval('kategorije_seq'::regclass)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp(0) without time zone");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.Naziv)
                    .HasColumnName("naziv")
                    .HasMaxLength(45);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp(0) without time zone");
            });

            modelBuilder.Entity<KategorijeStoritev>(entity =>
            {
                entity.HasKey(e => e.KategorijaStoritveId)
                    .HasName("kategorije_storitev_pkey");

                entity.ToTable("kategorije_storitev");

                entity.Property(e => e.KategorijaStoritveId)
                    .HasColumnName("kategorija_storitve_id")
                    .HasDefaultValueSql("nextval('kategorije_storitev_seq'::regclass)");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.Naziv)
                    .HasColumnName("naziv")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Mnenja>(entity =>
            {
                entity.HasKey(e => e.MnenjeId)
                    .HasName("mnenja_pkey");

                entity.ToTable("mnenja");

                entity.HasIndex(e => e.Avtokamp)
                    .HasName("fk_mnenja_avtokampi1_idx");

                entity.HasIndex(e => e.Uporabnik)
                    .HasName("fk_mnenja_uporabniki1_idx");

                entity.Property(e => e.MnenjeId)
                    .HasColumnName("mnenje_id")
                    .HasDefaultValueSql("nextval('mnenja_seq'::regclass)");

                entity.Property(e => e.Avtokamp).HasColumnName("avtokamp");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp(0) without time zone");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.Mnenje)
                    .HasColumnName("mnenje")
                    .HasMaxLength(1000);

                entity.Property(e => e.Ocena).HasColumnName("ocena");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp(0) without time zone");

                entity.Property(e => e.Uporabnik).HasColumnName("uporabnik");

                entity.HasOne(d => d.AvtokampNavigation)
                    .WithMany(p => p.Mnenja)
                    .HasForeignKey(d => d.Avtokamp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_mnenja_avtokampi1");

                entity.HasOne(d => d.UporabnikNavigation)
                    .WithMany(p => p.Mnenja)
                    .HasForeignKey(d => d.Uporabnik)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_mnenja_uporabniki1");
            });

            modelBuilder.Entity<Pravice>(entity =>
            {
                entity.HasKey(e => e.PravicaId)
                    .HasName("pravice_pkey");

                entity.ToTable("pravice");

                entity.Property(e => e.PravicaId)
                    .HasColumnName("pravica_id")
                    .HasDefaultValueSql("nextval('pravice_seq'::regclass)");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.Naziv)
                    .HasColumnName("naziv")
                    .HasMaxLength(45);

                entity.Property(e => e.Opis)
                    .HasColumnName("opis")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Regije>(entity =>
            {
                entity.HasKey(e => e.RegijaId)
                    .HasName("regije_pkey");

                entity.ToTable("regije");

                entity.HasIndex(e => e.Drzava)
                    .HasName("fk_regije_drzave1_idx");

                entity.Property(e => e.RegijaId)
                    .HasColumnName("regija_id")
                    .HasDefaultValueSql("nextval('regije_seq'::regclass)");

                entity.Property(e => e.Drzava).HasColumnName("drzava");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.Naziv)
                    .HasColumnName("naziv")
                    .HasMaxLength(45);

                entity.HasOne(d => d.DrzavaNavigation)
                    .WithMany(p => p.Regije)
                    .HasForeignKey(d => d.Drzava)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_regije_drzave1");
            });

            modelBuilder.Entity<Rezervacije>(entity =>
            {
                entity.HasKey(e => e.RezervacijaId)
                    .HasName("rezervacije_pkey");

                entity.ToTable("rezervacije");

                entity.HasIndex(e => e.Avtokamp)
                    .HasName("fk_rezervacije_avtokampi1_idx");

                entity.HasIndex(e => e.KampirnoMesto)
                    .HasName("fk_rezervacije_kampirna_mesta1_idx");

                entity.HasIndex(e => e.StatusRezervacije)
                    .HasName("fk_rezervacije_status_rezervacije1_idx");

                entity.HasIndex(e => e.Uporabnik)
                    .HasName("fk_rezervacije_uporabniki1_idx");

                entity.HasIndex(e => e.VrstaKampiranja)
                    .HasName("fk_rezervacije_vrsta_kampiranja1_idx");

                entity.Property(e => e.RezervacijaId)
                    .HasColumnName("rezervacija_id")
                    .HasDefaultValueSql("nextval('rezervacije_seq'::regclass)");

                entity.Property(e => e.Avtokamp).HasColumnName("avtokamp");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp(0) without time zone");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.KampirnoMesto).HasColumnName("kampirno_mesto");

                entity.Property(e => e.StatusRezervacije).HasColumnName("status_rezervacije");

                entity.Property(e => e.TrajanjeDo)
                    .HasColumnName("trajanje_do")
                    .HasColumnType("timestamp(0) without time zone");

                entity.Property(e => e.TrajanjeOd)
                    .HasColumnName("trajanje_od")
                    .HasColumnType("timestamp(0) without time zone");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp(0) without time zone");

                entity.Property(e => e.Uporabnik).HasColumnName("uporabnik");

                entity.Property(e => e.VrstaKampiranja).HasColumnName("vrsta_kampiranja");

                entity.HasOne(d => d.AvtokampNavigation)
                    .WithMany(p => p.Rezervacije)
                    .HasForeignKey(d => d.Avtokamp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_rezervacije_avtokampi1");

                entity.HasOne(d => d.KampirnoMestoNavigation)
                    .WithMany(p => p.Rezervacije)
                    .HasForeignKey(d => d.KampirnoMesto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_rezervacije_kampirna_mesta1");

                entity.HasOne(d => d.StatusRezervacijeNavigation)
                    .WithMany(p => p.Rezervacije)
                    .HasForeignKey(d => d.StatusRezervacije)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_rezervacije_status_rezervacije1");

                entity.HasOne(d => d.UporabnikNavigation)
                    .WithMany(p => p.Rezervacije)
                    .HasForeignKey(d => d.Uporabnik)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_rezervacije_uporabniki1");

                entity.HasOne(d => d.VrstaKampiranjaNavigation)
                    .WithMany(p => p.Rezervacije)
                    .HasForeignKey(d => d.VrstaKampiranja)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_rezervacije_vrsta_kampiranja1");
            });

            modelBuilder.Entity<Slike>(entity =>
            {
                entity.HasKey(e => e.SlikaId)
                    .HasName("slike_pkey");

                entity.ToTable("slike");

                entity.HasIndex(e => e.Avtokamp)
                    .HasName("fk_slike_avtokampi1_idx");

                entity.Property(e => e.SlikaId)
                    .HasColumnName("slika_id")
                    .HasDefaultValueSql("nextval('slike_seq'::regclass)");

                entity.Property(e => e.Avtokamp).HasColumnName("avtokamp");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp(0) without time zone");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.Slika).HasColumnName("slika");

                entity.Property(e => e.Updated)
                    .HasColumnName("updated")
                    .HasColumnType("timestamp(0) without time zone");

                entity.HasOne(d => d.AvtokampNavigation)
                    .WithMany(p => p.Slike)
                    .HasForeignKey(d => d.Avtokamp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_slike_avtokampi1");
            });

            modelBuilder.Entity<SoritveCenikov>(entity =>
            {
                entity.ToTable("soritve_cenikov");

                entity.HasIndex(e => e.AvtokampiAvtokampId)
                    .HasName("fk_soritve_cenikov_avtokampi1_idx");

                entity.HasIndex(e => e.CenikiCenikId)
                    .HasName("fk_soritve_cenikov_ceniki1_idx");

                entity.HasIndex(e => e.StoritveStoritevId)
                    .HasName("fk_soritve_cenikov_storitve1_idx");

                entity.Property(e => e.SoritveCenikovId)
                    .HasColumnName("soritve_cenikov_id")
                    .HasDefaultValueSql("nextval('soritve_cenikov_seq'::regclass)");

                entity.Property(e => e.AvtokampiAvtokampId).HasColumnName("avtokampi_avtokamp_id");

                entity.Property(e => e.CenikiCenikId).HasColumnName("ceniki_cenik_id");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.StoritveStoritevId).HasColumnName("storitve_storitev_id");

                entity.HasOne(d => d.AvtokampiAvtokamp)
                    .WithMany(p => p.SoritveCenikov)
                    .HasForeignKey(d => d.AvtokampiAvtokampId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_soritve_cenikov_avtokampi1");

                entity.HasOne(d => d.CenikiCenik)
                    .WithMany(p => p.SoritveCenikov)
                    .HasForeignKey(d => d.CenikiCenikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_soritve_cenikov_ceniki1");

                entity.HasOne(d => d.StoritveStoritev)
                    .WithMany(p => p.SoritveCenikov)
                    .HasForeignKey(d => d.StoritveStoritevId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_soritve_cenikov_storitve1");
            });

            modelBuilder.Entity<StatusRezervacije>(entity =>
            {
                entity.ToTable("status_rezervacije");

                entity.Property(e => e.StatusRezervacijeId)
                    .HasColumnName("status_rezervacije_id")
                    .HasDefaultValueSql("nextval('status_rezervacije_seq'::regclass)");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.Naziv)
                    .HasColumnName("naziv")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Storitve>(entity =>
            {
                entity.HasKey(e => e.StoritevId)
                    .HasName("storitve_pkey");

                entity.ToTable("storitve");

                entity.HasIndex(e => e.Cenik)
                    .HasName("fk_storitve_ceniki1_idx");

                entity.HasIndex(e => e.KategorijaStoritve)
                    .HasName("fk_storitve_kategorije_storitev1_idx");

                entity.Property(e => e.StoritevId)
                    .HasColumnName("storitev_id")
                    .HasDefaultValueSql("nextval('storitve_seq'::regclass)");

                entity.Property(e => e.Cenik).HasColumnName("cenik");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.KategorijaStoritve).HasColumnName("kategorija_storitve");

                entity.Property(e => e.Naziv)
                    .HasColumnName("naziv")
                    .HasMaxLength(45);

                entity.HasOne(d => d.CenikNavigation)
                    .WithMany(p => p.Storitve)
                    .HasForeignKey(d => d.Cenik)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_storitve_ceniki1");

                entity.HasOne(d => d.KategorijaStoritveNavigation)
                    .WithMany(p => p.Storitve)
                    .HasForeignKey(d => d.KategorijaStoritve)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_storitve_kategorije_storitev1");
            });

            modelBuilder.Entity<StoritveKampirnihMest>(entity =>
            {
                entity.ToTable("storitve_kampirnih_mest");

                entity.HasIndex(e => e.KampirnoMesto)
                    .HasName("fk_storitve_kampirnih_mest_kampirna_mesta1_idx");

                entity.HasIndex(e => e.Storitev)
                    .HasName("fk_storitve_kampirnih_mest_storitve1_idx");

                entity.Property(e => e.StoritveKampirnihMestId)
                    .HasColumnName("storitve_kampirnih_mest_id")
                    .HasDefaultValueSql("nextval('storitve_kampirnih_mest_seq'::regclass)");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.KampirnoMesto).HasColumnName("kampirno_mesto");

                entity.Property(e => e.Storitev).HasColumnName("storitev");

                entity.HasOne(d => d.KampirnoMestoNavigation)
                    .WithMany(p => p.StoritveKampirnihMest)
                    .HasForeignKey(d => d.KampirnoMesto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_storitve_kampirnih_mest_kampirna_mesta1");

                entity.HasOne(d => d.StoritevNavigation)
                    .WithMany(p => p.StoritveKampirnihMest)
                    .HasForeignKey(d => d.Storitev)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_storitve_kampirnih_mest_storitve1");
            });

            modelBuilder.Entity<Uporabniki>(entity =>
            {
                entity.HasKey(e => e.UporabnikId)
                    .HasName("uporabniki_pkey");

                entity.ToTable("uporabniki");

                entity.HasIndex(e => e.Pravice)
                    .HasName("fk_uporabniki_pravice_idx");

                entity.Property(e => e.UporabnikId)
                    .HasColumnName("uporabnik_id")
                    .HasDefaultValueSql("nextval('uporabniki_seq'::regclass)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("timestamp(0) without time zone");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(45);

                entity.Property(e => e.Geslo)
                    .HasColumnName("geslo")
                    .HasMaxLength(100);

                entity.Property(e => e.Ime)
                    .HasColumnName("ime")
                    .HasMaxLength(45);

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.Pravice).HasColumnName("pravice");

                entity.Property(e => e.Priimek)
                    .HasColumnName("priimek")
                    .HasMaxLength(45);

                entity.Property(e => e.Slika).HasColumnName("slika");

                entity.Property(e => e.Telefon)
                    .HasColumnName("telefon")
                    .HasMaxLength(45);

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("timestamp(0) without time zone");

                entity.HasOne(d => d.PraviceNavigation)
                    .WithMany(p => p.Uporabniki)
                    .HasForeignKey(d => d.Pravice)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_uporabniki_pravice");
            });

            modelBuilder.Entity<VrstaKampiranja>(entity =>
            {
                entity.ToTable("vrsta_kampiranja");

                entity.Property(e => e.VrstaKampiranjaId)
                    .HasColumnName("vrsta_kampiranja_id")
                    .HasDefaultValueSql("nextval('vrsta_kampiranja_seq'::regclass)");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.Naziv)
                    .HasColumnName("naziv")
                    .HasMaxLength(45);
            });

            modelBuilder.HasSequence("avtokampi_seq");

            modelBuilder.HasSequence("ceniki_seq");

            modelBuilder.HasSequence("drzave_seq");

            modelBuilder.HasSequence("kampirna_mesta_seq");

            modelBuilder.HasSequence("kategorije_seq");

            modelBuilder.HasSequence("kategorije_storitev_seq");

            modelBuilder.HasSequence("mnenja_seq");

            modelBuilder.HasSequence("pravice_seq");

            modelBuilder.HasSequence("regije_seq");

            modelBuilder.HasSequence("rezervacije_seq");

            modelBuilder.HasSequence("slike_seq");

            modelBuilder.HasSequence("soritve_cenikov_seq");

            modelBuilder.HasSequence("status_rezervacije_seq");

            modelBuilder.HasSequence("storitve_kampirnih_mest_seq");

            modelBuilder.HasSequence("storitve_seq");

            modelBuilder.HasSequence("uporabniki_seq");

            modelBuilder.HasSequence("vrsta_kampiranja_seq");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}