﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Der Code wurde von einer Vorlage generiert.
//
//     Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten der Anwendung.
//     Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QTouristik.PlugIn.OVH_V3.Search.LM
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class OHV_V3_SearchEntities : DbContext
    {
        public OHV_V3_SearchEntities()
            : base("name=OHV_V3_SearchEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<KeyDatabaseSet> KeyDatabaseSets { get; set; }
        public virtual DbSet<SD_PartnerSet> SD_PartnerSet { get; set; }
        public virtual DbSet<SEH_FeWoPreiseSet> SEH_FeWoPreiseSet { get; set; }
        public virtual DbSet<SEH_ObjektInfo> SEH_ObjektInfo { get; set; }
        public virtual DbSet<SEH_PlaceInfoSet> SEH_PlaceInfoSet { get; set; }
        public virtual DbSet<SEH_PortalSet> SEH_PortalSet { get; set; }
        public virtual DbSet<SEH_RegionInfoSet> SEH_RegionInfoSet { get; set; }
        public virtual DbSet<SEH_UnitInfo> SEH_UnitInfo { get; set; }
        public virtual DbSet<dbGeoLocation> dbGeoLocations { get; set; }
    }
}
