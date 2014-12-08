using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ShipTransportations.Model.Model;

namespace ShipTransportations.Model.Repository
{
    public class CityRepository : IRepository<City>
    {
        public void Create(City item) {
            using (var cn = new SqlConnection(RepositoryHelper.ConnStr)) {
                try {
                    using (var cmd = new SqlCommand("CreateCity", cn)) {
                        cmd.CommandType = CommandType.StoredProcedure;
                        var param = new SqlParameter {
                            ParameterName = "@Name",
                            Value = item.Name,
                            SqlDbType = SqlDbType.VarChar,
                            Direction = ParameterDirection.Input
                        };
                        cmd.Parameters.Add(param);
                        cn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                }
                finally {
                    cn.Close();
                }
            }
        }

        public void Update(City item)
        {
            using (var cn = new SqlConnection(RepositoryHelper.ConnStr))
            {
                try {
                    using (var cmd = new SqlCommand("UpdateCity", cn)) {
                        cmd.CommandType = CommandType.StoredProcedure;
                        var parameters = new[] {
                            new SqlParameter {
                                ParameterName = "@CityID",
                                Value = item.CityId,
                                SqlDbType = SqlDbType.Int,
                                Direction = ParameterDirection.Input
                            },
                            new SqlParameter {
                                ParameterName = "@Name",
                                Value = item.Name,
                                SqlDbType = SqlDbType.VarChar,
                                Direction = ParameterDirection.Input
                            }
                        };
                        cmd.Parameters.Add(parameters);
                        cn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                }
                finally {
                    cn.Close();
                }
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<City> ReadAll()
        {
            var cities = new List<City>();
            using (var cn = new SqlConnection(RepositoryHelper.ConnStr)) {
                try {
                    using (var cmd = new SqlCommand("ReadCities", cn)) {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cn.Open();
                        using (var dr = cmd.ExecuteReader()) {
                            while (dr.Read()) {
                                cities.Add(new City {
                                        CityId = int.Parse(dr["CityID"].ToString()),
                                        Name = dr["Name"].ToString()
                                    });
                            }
                        }
                    }
                }
                catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                }
                finally {
                    cn.Close();
                }
            }
            return cities;
        }

        public City GetItem(int id) {
            var city = new City();
            using (var cn = new SqlConnection(RepositoryHelper.ConnStr)) {
                try {
                    using (var cmd = new SqlCommand("ReadCity", cn)) {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter {
                            ParameterName = "ID",
                            SqlDbType = SqlDbType.Int,
                            Value = id,
                            Direction = ParameterDirection.Input
                        });
                        cn.Open();
                        using (var dr = cmd.ExecuteReader()) {
                            while (dr.Read()) {
                                city.CityId = int.Parse(dr["CityID"].ToString());
                                city.Name = dr["Name"].ToString();
                            }
                        }
                    }
                }
                catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                }
                finally {
                    cn.Close();
                    if (city.CityId == 0) throw new Exception("Can't find object with such id.");
                }
            }
            return city;
        }
    }
}
