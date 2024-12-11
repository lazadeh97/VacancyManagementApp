namespace VacancyManagement.Web.Extensions
{
    static class Configuration
    {
        static public string ConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(AppContext.BaseDirectory);
                configurationManager.AddJsonFile("appsettings.json");

                return configurationManager.GetConnectionString("SQLServerConnStr");
            }
        }
    }
}
