using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;

namespace ProjectTLCNShopCore.Infrastructure
{
    public static class SessionExtensions
    {
		public static void SetJson(this ISession session, string key, object value)
		{
			session.SetString(key, JsonConvert.SerializeObject(value));
		}
		public static T GetJson<T>(this ISession session, string key)
		{
			var sessionData = session.GetString(key);
			return sessionData == null ? default(T) : JsonConvert.DeserializeObject<T>(sessionData);
		}

		public static void Set(this ISession session, string key, object value)
		{
			string json = JsonConvert.SerializeObject(value);
			byte[] serializedResult = System.Text.Encoding.UTF8.GetBytes(json);

			session.Set(key, serializedResult);
		}

		public static T Get<T>(this ISession session, string key)
		{
			var value = session.Get(key);
			string json = System.Text.Encoding.UTF8.GetString(value);

			return value == null ? default(T) : JsonConvert.DeserializeObject<T>(json);
		}

		public static bool IsExists(this ISession session, string key)
		{
			return session.Get(key) != null;
		}
	}
}

