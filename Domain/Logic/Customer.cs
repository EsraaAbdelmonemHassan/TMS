namespace Domain
{
    using System.Threading.Tasks;
    using Olive;
    using Olive.Entities;

    partial class Customer
    {
        public override async Task Validate()
        {
            if (CustomerCode.HasValue())
            {
                var duplicate = await Database.Of<Customer>()
                    .Where(x => x.CustomerCode == CustomerCode && x.ID != ID)
                    .FirstOrDefault();

                if (duplicate != null)
                    throw new ValidationException("Customer code is already in use.");
            }

            await base.Validate();
        }
    }
}
