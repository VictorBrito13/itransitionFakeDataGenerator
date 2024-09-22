using System.Text;

namespace Services.ExportFile
{
    public class CSV
    {
        public static void Export(string fileName, List<UserModel> data)
        {
            Console.WriteLine(Directory.GetCurrentDirectory());
            using(StreamWriter sw = new StreamWriter($"{Directory.GetCurrentDirectory()}/files/{fileName}.csv", false, Encoding.UTF8)) {
                sw.WriteLine("ID,Name,Gender,Address,Phone");

                foreach (var user in data)
                {
                    sw.WriteLine($"{user.ID},{user.name},{user.gender},{user.address},{user.phone}");
                }
            }
            Console.WriteLine("Archivo Generado");
        }
    }
}