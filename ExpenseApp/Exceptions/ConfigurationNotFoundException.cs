namespace ExpenseApp.Exceptions
{
    public class ConfigurationNotFoundException(string key) : Exception($"Configuration key {key} not found")
    {
    }
}
