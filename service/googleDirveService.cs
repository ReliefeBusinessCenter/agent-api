// using Google.Apis.Auth.OAuth2;
// using Google.Apis.Download;
// using Google.Apis.Drive.v2;
// using Google.Apis.Drive.v3;
// using Google.Apis.Services;
// using Google.Apis.Util.Store;
// using GoogleDriveRestAPI_v3.Models;
// using System;
// using System.Collections.Generic;
// using System.IO;
// using System.Linq;
// using System.Threading;
// using System.Web;

// namespace DriveApi.Models
// {
//     public class GoogleDriveFilesRepository
//     {
//         public static string[] Scopes = { Google.Apis.Drive.v3.DriveService.Scope.Drive};

//         //create Drive API service.
//         private Google.Apis.Drive.v2.DriveService GetDriveServiceInstance()
// {
//     UserCredential credential;
 
//     using (var stream =
//         new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
//     {
//         string credPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
 
//         credPath = Path.Combine(credPath, "./credentials/credentials.json");
 
//         credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
//             GoogleClientSecrets.Load(stream).Secrets,
//             Scopes,
//             "user",
//             CancellationToken.None,
//             new FileDataStore(credPath, true)).Result;
//     }
 
//     var service = new Google.Apis.Drive.v2.DriveService(new BaseClientService.Initializer()
//     {
//         HttpClientInitializer = credential,
//         ApplicationName = ApplicationName,
//     });
 
//     return service;
// }
// public string UploadFIle(string path)
// {
//     var service = GetDriveServiceInstance();
//     var fileMetadata = new Google.Apis.Drive.v3.Data.File();
//     fileMetadata.Name = Path.GetFileName(path);
//     fileMetadata.MimeType = "image/jpeg";
//     FilesResource.CreateMediaUpload request;
//     using (var stream = new FileStream(path, FileMode.Open))
//     {
//         request = service.Files.Create(fileMetadata, stream, "image/jpeg");
//         request.Fields = "id";
//         request.Upload();
//     }
 
//     var file = request.ResponseBody;
 
//     return file.Id;
// }
//     }
// }