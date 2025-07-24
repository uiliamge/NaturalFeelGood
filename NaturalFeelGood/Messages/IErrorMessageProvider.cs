
namespace NaturalFeelGood.Api.Messages
{
    public interface IErrorMessageProvider
    {
        string GetMessage(string key, string language);
    }
}
