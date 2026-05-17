using MSharp;

namespace Admin
{
    public class CategoriesPage : SubPage<AdminPage>
    {
        public CategoriesPage()
        {
            Add<Modules.CategoriesList>();
        }
    }
}
