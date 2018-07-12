using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Web;
using System.Web;

namespace V50_IDOMBackOffice.AspxArea.Helper
{
    public class GridValidation
    {
        public static void ValidateInt(string fieldname,object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {
            int r;
            if (e.NewValues[fieldname] != null)
            {
                bool b = int.TryParse(e.NewValues[fieldname].ToString(), out r);
                if (!b)
                {
                    ASPxGridView grid = (ASPxGridView)sender;
                    AddError(e.Errors, grid.Columns[fieldname],
                    fieldname+" must be integer.");
                }
            }
        }

        public static void ValidateLength(string fieldname,int length, object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {
            ASPxGridView grid = (ASPxGridView)sender;

            if (fieldname == "ArrivalActual")
            {
                GridViewDataColumn col1 = grid.Columns["ArrivalActual"] as GridViewDataColumn;
                ASPxCheckBoxList chkListArrival = grid.FindEditRowCellTemplateControl(col1, "ASPxCheckBoxListArrival") as ASPxCheckBoxList;
                if (chkListArrival.SelectedItem == null) e.RowError = "Fill all the fields";
            }

            if (fieldname == "DepartureActual")
            {
                GridViewDataColumn col1 = grid.Columns["DepartureActual"] as GridViewDataColumn;
                ASPxCheckBoxList chkListDeparture = grid.FindEditRowCellTemplateControl(col1, "ASPxCheckBoxListDeparture") as ASPxCheckBoxList;
                if (chkListDeparture.SelectedItem == null) e.RowError = "Fill all the fields";
            }
            if (e.NewValues[fieldname] == null)
            {
                AddError(e.Errors, grid.Columns[fieldname],
                   fieldname + " cannot be null.");
            }
            if (e.NewValues[fieldname] != null &&
           e.NewValues[fieldname].ToString().Length < length)
            {
                
                AddError(e.Errors, grid.Columns[fieldname],
                fieldname+" must be at least " + length + " characters long.");
            }
        }
     /*   
        public static void ValidateFixedLength(string fieldname, object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
        {
            ASPxGridView grid = (ASPxGridView)sender;

           

            if (e.NewValues[fieldname] == null)
            {
                AddError(e.Errors, grid.Columns[fieldname],
                   fieldname + " cannot be null.");
            }

            //TODO: Ovo je jedna tehnicka funkcija u Helperu i ovdje ne smije da se obradjuju business logic informacije 
            if (e.NewValues[fieldname] != null &&
            (fieldname =="UnitCode"|| fieldname == "OfferCode"))
            {
                if (e.NewValues[fieldname].ToString().Length != 3)
                {
                    AddError(e.Errors, grid.Columns[fieldname],
                    fieldname + " must be three characters long.");
                }
            }
            //TODO: Ovo je jedna tehnicka funkcija u Helperu i ovdje ne smije da se obradjuju business logic informacije 
            if (grid.ID == "GridTouristSiteView")
            {
                if (e.NewValues[fieldname] != null &&
                    //TODO: Ovo je jedna tehnicka funkcija u Helperu i ovdje ne smije da se obradjuju business logic informacije 
                    fieldname == "SiteCode")
                {
                    if (e.NewValues[fieldname].ToString().Length != 6)
                    {
                        AddError(e.Errors, grid.Columns[fieldname],
                        fieldname + " must be six characters long.");
                    }
                }
            }
        }*/

        static void AddError(Dictionary<GridViewColumn, string> errors, GridViewColumn column, string errorText)
        {
            if (errors.ContainsKey(column)) return;
            errors[column] = errorText;
        }
    }
}
