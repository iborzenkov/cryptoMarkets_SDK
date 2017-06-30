using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Model
{
    public abstract class Connection
    {
        protected abstract string MainUri { get; }

        public T PublicGetQuery<T>(string endPoint, params Tuple<string, string>[] parameters)
        {
            var uri = $"{MainUri}{endPoint}";

            return CallGetRequestWithJsonResponse<T>(uri, parameters);
        }

        private string CodeGetParams(IReadOnlyCollection<Tuple<string, string>> parameters)
        {
            if (parameters == null || parameters.Count <= 0)
                return null;

            var extraParameters = new StringBuilder();
            foreach (var item in parameters)
                extraParameters.Append((extraParameters.Length == 0 ? "?" : "&") + item.Item1 + "=" + item.Item2);

            return extraParameters.Length > 0 ? extraParameters.ToString() : null;
        }

        private readonly TimeSpan _mDefaultTimeOut = new TimeSpan(TimeSpan.TicksPerMinute * 30); // Default timeout - 30 minutes

        private HttpClient CreateHttpClient(string url)
        {
            HttpClient result = new HttpClient
            {
                BaseAddress = new Uri(url),
                Timeout = _mDefaultTimeOut
            };

            result.DefaultRequestHeaders.Accept.Clear();
            result.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return result;
        }

        private T CallGetRequestWithJsonResponse<T>(string uri, Tuple<string, string>[] parameters,
            params Tuple<string, string>[] headers)
        {
            var result = default(T);

            using (var httpClient = CreateHttpClient(uri))
            {
                var response = httpClient.GetStreamAsync(CodeGetParams(parameters));
                response.Wait();

                if (response.IsCompleted)
                {
                    result = response.Result.ReadObject<T>();
                }
                return result;
            }
            /*var request = WebRequest.CreateHttp(uri);
            foreach (var header in headers)
            {
                request.Headers.Add(header.Item1, header.Item2);
            }

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    using (var sr = new StreamReader(response.GetResponseStream()))
                    {
                        var content = sr.ReadToEnd();
                        var jsonResponse = JsonConvert.DeserializeObject<ApiCallResponse<T>>(content);

                        if (jsonResponse.success)
                        {
                            return jsonResponse.result;
                        }
                        else
                        {
                            throw new Exception(jsonResponse.message.ToString() + "Call Details=" + GetCallDetails(uri));
                        }
                    }
                }
                else
                {
                    throw new Exception("Error - StatusCode=" + response.StatusCode + " Call Details=" + GetCallDetails(uri));
                }
            }*/
        }
    }
}