﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WheresTheBread.Data.Data
{
    public class SubActivityItemJoin
    {
        public int SubActivityId { get; set; }
        [ForeignKey("SubActivityId")]
        public SubActivity SubActivity { get; set; }
        public int ItemId { get; set; }
        [ForeignKey("ItemId")]
        public Item Item { get; set; }
    }
}
