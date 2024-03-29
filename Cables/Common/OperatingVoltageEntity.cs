﻿namespace Cables.Common
{
    public class OperatingVoltageEntity
    {
        public int Id { get; set; }

        public int ACVoltage { get; set; }

        public int ACFriquancy { get; set; }

        public int? DCVoltage { get; set; }

        public string Description { get; set; }
    }
}
