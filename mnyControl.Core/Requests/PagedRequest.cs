﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnyControl.Core.Requests
{
    public class PagedRequest : Request
    {
        public int PageNumber { get; set; } = Configuration.DefaultPageNumber;
        public int PageSize { get; set; } =  Configuration.DefaultPageSize;
    }
}
