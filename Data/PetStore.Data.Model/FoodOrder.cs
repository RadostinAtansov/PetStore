﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Data.Model
{
    public class FoodOrder
    {
        public int FoodId { get; set; }
        public Food Food { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
