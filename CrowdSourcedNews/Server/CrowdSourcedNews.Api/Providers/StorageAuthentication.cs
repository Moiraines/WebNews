using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v2;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace CrowdSourcedNews.Api.Providers
{

    public class StorageAuthentication
    {

        public static DriveService AuthenticateOauth(string clientId, string clientSecret, string userName) // removed the windows username of the currently logged user
        {
            string[] scopes = new string[] { DriveService.Scope.Drive,  // view and manage your files and documents
                                             DriveService.Scope.DriveAppdata,  // view and manage its own configuration data
                                             DriveService.Scope.DriveAppsReadonly,   // view your drive apps
                                             DriveService.Scope.DriveFile,   // view and manage files created by this app
                                             DriveService.Scope.DriveMetadataReadonly,   // view metadata for files
                                             DriveService.Scope.DriveReadonly,   // view files and documents on your drive
                                             DriveService.Scope.DriveScripts };  // modify your app scripts


            try
            {
                // here is where we Request the user to give us access, or use the Refresh Token that was previously stored in %AppData%
                UserCredential credential = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets { ClientId = clientId, ClientSecret = clientSecret }
                                                                                             , scopes
                                                                                             , userName
                                                                                             , CancellationToken.None
                                                                                             , new FileDataStore("Daimto.Drive.Auth.Store")).Result;

                DriveService service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Daimto Drive API Sample",
                });
                return service;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.InnerException);
                return null;

            }

        }

        public static DriveService AuthenticateServiceAccount(string serviceAccountEmail, string keyFilePath)
        {

            // check the file exists
            if (!File.Exists(keyFilePath))
            {
                Console.WriteLine("An Error occurred - Key file does not exist");
                return null;
            }

            string[] scopes = new string[] { DriveService.Scope.Drive,  // view and manage your files and documents
                                             DriveService.Scope.DriveAppdata,  // view and manage its own configuration data
                                             DriveService.Scope.DriveAppsReadonly,   // view your drive apps
                                             DriveService.Scope.DriveFile,   // view and manage files created by this app
                                             DriveService.Scope.DriveMetadataReadonly,   // view metadata for files
                                             DriveService.Scope.DriveReadonly,   // view files and documents on your drive
                                             DriveService.Scope.DriveScripts };  // modify your app scripts     

            var certificate = new X509Certificate2(keyFilePath, "notasecret", X509KeyStorageFlags.Exportable);
            try
            {
                ServiceAccountCredential credential = new ServiceAccountCredential(
                    new ServiceAccountCredential.Initializer(serviceAccountEmail)
                    {
                        Scopes = scopes
                    }.FromCertificate(certificate));

                // Create the service.
                DriveService service = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Daimto Drive API Sample",
                });
                return service;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                return null;

            }
        }
    }
}
