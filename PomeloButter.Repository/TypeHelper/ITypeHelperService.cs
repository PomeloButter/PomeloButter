namespace PomeloButter.Repository.TypeHelper
{
    public interface ITypeHelperService
    {
        bool TypeHasProperties<T>(string fields);
    }
}