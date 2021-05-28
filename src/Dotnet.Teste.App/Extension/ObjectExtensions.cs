namespace Dotnet.Teste.App.Extension
{
    public static class ObjectExtensions
    {
        public static dynamic Get(this object @this, string propertyName)
        {
            return @this.GetType().GetProperty(propertyName).GetValue(@this, null);
        }
    }
}
