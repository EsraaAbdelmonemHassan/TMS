namespace Domain
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Olive;
    using Olive.Entities;

    partial class Product
    {
        static readonly string[] AllowedManualExtensions = { ".pdf", ".docx", ".xlsx" };

        public bool IsExpired() =>
            AvailableTo.HasValue && AvailableTo.Value.Date < DateTime.Today;

        public override async Task Validate()
        {
            if (AvailableFrom.HasValue && AvailableTo.HasValue && AvailableTo < AvailableFrom)
                throw new ValidationException("End date must be after start date.");

            if (Price < 0 || Price > 10000)
                throw new ValidationException("Price must be between 0 and 10000.");

            if (Quantity < 0)
                throw new ValidationException("Quantity must be a positive number.");

            if (Manual.HasValue())
            {
                var ext = System.IO.Path.GetExtension(Manual)?.ToLowerInvariant();
                if (ext.IsEmpty() || !AllowedManualExtensions.Contains(ext))
                    throw new ValidationException("File type not allowed. Allowed: pdf, docx, xlsx");
            }

            if (Name.HasValue() && CategoryId != null)
            {
                var duplicate = await Database.Of<Product>()
                    .Where(x => x.Name == Name && x.CategoryId == CategoryId && x.ID != ID)
                    .FirstOrDefault();

                if (duplicate != null)
                    throw new ValidationException("A product with the same name already exists in this category.");
            }

            await base.Validate();
        }

        protected override async Task OnSaved(SaveEventArgs e)
        {
            await base.OnSaved(e);
            await ApplicationEventLogger.LogAsync("Product", e.Mode.ToString(), ID, Name);
        }
    }
}
