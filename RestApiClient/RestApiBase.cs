using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace RestApiClient
{
    public class RestApiBase
    {
	    public static HttpClient ApiClient { get; set; } // static => ouvre 1x pour toute l'application (optimisation tcp)

	    public static void InitializeClient(string uri)
	    {
		    // trust any certificate
		    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
		    ServicePointManager.ServerCertificateValidationCallback +=
			    (sender, cert, chain, sslPolicyErrors) => { return true; };

		    ApiClient = new HttpClient();

		    ApiClient.BaseAddress = new Uri(uri);

		    ApiClient.DefaultRequestHeaders.Accept.Clear(); // nettoie les headers

		    // crée un header qui demande du json
		    ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
	    }
	}
}
