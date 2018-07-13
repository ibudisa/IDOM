using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QTouristik.Interface.Search;
using QTouristik.PlugIn.OVH_V3.Search.LM;
using QTouristik.PlugIn.OVH_V10.Search.DP;

namespace QTouristik.PlugIn.OVH_V10.Search
{
    public class SearchManager : ISearchManager, ISearchBulkCopyManager
    {
        public void DeleteOfferForAngebotId(int id)
        {
            using (var context = new OHV_V3_SearchEntities())
            {
                context.SEH_FeWoPreiseSet.RemoveRange(context.SEH_FeWoPreiseSet.Where(m => m.Angebot_Id == id));
                context.SaveChanges();
            }
        }

        public void TruncateSearchItems(string dbName)
        {
            using (var context = new OHV_V3_SearchEntities())
            {
                context.Database.ExecuteSqlCommand("TRUNCATE TABLE [" + dbName + "]");
            }
        }

       

        public List<ObjektSearchResultEntity> GetBestPriceList(ObjektSearchArgs param, int page, ref int count)
        {
            if (param.ReisedauerMin > param.ReisedauerMax)
                param.ReisedauerMax = param.ReisedauerMin;

            if (param.FruehesteAnreise > param.SpaetesteRueckreise)
                param.SpaetesteRueckreise = param.FruehesteAnreise.AddDays(param.ReisedauerMax);

            DateTime lastAnreise = param.SpaetesteRueckreise.AddDays(-param.ReisedauerMin);
            int reisende = param.ReisendeErwachsener + param.ReisendeKinder;
            int erwachsene = param.ReisendeErwachsener;

            using (var context = new OHV_V3_SearchEntities())
            {
                var result = from unit in context.SEH_UnitInfo
                             join r in context.SEH_FeWoPreiseSet
                             on unit.suUnitId equals r.Angebot_Id

                             join ob in context.SEH_ObjektInfo
                             on unit.suObjektId equals ob.soObjektId

                             join rg in context.SEH_RegionInfoSet
                             on ob.soRegion equals rg.Id

                             join ort in context.SEH_PlaceInfoSet
                             on ob.soOrtId equals ort.Id

                             join portal in context.SEH_PortalSet
                             on unit.suTourOperator equals portal.TourOperator

                             where
                             r.Anreise >= param.FruehesteAnreise && r.Anreise <= lastAnreise &&
                                    r.Reisedauer >= param.ReisedauerMin && r.Reisedauer <= param.ReisedauerMax &&
                                   unit.suMaxBelegung >= reisende &&
                                   unit.suMaxErwachsener >= param.ReisendeErwachsener &&
                                    r.MaxPersonen >= reisende

                             select new
                             {
                                 Region = ob.soRegion,
                                 RegionName = rg.RegionName,

                                 ObjektName = ob.soKurzBeschreibung,
                                 ObjektImage = ob.soImageLocation,
                                 ObjektRoute = ob.soRouteObjektId,
                                 OrtId = ob.soOrtId,
                                 OrtName = ort.PlaceName,
                                 AnlageMitPool = ob.Pool,
                                 ObjektID = unit.suObjektId,
                                 Schlafzimmer = unit.suSchlafzimmer,
                                 MH_Grosse = unit.suMHGroße,
                                 Geschirrspüler = unit.suGeschirrspueler,
                                 Bettwaesche = unit.suBettwaesche,
                                 Hund = unit.suHund,
                                 UnitID = unit.suUnitId,

                                 r.Reisedauer,
                                 param.ReisedauerMin,

                                 LeistungBeschreibung = ob.soLangBeschreibung,
                                 TourOperator = unit.suTourOperator,
                                 resultPreis = r.EndPreis,
                                 PortalCode = portal.PortalCode.Trim(),
                                 r.Anreise
                             };

                if (param.PortalCode != string.Empty)
                    result = result.Where(i => i.PortalCode == param.PortalCode);

                if (param.MH_Grosse > 0)
                    result = result.Where(i => i.MH_Grosse >= param.MH_Grosse);

                if (param.Geschirrspüler)
                    result = result.Where(i => i.Geschirrspüler == "y");

                if (param.Bettwaesche)
                    result = result.Where(i => i.Bettwaesche == "y");


                if (param.AnlageMitPool)
                    result = result.Where(i => i.AnlageMitPool == "y");

                if (param.Hund > 0)
                    result = result.Where(i => i.Hund >= param.Hund);

                if (param.Schlafzimmer > 0)
                    result = result.Where(i => i.Schlafzimmer == param.Schlafzimmer);


                if (param.RegionId > 0)
                    result = result.Where(i => i.Region == param.RegionId);


                //if (param.OrtId > 0)
                //    result = result.Where(i => i.OrtId == param.OrtId);
                //else if (param.RegionId > 0)
                //    result = result.Where(i => i.RegionId == param.RegionId);

                //if (param.Kategorie > 0)
                //    result = result.Where(i => i.Sterne >= param.Kategorie);

                //if (param.Verflegung > 1)
                //    result = result.Where(i => i.Verpflegung >= param.Verflegung);

                var result1 = from s in result
                              group s by s.UnitID into grp
                              select grp.OrderBy(g => g.resultPreis).FirstOrDefault();


                var result2 = (from r in result1
                               join to in context.SD_PartnerSet
                             on r.TourOperator equals to.Id
                               orderby r.resultPreis
                               select new { r.UnitID, r.ObjektID, r.ObjektName, r.resultPreis, r.OrtId, r.OrtName, r.Reisedauer, r.Anreise, r.TourOperator, TourOperatorCode = to.Code, r.RegionName, r.LeistungBeschreibung, r.ObjektImage, r.ObjektRoute, r.AnlageMitPool }).Skip((page - 1) * 10).OrderBy(o => o.resultPreis);

                count = result2.Count() + (page - 1) * 10;
                var resultEntityList = new List<ObjektSearchResultEntity>();

                int counter = 0;

                foreach (var k in result2)
                {
                    int ix = resultEntityList.FindIndex(i => i.ObjektId == k.ObjektID);
                    if (ix == -1)
                    {
                        decimal preis = k.resultPreis;
                        resultEntityList.Add(new ObjektSearchResultEntity { ObjektId = k.ObjektID, Preis = preis, GesamtPreis = k.resultPreis, Reisedauer = k.Reisedauer, Reisende = reisende, Name = k.ObjektName, LeistungBeschreibung = k.LeistungBeschreibung, TourOperator = k.TourOperator.ToString(), TourOperatorCode = k.TourOperatorCode, OrtId = k.OrtId, OrtName = k.OrtName, RegionName = k.RegionName, ImageUrl = k.ObjektImage, ObjektRoute = k.ObjektRoute });
                        counter++;
                        if (counter == 50)
                            break;
                    }
                }

                return resultEntityList.OrderBy(o => o.Preis).ToList();

            }
        }

        public List<UnitSearchResultEntity> GetBestPriceListForObjekt(UnitSearchArgs param)
        {
            if (param.ReisedauerMin > param.ReisedauerMax)
                param.ReisedauerMax = param.ReisedauerMin;

            if (param.FruehesteAnreise > param.SpaetesteRueckreise)
                param.SpaetesteRueckreise = param.FruehesteAnreise.AddDays(param.ReisedauerMax);

            DateTime lastAnreise = param.SpaetesteRueckreise.AddDays(-param.ReisedauerMin);
            int reisende = param.ReisendeErwachsener + param.ReisendeKinder;
            int erwachsene = param.ReisendeErwachsener;

            using (var context = new OHV_V3_SearchEntities())
            {
                var result = from unit in context.SEH_UnitInfo
                             join r in context.SEH_FeWoPreiseSet
                             on unit.suUnitId equals r.Angebot_Id

                             join ob in context.SEH_ObjektInfo
                            on unit.suObjektId equals ob.soObjektId

                             join rg in context.SEH_RegionInfoSet
                             on ob.soRegion equals rg.Id

                             join ort in context.SEH_PlaceInfoSet
                             on ob.soOrtId equals ort.Id



                             where
                             unit.suUnitId == param.SD_UnitId &&
                             r.Anreise >= param.FruehesteAnreise && r.Anreise <= lastAnreise &&
                             r.Reisedauer >= param.ReisedauerMin && r.Reisedauer <= param.ReisedauerMax &&
                                   r.MaxPersonen >= reisende && r.MinPersonen <= reisende &&
                                   unit.suMaxErwachsener >= param.ReisendeErwachsener &&
                                   r.MaxPersonen >= reisende

                             select new
                             {
                                 UnitId = unit.suUnitId,
                                 Schlafzimmer = unit.suSchlafzimmer,
                                 MH_Grosse = unit.suMHGroße,
                                 Geschirrspüler = unit.suGeschirrspueler,
                                 Bettwaesche = unit.suBettwaesche,
                                 Hund = unit.suHund,
                                 Anreise = r.Anreise,
                                 Reisedauer = r.Reisedauer,
                                 TourOperator = unit.suTourOperator,
                                 ob.soRegion,
                                 RegionName = rg.RegionName,
                                 ImageName = unit.suImageLocation,
                                 UnitRoute = unit.suRouteObjektId,
                                 UnitTypRoute = unit.suRouteObjektTyp,
                                 ObjektName = ob.soKurzBeschreibung,
                                 OrtId = ob.soOrtId,
                                 OrtName = ort.PlaceName,
                                 ListenPreis = r.ListenPreis,
                                 EndPreis = r.EndPreis,
                                 PVPreisId = r.counter,
                                 PVLeistungId = r.Angebot_Id,
                                 HtmlBeschreibungLang = unit.suLangBeschreibung,
                                 UnitName = unit.suKurzBeschreibung
                             };


                var resultAlle = new List<IgorResult>();

                foreach (var k in result.OrderBy(m => m.EndPreis))
                {
                    string groupCode = k.TourOperator.ToString() + k.UnitId.ToString() + k.Reisedauer.ToString() + k.EndPreis.ToString();
                    resultAlle.Add(new IgorResult { Anreise = k.Anreise, GroupCode = groupCode, ListenPreis = k.ListenPreis, EndPreis = k.EndPreis, Reisedauer = k.Reisedauer, TourOperator = k.TourOperator.ToString(), UnitId = k.UnitId, PVPreisId = k.PVPreisId, PVLeistungId = k.PVLeistungId, ImageName = k.ImageName, HtmlBeschreibungLang = k.HtmlBeschreibungLang, UnitName = k.UnitName, UnitRoute = k.UnitRoute, UnitTypRoute = k.UnitTypRoute });
                }

                var resultGruppe = from s in resultAlle
                                   group s by s.GroupCode into grp
                                   select grp.OrderBy(g => g.EndPreis);

                var resultEntityList = new List<UnitSearchResultEntity>();


                int counter = 0;

                foreach (var k in resultGruppe)
                {
                    var anreiseList = new List<PreisVergleichUnitInfo>();
                    int pVPreisId = 0;
                    int pV_LeistungId = 0;
                    int verpflegung = 0;
                    decimal EndPreis = 0;
                    decimal listenPreis = 0;
                    int reisedauer = 0;
                    string leistungBeschreibung = String.Empty;
                    string tourOperator = String.Empty;
                    int UnitId = 0;
                    string imageName = String.Empty;
                    string groupCode = String.Empty;
                    string unitName = String.Empty;
                    string unitRoute = String.Empty;
                    string unitTypRoute = String.Empty;

                    foreach (IgorResult x in k)
                    {

                        groupCode = x.GroupCode;
                        UnitId = x.UnitId;
                        var pvui = new PreisVergleichUnitInfo { PVLeistungId = x.PVLeistungId, PVPreisId = x.PVPreisId, AnreiseDatum = x.Anreise };
                        anreiseList.Add(pvui);
                        EndPreis = x.EndPreis;
                        listenPreis = x.ListenPreis;

                        reisedauer = x.Reisedauer;
                        leistungBeschreibung = x.HtmlBeschreibungLang;
                        tourOperator = x.TourOperator;
                        pVPreisId = x.PVPreisId;
                        pV_LeistungId = x.PVLeistungId;
                        verpflegung = x.Verpflegung;
                        imageName = x.ImageName.Trim();
                        unitName = x.UnitName;
                        unitRoute = x.UnitRoute;
                        unitTypRoute = x.UnitTypRoute;

                    }

                    if (pVPreisId != 0)
                    {
                        var uvre = new UnitSearchResultEntity { AnreiseList = anreiseList, EndPreis = EndPreis, ListenPreis = listenPreis, Reisedauer = reisedauer, Reisende = reisende, LeistungBeschreibung = leistungBeschreibung, TourOperator = tourOperator, Verpflegung = verpflegung, TO_UnitId = UnitId.ToString(), ImageName = imageName, UnitName = unitName, GroupCode = groupCode, UnitRoute = unitRoute, UnitTypRoute = unitTypRoute, UnitId = UnitId };
                        uvre.AnreiseBuchungsTermin = anreiseList[0].AnreiseDatum;
                        uvre.BuchungsLeistungId = anreiseList[0].PVLeistungId;
                        uvre.BuchungPreisId = anreiseList[0].PVPreisId;
                        uvre.Counter = counter;
                        resultEntityList.Add(uvre);
                    }
                    if (counter == 10)
                        break;
                }
                return resultEntityList.OrderBy(o => o.EndPreis).ToList();
            }

        }

        public List<UnitSearchResultEntity> GetBestPriceListForObjekt(UnitSearchArgs param, int page, ref int count)
        {
            if (param.ReisedauerMin > param.ReisedauerMax)
                param.ReisedauerMax = param.ReisedauerMin;

            if (param.FruehesteAnreise > param.SpaetesteRueckreise)
                param.SpaetesteRueckreise = param.FruehesteAnreise.AddDays(param.ReisedauerMax);

            DateTime lastAnreise = param.SpaetesteRueckreise.AddDays(-param.ReisedauerMin);
            int reisende = param.ReisendeErwachsener + param.ReisendeKinder;
            int erwachsene = param.ReisendeErwachsener;

            using (var context = new OHV_V3_SearchEntities())
            {
                var result = from unit in context.SEH_UnitInfo
                             join r in context.SEH_FeWoPreiseSet
                             on unit.suUnitId equals r.Angebot_Id

                             join ob in context.SEH_ObjektInfo
                            on unit.suObjektId equals ob.soObjektId

                             //join o in context.dbGeoLocation
                             //on ob.soObjektId equals o.geoID

                             join rg in context.SEH_RegionInfoSet
                             on ob.soRegion equals rg.Id

                             join ort in context.SEH_PlaceInfoSet
                             on ob.soOrtId equals ort.Id

                             join portal in context.SEH_PortalSet
                             on unit.suTourOperator equals portal.TourOperator

                             where
                             unit.suObjektId == param.SD_ObjektId &&
                             r.Anreise >= param.FruehesteAnreise && r.Anreise <= lastAnreise &&
                             r.Reisedauer >= param.ReisedauerMin && r.Reisedauer <= param.ReisedauerMax &&
                                   r.MaxPersonen >= reisende && r.MinPersonen <= reisende &&
                                   unit.suMaxErwachsener >= param.ReisendeErwachsener &&
                                   r.MaxPersonen >= reisende

                             select new
                             {
                                 UnitId = unit.suUnitId,
                                 Schlafzimmer = unit.suSchlafzimmer,
                                 MH_Grosse = unit.suMHGroße,
                                 Geschirrspüler = unit.suGeschirrspueler,
                                 Bettwaesche = unit.suBettwaesche,
                                 Hund = unit.suHund,
                                 Anreise = r.Anreise,
                                 Reisedauer = r.Reisedauer,
                                 TourOperator = unit.suTourOperator,
                                 ob.soRegion,
                                 RegionName = rg.RegionName,
                                 ImageName = unit.suImageLocation,
                                 UnitRoute = unit.suRouteObjektId,
                                 UnitTypRoute = unit.suRouteObjektTyp,
                                 ObjektName = ob.soKurzBeschreibung,
                                 OrtId = ob.soOrtId,
                                 OrtName = ort.PlaceName,
                                 ListenPreis = r.ListenPreis,
                                 EndPreis = r.EndPreis,
                                 PVPreisId = r.counter,
                                 PVLeistungId = r.Angebot_Id,
                                 HtmlBeschreibungLang = unit.suLangBeschreibung,
                                 UnitName = unit.suKurzBeschreibung,
                                 PortalCode = portal.PortalCode.Trim()

                             };

                if (param.PortalCode != string.Empty)
                    result = result.Where(i => i.PortalCode == param.PortalCode);

                if (param.SD_UnitId > 0)
                    result = result.Where(i => i.UnitId == param.SD_UnitId);

                if (param.MobilhomeGrosse > 0)
                    result = result.Where(i => i.MH_Grosse >= param.MobilhomeGrosse);

                if (param.Geschirrspüler)
                    result = result.Where(i => i.Geschirrspüler == "y");

                if (param.Bettwaesche)
                    result = result.Where(i => i.Bettwaesche == "y");

                if (param.Hund > 0)
                    result = result.Where(i => i.Hund >= param.Hund);

                if (param.Schlafzimmer > 0)
                    result = result.Where(i => i.Schlafzimmer == param.Schlafzimmer);

                var resultAlle = new List<IgorResult>();

                foreach (var k in result.OrderBy(m => m.EndPreis))
                {
                    string groupCode = k.TourOperator.ToString() + k.UnitId.ToString() + k.Reisedauer.ToString() + k.EndPreis.ToString();
                    resultAlle.Add(new IgorResult { Anreise = k.Anreise, GroupCode = groupCode, ListenPreis = k.ListenPreis, EndPreis = k.EndPreis, Reisedauer = k.Reisedauer, TourOperator = k.TourOperator.ToString(), UnitId = k.UnitId, PVPreisId = k.PVPreisId, PVLeistungId = k.PVLeistungId, ImageName = k.ImageName, HtmlBeschreibungLang = k.HtmlBeschreibungLang, UnitName = k.UnitName, UnitRoute = k.UnitRoute, UnitTypRoute = k.UnitTypRoute });
                }

                var resultGruppe = from s in resultAlle
                                   group s by s.GroupCode into grp
                                   select grp.OrderBy(g => g.EndPreis);

                var resultEntityList = new List<UnitSearchResultEntity>();
                int skip = (page - 1) * 10;
                count = resultGruppe.Count();
                int counter = 0;
                int skipCounter = 0;
                foreach (var k in resultGruppe)
                {
                    if (skipCounter < skip)
                    {
                        ++skipCounter;
                        continue;
                    }

                    var anreiseList = new List<PreisVergleichUnitInfo>();
                    int pVPreisId = 0;
                    int pV_LeistungId = 0;
                    int verpflegung = 0;
                    decimal EndPreis = 0;
                    decimal listenPreis = 0;
                    int reisedauer = 0;
                    string leistungBeschreibung = String.Empty;
                    string tourOperator = String.Empty;
                    int UnitId = 0;
                    string imageName = String.Empty;
                    string groupCode = String.Empty;
                    string unitName = String.Empty;
                    string unitRoute = String.Empty;
                    string unitTypRoute = String.Empty;

                    foreach (IgorResult x in k)
                    {

                        groupCode = x.GroupCode;
                        UnitId = x.UnitId;
                        var pvui = new PreisVergleichUnitInfo { PVLeistungId = x.PVLeistungId, PVPreisId = x.PVPreisId, AnreiseDatum = x.Anreise };
                        anreiseList.Add(pvui);
                        EndPreis = x.EndPreis;
                        listenPreis = x.ListenPreis;

                        reisedauer = x.Reisedauer;
                        leistungBeschreibung = x.HtmlBeschreibungLang;
                        tourOperator = x.TourOperator;
                        pVPreisId = x.PVPreisId;
                        pV_LeistungId = x.PVLeistungId;
                        verpflegung = x.Verpflegung;
                        imageName = x.ImageName.Trim();
                        unitName = x.UnitName;
                        unitRoute = x.UnitRoute;
                        unitTypRoute = x.UnitTypRoute;

                    }

                    if (pVPreisId != 0)
                    {
                        var uvre = new UnitSearchResultEntity { AnreiseList = anreiseList, EndPreis = EndPreis, ListenPreis = listenPreis, Reisedauer = reisedauer, Reisende = reisende, LeistungBeschreibung = leistungBeschreibung, TourOperator = tourOperator, Verpflegung = verpflegung, TO_UnitId = UnitId.ToString(), ImageName = imageName, UnitName = unitName, GroupCode = groupCode, UnitRoute = unitRoute, UnitTypRoute = unitTypRoute, UnitId = UnitId };
                        uvre.AnreiseBuchungsTermin = anreiseList[0].AnreiseDatum;
                        uvre.BuchungsLeistungId = anreiseList[0].PVLeistungId;
                        uvre.BuchungPreisId = anreiseList[0].PVPreisId;
                        uvre.Counter = counter;
                        resultEntityList.Add(uvre);
                    }
                    if (counter == 10)
                        break;
                }
                return resultEntityList.OrderBy(o => o.EndPreis).ToList();
            }

        }

        public int GetNewAppKeyCode(string key)
        {
            var entity = DP_Search.KeyDatabase.GetFirstOrDefault(m => m.AppKeyCode == key);
            entity.KeyCounter++;
            DP_Search.KeyDatabase.UpdateEntity(entity);
            return entity.KeyCounter;

        }

        public int GetObjektIdForRoute(string route)
        {
            var obj = DP_Search.SEH_ObjektInfo.GetFirstOrDefault(m => m.soRouteObjektId.ToLower() == route.ToLower());
            if (obj == null)
                return 0;

            return obj.soObjektId;
        }

        public SearchMasterDataUnitEntity GetSearchMasterDataUnitEntity(int id)
        {
            var ret = new SearchMasterDataUnitEntity();
            using (var context = new OHV_V3_SearchEntities())
            {
                var result = (from unit in context.SEH_UnitInfo
                              where unit.suUnitId == id
                              select unit).FirstOrDefault();

                if (result == null)
                    return null;

                ret.suUnitId = result.suUnitId;
                ret.SiteCode = result.suSiteCode.Trim();
                ret.OfferCode = result.suOfferCode.Trim();
                ret.TourOperatorId = result.suTourOperator;
                ret.TourOperatorCode = result.TourOperatorCode.Trim();
                ret.ImagePath = "/thumbnail/" + result.suImageLocation.Trim();
                ret.OfferName = result.suKurzBeschreibung.Trim();
                ret.AnbieterHinweis = result.suAnbieterHinweis == null ? string.Empty : result.suAnbieterHinweis.Trim();
            }
            return ret;
        }
        public IEnumerable<SearchMasterDataUnitEntity> GetSearchMasterDataUnitEntitys(string routeObjektId, string portalCode)
        {
            var list = new List<SearchMasterDataUnitEntity>();
            using (var context = new OHV_V3_SearchEntities())
            {
                var result = from unit in context.SEH_UnitInfo
                             join portal in context.SEH_PortalSet
                             on unit.suTourOperator equals portal.TourOperator
                             where unit.suRouteObjektId.ToUpper() == routeObjektId.ToUpper() 
                             && portal.PortalCode.ToLower() == portalCode.ToLower()
                             orderby unit.SuSort
                             select new
                             {
                                 unit.Id,
                                 SuUnitId = unit.suUnitId,
                                 TourOperator = unit.suTourOperator,
                                 SiteCode = unit.suSiteCode,
                                 
                                 OfferCode = unit.suOfferCode,
                                 OfferName = unit.suKurzBeschreibung,
                                 Description = unit.suLangBeschreibung,
                                 ImageName = unit.suImageLocation,
                                 RouteObjektType = unit.suRouteObjektTyp,
                                 IsActive = unit.suIsActive
                             };

                foreach (var item in result)
                {
                    if (item.IsActive.Trim() == "y")
                    {
                        var smdue = new SearchMasterDataUnitEntity();
                        smdue.Id = item.Id;
                        smdue.SiteCode = item.SiteCode.Trim();
                        
                        smdue.OfferCode = item.OfferCode.Trim();
                        smdue.TourOperatorId = item.TourOperator;
                        smdue.suUnitId = item.SuUnitId;
                        smdue.OfferName = item.OfferName.Trim();
                        smdue.Description = item.Description.Trim();
                        smdue.ImagePath = item.ImageName.Trim();
                        smdue.RouteObjektTyp = item.RouteObjektType.Trim();
                        smdue.IsActiveUnit = item.IsActive.Trim();
                        list.Add(smdue);
                    }
                }
            }

            return list;
        }
        public IEnumerable<SearchMasterDataUnitEntity> GetSearchMasterDataUnitEntitys(string routeObjektId)
        {
            var list = new List<SearchMasterDataUnitEntity>();
            using (var context = new OHV_V3_SearchEntities())
            {
                var result = from unit in context.SEH_UnitInfo
                             where unit.suRouteObjektId.ToUpper() == routeObjektId.ToUpper()
                             orderby unit.SuSort
                             select new
                             {
                                 unit.Id,
                                 SuUnitId = unit.suUnitId,
                                 TourOperator = unit.suTourOperator,
                                 SiteCode = unit.suSiteCode,
                                 
                                 OfferCode = unit.suOfferCode,
                                 OfferName = unit.suKurzBeschreibung,
                                 Description = unit.suLangBeschreibung,
                                 ImageName = unit.suImageLocation,
                                 RouteObjektType = unit.suRouteObjektTyp,
                                 IsActive = unit.suIsActive
                             };

                foreach (var item in result)
                {
                    if (item.IsActive.Trim() == "y")
                    {
                        var smdue = new SearchMasterDataUnitEntity();
                        smdue.Id = item.Id;
                        smdue.SiteCode = item.SiteCode.Trim();
                        
                        smdue.OfferCode = item.OfferCode.Trim();
                        smdue.TourOperatorId = item.TourOperator;
                        smdue.suUnitId = item.SuUnitId;
                        smdue.OfferName = item.OfferName.Trim();
                        smdue.Description = item.Description.Trim();
                        smdue.ImagePath = item.ImageName.Trim();
                        smdue.RouteObjektTyp = item.RouteObjektType.Trim();
                        list.Add(smdue);
                    }
                }
            }

            return list;
        }

        public IEnumerable<SearchMasterDataUnitEntity> GetSearchMasterDataUnitEntitys(int tourOperatorId)
        {
            var list = new List<SearchMasterDataUnitEntity>();
            using (var context = new OHV_V3_SearchEntities())
            {
                var result = from unit in context.SEH_UnitInfo
                             where unit.suTourOperator == tourOperatorId
                             select new
                             {
                                 unit.Id,
                                 SuUnitId = unit.suUnitId,
                                 angebotVon = unit.suAngebotVon,
                                 angebotBis = unit.suAngebotBis,
                                 TourOperator = unit.suTourOperator,
                                 TourOperatorCode = unit.TourOperatorCode,
                                 SiteCode = unit.suSiteCode,
                                 OfferCode = unit.suOfferCode,
                                 OfferName = unit.suKurzBeschreibung,
                                 Description = unit.suLangBeschreibung,
                                 IsActive = unit.suIsActive
                             };


                foreach (var item in result)
                {
                    if (item.IsActive.Trim() == "y")
                    {
                        var smdue = new SearchMasterDataUnitEntity();
                        smdue.Id = item.Id;
                        smdue.SiteCode = item.SiteCode.Trim();
                        
                        smdue.OfferName = item.OfferName.Trim();
                        smdue.OfferCode = item.OfferCode.Trim();
                        smdue.Description = item.Description.Trim();
                        smdue.AngebotVon = item.angebotVon;
                        smdue.AngebotBis = item.angebotBis;
                        smdue.TourOperatorId = item.TourOperator;
                        smdue.TourOperatorCode = item.TourOperatorCode;
                        smdue.suUnitId = item.SuUnitId;
                        list.Add(smdue);
                    }
                }
            }

            return list;
        }

        public List<TouristSiteItem> GetTouristSiteItems()
        {
            var retList = new List<TouristSiteItem>();
            using (var context = new OHV_V3_SearchEntities())
            {
                var result = from obj in context.SEH_ObjektInfo
                             select obj;

                foreach (var item in result)
                {
                    var siteItem = new TouristSiteItem();
                    siteItem.Description = item.soLangBeschreibung;
                    siteItem.SiteName = item.soKurzBeschreibung;
                    siteItem.ImageThumbnailsPath = item.soImageLocation;
                    siteItem.SiteCode = item.soRouteObjektId;
                    siteItem.RegionId = item.soRegion;
                    siteItem.ImageThumbnailsPath = item.soImageLocation;
                    siteItem.PlaceId = item.soObjektId;

                    retList.Add(siteItem);
                }
            }
            return retList;
        }

        public void UpdateSearchUnit(SearchMasterDataUnitEntity unit)
        {
            SEH_UnitInfo entity = DP_Search.SEH_UnitInfo.GetFirstOrDefault(m => m.suSiteCode == unit.SiteCode &&
                                                                                m.suOfferCode == unit.OfferCode);
            if (entity != null)
            {
                entity.suAngebotVon = unit.AngebotVon;
                entity.suAngebotBis = unit.AngebotBis;
                entity.suKurzBeschreibung = unit.OfferName;
                entity.suLangBeschreibung = unit.Description;
                entity.suAnbieterHinweis = unit.AnbieterHinweis;
                DP_Search.SEH_UnitInfo.AddEntity(entity);
            }
        }

        public void DeletePriceIndexForStopBooking(string touropetatorCode, string siteCode, string unitCode, DateTime von, DateTime bis)
        {
            var unit = DP_Search.SEH_UnitInfo.GetFirstOrDefault(m => m.TourOperatorCode == touropetatorCode && m.suSiteCode == siteCode );
            DeletePriceIndexForStopBooking(unit.suUnitId, von, bis);
        }
        public void DeletePriceIndexForStopBooking(int unitId, DateTime von, DateTime bis)
        {
            var entities = new OHV_V3_SearchEntities();
            DateTime abr = von.AddDays(-21);
            var v = from preis in entities.SEH_FeWoPreiseSet
                    join unit in entities.SEH_UnitInfo
                             on preis.Angebot_Id equals unit.suUnitId
                    where unit.suUnitId == unitId
                    && preis.Anreise >= abr
                    && preis.Anreise <= bis
                    select preis;

            foreach (SEH_FeWoPreiseSet fp in v)
            {
                DateTime anreise = fp.Anreise;
                DateTime abreise = fp.Anreise.AddDays(fp.Reisedauer);
                if (abreise > von && abreise < bis)
                    entities.SEH_FeWoPreiseSet.Remove(fp);
                else if (anreise > von && anreise < bis)
                    entities.SEH_FeWoPreiseSet.Remove(fp);
                else if (anreise < von && abreise > bis)
                    entities.SEH_FeWoPreiseSet.Remove(fp);
                else if (anreise >= von && abreise <= bis)
                    entities.SEH_FeWoPreiseSet.Remove(fp);
                else if (von >= anreise && von < abreise)
                    entities.SEH_FeWoPreiseSet.Remove(fp);
                else if (bis > anreise && bis < abreise)
                    entities.SEH_FeWoPreiseSet.Remove(fp);
            }
            entities.SaveChanges();
        }

        public TouristSiteItem GetSiteEntity(string siteCode)
        {
            var ret = new TouristSiteItem();
            using (var context = new OHV_V3_SearchEntities())
            {
                var result = (from site in context.SEH_ObjektInfo
                              where site.soRouteObjektId == siteCode
                              select site).FirstOrDefault();

                if (result == null)
                    return null;

                ret.SiteCode = result.soRouteObjektId;
                ret.SiteName = result.soKurzBeschreibung.Trim();
                ret.RegionId = result.soRegion;
                ret.Description = result.soLangBeschreibung;
                ret.PlaceId = result.soOrtId;
            }
            return ret;
        }

        public List<TerminAndPriceItem> GetTerminAndPriceList(int unitId)
        {
            var entities = new OHV_V3_SearchEntities();
            var retList = new List<TerminAndPriceItem>();

            var v = from preis in entities.SEH_FeWoPreiseSet
                    where preis.Angebot_Id == unitId
                    select preis;
            foreach (var item in v)
                retList.Add(new TerminAndPriceItem()
                {
                    Anreise = item.Anreise,
                    ReiseDauer = item.Reisedauer,
                    VonPersonen = item.MinPersonen,
                    BisPersonen =
                    item.MaxPersonen,
                    Preis = item.EndPreis
                });
            return retList;
        }
    }
    public class IgorResult
    {
        public int PVLeistungId;
        public int PVPreisId;
        public string GroupCode;
        public int UnitId;
        public DateTime Anreise;
        public int Reisedauer;
        public decimal ListenPreis;
        public decimal EndPreis;
        public string HtmlBeschreibungLang;
        public string TourOperator;
        public int Verpflegung;
        public string ImageName;
        public string UnitName;
        public string UnitRoute;
        public string UnitTypRoute;

    }
}
