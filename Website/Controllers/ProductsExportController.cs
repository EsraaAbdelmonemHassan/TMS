namespace Controllers
{
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Domain;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Olive;
    using Olive.Entities;

    [Authorize]
    [Route("export")]
    public class ProductsExportController : BaseController
    {
        [HttpGet("products")]
        public async Task<IActionResult> ExportProducts()
        {
            var products = await Database.Of<Product>()
                .Where(x => x.IsActive)
                .OrderBy(x => x.Name)
                .GetList();

            var csv = new StringBuilder();
            csv.AppendLine("Name,Code,Price,Quantity,Category,IsActive");

            foreach (var p in products)
            {
                var category = p.CategoryId.HasValue
                    ? (await Database.GetOrDefault<Category>(p.CategoryId))?.Name ?? ""
                    : "";

                csv.AppendLine($"{Escape(p.Name)},{Escape(p.Code)},{p.Price},{p.Quantity},{Escape(category)},{p.IsActive}");
            }

            var bytes = Encoding.UTF8.GetBytes(csv.ToString());
            return File(bytes, "text/csv", "products.csv");
        }

        static string Escape(string value) =>
            $"\"{(value ?? "").Replace("\"", "\"\"")}\"";
    }
}
