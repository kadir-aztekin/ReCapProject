using Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class CarDetailDto:IDto
    {
        public decimal DailyPrice { get; set; }
        public int ModelYear { get; set; }
        public int BrandId { get; set; }
        public string Description { get; set; }
        public string BrandName { get; set; }
        
    }
}
