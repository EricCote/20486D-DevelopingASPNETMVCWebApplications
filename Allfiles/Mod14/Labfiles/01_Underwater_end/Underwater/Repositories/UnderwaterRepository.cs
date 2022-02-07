using Microsoft.EntityFrameworkCore;
using Underwater.Data;
using Underwater.Models;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;

namespace Underwater.Repositories;

public class UnderwaterRepository : IUnderwaterRepository
{
    private UnderwaterContext _context;
    private IConfiguration _configuration;
    private BlobContainerClient _container;

    public UnderwaterRepository(UnderwaterContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
        string connectionString = _configuration.GetConnectionString("AzureStorageConnectionString-1");
        string containerName = _configuration.GetValue<string>("ContainerSettings:ContainerName");
        BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString); 
        _container = blobServiceClient.GetBlobContainerClient(containerName);
    }

    public IEnumerable<Fish> Getfishes()
    {
        return _context.fishes.ToList();
    }

    public Fish GetFishById(int id)
    {
        return _context.fishes.Include(a => a.Aquarium)
             .SingleOrDefault(f => f.FishId == id);
    }

    public void AddFish(Fish fish)
    {
        if (fish.PhotoAvatar != null && fish.PhotoAvatar.Length > 0)
        {
            string imageURL = UploadImageAsync(fish.PhotoAvatar).GetAwaiter().GetResult();
            fish.ImageURL = imageURL;
            fish.ImageMimeType = fish.PhotoAvatar.ContentType;
            fish.ImageName = Path.GetFileName(fish.PhotoAvatar.FileName);
            _context.Add(fish);
            _context.SaveChanges();
        }
    }

    public void RemoveFish(int id)
    {
        var fish = _context.fishes.SingleOrDefault(f => f.FishId == id);
        if (fish.ImageURL != null)
        {
            DeleteImageAsync(fish.ImageName).GetAwaiter().GetResult();
        }
        _context.fishes.Remove(fish);
        _context.SaveChanges();
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public IQueryable<Aquarium> PopulateAquariumsDropDownList()
    {
        var aquariumsQuery = from a in _context.Aquariums
                             orderby a.Name
                             select a;
        return aquariumsQuery;
    }

    private async Task<string> UploadImageAsync(IFormFile photo)
    {
        await _container.CreateIfNotExistsAsync(PublicAccessType.Blob);

        BlobClient blob = _container.GetBlobClient(Path.GetFileName(photo.FileName));
        await blob.UploadAsync(photo.OpenReadStream());
 
        return blob.Uri.ToString();
    }

    private async Task<bool> DeleteImageAsync(string PhotoFileName)
    {
        BlobClient blob = _container.GetBlobClient(PhotoFileName);
        await blob.DeleteAsync();
        return true;
    }
}
