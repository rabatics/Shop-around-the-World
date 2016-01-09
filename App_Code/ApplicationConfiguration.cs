using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

/// <summary>
/// Summary description for ApplicationConfiguration
/// </summary>
public class ApplicationConfiguration
{
	public ApplicationConfiguration()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}

public static class ShopConfiguration
{
    // Caches the connection string  
    private static string dbConnectionString;  // Caches the data provider name   
    private static string dbProviderName;
    // Caches the connection string  private static string dbConnectionString;  // Caches the data provider name   private static string dbProviderName;
    static ShopConfiguration()
    {
        dbConnectionString = ConfigurationManager.ConnectionStrings["ShopConnection"].ConnectionString;
        dbProviderName = ConfigurationManager.ConnectionStrings["ShopConnection"].ProviderName;
    }

    public static string DbConnectionString
    {
        get { return dbConnectionString; }
    }
    // Returns the data provider name  
    public static string DbProviderName
    {
        get { return dbProviderName; }
    }
}