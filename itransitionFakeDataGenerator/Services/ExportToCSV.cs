using System.Text;

namespace Services.ExportFile
{
    public class CSV
    {
        public static void Export(string fileName, List<UserModel> data, string filesDir)
        {
            string filePath = Path.Combine(filesDir, $"{fileName}.csv");
            using(StreamWriter sw = new StreamWriter(filePath, false, Encoding.UTF8)) {
                sw.WriteLine("ID,Name,Gender,Address,Phone");

                foreach (var user in data)
                {
                    string safeAddress = user.address?.Replace(",", " ") ?? "";
                    sw.WriteLine($"{user.ID},{user.name},{user.gender},{safeAddress},{user.phone}");
                }
            }
        }
    }
}