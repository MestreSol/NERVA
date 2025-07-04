﻿namespace Domain.Common
{
    public class Localization : BaseAuditableEntity
    {
        public string Country { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}
