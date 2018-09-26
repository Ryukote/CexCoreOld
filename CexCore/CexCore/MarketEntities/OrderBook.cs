﻿using CexCore.Helpers;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CexCore.MarketEntities
{
    public class OrderBook : EntityBase
    {
        [JsonProperty("asks")]
        public IEnumerable<IEnumerable<decimal>> Asks { get; private set; }

        [JsonProperty("bids")]
        public IEnumerable<IEnumerable<decimal>> Bids { get; private set; }

        [JsonProperty("timestamp")]
        public Timestamp Timestamp { get; private set; }

        public OrderBook()
        {

        }

    }
}
