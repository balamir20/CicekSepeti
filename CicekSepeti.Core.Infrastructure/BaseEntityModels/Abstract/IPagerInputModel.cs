namespace CicekSepeti.Core.Infrastructure.BaseEntityModels.Abstract
{
    public interface IPagerInputModel
    {
        int PageNumber { get; set; }
        int PageSize { get; set; }
        string SearchText { get; set; }
        string SortColumn { get; set; }
        bool SortDescending { get; set; }
    }
}
