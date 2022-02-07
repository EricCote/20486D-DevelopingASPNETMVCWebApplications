using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using AzureStorageDemo.Models;
using AzureStorageDemo.Data;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace AzureStorageDemo.Controllers;

public class BlobController : Controller
{
    private IConfiguration _configuration;
    private string _connectionString;
    private PhotoContext _dbContext;

    public BlobController(IConfiguration configuration, PhotoContext dbContext)
    {
        _dbContext = dbContext;
        _configuration = configuration;
        _connectionString = _configuration.GetConnectionString("AzureStorageConnectionString-1");
    }

    [HttpGet]
    public IActionResult CreateImage()
    {
        return View();
    }


    [HttpPost, ActionName("CreateImage")]
    public async Task<IActionResult> CreateImageAsync(Photo photo)
    {
        if (ModelState.IsValid)
        {
            photo.CreatedDate = DateTime.Today;
            if (photo.PhotoAvatar != null && photo.PhotoAvatar.Length > 0)
            {
                photo.ImageMimeType = photo.PhotoAvatar.ContentType;
                photo.ImageName = Path.GetFileName(photo.PhotoAvatar.FileName);
                using (var memoryStream = new MemoryStream())
                {
                    photo.PhotoAvatar.CopyTo(memoryStream);
                    photo.PhotoFile = memoryStream.ToArray();
                }
                await UploadAsync(photo.PhotoAvatar);
                _dbContext.Add(photo);
                _dbContext.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(photo);
        }
        return View(photo);
    }

    public async Task UploadAsync(IFormFile photo)
    {
        BlobServiceClient blobServiceClient = new BlobServiceClient(_connectionString);
//        CloudStorageAccount storageAccount = CloudStorageAccount.Parse(_connectionString);
      //  CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
        BlobContainerClient container = blobServiceClient.GetBlobContainerClient("myimagecontainer");

        await container.CreateIfNotExistsAsync(PublicAccessType.Blob);

        BlobClient blob = container.GetBlobClient(Path.GetFileName(photo.FileName));
        await blob.UploadAsync(photo.OpenReadStream());
    }
}
