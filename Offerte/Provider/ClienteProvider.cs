using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Offerte.Provider
{
    public class ClienteProvider
    {
        public static List<Datatype.Cliente> NomiAziende()
        {
            string connectionString = Properties.Settings.Default.ConnectionString;
#if !Debug
            connectionString = Properties.Settings.Default.ConnessioneDB;
#endif
            List<Datatype.Cliente> result = new List<Datatype.Cliente>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    //string sql = @"SELECT RagioneSociale, Indirizzo, Citta, Cap FROM Anagrafiche.Cliente WHERE CodiceERP IS NOT NULL ORDER BY RagioneSociale ASC";
                    string sql = @" SELECT [Extent2].[Descr] AS [RagioneSociale], [Extent2].[Indir] AS [Indirizzo], [Extent2].[Citta] AS [Citta], [Extent2].[CAP] AS [CAP], [Extent5].Descrizione AS CondizionePagamento, NumeroCivico
                                    FROM  [dbo].[CliFor] AS [Extent1]
                                    INNER JOIN [dbo].[Anagrafiche] AS [Extent2] ON [Extent1].[CODFISC] = [Extent2].[CODFISC]
					                LEFT JOIN [Anagrafe].[CondizionePagamento] AS [Extent5] ON Extent1.[CODPAG] = [Extent5].[Codice]
                                    WHERE ([Extent1].[PrdTipo] = 'C') AND ([Extent1].[Abilitato] = 1) 
					                ORDER BY [Extent2].Descr ";
                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                            while (dr.Read())
                            {
                                Datatype.Cliente objTmp = new Datatype.Cliente();
                                if (!dr.IsDBNull(dr.GetOrdinal("RagioneSociale"))) objTmp.RagioneSociale = dr.GetString(dr.GetOrdinal("RagioneSociale"));
                                if (!dr.IsDBNull(dr.GetOrdinal("Indirizzo"))) objTmp.Indirizzo = dr.GetString(dr.GetOrdinal("Indirizzo"));
                                if (!dr.IsDBNull(dr.GetOrdinal("Citta"))) objTmp.Citta = dr.GetString(dr.GetOrdinal("Citta"));
                                if (!dr.IsDBNull(dr.GetOrdinal("Cap"))) objTmp.Cap = dr.GetString(dr.GetOrdinal("Cap"));
                                if (!dr.IsDBNull(dr.GetOrdinal("NumeroCivico"))) objTmp.NumeroCivico = dr.GetString(dr.GetOrdinal("NumeroCivico"));

                                if (!dr.IsDBNull(dr.GetOrdinal("CondizionePagamento"))) objTmp.CondizionePagamento = dr.GetString(dr.GetOrdinal("CondizionePagamento"));

                                result.Add(objTmp);
                            }
                    }
                    cnn.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }
    }
}
