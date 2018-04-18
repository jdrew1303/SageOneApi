﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SageOneApi.Client.Models
{
    public abstract class ControlTransaction
    {
        public string id { get; set; }
        public string displayed_as { get; set; }
        [JsonProperty("$path")]
        public string path { get; set; }
        public PropertyValueWithPath transaction { get; set; }
        public PropertyValueWithPath transaction_type { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public List<Link> links { get; set; }
        public string contact_name { get; set; }
        public string contact_reference { get; set; }
        public Contact contact { get; set; }
        public string date { get; set; }
        public string reference { get; set; }
        public string notes { get; set; }
        public string total_quantity { get; set; }
        public string net_amount { get; set; }
        public string tax_amount { get; set; }
        public string total_amount { get; set; }
        public string payments_allocations_total_amount { get; set; }
        public string payments_allocations_total_discount { get; set; }
        public string total_paid { get; set; }
        public string outstanding_amount { get; set; }
        public PropertyValueWithPath currency { get; set; }
        public string exchange_rate { get; set; }
        public string inverse_exchange_rate { get; set; }
        public string base_currency_net_amount { get; set; }
        public string base_currency_tax_amount { get; set; }
        public string base_currency_total_amount { get; set; }
        public string base_currency_outstanding_amount { get; set; }
        public PropertyValueWithPath status { get; set; }
        public object void_reason { get; set; }
        public List<TaxAnalysis> tax_analysis { get; set; }
        public string last_paid { get; set; }
        public object tax_address_region { get; set; }
        public bool tax_reconciled { get; set; }
        public bool migrated { get; set; }
        public object tax_calculation_method { get; set; }
    }
}