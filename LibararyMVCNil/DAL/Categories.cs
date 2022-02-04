using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace LibararyMVCNil.DAL
{
    public class Categories
    {
        #region Variable Declaration

        /// <summary>
        /// Variable to store Database object to interact with database.
        /// </summary>
        private Database db;
        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the Categories class.
        /// </summary>
        public Categories()
        {
            this.db = DatabaseFactory.CreateDatabase();
        }

        /// <summary>
        /// Initializes a new instance of the Categoriesclass.
        /// </summary>
        /// <param name="CategoryId">Sets the value of CategoryId.</param>
        public Categories(int CategoryId)
        {
            this.db = DatabaseFactory.CreateDatabase();
            this.CategoryId = CategoryId;
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets CategoryId
        /// </summary>
        public int CategoryId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets CategoryName
        /// </summary>
        public string CategoryName
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets ShortCode
        /// </summary>
       

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
        /// Get list of CategoryId for provided parameters.
        /// </summary>
        /// <returns>DataSet of result</returns>
        /// <remarks></remarks>
        public List<Categories> GetList()
        {
            DataSet ds = null;
            try
            {
                DbCommand com = db.GetStoredProcCommand("CategoriesGetDetails");
                ds = db.ExecuteDataSet(com);
                var category = (from DataRow dr in ds.Tables[0].Rows
                                select new Categories()
                                {
                                    CategoryId = Convert.ToInt32(dr["CategoryId"]),
                                    CategoryName = dr["CategoryName"].ToString()
                                }).ToList();
                return category;
            }
            catch (Exception ex)
            {
                //To Do: Handle Exception
            }

            return null;
        }
        #endregion
    }
}