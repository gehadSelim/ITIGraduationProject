﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graduationProject.Bl.DTOs
{
    public class CityReadSimpleDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public byte StateId { get; set; }
    }
}
