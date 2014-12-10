using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ShipTransportations.Model.Model;

namespace ShipTransportations.Model.Repository
{
    public class TripRepositiry : IRepository<Trip>
    {
        public void Create(Trip item)
        {
            using (var cn = new SqlConnection(RepositoryHelper.ConnStr)) {
                try {
                    using (var cmd = new SqlCommand("CreateTrip", cn)) {
                        cmd.CommandType = CommandType.StoredProcedure;
                        var parameters = new[] {
                            new SqlParameter {
                                ParameterName = "@CaptainID",
                                Value = item.CaptainId,
                                SqlDbType = SqlDbType.Int,
                                Direction = ParameterDirection.Input
                            },
                            new SqlParameter {
                                ParameterName = "@ShipID",
                                Value = item.ShipId,
                                SqlDbType = SqlDbType.Int,
                                Direction = ParameterDirection.Input
                            },
                            new SqlParameter {
                                ParameterName = "@PortFromID",
                                Value = item.PortIdFrom,
                                SqlDbType = SqlDbType.Int,
                                Direction = ParameterDirection.Input
                            },
                            new SqlParameter {
                                ParameterName = "@PortToID",
                                Value = item.PortIdTo,
                                SqlDbType = SqlDbType.Money,
                                Direction = ParameterDirection.Input
                            },
                            new SqlParameter {
                                ParameterName = "@StartDate",
                                Value = item.StartDate,
                                SqlDbType = SqlDbType.Date,
                                Direction = ParameterDirection.Input
                            },
                            new SqlParameter {
                                ParameterName = "@EndDate",
                                Value = item.EndDate,
                                SqlDbType = SqlDbType.Date,
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

        public void Update(Trip item)
        {
             using (var cn = new SqlConnection(RepositoryHelper.ConnStr)) {
                try {
                    using (var cmd = new SqlCommand("UpdateTrip", cn)) {
                        cmd.CommandType = CommandType.StoredProcedure;
                        var parameters = new[] {
                            new SqlParameter {
                                ParameterName = "@TripID",
                                Value = item.TripId,
                                SqlDbType = SqlDbType.Int,
                                Direction = ParameterDirection.Input
                            },
                            new SqlParameter {
                                ParameterName = "@CaptainID",
                                Value = item.CaptainId,
                                SqlDbType = SqlDbType.Int,
                                Direction = ParameterDirection.Input
                            },
                            new SqlParameter {
                                ParameterName = "@ShipID",
                                Value = item.ShipId,
                                SqlDbType = SqlDbType.Int,
                                Direction = ParameterDirection.Input
                            },
                            new SqlParameter {
                                ParameterName = "@PortFromID",
                                Value = item.PortIdFrom,
                                SqlDbType = SqlDbType.Int,
                                Direction = ParameterDirection.Input
                            },
                            new SqlParameter {
                                ParameterName = "@PortFromID",
                                Value = item.PortIdTo,
                                SqlDbType = SqlDbType.Money,
                                Direction = ParameterDirection.Input
                            },
                            new SqlParameter {
                                ParameterName = "@StartDate",
                                Value = item.StartDate,
                                SqlDbType = SqlDbType.Date,
                                Direction = ParameterDirection.Input
                            },
                            new SqlParameter {
                                ParameterName = "@EndDate",
                                Value = item.EndDate,
                                SqlDbType = SqlDbType.Date,
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
                    using (var cmd = new SqlCommand("DeleteTrip", cn)) {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(
                            new SqlParameter {
                                ParameterName = "@TripID",
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

        public List<Trip> ReadAll()
        {
            var trips = new List<Trip>();
            using (var cn = new SqlConnection(RepositoryHelper.ConnStr)) {
                try {
                    using (var cmd = new SqlCommand("ReadTrips", cn)) {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cn.Open();
                        using (var dr = cmd.ExecuteReader()) {
                            while (dr.Read()) {
                                trips.Add(new Trip {
                                    TripId = int.Parse(dr["TripID"].ToString()),
                                    CaptainId = int.Parse(dr["CaptainID"].ToString()),
                                    ShipId = int.Parse(dr["ShipID"].ToString()),
                                    PortIdFrom = int.Parse(dr["PortFromID"].ToString()),
                                    PortIdTo = int.Parse(dr["PortToID"].ToString()),
                                    StartDate = DateTime.Parse(dr["StartDate"].ToString()),
                                    EndDate = DateTime.Parse(dr["EndDate"].ToString())
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
            return trips;
        }

        public Trip GetItem(int id)
        {
            var trip = new Trip();
            using (var cn = new SqlConnection(RepositoryHelper.ConnStr)) {
                try {
                    using (var cmd = new SqlCommand("ReadTrip", cn)) {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cn.Open();
                        using (var dr = cmd.ExecuteReader()) {
                            while (dr.Read()) {
                                trip.TripId = int.Parse(dr["TripID"].ToString());
                                trip.CaptainId = int.Parse(dr["CaptainID"].ToString());
                                trip.ShipId = int.Parse(dr["ShipID"].ToString());
                                trip.PortIdFrom = int.Parse(dr["PortFromID"].ToString());
                                trip.PortIdTo = int.Parse(dr["PortToID"].ToString());
                                trip.StartDate = DateTime.Parse(dr["StartDate"].ToString());
                                trip.EndDate = DateTime.Parse(dr["EndDate"].ToString());
                            }
                        }
                    }
                }
                catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                }
                finally {
                    cn.Close();
                    if (trip.TripId == 0) throw new Exception("Can't find object with such id.");
                }
            }
            return trip;
        }
    }
}
