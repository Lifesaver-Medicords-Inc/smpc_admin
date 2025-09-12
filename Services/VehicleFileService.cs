using smpc_admin.Models;
using smpc_admin.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace smpc_admin.Services
{
    class VehicleFileService
    {

        public async static Task<HttpResponse<VehicleFileModel>> UploadVehicleFileAsync(string filePath, int vehicleId)
        {

            using (var form = new MultipartFormDataContent())
            using (var fileStream = File.OpenRead(filePath))
            using (var client = new HttpClient())
            {
                var fileName = Path.GetFileName(filePath);
                var streamContent = new StreamContent(fileStream);
                streamContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

                form.Add(streamContent, "file", fileName);
                form.Add(new StringContent(vehicleId.ToString()), "vehicle-id"); 

                var res = await HttpClientHelper.PostMultipartAsync<HttpResponse<VehicleFileModel>>("vehicle-files", form);

                return res;


            }

        }


        public async static Task<HttpResponse<VehicleFileModel>> DownloadVehicleFileAsync(string path)
        {
            var fileBytes = await DownloadFileBytesAsync(path);

            var res = new HttpResponse<VehicleFileModel>();

            if (fileBytes != null)
            {
                string filename = Path.GetFileName(path);

                // Save the file locally, e.g., Desktop folder
                string savePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), filename);

                // For .NET Framework 4.x (synchronous write)
                File.WriteAllBytes(savePath, fileBytes);

                res.Success = true;
                res.Data = new VehicleFileModel
                {
                    FileName = filename,
                    FilePath = savePath
                };
            }
            else
            {
                res.Success = false;
                res.Message = "Failed to download file bytes.";
            }

            return res;
        }

        private async static Task<byte[]> DownloadFileBytesAsync(string path)
        {
            string normalizedPath = path.Replace("\\", "/");
            var encodedPath = Uri.EscapeDataString(normalizedPath);

            var queryParams = new List<string>();
            if (!string.IsNullOrEmpty(encodedPath))
                queryParams.Add($"path={encodedPath}");

          
            string queryString = string.Join("&", queryParams);

            string baseUrl = Program.Configuration["AppSettings:ApiBaseUrl"].TrimEnd('/') + "/";

     
            string fullUrl = $"{baseUrl}vehicle-files/download";
            if (!string.IsNullOrEmpty(queryString))
                fullUrl += "?" + queryString;

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(fullUrl);

                if (!response.IsSuccessStatusCode)
                    return null;

                return await response.Content.ReadAsByteArrayAsync();
            }
        }

        public async static Task<HttpResponse<VehicleFileModel>> GetVehicleFileAsync(int id)
        {
            var res = await HttpClientHelper.Get<HttpResponse<VehicleFileModel>>($"vehicle-files/{id}");
            return res;
        }


        public async static Task<HttpResponse<VehicleFileModel>> RemoveVehicleFileAsync(int id)
        {
            var res = await HttpClientHelper.Delete<HttpResponse<VehicleFileModel>>($"vehicle-files/{id}");
            return res;
        }

        public async static Task<HttpResponse<IEnumerable<VehicleFileModel>>> GetVehicleFilesAsync(int? id, int? vehicleId, string fileName = null)
        {
            var queryParams = new List<string>();
            if (id.HasValue) queryParams.Add($"id={id.Value}");
            if (vehicleId.HasValue) queryParams.Add($"vehicle-id={vehicleId.Value}");
            if (!string.IsNullOrWhiteSpace(fileName)) queryParams.Add($"file-name={Uri.EscapeDataString(fileName)}");
  

            string queryString = queryParams.Count > 0 ? "?" + string.Join("&", queryParams) : "";

            var res = await HttpClientHelper.Get<HttpResponse<IEnumerable<VehicleFileModel>>>($"vehicle-files{queryString}");

            return res;
        }


    }
}
