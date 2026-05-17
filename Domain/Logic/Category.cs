namespace Domain
{
    using System.Threading.Tasks;
    using Olive.Entities;

    partial class Category
    {
        protected override async Task OnSaved(SaveEventArgs e)
        {
            await base.OnSaved(e);
            await ApplicationEventLogger.LogAsync("Category", e.Mode.ToString(), ID, Name);
        }
    }
}
