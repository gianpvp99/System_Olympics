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
    public class DEvent
    {
        readonly IConfiguration _configuration;
        public DEvent(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public async Task<List<EEvent>> List(string search, int page, int pageSize)
        {
            try
            {
                List<EEvent> list = new List<EEvent>();
                using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    await cn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("dbo.listEvent", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@search", search);
                        cmd.Parameters.AddWithValue("@page", page);
                        cmd.Parameters.AddWithValue("@pageSize", pageSize);
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                list.Add(new EEvent()
                                {
                                    idEvent = reader.GetInt32(reader.GetOrdinal("idEvent")),
                                    idSportComplex = reader.GetInt32(reader.GetOrdinal("idSportComplex")),
                                    name = reader.GetString(reader.GetOrdinal("name")),
                                    numberParticipant = reader.GetInt32(reader.GetOrdinal("numberParticipant")),
                                    numberCommissar = reader.GetInt32(reader.GetOrdinal("numberCommissar")),
                                    state = reader.GetBoolean(reader.GetOrdinal("state"))
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

        public async Task<RESEvent> Maintenance(REvent maintenance)
        {
            try
            {
                RESEvent response = new RESEvent();
                using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    await cn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("dbo.maintenanceEvent", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idUser", maintenance.idUser);
                        cmd.Parameters.AddWithValue("@option", maintenance.option);
                        cmd.Parameters.AddWithValue("@idEvent", maintenance.idEvent);
                        cmd.Parameters.AddWithValue("@idSportComplex", maintenance.idSportComplex);
                        cmd.Parameters.AddWithValue("@name", maintenance.name);
                        cmd.Parameters.AddWithValue("@numberParticipant", maintenance.numberParticipant);
                        cmd.Parameters.AddWithValue("@numberCommissar", maintenance.numberCommissar);
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
