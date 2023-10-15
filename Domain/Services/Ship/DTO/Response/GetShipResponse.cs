﻿namespace Domain.Services.ShipService.DTO
{
    public class GetShipResponse
    {
        public Guid ShipId { get; set; }

        public string? ImoNumber { get; set; }

        public string? ShipName { get; set; }
    }
}