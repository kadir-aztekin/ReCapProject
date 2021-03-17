﻿
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public  class Car:IEntity
    {
        // CAR ÜRÜNÜNN PROP METHODU İLE BİLGİLERİNİ YAZDIRDIK
        public int CarId { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string  Description { get; set; }
        public string BrandName { get; set; }
    }
}
