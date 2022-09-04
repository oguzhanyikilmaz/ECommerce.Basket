﻿using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Basket.Infrastructure.Configurations
{
   public interface IRedisConnectionFactory
    {
        ConnectionMultiplexer Connection();
    }
}
