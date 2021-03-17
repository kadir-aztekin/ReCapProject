using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class RentalsDetailDto:IDto
    {
        public int Id { get; set; }
        public string brandName { get; set; }
        public string userName { get; set; }
        public DateTime rentDate { get; set; }
        public DateTime? returnDate { get; set; }
    }
}
