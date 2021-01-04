﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DigWorkSheet.WebApi.Database;

namespace DigWorkSheet.WebApi.Mappers
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Customer, Model.Customer>(); // means you want to map from Customer to Model.Customer
        }
    }
}
