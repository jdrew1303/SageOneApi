﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace SageOneApi.Client
{
    internal class SageOneApiClientPagingHandler : SageOneApiClientBaseHandler
    {
        private readonly Action<string> _logMessage;

        public SageOneApiClientPagingHandler(Action<string> logMessage, SageOneApiClientConfig config, ISageOneApiClientHandler apiClient) : base(apiClient, config)
        {
            _logMessage = logMessage;
        }

        public override IEnumerable<T> GetAll<T>(Dictionary<string, string> queryParameters) 
        {
            var pageNumber = 1;
            var itemsDownloaded = 0;
            var isDownloadRequired = true;
            var entities = new List<T>(); 

            while (isDownloadRequired)
            {
                var summaryResponse = base.GetAllFromPage<T>(pageNumber++, queryParameters);

                entities.AddRange(summaryResponse.items);

                itemsDownloaded += summaryResponse.items.Length;

                _logMessage($"Downloaded {itemsDownloaded}/{summaryResponse.total} {typeof(T).Name} records");

                isDownloadRequired = summaryResponse.next != null;
            }

            return entities;
        }
    }
}
