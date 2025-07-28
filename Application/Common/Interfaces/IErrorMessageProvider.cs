namespace Application.Common.Interfaces
{
    public interface IErrorMessageProvider
    {
        string GetMessage(string key, string language);
    }
}
