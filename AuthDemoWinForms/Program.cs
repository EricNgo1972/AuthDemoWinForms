using Microsoft.Identity.Client;
using System;
using System.Windows.Forms;

namespace AuthDemoWinForms
{
    static class Program
    {

        public static string ClientId = "8be9c6e5-2860-41b8-bf09-f81bce6b6faa";
        public static string Tenant = "9e11a329-847d-43f2-b751-104a09caddd1";//Environment.GetEnvironmentVariable("Tenant", EnvironmentVariableTarget.User);
        private static IPublicClientApplication clientApp;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            InitializeAuth();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static IPublicClientApplication PublicClientApp { get { return clientApp; } }

        private static void InitializeAuth()
        {

            clientApp = PublicClientApplicationBuilder.Create(ClientId)
                    .WithRedirectUri("https://login.microsoftonline.com/common/oauth2/nativeclient")
                    .WithAuthority(AzureCloudInstance.AzurePublic, Tenant)
                    .Build();
            TokenCacheHelper.EnableSerialization(clientApp.UserTokenCache);
        }
    }
}