﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultCo_ISD_API.V1.DTO
{
    public class LocationV1DTO
    {
        public int LocationId { get; set; }
        public int LocationTypeId { get; set; }
        public string LocationName { get; set; }
        public string BuildingId { get; set; }
        public string LocationAddress { get; set; }
        public string RoomNumber { get; set; }
        public string FloorNumber { get; set; }


        public LocationTypeV1DTO LocationTypeDTO { get; set; }
    }
}
