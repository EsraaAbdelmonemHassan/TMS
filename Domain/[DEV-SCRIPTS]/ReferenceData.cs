using Olive;
using Olive.Entities;
using Olive.Entities.Data;
using Olive.Security;
using System.Threading.Tasks;

namespace Domain
{
    public class ReferenceData : IReferenceData
    {
        static IDatabase Database => Context.Current.Database();

        async Task<T> Create<T>(T item) where T : IEntity
        {
            await Context.Current.Database().Save(item);
            return item;
        }

        public async Task Create()
        {
            await Create(new Settings { Name = "Current", PasswordResetTicketExpiryMinutes = 2 });

            await CreateAdmins();
            await CreateContacts();
            await CreateCatalog();
        }

        async Task CreateCatalog()
        {
            var electronics = await Create(new Category { Name = "Electronics", IsActive = true, SortOrder = 1 });
            var books = await Create(new Category { Name = "Books", IsActive = true, SortOrder = 2 });

            var phone = await Create(new Product
            {
                Name = "Smartphone",
                Code = "PH-001",
                Price = 499.99m,
                Quantity = 25,
                IsActive = true,
                Category = electronics
            });

            await Create(new Product
            {
                Name = "Programming book",
                Code = "BK-001",
                Price = 29.99m,
                Quantity = 100,
                IsActive = true,
                Category = books
            });

            var customer = await Create(new Customer
            {
                FirstName = "Ahmed",
                LastName = "Ali",
                Email = "ahmed@example.com",
                CustomerCode = "CUST-001",
                CreditLimit = 5000m
            });

            var order = await Create(new Order
            {
                Customer = customer,
                Status = "Pending",
                IsApproved = false
            });

            await Create(new OrderItem
            {
                Order = order,
                Product = phone,
                Quantity = 2,
                UnitPrice = phone.Price
            });

            await order.RecalculateTotalAsync();

            var course = await Create(new Course { Name = "MSharp Programming", Code = "CS101" });
            var student = await Create(new Student { FirstName = "Sara", LastName = "Mohammed" });
            await Create(new StudentCourse { Student = student, Course = course });
        }

        async Task CreateAdmins()
        {
            await AddAdmin("Oliver", "Jones", "oiver@fakemail.com");
            await AddAdmin("Daniel", "Williams", "daniel@office.edu");
            await AddAdmin("Thomas", "Davies", "thomas@uat.co");
            await AddAdmin("Harry", "Evans", "harry@williams.com");
            await AddAdmin("Jack", "Roberts", "jack@for-test.net");
            await AddAdmin("Samuel", "Morgan", "samuel@college.edu");
            await AddAdmin("James", "Edwards", "james@humour.org");
            await AddAdmin("Alexander", "Smith", "alexander@fakemail.com");
            await AddAdmin("Charlie", "Phillips", "charlie@office.edu");
            await AddAdmin("Emma", "Richards", "emma@uat.co");
        }

        async Task CreateContacts()
        {
            await AddContact("Oliver", "Jones", "020 8549 1245");
            await AddContact("Daniel", "Williams", "084 5264 8548");
            await AddContact("Thomas", "Davies", "020 7569 3254");
            await AddContact("Harry", "Evans", "0127 7786 5314");
            await AddContact("Jack", "Roberts", "079 8556 7059");
            await AddContact("Samuel", "Morgan", "0800 6325 978");
            await AddContact("James", "Edwards", "0109 6455 2135");
            await AddContact("Alexander", "Smith", "078 9563 2157");
            await AddContact("Charlie", "Phillips", "0203 6654 162");
            await AddContact("Emma", "Richards", "020 8549 1245");
            await AddContact("Andrew", "Richards", "020 9587 8765");
        }

        private Task<Contact> AddContact(string firstName, string lastName, string phone)
        {
            return Create(new Contact
            {
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phone
            });
        }

        private Task<Administrator> AddAdmin(string firstName, string lastName, string email)
        {
            var pass = SecurePassword.Create("test");
            return Create(new Administrator
            {
#pragma warning disable GCop646 // Email addresses should not be hard-coded. Move this to Settings table or Config file.
                Email = email,
#pragma warning restore GCop646 // Email addresses should not be hard-coded. Move this to Settings table or Config file.
                FirstName = firstName,
                LastName = lastName,
                Password = pass.Password,
                Salt = pass.Salt
            });
        }
    }
}

