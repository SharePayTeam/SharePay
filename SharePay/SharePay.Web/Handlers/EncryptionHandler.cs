using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SharePay.Common.Interfaces.Managers;
using SharePay.Common.Interfaces.Services;
using SharePay.DependencyResolution;
using SharePay.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace SharePay.Web.Handlers
{
    public class EncryptionHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var isEncryptionEnabled = DependencyRegistar.Resolve<IConfigurationManager>().GetAppSetting<bool>("IsEncryptionEnabled");

            if (isEncryptionEnabled)
            {
                request.RequestUri = UriEncryption(request.RequestUri.AbsoluteUri);

                if (request.Content != null)
                {
                    request.Content = ContentEncryption(await request.Content.ReadAsStringAsync(), EncryptionEnum.Decrypt);
                }
            }

            var response = await base.SendAsync(request, cancellationToken);

            if (isEncryptionEnabled && response.Content != null)
            {
                response.Content = ContentEncryption(await response.Content.ReadAsStringAsync(), EncryptionEnum.Encrypt);
            }

            return response;
        }

        private static void FindTokens(JToken token, string name, List<JToken> tokens)
        {
            if (token.Type == JTokenType.Object)
            {
                foreach (var child in token.Children<JProperty>())
                {
                    if (child.Name.EndsWith(name, StringComparison.InvariantCultureIgnoreCase))
                    {
                        tokens.Add(child.Value);
                    }

                    FindTokens(child.Value, name, tokens);
                }
            }
            else if (token.Type == JTokenType.Array)
            {
                foreach (var child in token.Children())
                {
                    FindTokens(child, name, tokens);
                }
            }
        }

        private Uri UriEncryption(string url)
        {
            var uri = new Uri(url);
            var uriBuilder = new UriBuilder(uri);

            var queryStringParams = uri.ParseQueryString();

            if (queryStringParams.Keys.Count > 0)
            {
                for (int i = 0; i < queryStringParams.Count; i++)
                {
                    if (queryStringParams.Keys[i].ToString().EndsWith("id", StringComparison.InvariantCultureIgnoreCase)
                        || queryStringParams.Keys[i].ToString().EndsWith("ids", StringComparison.InvariantCultureIgnoreCase))
                    {
                        queryStringParams.Set(queryStringParams.Keys[i], DependencyRegistar.Resolve<ICryptographicService>().GetDecryptedValue(queryStringParams[i]));
                    }
                }

                uriBuilder.Query = queryStringParams.ToString();
            }

            return uriBuilder.Uri;
        }

        private StringContent ContentEncryption(string content, EncryptionEnum encryption)
        {
            if (!string.IsNullOrEmpty(content))
            {
                var tokens = new List<JToken>();

                var token = JToken.Parse(content);

                FindTokens(token, "id", tokens);
                FindTokens(token, "ids", tokens);

                foreach (var value in tokens)
                {
                    if (value.Type == JTokenType.Array)
                    {
                        foreach (JValue value2 in value)
                        {
                            ValueEncryption(value2, encryption);
                        }
                    }
                    else if (value.Type == JTokenType.Integer
                        || value.Type == JTokenType.String
                        || value.Type == JTokenType.Guid)
                    {
                        ValueEncryption((JValue)value, encryption);
                    }
                }

                return new StringContent(JsonConvert.SerializeObject(token), Encoding.UTF8, "application/json");
            }
            else
            {
                return new StringContent(string.Empty, Encoding.UTF8, "application/json");
            }
        }

        private void ValueEncryption(JValue value, EncryptionEnum encryption)
        {
            if (value.Value != null)
            {
                if (encryption == EncryptionEnum.Encrypt)
                {
                    value.Value = DependencyRegistar.Resolve<ICryptographicService>().GetEncryptedValue(value.Value.ToString());
                }
                else
                {
                    value.Value = DependencyRegistar.Resolve<ICryptographicService>().GetDecryptedValue(value.Value.ToString());
                }
            }
        }
    }
}