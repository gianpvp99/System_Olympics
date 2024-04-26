using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Formats.Tar;
using System.Security.Claims;
using System.Text;
using SystemOlympics_Entity;

namespace SystemOlympics_Data
{
    public class DLogin
    {
        readonly IConfiguration _configuration;
        public DLogin(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public async Task<ELogin> Login(string user, string password)
        {
            try
            {
                ELogin response = new ELogin();
                using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    await cn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("dbo.login", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@user", user);
                        cmd.Parameters.AddWithValue("@password", password);

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {

                                response.Rstate = reader.GetInt32(reader.GetOrdinal("Estado"));
                                response.message = reader.GetString(reader.GetOrdinal("Mensaje"));

                                if (response.Rstate == 1)
                                {
                                    //// Decodificar el Token con hash256
                                    //var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
                                    //var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                                    //// Crear los claims

                                    //var claims = new[]
                                    //{
                                    //    new Claim(ClaimTypes.Name, reader.GetString(reader.GetOrdinal("name"))),
                                    //    new Claim(ClaimTypes.Email, reader.GetString(reader.GetOrdinal("name"))),
                                    //    new Claim(ClaimTypes.GivenName, reader.GetString(reader.GetOrdinal("name"))),
                                    //    new Claim("Lo que tu quieras", "El valor ingresar aqui")
                                    //};

                                    ////// Crear el token

                                    //var token = new JwtSecurityToken(
                                    //    _configuration["Jwt:Issuer"],
                                    //    _configuration["Jwt:Audience"],
                                    //    claims,
                                    //    expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(_configuration["Jwt:Expire"])),
                                    //    signingCredentials: credentials);

                                    //response.Token = new JwtSecurityTokenHandler().WriteToken(token);
                                    response.idUser = reader.GetInt32(reader.GetOrdinal("idUser"));
                                    response.user = reader.GetString(reader.GetOrdinal("user"));
                                    response.nroDocument = reader.GetString(reader.GetOrdinal("nroDocument"));
                                    response.name= reader.GetString(reader.GetOrdinal("name"));
                                    response.email = reader.GetString(reader.GetOrdinal("email"));
                                    response.phone = reader.GetString(reader.GetOrdinal("phone"));

                                }

                            }
                        }
                        return response;
                    }
                }

            } catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
