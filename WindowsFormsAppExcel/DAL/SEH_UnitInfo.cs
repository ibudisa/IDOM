//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class SEH_UnitInfo
    {
        public int Id { get; set; }
        public int suUnitId { get; set; }
        public int suObjektId { get; set; }
        public string suKurzBeschreibung { get; set; }
        public string suLangBeschreibung { get; set; }
        public string suImageLocation { get; set; }
        public string suRouteObjektId { get; set; }
        public string suRouteObjektTyp { get; set; }
        public System.DateTime suAngebotVon { get; set; }
        public System.DateTime suAngebotBis { get; set; }
        public int suFreeUnitCount { get; set; }
        public int suMaxBelegung { get; set; }
        public int suMaxErwachsener { get; set; }
        public int suTourOperator { get; set; }
        public int suHund { get; set; }
        public string suBettwaesche { get; set; }
        public string suGeschirrspueler { get; set; }
        public int suMHGroße { get; set; }
        public int suSchlafzimmer { get; set; }
        public string suIsActive { get; set; }
        public string SiteCode { get; set; }
        public string UnitOfferCode { get; set; }
        public int suLeistungstraegerId { get; set; }
        public string suIsActiveUnit { get; set; }
    
        public virtual SEH_SiteInfo SEH_SiteInfo { get; set; }
    }
}
