using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ShipTransportations.Model.Model;

namespace ShipTransportations.Model.Repository
{
    public class CargoTypesRepository : IRepository<CargoType>
    {
        public void Create(CargoType item)
        {
            using (var cn = new SqlConnection(RepositoryHelper.ConnStr)) {
                try {
                    using (var cmd = new SqlCommand("CreateCargoType", cn)) {
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

        public void Update(CargoType item)
        {
            using (var cn = new SqlConnection(RepositoryHelper.ConnStr))
            {
                try {
                    using (var cmd = new SqlCommand("UpdateCargoType", cn)) {
                        cmd.CommandType = CommandType.StoredProcedure;
                        var parameters = new[] {
                            new SqlParameter {
                                ParameterName = "@TypeID",
                                Value = item.TypeId,
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

        public List<CargoType> ReadAll()
        {
            var types = new List<CargoType>();
            using (var cn = new SqlConnection(RepositoryHelper.ConnStr)) {
                try {
                    using (var cmd = new SqlCommand("ReadCargoTypes", cn)) {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cn.Open();
                        using (var dr = cmd.ExecuteReader()) {
                            while (dr.Read()) {
                                types.Add(new CargoType {
                                    TypeId = int.Parse(dr["TypeID"].ToString()),
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
            return types;
        }

        public CargoType GetItem(int id)
        {
            var cargoType = new CargoType();
            using (var cn = new SqlConnection(RepositoryHelper.ConnStr)) {
                try {
                    using (var cmd = new SqlCommand("ReadCargoType", cn)) {
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
                                cargoType.TypeId = int.Parse(dr["TypeID"].ToString());
                                cargoType.Name = dr["Name"].ToString();
                            }
                        }
                    }
                }
                catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                }
                finally {
                    cn.Close();
                    if (cargoType.TypeId == 0) throw new Exception("Can't find object with such id.");
                }
            }
            return cargoType;
        }
    }
}
