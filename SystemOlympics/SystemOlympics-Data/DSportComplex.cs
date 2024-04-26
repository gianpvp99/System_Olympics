using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemOlympics_Entity;
using SystemOlympics_Entity.EResponse;
using SystemOlympics_Entity.Request;

namespace SystemOlympics_Data
{
    public class DSportComplex
    {
        readonly IConfiguration _configuration;
        public DSportComplex(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public async Task<List<ESportComplex>> List(string search, int page, int pageSize)
        {
            try
            {
                List<ESportComplex> list = new List<ESportComplex>();
                using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    await cn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("dbo.listSportComplex", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@search", search);
                        cmd.Parameters.AddWithValue("@page", page);
                        cmd.Parameters.AddWithValue("@pageSize", pageSize);
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                list.Add(new ESportComplex()
                                {
                                    idSportComplex = reader.GetInt32(reader.GetOrdinal("idSportComplex")),
                                    idCampusOlympic = reader.GetInt32(reader.GetOrdinal("idCampusOlympic")),
                                    idTypeSportComplex = reader.GetInt32(reader.GetOrdinal("idTypeSportComplex")),
                                    name = reader.GetString(reader.GetOrdinal("name")),
                                    bossOrganization = reader.GetString(reader.GetOrdinal("bossOrganization")),
                                    totalArea = reader.GetString(reader.GetOrdinal("totalArea")),
                                    state = reader.GetBoolean(reader.GetOrdinal("state")),
                                    dateCreate = reader.GetDateTime(reader.GetOrdinal("dateCreate")),
                                    dateModification = reader.GetDateTime(reader.GetOrdinal("dateModification"))
                                });
                            }
                        }
                    }
                    cn.Close();

                }

                return list;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<RESSportComplex> Maintenance(RSportComplex maintenance)
        {
            try
            {
                RESSportComplex response = new RESSportComplex();
                using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    await cn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("dbo.maintenanceSportComplex", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idUser", maintenance.idUser);
                        cmd.Parameters.AddWithValue("@option", maintenance.option);
                        cmd.Parameters.AddWithValue("@idSportComplex", maintenance.idSportComplex);
                        cmd.Parameters.AddWithValue("@idCampusOlympic", maintenance.idCampusOlympic);
                        cmd.Parameters.AddWithValue("@idTypeSportComplex", maintenance.idTypeSportComplex);
                        cmd.Parameters.AddWithValue("@name", maintenance.name);
                        cmd.Parameters.AddWithValue("@bossOrganization", maintenance.bossOrganization);
                        cmd.Parameters.AddWithValue("@totalArea", maintenance.totalArea);
                        cmd.Parameters.AddWithValue("@state", maintenance.state);

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                response.state = reader.GetInt32(reader.GetOrdinal("Estado"));
                                response.message = reader.GetString(reader.GetOrdinal("Mensaje"));
                            }
                        }
                    }
                    await cn.CloseAsync();

                    return response;


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
