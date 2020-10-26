using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BoostCommunicatorService
{
    public static class TruTopsApiHelper
    {
        public static HttpClient TruTopsApiClient { get; set; }

        /// <summary>
        /// Führt einen Post auf ein EndPunkt aus und liefert das Antwort Objekt zurück
        /// </summary>
        /// <param name="urlParameter"></param>
        /// <param name="bodyContent"></param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException">Wirft einen Fehler zurück in Abhängigkeit des StatusCodes</exception>
        public static async Task<string> InitializeClient_PostAsync(string urlParameter, object bodyContent)
        {
            CreateHttpClient();

            HttpResponseMessage result = await TruTopsApiClient.PostAsync(urlParameter, SetUrlAndBody(urlParameter, bodyContent)).ConfigureAwait(continueOnCapturedContext: false);

            CheckResponse(urlParameter, result);

            return await result.Content.ReadAsStringAsync();
        }

        public static async Task<string> InitializeClient_GetAsync(string urlParameter)
        {
            CreateHttpClient();
            HttpResponseMessage result = await TruTopsApiClient.GetAsync(urlParameter).ConfigureAwait(continueOnCapturedContext: false);
            CheckResponse(urlParameter, result);

            return await result.Content.ReadAsStringAsync();
        }

        public static async Task<string> InitializeClient_DeleteAsync(string urlParameter)
        {
            CreateHttpClient();
            HttpResponseMessage result = await TruTopsApiClient.DeleteAsync(urlParameter).ConfigureAwait(continueOnCapturedContext: false);
            CheckResponse(urlParameter, result);

            return await result.Content.ReadAsStringAsync();
        }

        private static StringContent SetUrlAndBody(string urlParameter, object bodyContent)
        {
            string body = JsonConvert.SerializeObject(bodyContent);
            StringContent stringContent = new StringContent(body, Encoding.UTF8, "application/json");

            return stringContent;
        }

        public static async Task<string> InitializeClient_PutAsync(string urlParameter, object bodyContent)
        {
            CreateHttpClient();

            HttpResponseMessage result = await TruTopsApiClient.PutAsync(urlParameter, SetUrlAndBody(urlParameter, bodyContent)).ConfigureAwait(continueOnCapturedContext: false);
            CheckResponse(urlParameter, result);

            return await result.Content.ReadAsStringAsync();
        }

        private static void CheckResponse(string urlParameter, HttpResponseMessage result)
        {
            if (result.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new ApplicationException($"Der Endpunkt {TruTopsApiClient.BaseAddress}{urlParameter} konnte nicht gefunden werden. StatusCode war {result.StatusCode}");
            }

            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                throw new ApplicationException($"Ein Fehler ist aufgetreten. {result.StatusCode}: {result.ReasonPhrase}");
            }

            if (result.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                Debug.WriteLine($"Fehler bei Request: {result.ReasonPhrase}");
            }
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Debug.WriteLine($"Erfolg");
            }

            if (result.StatusCode == System.Net.HttpStatusCode.UnsupportedMediaType)
            {
                throw new System.InvalidOperationException(result.ReasonPhrase);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private static void CreateHttpClient()
        {
            TruTopsApiClient = new HttpClient();
            TruTopsApiClient.BaseAddress = new Uri(Properties.Settings.Default.TruTopsApi);

            TruTopsApiClient.DefaultRequestHeaders.Accept.Clear();
            TruTopsApiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            TruTopsApiClient.DefaultRequestHeaders.Add("Trumpf-Version", "1.0");
            TruTopsApiClient.DefaultRequestHeaders.Add("Trumpf-User", "Lamberth, A.");
            TruTopsApiClient.DefaultRequestHeaders.Add("Trumpf-Terminal", "BUS7-1");
            TruTopsApiClient.DefaultRequestHeaders.Add("Authorization", "Basic TGFtYmVydGgsIEEuOjExMDk5Mw==");
        }
    }
}
