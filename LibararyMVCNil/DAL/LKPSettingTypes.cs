// -----------------------------------------------------------------------
// <copyright file="LKPSettingTypes.cs" company="Rheal Software (P.) Ltd.">
// Copyright (c) "Rheal Software (P.) Ltd.". All rights reserved.
// </copyright>
// <author>Anuja Ashok Bhatkar</author>
// -----------------------------------------------------------------------
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

/// <summary>
/// Business class representing LKPSettingTypes
/// </summary>
public class LKPSettingTypes
{
#region Basic Functionality

#region Variable Declaration

   /// <summary>
   /// Variable to store Database object to interact with database.
   /// </summary>
   private Database db;
#endregion

#region Constructors

   /// <summary>
   /// Initializes a new instance of the LKPSettingTypes class.
   /// </summary>
   public LKPSettingTypes()
   {
      this.db  = DatabaseFactory.CreateDatabase();
   }

   /// <summary>
   /// Initializes a new instance of the LKPSettingTypes class.
   /// </summary>
   /// <param name="lKPSettingTypeID">Sets the value of LKPSettingTypeID.</param>
   public LKPSettingTypes(int lKPSettingTypeID)
   {
      this.db = DatabaseFactory.CreateDatabase();
      this.LKPSettingTypeID = lKPSettingTypeID;
   }
#endregion

#region Properties

   /// <summary>
   /// Gets or sets LKPSettingTypeID
   /// </summary>
   public int LKPSettingTypeID
   {
      get; set;
   }

   /// <summary>
   /// Gets or sets SettingType
   /// </summary>
   public string SettingType
   {
      get; set;
   }

   /// <summary>
   /// Gets or sets ShortCode
   /// </summary>
   public string ShortCode
   {
      get; set;
   }

   /// <summary>
   /// Gets or sets IsActive
   /// </summary>
   public bool IsActive
   {
      get; set;
   }

   /// <summary>
   /// Gets or sets CreatedBy
   /// </summary>
   public int CreatedBy
   {
      get; set;
   }

   /// <summary>
   /// Gets or sets CreatedOn
   /// </summary>
   public DateTime CreatedOn
   {
      get; set;
   }

   /// <summary>
   /// Gets or sets ModifiedBy
   /// </summary>
   public int ModifiedBy
   {
      get; set;
   }

   /// <summary>
   /// Gets or sets ModifiedOn
   /// </summary>
   public DateTime ModifiedOn
   {
      get; set;
   }
#endregion

#region Actions

   /// <summary>
   /// Loads the details for LKPSettingTypes.
   /// </summary>
   /// <returns>True if Load operation is successful; Else False.</returns>
   public bool Load()
   {
      try
      {
         if (this.LKPSettingTypeID != 0)
         {
            DbCommand com = this.db.GetStoredProcCommand("LKPSettingTypesGetDetails");
            this.db.AddInParameter(com, "LKPSettingTypeID", DbType.Int32, this.LKPSettingTypeID);
            DataSet ds = this.db.ExecuteDataSet(com);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
               DataTable dt = ds.Tables[0];
               this.LKPSettingTypeID = Convert.ToInt32(dt.Rows[0]["LKPSettingTypeID"]);
               this.SettingType = Convert.ToString(dt.Rows[0]["SettingType"]);
               this.ShortCode = Convert.ToString(dt.Rows[0]["ShortCode"]);
               this.IsActive = Convert.ToBoolean(dt.Rows[0]["IsActive"]);
               this.CreatedBy = Convert.ToInt32(dt.Rows[0]["CreatedBy"]);
               this.CreatedOn = Convert.ToDateTime(dt.Rows[0]["CreatedOn"]);
               this.ModifiedBy = Convert.ToInt32(dt.Rows[0]["ModifiedBy"]);
               this.ModifiedOn = Convert.ToDateTime(dt.Rows[0]["ModifiedOn"]);
               return true;
            }
         }

      return false;
      }
      catch (Exception ex)
      {
         // To Do: Handle Exception
         return false;
      }
   }

   /// <summary>
   /// Inserts details for LKPSettingTypes if LKPSettingTypeID = 0.
   /// Else updates details for LKPSettingTypes.
   /// </summary>
   /// <returns>True if Save operation is successful; Else False.</returns>
   public bool Save()
   {
      if (this.LKPSettingTypeID == 0)
      {
         return this.Insert();
      }
      else
      {
         if (this.LKPSettingTypeID > 0)
         {
            return this.Update();
         }
         else
         {
            this.LKPSettingTypeID = 0;
            return false;
         }
      }
   }

   /// <summary>
   /// Inserts details for LKPSettingTypes.
   /// Saves newly created Id in LKPSettingTypeID.
   /// </summary>
   /// <returns>True if Insert operation is successful; Else False.</returns>
   private bool Insert()
   {
      try
      {
         DbCommand com = this.db.GetStoredProcCommand("LKPSettingTypesInsert");
         this.db.AddOutParameter(com, "LKPSettingTypeID", DbType.Int32, 1024);
         if (!String.IsNullOrEmpty(this.SettingType))
         {
            this.db.AddInParameter(com, "SettingType", DbType.String, this.SettingType);
         }
         else
         {
            this.db.AddInParameter(com, "SettingType", DbType.String, DBNull.Value);
         }
        /* if (!String.IsNullOrEmpty(this.ShortCode))
         {
            this.db.AddInParameter(com, "ShortCode", DbType.String, this.ShortCode);
         }
         else
         {
            this.db.AddInParameter(com, "ShortCode", DbType.String, DBNull.Value);
         }*/
         this.db.AddInParameter(com, "IsActive", DbType.Boolean, this.IsActive);
         if (this.CreatedBy > 0)
         {
            this.db.AddInParameter(com, "CreatedBy", DbType.Int32, this.CreatedBy);
         }
         else
         {
            this.db.AddInParameter(com, "CreatedBy", DbType.Int32, DBNull.Value);
         }
         if (this.CreatedOn > DateTime.MinValue)
         {
            this.db.AddInParameter(com, "CreatedOn", DbType.DateTime, this.CreatedOn);
         }
         else
         {
            this.db.AddInParameter(com, "CreatedOn", DbType.DateTime, DBNull.Value);
         }
         if (this.ModifiedBy > 0)
         {
            this.db.AddInParameter(com, "ModifiedBy", DbType.Int32, this.ModifiedBy);
         }
         else
         {
            this.db.AddInParameter(com, "ModifiedBy", DbType.Int32, DBNull.Value);
         }
         if (this.ModifiedOn > DateTime.MinValue)
         {
            this.db.AddInParameter(com, "ModifiedOn", DbType.DateTime, this.ModifiedOn);
         }
         else
         {
            this.db.AddInParameter(com, "ModifiedOn", DbType.DateTime, DBNull.Value);
         }
         this.db.ExecuteNonQuery(com);
         this.LKPSettingTypeID = Convert.ToInt32(this.db.GetParameterValue(com, "LKPSettingTypeID"));      // Read in the output parameter value
      }
      catch (Exception ex)
      {
         // To Do: Handle Exception
         return false;
      }

      return this.LKPSettingTypeID > 0; // Return whether ID was returned
   }

   /// <summary>
   /// Updates details for LKPSettingTypes.
   /// </summary>
   /// <returns>True if Update operation is successful; Else False.</returns>
   private bool Update()
   {
      try
      {
         DbCommand com = this.db.GetStoredProcCommand("LKPSettingTypesUpdate");
         this.db.AddInParameter(com, "LKPSettingTypeID", DbType.Int32, this.LKPSettingTypeID);
         if (!String.IsNullOrEmpty(this.SettingType))
         {
            this.db.AddInParameter(com, "SettingType", DbType.String, this.SettingType);
         }
         else
         {
            this.db.AddInParameter(com, "SettingType", DbType.String, DBNull.Value);
         }
         if (!String.IsNullOrEmpty(this.ShortCode))
         {
            this.db.AddInParameter(com, "ShortCode", DbType.String, this.ShortCode);
         }
         else
         {
            this.db.AddInParameter(com, "ShortCode", DbType.String, DBNull.Value);
         }
         this.db.AddInParameter(com, "IsActive", DbType.Boolean, this.IsActive);
         if (this.CreatedBy > 0)
         {
            this.db.AddInParameter(com, "CreatedBy", DbType.Int32, this.CreatedBy);
         }
         else
         {
            this.db.AddInParameter(com, "CreatedBy", DbType.Int32, DBNull.Value);
         }
         if (this.CreatedOn > DateTime.MinValue)
         {
            this.db.AddInParameter(com, "CreatedOn", DbType.DateTime, this.CreatedOn);
         }
         else
         {
            this.db.AddInParameter(com, "CreatedOn", DbType.DateTime, DBNull.Value);
         }
         if (this.ModifiedBy > 0)
         {
            this.db.AddInParameter(com, "ModifiedBy", DbType.Int32, this.ModifiedBy);
         }
         else
         {
            this.db.AddInParameter(com, "ModifiedBy", DbType.Int32, DBNull.Value);
         }
         if (this.ModifiedOn > DateTime.MinValue)
         {
            this.db.AddInParameter(com, "ModifiedOn", DbType.DateTime, this.ModifiedOn);
         }
         else
         {
            this.db.AddInParameter(com, "ModifiedOn", DbType.DateTime, DBNull.Value);
         }
         this.db.ExecuteNonQuery(com);
      }
      catch (Exception ex)
      {
         // To Do: Handle Exception
         return false;
      }

      return true;
   }

   /// <summary>
   /// Deletes details of LKPSettingTypes for provided LKPSettingTypeID.
   /// </summary>
   /// <returns>True if Delete operation is successful; Else False.</returns>
   public bool Delete()
   {
      try
      {
         DbCommand com = this.db.GetStoredProcCommand("LKPSettingTypesDelete");
         this.db.AddInParameter(com, "LKPSettingTypeID", DbType.Int32, this.LKPSettingTypeID);
         this.db.ExecuteNonQuery(com);
      }
      catch (Exception ex)
      {
         // To Do: Handle Exception
         return false;
      }

      return true;
   }

   /// <summary>
   /// Get list of LKPSettingTypes for provided parameters.
   /// </summary>
   /// <returns>DataSet of result</returns>
   /// <remarks></remarks>
   public DataSet GetList()
   {
      DataSet ds = null;
      try
      {
         DbCommand com = db.GetStoredProcCommand("LKPSettingTypesGetList");
         ds = db.ExecuteDataSet(com);
      }
      catch (Exception ex)
      {
         //To Do: Handle Exception
      }

      return ds;
   }
#endregion

#endregion
}
