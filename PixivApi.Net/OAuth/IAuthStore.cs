using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace PixivApi.Net.OAuth
{
    public interface IAuthStore
    {
        Task AddAuthResponseAsync(PixivOAuthResponse pixivOAuth);
        Task<PixivOAuthResponse> GetAuthResponseAsync();
    }

    public class JsonFileAuthStore : IAuthStore
    {
        private readonly string _storageFileName = "oauth.json";

        public async Task AddAuthResponseAsync(PixivOAuthResponse pixivOAuth)
        {
            var json = JsonConvert.SerializeObject(pixivOAuth);
            var buffer = Encoding.UTF8.GetBytes(json);
            var path = GetPathWithBaseDirectory();
            var fileMode = File.Exists(path) ? FileMode.Truncate : FileMode.Create;
            using (var fileStream = new FileStream(path, fileMode))
            {
                await fileStream.WriteAsync(buffer);
            }
        }

        public async Task<PixivOAuthResponse> GetAuthResponseAsync()
        {
            var path = GetPathWithBaseDirectory();
            if (!File.Exists(path))
            {
                return null;
            }
            using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                var buffer = new byte[fileStream.Length];
                await fileStream.ReadAsync(buffer, 0, buffer.Length);
                var result = JsonConvert.DeserializeObject<PixivOAuthResponse>(Encoding.UTF8.GetString(buffer));
                return result;
            }
        }

        private string GetPathWithBaseDirectory() => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _storageFileName);

    }
}
