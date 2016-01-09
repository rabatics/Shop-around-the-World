﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;

public struct VendorDetails
{
    public string vendorName;
    public string vendorEmail;
    public string vendorShortDesc;
    public string vendorPhone;
    public string vendorAddress;
    public int vendorRating;
    public int vendorCountryId;
}

public static class CatalogAccess
{
	static CatalogAccess()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static String getProductpath(int id)
    {
        // get a configured DbCommand object    
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "getProductpath";
        comm.CommandType = CommandType.StoredProcedure;
        // create a new parameter
        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@pCountryId";
        param1.Value = id;
        param1.DbType = DbType.Int16;
        comm.Parameters.Add(param1);
        DbParameter param3 = comm.CreateParameter();
        param3.ParameterName = "@productPath";
        param3.Direction = ParameterDirection.Output;
        param3.DbType = DbType.String;
        param3.Size = 500;
        comm.Parameters.Add(param3);
        // execute the stored procedure
        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        String path = comm.Parameters["@productPath"].Value.ToString();
        return path;
    }

    public static String validateUser(String username, String password)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "validateUser";
        comm.CommandType = CommandType.StoredProcedure;
        // create a new parameter
        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@uname";
        param1.Value = username;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);
        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@pwd";
        param2.Value = password;
        param2.DbType = DbType.String;
        comm.Parameters.Add(param2);
        DbParameter param3 = comm.CreateParameter();
        param3.ParameterName = "@validuser";
        param3.Direction = ParameterDirection.Output;
        param3.DbType = DbType.String;
        param3.Size = 1;
        comm.Parameters.Add(param3);
        // execute the stored procedure
        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        String num =comm.Parameters["@validuser"].Value.ToString();
        return num;
    }

    public static DataTable GetVendors(out int NumOfVendors)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "getVendors";
        comm.CommandType = CommandType.StoredProcedure;
        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@NumOfVendors";
        param1.Direction = ParameterDirection.Output;
        param1.DbType = DbType.Int32;
        param1.Size = 1;
        comm.Parameters.Add(param1);
        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        int num = Int32.Parse(comm.Parameters["@NumOfVendors"].Value.ToString());
        NumOfVendors = num;
        // return vendor details
        return table;
    }

    public static DataTable GetProducts(String country)
    {    // get a configured DbCommand object    
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name   
        comm.CommandText = "SELECT productName,productShortDesc,productPrice FROM dbo.Product where productCountryId='" + country + "';";
        comm.CommandType = CommandType.Text;
        // execute the stored procedure and return the results    
        return GenericDataAccess.ExecuteSelectCommand(comm);
    }





    public static int GetCustomerId(String loginId, out int custId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "getCustomerId";
        comm.CommandType = CommandType.StoredProcedure;
        DbParameter param4 = comm.CreateParameter();
        param4.ParameterName = "@loginId";
        param4.Value = loginId;
        param4.DbType = DbType.String;
        param4.Size = 50;
        comm.Parameters.Add(param4);
        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@custId";
        param1.Direction = ParameterDirection.Output;
        param1.DbType = DbType.Int32;
        param1.Size = 4;
        comm.Parameters.Add(param1);
        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        String custidstr = comm.Parameters["@custId"].Value.ToString();
        int custid = Int32.Parse(custidstr);
        custId = custid;
        // return customer id
        return custid;
    }

    public static DataTable GetCustomerInfo(int custId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "getCustomerInfo";
        comm.CommandType = CommandType.StoredProcedure;
        DbParameter param4 = comm.CreateParameter();
        param4.ParameterName = "@custId";
        param4.Value = custId;
        param4.DbType = DbType.Int32;
        param4.Size = 4;
        comm.Parameters.Add(param4);
        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        return table;
    }

    public static DataTable GetOrders(int custId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "getOrders";
        comm.CommandType = CommandType.StoredProcedure;
        DbParameter param4 = comm.CreateParameter();
        param4.ParameterName = "@custId";
        param4.Value = custId;
        param4.DbType = DbType.Int32;
        param4.Size = 2;
        comm.Parameters.Add(param4);
        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        // return order details
        return table;
    }

    public static DataTable GetOrderDetails(int orderId)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        comm.CommandText = "getOrderDetails";
        comm.CommandType = CommandType.StoredProcedure;
        DbParameter param4 = comm.CreateParameter();
        param4.ParameterName = "@orderId";
        param4.Value = orderId;
        param4.DbType = DbType.Int32;
        param4.Size = 2;
        comm.Parameters.Add(param4);
        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        // return order details
        return table;
    }

    public static int changePassword(string oldpwd, string login, out int flag)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "checkPassword";
        comm.CommandType = CommandType.StoredProcedure;
        // create a new parameter
        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@loginId";
        param1.Value = login;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);
        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@OldPassword";
        param2.Value = oldpwd;
        param2.DbType = DbType.String;
        comm.Parameters.Add(param2);
        DbParameter param3 = comm.CreateParameter();
        param3.ParameterName = "@flag";
        param3.Direction = ParameterDirection.Output;
        param3.DbType = DbType.String;
        param3.Size = 1;
        comm.Parameters.Add(param3);
        // execute the stored procedure
        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        int num = Int32.Parse(comm.Parameters["@flag"].Value.ToString());
        flag = num;
        return num;
    }

    public static void updatePassword(string login, string newpwd)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "updatePassword";
        comm.CommandType = CommandType.StoredProcedure;
        // create a new parameter
        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@loginId";
        param1.Value = login;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);
        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@NewPassword";
        param2.Value = newpwd;
        param2.DbType = DbType.String;
        comm.Parameters.Add(param2);
        // execute the stored procedure
        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static void addNewCustomer(string email, string fname, string lname, string gender, string dob, string phone, string address)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "registerUser";
        comm.CommandType = CommandType.StoredProcedure;
        // create a new parameter
        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@customeremailid";
        param1.Value = email;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);
        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@customerfirstname";
        param2.Value = fname;
        param2.DbType = DbType.String;
        comm.Parameters.Add(param2);
        DbParameter param3 = comm.CreateParameter();
        param3.ParameterName = "@customerlastname";
        param3.Value = lname;
        param3.DbType = DbType.String;
        comm.Parameters.Add(param3);
        DbParameter param4 = comm.CreateParameter();
        param4.ParameterName = "@customergender";
        param4.Value = gender;
        param4.DbType = DbType.String;
        comm.Parameters.Add(param4);
        DbParameter param5 = comm.CreateParameter();
        param5.ParameterName = "@customerdateofbirth";
        param5.Value = dob;
        param5.DbType = DbType.Date;
        comm.Parameters.Add(param5);
        DbParameter param6 = comm.CreateParameter();
        param6.ParameterName = "@customerphone";
        param6.Value = phone;
        param6.DbType = DbType.String;
        comm.Parameters.Add(param6);
        DbParameter param7 = comm.CreateParameter();
        param7.ParameterName = "@customeraddress";
        param7.Value = address;
        param7.DbType = DbType.String;
        comm.Parameters.Add(param7);
        // execute the stored procedure
        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static int checkEmail(string login, out int valid)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "validEmailid";
        comm.CommandType = CommandType.StoredProcedure;
        // create a new parameter
        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@emailid";
        param1.Value = login;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);
        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@CheckExists";
        param2.Direction = ParameterDirection.Output;
        param2.DbType = DbType.Int32;
        param2.Size = 1;
        comm.Parameters.Add(param2);
        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        int num = Int32.Parse(comm.Parameters["@CheckExists"].Value.ToString());
        valid = num;
        return num;
    }
    public static int getLatestCustomerId(out int latest)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "getLatestCustomerId";
        comm.CommandType = CommandType.StoredProcedure;
        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@custId";
        param2.Direction = ParameterDirection.Output;
        param2.DbType = DbType.Int32;
        param2.Size = 4;
        comm.Parameters.Add(param2);
        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
        int num = Int32.Parse(comm.Parameters["@custId"].Value.ToString());
        latest = num;
        return num;
    }

    public static void putNewLoginInfo(string login, string pwd, int custid)
    {
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "putNewLoginInfo";
        comm.CommandType = CommandType.StoredProcedure;
        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@loginid";
        param1.Value = login;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);
        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@loginpwd";
        param2.Value = pwd;
        param2.DbType = DbType.String;
        comm.Parameters.Add(param2);
        DbParameter param3 = comm.CreateParameter();
        param3.ParameterName = "@custid";
        param3.Value = custid;
        param3.DbType = DbType.Int32;
        comm.Parameters.Add(param3);
        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
    }

    public static void updateCustomerInfo(string email, int custid, string lname, string gender, string dob, string phone, string address)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
        // set the stored procedure name
        comm.CommandText = "updateCustomerInfo";
        comm.CommandType = CommandType.StoredProcedure;
        // create a new parameter
        DbParameter param1 = comm.CreateParameter();
        param1.ParameterName = "@customeremailid";
        param1.Value = email;
        param1.DbType = DbType.String;
        comm.Parameters.Add(param1);
        DbParameter param2 = comm.CreateParameter();
        param2.ParameterName = "@custid";
        param2.Value = custid;
        param2.DbType = DbType.Int32;
        comm.Parameters.Add(param2);
        DbParameter param3 = comm.CreateParameter();
        param3.ParameterName = "@customerlastname";
        param3.Value = lname;
        param3.DbType = DbType.String;
        comm.Parameters.Add(param3);
        DbParameter param4 = comm.CreateParameter();
        param4.ParameterName = "@customergender";
        param4.Value = gender;
        param4.DbType = DbType.String;
        comm.Parameters.Add(param4);
        DbParameter param5 = comm.CreateParameter();
        param5.ParameterName = "@customerdateofbirth";
        param5.Value = dob;
        param5.DbType = DbType.Date;
        comm.Parameters.Add(param5);
        DbParameter param6 = comm.CreateParameter();
        param6.ParameterName = "@customerphone";
        param6.Value = phone;
        param6.DbType = DbType.String;
        comm.Parameters.Add(param6);
        DbParameter param7 = comm.CreateParameter();
        param7.ParameterName = "@customeraddress";
        param7.Value = address;
        param7.DbType = DbType.String;
        comm.Parameters.Add(param7);
        // execute the stored procedure
        DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
    }

}