﻿using System;
using System.Threading.Tasks;
using TmdbEasy.Configurations;
using TmdbEasy.Interfaces;

namespace TmdbEasy
{
    public class RequestHandler : IRequestHandler
    {
        private readonly ITmdbEasyClient _client;
        private readonly TmdbEasyOptions _options;

        public RequestHandler(ITmdbEasyClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _options = _client.Options;
        }

        public Request CreateRequest()
        {
            return new Request(_options);
        }

        public async Task<TmdbEasyModel> ExecuteAsync<TmdbEasyModel>(Request request)
        {
            return await _client.GetResponseAsync<TmdbEasyModel>(request.GetUri()).ConfigureAwait(false);
        }
    }
}