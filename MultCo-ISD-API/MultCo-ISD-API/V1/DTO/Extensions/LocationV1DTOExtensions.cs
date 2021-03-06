﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MultCo_ISD_API.Models;

namespace MultCo_ISD_API.V1.DTO
{
	public static class LocationV1DTOExtensions
	{
		public static LocationV1DTO ToLocationV1DTO(this Location item)
		{
			if (item == null)
			{
				throw new ArgumentException(nameof(item));
			}

			LocationV1DTO locationV1DTO = new LocationV1DTO();
			locationV1DTO.CopyFromLocation(item);
			return locationV1DTO;
		}

		public static Location toLocation(this LocationV1DTO item)
		{
			if (item == null)
			{
				throw new ArgumentException(nameof(item));
			}

			Location location = new Location();
			location.CopyFromLocationV1DTO(item);
			return location;
		}

		public static void CopyFromLocationV1DTO(this Location to, LocationV1DTO from)
		{
			to.LocationId = from.LocationId;
			to.LocationTypeId = from.LocationTypeId;
			to.BuildingId = from.BuildingId;
			to.LocationAddress = from.LocationAddress;
			to.RoomNumber = from.RoomNumber;
			to.FloorNumber = from.FloorNumber;
			to.LocationName = from.LocationName;

			to.LocationType = from.LocationTypeDTO?.ToLocationType();
		}

		public static void CopyFromLocation(this LocationV1DTO to, Location from)
		{
			to.LocationId = from.LocationId;
			to.LocationTypeId = from.LocationTypeId;
			to.BuildingId = from.BuildingId;
			to.LocationAddress = from.LocationAddress;
			to.RoomNumber = from.RoomNumber;
			to.FloorNumber = from.FloorNumber;
			to.LocationName = from.LocationName;

			to.LocationTypeDTO = from.LocationType?.ToLocationTypeV1DTO();
		}
	}
}
