using System;
using System.Data;
using System.Data.SqlClient;

namespace PokemonNameGame.API
{
    public class InsertService
    {
        private string SQLConnString { get; set; } = string.Empty;

        public InsertService()
        {
            if (SQLConnString == string.Empty)
            {
                SqlConnectionStringBuilder sqlConStringBuilder = new SqlConnectionStringBuilder();
                sqlConStringBuilder["server"] = @"(localdb)\MSSQLLocalDB";
                sqlConStringBuilder["Trusted_Connection"] = true;
                sqlConStringBuilder["Integrated Security"] = "SSPI";
                sqlConStringBuilder["Initial Catalog"] = "PROG455SP23";

                SQLConnString = sqlConStringBuilder.ToString();
            }
        }

        public void InsertPokemon(PokemonInsertModel model)
        {
            using (SqlConnection conn = new SqlConnection(SQLConnString))
            {
                conn.Open();

                string sproc = @"[dbo].[sp_InsertPokemon]";

                using (var cmd = new SqlCommand(sproc, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Name", model.Name);
                    cmd.Parameters.AddWithValue("@TypeID", model.Name);
                    cmd.Parameters.AddWithValue("@AltTypeID", model.AltTypeID);
                    cmd.Parameters.AddWithValue("@GenerationID", model.GenerationID);

                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
    }
}