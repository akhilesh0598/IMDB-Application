using Firebase.Auth;
using Firebase.Storage;
using IMDB_API_Project.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IMDB_API_Project.ImageUploaderFile
{
    public class ClientImageUploader
    {
        private static string ApiKey = "your api key";
        private static string Bucket = "your bucket key";
        private static string AuthEmail = "email@gmail.com";
        private static string AuthPassword = "password";

        public string FileUpload(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new InvalidRequestDataException("you have not selected image");
            }
            return Upload(file);
        }

        private string Upload(IFormFile file)
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
            var firebaseAuthLink = authProvider.SignInWithEmailAndPasswordAsync(AuthEmail, AuthPassword).Result;
            var storage = new FirebaseStorage(
                Bucket,
                new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(firebaseAuthLink.FirebaseToken)
                });
            var taskchild = storage.Child(file.FileName);
            var task = taskchild.PutAsync(file.OpenReadStream()).GetAwaiter().GetResult();
            return task;

        }
    }
}