namespace MoviesAdmin.Service
{
    public interface IAzureStrorageService
    {
        Task<string> UploadFileAsync(IFormFile file, string filename);
    }
}
