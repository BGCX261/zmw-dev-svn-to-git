using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;

namespace StorageUploadFiles
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                // Variables for the cloud storage objects.
                var storageAccount = new StorageAccount();
                
               // Use the emulatedstorage account.
                var cloudStorageAccount = new CloudStorageAccount(new StorageCredentialsAccountAndKey(storageAccount.Account, storageAccount.Key), storageAccount.Https);
               
                // If you want to use Windows Azure cloud storage account, use the following
                // code (after uncommenting) instead of the code above.
                // cloudStorageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=http;AccountName=your_storage_account_name;AccountKey=your_storage_account_key");

                // Create the blob client, which provides
                // authenticated access to the Blob service.
                CloudBlobClient blobClient = cloudStorageAccount.CreateCloudBlobClient();

                // Get the container reference.
                Console.Write("input your container:");
                storageAccount.Container = Console.ReadLine();
                CloudBlobContainer blobContainer = blobClient.GetContainerReference(storageAccount.Container);
                // Create the container if it does not exist.
                blobContainer.CreateIfNotExist();

                // Set permissions on the container.
                var containerPermissions = new BlobContainerPermissions
                    {
                        PublicAccess = BlobContainerPublicAccessType.Blob
                    };
                // This sample sets the container to have public blobs. Your application
                // needs may be different. See the documentation for BlobContainerPermissions
                // for more information about blob container permissions.
                blobContainer.SetPermissions(containerPermissions);

                var directory = GetDirectory();
                var fileInfos = GetAllFiles(directory);
                foreach (var @fileInfo in fileInfos)
                {
                    CloudBlob blob = blobContainer.GetBlobReference(@fileInfo.FullName.Replace(directory,""));

                // Upload a file from the local system to the blob.

                    Console.WriteLine("Starting file upload");
                    blob.UploadFile(@fileInfo.FullName);  // File from emulated storage.
                    Console.WriteLine("File upload complete to blob: " + blob.Uri);
                }
            }
            catch (StorageClientException e)
            {
                Console.WriteLine("Storage client error encountered: " + e.Message);

                // Exit the application with exit code 1.
                System.Environment.Exit(1);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error encountered: " + e.Message);

                // Exit the application with exit code 1.
                System.Environment.Exit(1);
            }
            finally
            {
                // Exit the application.
                System.Environment.Exit(0);
            }

            
        }

        private static string GetDirectory()
        {
// Get a reference to the blob.
            Console.Write("input your directory:");
            var directory = Console.ReadLine();
            if (string.IsNullOrEmpty(directory))
            {
                GetDirectory();
            }
            return directory;
        }

        private static IEnumerable<FileInfo> GetAllFiles(string directory)
        {
            string[] filePaths = Directory.GetFiles(@directory, "*.*", SearchOption.AllDirectories);
            return filePaths.Select(filePath => new FileInfo(filePath)).ToList();
        }
    }
}
