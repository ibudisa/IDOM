using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QTouristik.PlugIn.OVH_V3.Search.LM
{
    public partial class OHV_V3_SearchEntities
    {
        public OHV_V3_SearchEntities()
     : base(GetConnectionString())
        {
        }
        public static string GetConnectionString()
        {

            // Initialize the connection string builder for the underlying provider.
            SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder
            {
                DataSource = "",
                InitialCatalog = "V10_QTouristik.Search",
                Encrypt = true,
                TrustServerCertificate = true,
                UserID = "",
                Password = ""

            };

            // Initialize the EntityConnectionStringBuilder.
            System.Data.EntityClient.EntityConnectionStringBuilder entityBuilder = new System.Data.EntityClient.EntityConnectionStringBuilder();
            entityBuilder.Provider = "System.Data.SqlClient";

            // Set the provider-specific connection string.
            entityBuilder.ProviderConnectionString = sqlBuilder.ToString();

            // Set the Metadata location.
            entityBuilder.Metadata = @"res://*/LM.OVH_V3_SearchModel.csdl|res://*/LM.OVH_V3_SearchModel.ssdl|res://*/LM.OVH_V3_SearchModel.msl";

            return entityBuilder.ConnectionString;
        }
    }
}
