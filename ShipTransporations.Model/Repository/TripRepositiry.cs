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
                                int? cId, sId, pfId, ptId;
                                if (string.IsNullOrEmpty(dr["CaptainID"].ToString()))
                                    cId = null;
                                else
                                    cId = int.Parse(dr["CaptainID"].ToString());
                                if (string.IsNullOrEmpty(dr["ShipID"].ToString()))
                                    sId = null;
                                else
                                    sId = int.Parse(dr["ShipID"].ToString());
                                if (string.IsNullOrEmpty(dr["PortFromID"].ToString()))
                                    pfId = null;
                                else
                                    pfId = int.Parse(dr["PortFromID"].ToString());
                                if (string.IsNullOrEmpty(dr["PortToID"].ToString()))
                                    ptId = null;
                                else
                                    ptId = int.Parse(dr["PortToID"].ToString());
                                trips.Add(new Trip {
                                    TripId = int.Parse(dr["TripID"].ToString()),
                                    CaptainId = cId,
                                    ShipId = sId,
                                    PortIdFrom = pfId,
                                    PortIdTo = ptId,
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
                        cmd.Parameters.Add(new SqlParameter {
                            ParameterName = "@ID",
                            Value = id,
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.Input
                        });
                        cn.Open();
                        using (var dr = cmd.ExecuteReader()) {
                            while (dr.Read()) {
                                trip.TripId = int.Parse(dr["TripID"].ToString());
                                if (string.IsNullOrEmpty(dr["CaptainID"].ToString()))
                                    trip.CaptainId = null;
                                else
                                    trip.CaptainId = int.Parse(dr["CaptainID"].ToString());
                                if (string.IsNullOrEmpty(dr["ShipID"].ToString()))
                                    trip.ShipId = null;
                                else
                                    trip.ShipId = int.Parse(dr["ShipID"].ToString());
                                if (string.IsNullOrEmpty(dr["PortFromID"].ToString()))
                                    trip.PortIdFrom = null;
                                else
                                    trip.PortIdFrom = int.Parse(dr["PortFromID"].ToString());
                                if (string.IsNullOrEmpty(dr["PortToID"].ToString()))
                                    trip.PortIdTo = null;
                                else
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
