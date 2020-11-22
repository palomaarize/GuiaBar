
using System;

namespace GuiaBar.Domain.Config
{
    public class Settings
    {
      public static string DATABASE_CONNECTION_STRING = Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING");
      public static string TOKEN_KEY = Environment.GetEnvironmentVariable("TOKEN_KEY");
    }
}