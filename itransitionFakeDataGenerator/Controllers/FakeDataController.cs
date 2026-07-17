using Bogus;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Services.GenerateFakeData;
using Services.ExportFile;

public enum Gender {
    Male,
    Female
}

public class FakeDataController : Controller {
    private readonly IWebHostEnvironment _env;

    public FakeDataController(IWebHostEnvironment env)
    {
        _env = env;
    }

    [HttpGet("/FakeData/GenerateData")]
    public string GenerateData([FromQuery] string region, [FromQuery] int seed, [FromQuery] int page, [FromQuery] int limit = 10, [FromQuery] int errors = 0) {
        var users = new FakeData().Generate(seed, region, limit, errors, page);
        string usersJSON = JsonSerializer.Serialize(users);
        return usersJSON;
    }

    [HttpGet("/FakeData/GenerateFile")]
    public FileResult GenerateFile([FromQuery] string region, [FromQuery] int seed, [FromQuery] int page, [FromQuery] int limit = 10, [FromQuery] int errors = 0) {
        var users = new FakeData().Generate(seed, region, limit, errors, page);
        string fileName = $"users_{seed}_{region}";

        string filesDir = Path.Combine(_env.ContentRootPath, "files");
        if (!Directory.Exists(filesDir))
        {
            Directory.CreateDirectory(filesDir);
        }

        CSV.Export(fileName, users, filesDir);

        string filePath = Path.Combine(filesDir, $"{fileName}.csv");
        byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
        return File(fileBytes, "application/csv", $"{fileName}.csv");
    }
}