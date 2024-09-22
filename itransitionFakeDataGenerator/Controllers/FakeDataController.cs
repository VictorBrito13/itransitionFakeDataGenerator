using System.Runtime.Intrinsics.X86;
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

    [HttpGet("/FakeData/GenerateData")]
    public string GenerateData([FromQuery] string region, [FromQuery] int seed, [FromQuery] int page, [FromQuery] int limit = 10, [FromQuery] int errors = 0) {

        var users = new FakeData().Generate(seed, region, limit, errors, page);
        string usersJSON = JsonSerializer.Serialize(users);
        return usersJSON;
    }

    [HttpGet("/FakeData/GenerateFile")]
    public FileResult GenerateFile([FromQuery] string region, [FromQuery] int seed, [FromQuery] int page, [FromQuery] int limit = 10, [FromQuery] int errors = 0) {
        var users = new FakeData().Generate(seed, region, limit, errors, page);
        string fileName = $"users{new Random().NextInt64()}";
        CSV.Export(fileName, users);

        byte[] archivo = System.IO.File.ReadAllBytes($"{Directory.GetCurrentDirectory()}/files/{fileName}.csv");
        return File(archivo, "application/csv", $"{fileName}.csv");
    }
}