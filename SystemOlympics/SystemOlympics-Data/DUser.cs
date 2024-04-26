using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemOlympics_Entity;
using SystemOlympics_Entity.Request;
using SystemOlympics_Entity.EResponse;

namespace SystemOlympics_Data
{
    public  class DUser
    {
        readonly IConfiguration _configuration;
        public DUser(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public async Task<List<EUser>> List(string search, int page, int pageSize)
        {
            try
            {
                List<EUser> list = new List<EUser>();
                using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    await cn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("dbo.listUser", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@search", search);
                        cmd.Parameters.AddWithValue("@page", page);
                        cmd.Parameters.AddWithValue("@pageSize", pageSize);
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                list.Add(new EUser()
                                {
                                    idUser = reader.GetInt32(0),
                                    user = reader.GetString(1),
                                    nroDocument = reader.GetString(2),
                                    name = reader.GetString(3),
                                    email = reader.GetString(4),
                                    phone = reader.GetString(5),
                                    state = reader.GetBoolean(6)
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
        public async Task<RESUser> Maintenance(RUser maintenance)
        {
            try
            {
                RESUser response = new RESUser();
                using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    await cn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("dbo.maintenanceUser", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idUser", maintenance.idUser);
                        cmd.Parameters.AddWithValue("@idUserDelete", maintenance.idUserDelete);
                        cmd.Parameters.AddWithValue("@user", maintenance.user);
                        cmd.Parameters.AddWithValue("@password", maintenance.password);
                        cmd.Parameters.AddWithValue("@nroDocument", maintenance.nroDocument);
                        cmd.Parameters.AddWithValue("@name", maintenance.name);
                        cmd.Parameters.AddWithValue("@email", maintenance.email);
                        cmd.Parameters.AddWithValue("@phone", maintenance.phone);
                        cmd.Parameters.AddWithValue("@state", maintenance.state);
                        cmd.Parameters.AddWithValue("@idUserModification", maintenance.idUserModification);
                        cmd.Parameters.AddWithValue("@option", maintenance.option);

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
