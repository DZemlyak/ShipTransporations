using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ShipTransportations.Model.Model;

namespace ShipTransportations.Model.Repository
{
    public class ShipRepository : IRepository<Ship>
    {
        public void Create(Ship item)
        {
            using (var cn = new SqlConnection(RepositoryHelper.ConnStr)) {
                try {
                    using (var cmd = new SqlCommand("CreateShip", cn)) {
                        cmd.CommandType = CommandType.StoredProcedure;
                        var parameters = new[] {
                            new SqlParameter {
                                ParameterName = "@PortID",
                                Value = item.PortId,
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
                                ParameterName = "@Capacity",
                                Value = item.Capacity,
                                SqlDbType = SqlDbType.Int,
                                Direction = ParameterDirection.Input
                            },
                            new SqlParameter {
                                ParameterName = "@CreateDate",
                                Value = item.CreateDate,
                                SqlDbType = SqlDbType.Date,
                                Direction = ParameterDirection.Input
                            },
                            new SqlParameter {
                                ParameterName = "@MaxDistance",
                                Value = item.MaxDistance,
                                SqlDbType = SqlDbType.Int,
                                Direction = ParameterDirection.Input
                            },
                            new SqlParameter {
                                ParameterName = "@CrewSize",
                                Value = item.CrewSize,
                                SqlDbType = SqlDbType.Int,
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

        public void Update(Ship item)
        {
            using (var cn = new SqlConnection(RepositoryHelper.ConnStr)) {
                try {
                    using (var cmd = new SqlCommand("UpdateShip", cn)) {
                        cmd.CommandType = CommandType.StoredProcedure;
                        var parameters = new[] {
                            new SqlParameter {
                                ParameterName = "@ShipID",
                                Value = item.ShipId,
                                SqlDbType = SqlDbType.Int,
                                Direction = ParameterDirection.Input
                            },
                            new SqlParameter {
                                ParameterName = "@PortID",
                                Value = item.PortId,
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
                                ParameterName = "@Capacity",
                                Value = item.Capacity,
                                SqlDbType = SqlDbType.Int,
                                Direction = ParameterDirection.Input
                            },
                            new SqlParameter {
                                ParameterName = "@CreateDate",
                                Value = item.CreateDate,
                                SqlDbType = SqlDbType.Date,
                                Direction = ParameterDirection.Input
                            },
                            new SqlParameter {
                                ParameterName = "@MaxDistance",
                                Value = item.MaxDistance,
                                SqlDbType = SqlDbType.Int,
                                Direction = ParameterDirection.Input
                            },
                            new SqlParameter {
                                ParameterName = "@CrewSize",
                                Value = item.CrewSize,
                                SqlDbType = SqlDbType.Int,
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

        public List<Ship> ReadAll()
        {
            var ships = new List<Ship>();
            using (var cn = new SqlConnection(RepositoryHelper.ConnStr)) {
                try {
                    using (var cmd = new SqlCommand("ReadShips", cn)) {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cn.Open();
                        using (var dr = cmd.ExecuteReader()) {
                            while (dr.Read()) {
                                ships.Add(new Ship {
                                    ShipId = int.Parse(dr["ShipID"].ToString()),
                                    PortId = int.Parse(dr["PortID"].ToString()),
                                    Number = int.Parse(dr["Number"].ToString()),
                                    Capacity = int.Parse(dr["Capacity"].ToString()),
                                    CreateDate = DateTime.Parse(dr["CreateDate"].ToString()),
                                    MaxDistance = int.Parse(dr["MaxDistance"].ToString()),
                                    CrewSize = int.Parse(dr["CrewSize"].ToString())
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
            return ships;
        }

        public Ship GetItem(int id)
        {
            var ship = new Ship();
            using (var cn = new SqlConnection(RepositoryHelper.ConnStr)) {
                try {
                    using (var cmd = new SqlCommand("ReadShip", cn)) {
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
                                ship.ShipId = int.Parse(dr["ShipID"].ToString());
                                ship.PortId = int.Parse(dr["PortID"].ToString());
                                ship.Number = int.Parse(dr["Number"].ToString());
                                ship.Capacity = int.Parse(dr["Capacity"].ToString());
                                ship.CreateDate = DateTime.Parse(dr["CreateDate"].ToString());
                                ship.MaxDistance = int.Parse(dr["MaxDistance"].ToString());
                                ship.CrewSize = int.Parse(dr["CrewSize"].ToString());
                            }
                        }
                    }
                }
                catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                }
                finally {
                    cn.Close();
                    if (ship.ShipId == 0) throw new Exception("Can't find object with such id.");
                }
            }
            return ship;
        }
    }
}
