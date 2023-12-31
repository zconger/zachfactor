using Microsoft.Identity.Client;
using Microsoft.Identity.Web;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace daemon_console
{
    // For more information see https://aka.ms/msal-net-client-credentials
    class Program
    {
        static void Main(string[] args)
        {
            try
            {   RunAsync().GetAwaiter().GetResult();   }
            catch (Exception ex)
            {   Console.WriteLine(ex.Message);  }
        }

        private static string certificateFullPath = "/Users/zconger/git/github/zconger/zachfactor/keyster-zachlock-20231021.pfx"; // Replace with your certificate path
        private static string applicationID="d4b58aba-58c7-4e58-a604-b4d7c0b8f7f5"; // replace with your application ID
        private static string authority="https://login.microsoftonline.com/ca346305-52ed-45ea-8064-3c4e8196ea12/"; // replace with your AAD authority

        private static async Task RunAsync()
        {
            ICertificateLoader certificateLoader = new DefaultCertificateLoader();

            // full path Certificate File
            var myCertificate = X509Certificate2.CreateFromCertFile(certificateFullPath);
            X509Certificate2 myCertificate2 = new X509Certificate2(myCertificate);

            var app = ConfidentialClientApplicationBuilder.Create(applicationID) 
                .WithCertificate(myCertificate2)
                .WithAuthority(new Uri(authority)) // Tenant ID
                .Build();

            app.AddInMemoryTokenCache();

            // With client credentials flows the scopes is ALWAYS of the shape "resource/.default", as the 
            // application permissions need to be set statically (in the portal or by PowerShell), and then granted by
            // a tenant administrator. 
            string[] scopes = new string[] { "https://graph.microsoft.com/.default" }; // Generates a scope -> "https://graph.microsoft.com/.default"
            //string[] scopes = new string[] { "api://ace7a10d-aaaa-4a01-8663-1440b6b78cb9/.default" }; // custom API on same tenant

            AuthenticationResult result = null;
            try
            {
                result = await app.AcquireTokenForClient(scopes).ExecuteAsync();
                Console.WriteLine("Token acquired");
                Console.WriteLine("Token: " + result.AccessToken);
            }
            catch (MsalServiceException ex) when (ex.Message.Contains("AADSTS70011"))
            {
                // Invalid scope. The scope has to be of the form "https://resourceurl/.default"
                // Mitigation: change the scope to be as expected
                Console.WriteLine("Scope provided is not supported");
            }
        }
    }
}