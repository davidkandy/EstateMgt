namespace Client.Static
{
    public static class APIEndpoints
    {
#if DEBUG
        internal const string ServerBaseUrl = "https://localhost:5003";
#else
        internal const string ServerBaseUrl = "https:estatedev.azurewebsites.net";
#endif

        internal readonly static string s_register = $"{ServerBaseUrl}/api/user/register";
        internal readonly static string s_signIn = $"{ServerBaseUrl}/api/user/signin";
        internal readonly static string s_weatherforecast = $"{ServerBaseUrl}/weatherforecast";

        internal readonly static string s_company = $"{ServerBaseUrl}/api/company";
        internal readonly static string s_departments = $"{ServerBaseUrl}/api/departments";
        internal readonly static string s_jobs = $"{ServerBaseUrl}/api/jobs";
        internal readonly static string s_employees = $"{ServerBaseUrl}/api/employees";
    }
}
