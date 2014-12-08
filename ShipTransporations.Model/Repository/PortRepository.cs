using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ShipTransportations.Model.Model;

namespace ShipTransportations.Model.Repository
{
    public class PortRepository : IRepository<Port>
    {
        public void Create(Port item)
        {
            using (var cn = new SqlConnection(RepositoryHelper.ConnStr)) {
                try {
                    using (var cmd = new SqlCommand("CreatePort", cn)) {
                        cmd.CommandType = CommandType.StoredProcedure;
                        var param = new SqlParameter {
                            ParameterName = "@Name",
                            Value = item.Name,
                            SqlDbType = SqlDbType.VarChar,
                            Direction = ParameterDirection.Input
                        };
                        cmd.Parameters.Add(param);
                        param = new SqlParameter {
                            ParameterName = "@CityID",
                            Value = item.CityId,
                            SqlDbType = SqlDbType.Int,
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

        public void Update(Port item)
        {
            using (var cn = new SqlConnection(RepositoryHelper.ConnStr))
            {
                try {
                    using (var cmd = new SqlCommand("UpdatePort", cn)) {
                        cmd.CommandType = CommandType.StoredProcedure;
                        var parameters = new[] {
                            new SqlParameter {
                                ParameterName = "@PortID",
                                Value = item.PortId,
                                SqlDbType = SqlDbType.Int,
                                Direction = ParameterDirection.Input
                            },
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

        public List<Port> ReadAll()
        {
            var ports = new List<Port>();
            using (var cn = new SqlConnection(RepositoryHelper.ConnStr)) {
                try {
                    using (var cmd = new SqlCommand("ReadPorts", cn)) {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cn.Open();
                        using (var dr = cmd.ExecuteReader()) {
                            while (dr.Read()) {
                                ports.Add(new Port {
                                    PortId = int.Parse(dr["PortID"].ToString()),
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
            return ports;
        }

        public Port GetItem(int id)
        {
            var port = new Port();
            using (var cn = new SqlConnection(RepositoryHelper.ConnStr)) {
                try {
                    using (var cmd = new SqlCommand("ReadPort", cn)) {
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
                                port.PortId = int.Parse(dr["PortID"].ToString());
                                port.CityId = int.Parse(dr["CityID"].ToString());
                                port.Name = dr["Name"].ToString();
                            }
                        }
                    }
                }
                catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                }
                finally {
                    cn.Close();
                    if (port.PortId == 0) throw new Exception("Can't find object with such id.");
                }
            }
            return port;
        }
    }
}
