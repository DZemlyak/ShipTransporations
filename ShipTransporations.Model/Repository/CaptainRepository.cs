using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using ShipTransportations.Model.Model;

namespace ShipTransportations.Model.Repository
{
    public class CaptainRepository : IRepository<Captain>
    {
        public void Create(Captain item)
        {
            using (var cn = new SqlConnection(RepositoryHelper.ConnStr)) {
                try {
                    using (var cmd = new SqlCommand("CreateCaptain", cn)) {
                        cmd.CommandType = CommandType.StoredProcedure;
                        var parameters = new[] {
                            new SqlParameter {
                                ParameterName = "@FirstName",
                                SqlDbType = SqlDbType.VarChar,
                                Value = item.FirstName,
                                Direction = ParameterDirection.Input
                            },
                            new SqlParameter {
                                ParameterName = "@LastName",
                                SqlDbType = SqlDbType.VarChar,
                                Value = item.LastName,
                                Direction = ParameterDirection.Input
                            },
                            new SqlParameter {
                                ParameterName = "@ShipId",
                                SqlDbType = SqlDbType.Int,
                                Value = item.ShipId,
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

        public void Update(Captain item)
        {
            using (var cn = new SqlConnection(RepositoryHelper.ConnStr)) {
                try {
                    using (var cmd = new SqlCommand("UpdateCaptain", cn)) {
                        cmd.CommandType = CommandType.StoredProcedure;
                        var parameters = new[] {
                            new SqlParameter {
                                ParameterName = "@CaptainID",
                                SqlDbType = SqlDbType.Int,
                                Value = item.CaptainId,
                                Direction = ParameterDirection.Input
                            },
                            new SqlParameter {
                                ParameterName = "@FirstName",
                                SqlDbType = SqlDbType.VarChar,
                                Value = item.FirstName,
                                Direction = ParameterDirection.Input
                            },
                            new SqlParameter {
                                ParameterName = "@LastName",
                                SqlDbType = SqlDbType.VarChar,
                                Value = item.LastName,
                                Direction = ParameterDirection.Input
                            },
                            new SqlParameter {
                                ParameterName = "@ShipId",
                                SqlDbType = SqlDbType.Int,
                                Value = item.ShipId,
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

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Captain> ReadAll()
        {
            var captains = new List<Captain>();
            using (var cn = new SqlConnection(RepositoryHelper.ConnStr)) {
                try {
                    using (var cmd = new SqlCommand("ReadCaptains", cn)) {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cn.Open();
                        using (var dr = cmd.ExecuteReader()) {
                            while (dr.Read()) {
                                captains.Add(new Captain {
                                    CaptainId = int.Parse(dr["CaptainID"].ToString()),
                                    ShipId = int.Parse(dr["ShipID"].ToString()),
                                    FirstName = dr["FirstName"].ToString(),
                                    LastName = dr["LastName"].ToString(),
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
            return captains;
        }

        public Captain GetItem(int id)
        {
            var captain = new Captain();
            using (var cn = new SqlConnection(RepositoryHelper.ConnStr)) {
                try {
                    using (var cmd = new SqlCommand("ReadCaptain", cn)) {
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
                                captain.CaptainId = int.Parse(dr["CaptainID"].ToString());
                                captain.FirstName = dr["FirstName"].ToString();
                                captain.LastName = dr["LastName"].ToString();
                                captain.ShipId = int.Parse(dr["ShipID"].ToString());
                            }
                        }
                    }
                }
                catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                }
                finally {
                    cn.Close();
                    if (captain.CaptainId == 0) throw new Exception("Can't find object with such id.");
                }
            }
            return captain;
        }
    }
}
