using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ShipTransportations.Model.Model;

namespace ShipTransportations.Model.Repository
{
    public class CargoRepository : IRepository<Cargo>
    {
        public void Create(Cargo item)
        {
            using (var cn = new SqlConnection(RepositoryHelper.ConnStr)) {
                try {
                    using (var cmd = new SqlCommand("CreateCargo", cn)) {
                        cmd.CommandType = CommandType.StoredProcedure;
                        var parameters = new[] {
                            new SqlParameter {
                                ParameterName = "@TypeID",
                                Value = item.TypeId,
                                SqlDbType = SqlDbType.Int,
                                Direction = ParameterDirection.Input
                            },
                            new SqlParameter {
                                ParameterName = "@TripID",
                                Value = item.TripId,
                                SqlDbType = SqlDbType.Int,
                                Direction = ParameterDirection.Input
                            },
                            new SqlParameter {
                                ParameterName = "@Number",
                                Value = item.Number,
                                SqlDbType = SqlDbType.Int,
                                Direction = ParameterDirection.Input
                            },
                            new SqlParameter {
                                ParameterName = "@Weight",
                                Value = item.Weight,
                                SqlDbType = SqlDbType.Int,
                                Direction = ParameterDirection.Input
                            },
                            new SqlParameter {
                                ParameterName = "@Price",
                                Value = item.Price,
                                SqlDbType = SqlDbType.Money,
                                Direction = ParameterDirection.Input
                            },
                            new SqlParameter {
                                ParameterName = "@InsurancePrice",
                                Value = item.InsurancePrice,
                                SqlDbType = SqlDbType.Money,
                                Direction = ParameterDirection.Input
                            }
                        };
                        cmd.Parameters.AddRange(parameters);
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

        public void Update(Cargo item)
        {
            using (var cn = new SqlConnection(RepositoryHelper.ConnStr)) {
                try {
                    using (var cmd = new SqlCommand("UpdateCargo", cn)) {
                        cmd.CommandType = CommandType.StoredProcedure;
                        var parameters = new[] {
                            new SqlParameter {
                                ParameterName = "@CargoID",
                                Value = item.CargoId,
                                SqlDbType = SqlDbType.Int,
                                Direction = ParameterDirection.Input
                            },
                            new SqlParameter {
                                ParameterName = "@TypeID",
                                Value = item.TypeId,
                                SqlDbType = SqlDbType.Int,
                                Direction = ParameterDirection.Input
                            },
                            new SqlParameter {
                                ParameterName = "@TripID",
                                Value = item.TripId,
                                SqlDbType = SqlDbType.Int,
                                Direction = ParameterDirection.Input
                            },
                            new SqlParameter {
                                ParameterName = "@Number",
                                Value = item.Number,
                                SqlDbType = SqlDbType.Int,
                                Direction = ParameterDirection.Input
                            },
                            new SqlParameter {
                                ParameterName = "@Weight",
                                Value = item.Weight,
                                SqlDbType = SqlDbType.Int,
                                Direction = ParameterDirection.Input
                            },
                            new SqlParameter {
                                ParameterName = "@Price",
                                Value = item.Price,
                                SqlDbType = SqlDbType.Money,
                                Direction = ParameterDirection.Input
                            },
                            new SqlParameter {
                                ParameterName = "@InsurancePrice",
                                Value = item.InsurancePrice,
                                SqlDbType = SqlDbType.Money,
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
            using (var cn = new SqlConnection(RepositoryHelper.ConnStr)) {
                try {
                    using (var cmd = new SqlCommand("DeleteCargo", cn)) {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(
                            new SqlParameter {
                                ParameterName = "@CargoID",
                                Value = id,
                                SqlDbType = SqlDbType.Int,
                                Direction = ParameterDirection.Input
                        });
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

        public List<Cargo> ReadAll()
        {
            var cargos = new List<Cargo>();
            using (var cn = new SqlConnection(RepositoryHelper.ConnStr)) {
                try {
                    using (var cmd = new SqlCommand("ReadCargos", cn)) {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cn.Open();
                        using (var dr = cmd.ExecuteReader()) {
                            while (dr.Read()) {
                                cargos.Add(new Cargo {
                                    CargoId = int.Parse(dr["CargoID"].ToString()),
                                    TypeId = int.Parse(dr["TypeID"].ToString()),
                                    TripId = int.Parse(dr["TripID"].ToString()),
                                    Number = int.Parse(dr["Number"].ToString()),
                                    Weight = int.Parse(dr["Weight"].ToString()),
                                    Price = double.Parse(dr["Price"].ToString()),
                                    InsurancePrice = double.Parse(dr["InsurancePrice"].ToString())
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
            return cargos;
        }

        public Cargo GetItem(int id)
        {
            var cargo = new Cargo();
            using (var cn = new SqlConnection(RepositoryHelper.ConnStr)) {
                try {
                    using (var cmd = new SqlCommand("ReadCargo", cn)) {
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
                                cargo.CargoId = int.Parse(dr["CargoID"].ToString());
                                cargo.TypeId = int.Parse(dr["TypeID"].ToString());
                                cargo.TripId = int.Parse(dr["TripID"].ToString());
                                cargo.Number = int.Parse(dr["Number"].ToString());
                                cargo.Weight = int.Parse(dr["Weight"].ToString());
                                cargo.Price = double.Parse(dr["Price"].ToString());
                                cargo.InsurancePrice = double.Parse(dr["InsurancePrice"].ToString());
                            }
                        }
                    }
                }
                catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                }
                finally {
                    cn.Close();
                    if (cargo.CargoId == 0) throw new Exception("Can't find object with such id.");
                }
            }
            return cargo;
        }
    }
}
