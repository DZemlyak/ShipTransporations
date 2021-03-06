﻿using System;
using System.Linq;
using ShipTransportations.Model.Repository;

namespace ShipTransportations.Model.Model
{
    public class Captain
    {
        private int? _shipId;
        public int CaptainId { get; set; }

        public int? ShipId {
            get { return _shipId; }
            set {
                if (value != null && RepositoryHelper.ShipRepository.ReadAll().All(a => a.ShipId != value))
                    throw new Exception(string.Format("\nCan't find specified ShipID : {0}.", value));               
                _shipId = value;
            }
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString() {
            return string.Format("\nCaptainID: {0}\nShipID: {1}\nFirstName: {2}\nLastName: {3}",
                CaptainId, ShipId, FirstName, LastName);
        }
    }
}
