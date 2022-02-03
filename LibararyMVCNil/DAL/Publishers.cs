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
    public class Publishers
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
        /// Initializes a new instance of the Publishers class.
        /// </summary>
        public Publishers()
        {
            this.db = DatabaseFactory.CreateDatabase();
        }

        /// <summary>
        /// Initializes a new instance of the Publishers class.
        /// </summary>
        /// <param name="PublisherId">Sets the value of PublisherId.</param>
        public Publishers(int PublisherId)
        {
            this.db = DatabaseFactory.CreateDatabase();
            this.PublisherId = PublisherId;
        }
        #endregion


        #region Properties

        /// <summary>
        /// Gets or sets PublisherId
        /// </summary>
        public int PublisherId
    {
            get; set;
        }

        /// <summary>
        /// Gets or sets SettingType
        /// </summary>
        public string PublisherName
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
        /// Get list of Publishers for provided parameters.
        /// </summary>
        /// <returns>DataSet of result</returns>
        /// <remarks></remarks>
        public DataSet GetList()
        {
            DataSet ds = null;
            try
            {
                DbCommand com = db.GetStoredProcCommand("PublishersGetDetails");
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
}