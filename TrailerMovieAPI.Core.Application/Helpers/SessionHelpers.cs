﻿using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailerMovieAPI.Core.Application.Helpers
{
    public static class SessionHelpers
    {

        public static void Set<T>(this ISession session, string key, T Value) {
            session.SetString(key, JsonConvert.SerializeObject(Value));
        }
        public static T Get<T>(this ISession session, string key) {
            var value = session.GetString(key);

            return value == null ? default : JsonConvert.DeserializeObject<T>(value);
        }

    }
}