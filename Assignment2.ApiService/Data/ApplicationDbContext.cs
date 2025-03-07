using System.Globalization;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using Assignment2Library;
using Microsoft.EntityFrameworkCore;

namespace Assignment2.ApiService.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Article> Articles => Set<Article>();
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Article>().HasData(GetArticles());
        }
        public static IEnumerable<Article> GetArticles()
        {
            string[] p = { Directory.GetCurrentDirectory(), "wwwroot", "articles.csv"
};
            var csvFilePath = Path.Combine(p);
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Encoding = Encoding.UTF8,
                PrepareHeaderForMatch = args => args.Header.ToLower(),
            };
            var data = new List<Article>().AsEnumerable();
            using (var reader = new StreamReader(csvFilePath))
            {
                using (var csvReader = new CsvReader(reader, config))
                {
                    data = csvReader.GetRecords<Article>().ToList();
                }
            }
            return data;
        }
    }
}