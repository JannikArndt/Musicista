using MuseScoreAPI.RESTObjects;
using RestSharp;
using System;
using System.Collections.Generic;

namespace Musicista
{
    public static class MuseScoreAPI
    {
        public static RestClient Client;

        static MuseScoreAPI()
        {
            Client = new RestClient("http://api.musescore.com/services/rest");
        }

        public static List<Score> Search(String query)
        {
            var request = new RestRequest("score.xml", Method.GET);
            request.AddParameter("oauth_consumer_key", "B9nVidVP2ZQBm6mXTuzhwS2tgR4KZZxJ");
            request.AddParameter("text", query);

            // execute the request
            var response = Client.Execute<ScoreInfo>(request);

            if (response.Data == null)
                return null;
            return response.Data.Scores;
        }
    }
}
