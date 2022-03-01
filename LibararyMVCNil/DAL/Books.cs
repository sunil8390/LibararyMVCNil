﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using LibararyMVCNil.ViewModel;

namespace LibararyMVCNil.DAL
{
    public class Books
    {
        #region Variable Declaration

        /// <summary>
        /// Variable to store Database object to interact with database.
        /// </summary>
        private Database db;
        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of theBooks class.
        /// </summary>
        public Books()
        {
            this.db = DatabaseFactory.CreateDatabase();
        }

        /// <summary>
        /// Initializes a new instance of the Books class.
        /// </summary>
        /// <param name="BookId">Sets the value of BookId.</param>
        public Books(int BookId)
        {
            this.db = DatabaseFactory.CreateDatabase();
            this.BookId = BookId;
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets  BookId
        /// </summary>
        public int BookId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets BookName
        /// </summary>
        public string BookName
        {
            get; set;
        }
        /// <summary>
        /// Gets or sets CategoryId
        /// </summary>

        public int CategoryId
        {
            get; set;
        }
        /// <summary>
        /// Gets or sets PublisherId
        /// </summary>

        public int PublisherId
        {
            get; set;
        }


        public String CategoryName
        {
            get; set;
        }
        /// <summary>
        /// Gets or sets PublisherId
        /// </summary>

        public String PublisherName 
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets Category and publsiher 
        /// </summary>
        /// 

        //public List<Books> Booksinfo
        //{
        //    get; set;
        //}

        //public List<Categories> categoryinfo 
        //{ 
        //    get; set; 
        //}
        //public List<Publishers> publisherinfo 
        //{ 
        //    get; set;
        //}


        /// <summary>
        /// Gets or sets Quantity
        /// </summary>

        public int Quantity
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

        public int PageNumber
        {
            get; set;
        }
        public int RowsOfPage
        {
            get; set;
        }

        

       public int RowCounts
        {
            get; set;
        }


        public List<int> PageSizeList 
        
        {
            get; set; 
        }

        //public int TotalPages
        //{
        //    get; set;
        //}







        #endregion

        #region Actions



        /// <summary>
        /// Loads the details for Books.
        /// </summary>
        /// <returns>True if Load operation is successful; Else False.</returns>
        public bool Load()
        {
            try
            {
                if (this.BookId != 0)
                {
                    DbCommand com = this.db.GetStoredProcCommand("BooksGetDetails");
                    this.db.AddInParameter(com, "BookID", DbType.Int32, this.BookId);
                    DataSet ds = this.db.ExecuteDataSet(com);
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        DataTable dt = ds.Tables[0];
                        this.BookId = Convert.ToInt32(dt.Rows[0]["BookId"]);
                        this.BookName = Convert.ToString(dt.Rows[0]["BookName"]);
                        this.CategoryId = Convert.ToInt32(dt.Rows[0]["CategoryId"]);
                        this.PublisherId = Convert.ToInt32(dt.Rows[0]["PublisherId"]);
                        this.Quantity = Convert.ToInt32(dt.Rows[0]["Quantity"]);
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
        /// Inserts details for Books if BookId = 0.
        /// Else updates details Books.
        /// </summary>
        /// <returns>True if Save operation is successful; Else False.</returns>
        public bool Save()
        {
            if (this.BookId == 0)
            {
                return this.Insert();
            }
            else
            {
                if (this.BookId > 0)
                {
                    return this.Update();
                }
                else
                {
                    this.BookId = 0;
                    return false;
                }
            }
        }

        /// <summary>
        /// Inserts details for Books.
        /// Saves newly created Id in BookId.
        /// </summary>
        /// <returns>True if Insert operation is successful; Else False.</returns>
        private bool Insert()
        {
            try
            {
                DbCommand com = this.db.GetStoredProcCommand("BooksInsert");
                this.db.AddOutParameter(com, "BookId", DbType.Int32, 1024);
                if (!String.IsNullOrEmpty(this.BookName))
                {
                    this.db.AddInParameter(com, "BookName", DbType.String, this.BookName);
                }
                else
                {
                    this.db.AddInParameter(com, "BookName", DbType.String, DBNull.Value);
                }
                if (this.CategoryId > 0)
                {
                    this.db.AddInParameter(com, "CategoryId", DbType.Int32, this.CategoryId);
                }
                else
                {
                    this.db.AddInParameter(com, "CategoryId", DbType.Int32, DBNull.Value);
                }
                if (this.PublisherId > 0)
                {
                    this.db.AddInParameter(com, "PublisherId", DbType.Int32, this.PublisherId);
                }
                else
                {
                    this.db.AddInParameter(com, "PublisherId", DbType.Int32, DBNull.Value);
                }

                if (this.Quantity > 0)
                {
                    this.db.AddInParameter(com, "Quantity", DbType.Int32, this.Quantity);
                }
                else
                {
                    this.db.AddInParameter(com, "Quantity", DbType.Int32, DBNull.Value);
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

                this.BookId = Convert.ToInt32(this.db.GetParameterValue(com, "BookId"));      // Read in the output parameter value



            

            }
            catch (Exception ex)
            {
                // To Do: Handle Exception
                return false;
            }

            return this.BookId > 0; // Return whether ID was returned
        }

        /// <summary>
        /// Updates details for Books.
        /// </summary>
        /// <returns>True if Update operation is successful; Else False.</returns>
        private bool Update()
        {
            try
            {
                DbCommand com = this.db.GetStoredProcCommand("BooksUpdate");
                this.db.AddInParameter(com, "BookId", DbType.Int32, this.BookId);
                if (!String.IsNullOrEmpty(this.BookName))
                {
                    this.db.AddInParameter(com, "BookName", DbType.String, this.BookName);
                }
                else
                {
                    this.db.AddInParameter(com, "BookName", DbType.String, DBNull.Value);
                }

                if (this.CategoryId > 0)
                {
                    this.db.AddInParameter(com, "CategoryId", DbType.Int32, this.CategoryId);
                }
                else
                {
                    this.db.AddInParameter(com, "CategoryId", DbType.Int32, DBNull.Value);
                }
                if (this.PublisherId > 0)
                {
                    this.db.AddInParameter(com, "PublisherId", DbType.Int32, this.PublisherId);
                }
                else
                {
                    this.db.AddInParameter(com, "PublisherId", DbType.Int32, DBNull.Value);
                }

                if (this.Quantity > 0)
                {
                    this.db.AddInParameter(com, "Quantity", DbType.Int32, this.Quantity);
                }
                else
                {
                    this.db.AddInParameter(com, "Quantity", DbType.Int32, DBNull.Value);
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
        /// Deletes details of Bookd for provided BookId.
        /// </summary>
        /// <returns>True if Delete operation is successful; Else False.</returns>
        public bool Delete()
        {
            try
            {
                DbCommand com = this.db.GetStoredProcCommand("BooksDelete");
                this.db.AddInParameter(com, "BookId", DbType.Int32, this.BookId);
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
        /// Get list of Books for provided parameters.
        /// </summary>
        /// <returns>DataSet of result</returns>
        /// <remarks></remarks>
        public List<BooksViewModel> GetList(BooksViewModel Model)
         {
           
            DataSet ds = null;

            try
            {

                DbCommand com = db.GetStoredProcCommand("BooksGetList");
                if (!String.IsNullOrEmpty(Model.BookName))
                {
                    this.db.AddInParameter(com, "BookName", DbType.String, Model.BookName);
                }
                else
                {
                    this.db.AddInParameter(com, "BookName", DbType.String, DBNull.Value);
                }
                if (Model.CategoryId > 0)
                {
                    this.db.AddInParameter(com, "CategoryId", DbType.Int32, Model.CategoryId);
                }
                else
                {
                    this.db.AddInParameter(com, "CategoryId", DbType.Int32, DBNull.Value);
                }
                if (Model.PublisherId > 0)
                {
                    this.db.AddInParameter(com, "PublisherId", DbType.Int32, Model.PublisherId);
                }
                else
                {
                    this.db.AddInParameter(com, "PublisherId", DbType.Int32, DBNull.Value);
                }


                if (Model.PageNumber > 0)
                {
                    this.db.AddInParameter(com, "PageNumber", DbType.Int32, Model.PageNumber);
                }
                else
                {
                    this.db.AddInParameter(com, "PageNumber", DbType.Int32, DBNull.Value);
                }

                if (Model.RowsOfPage > 0)
                {
                    this.db.AddInParameter(com, "RowsOfPage", DbType.Int32, Model.RowsOfPage);
                }
                else
                {
                    this.db.AddInParameter(com, "RowsOfPage", DbType.Int32, DBNull.Value);
                }


                ds = db.ExecuteDataSet(com);

               


                var book = (from DataRow dr in ds.Tables[0].Rows
                            select new BooksViewModel()
                            {
                                BookId = Convert.ToInt32(dr["BookId"]),
                                BookName = dr["BookName"].ToString(),
                                CategoryId = Convert.ToInt32(dr["CategoryId"]),
                                CategoryName = dr["CategoryName"].ToString(),
                                PublisherId = Convert.ToInt32(dr["PublisherId"]),
                                PublisherName = dr["PublisherName"].ToString(),
                               Quantity = Convert.ToInt32(dr["Quantity"]),
                                IsActive = Convert.ToBoolean(dr["IsActive"])
                              


                            }).ToList();


                Model.RowCounts = Convert.ToInt32(ds.Tables[0].Rows[0]["TotalRecords"].ToString());

                //models.RowCounts = ds.Tables[0].Rows.Count;
                Model.TotalPages = (int)Math.Ceiling((double)Model.RowCounts / Model.RowsOfPage);


                return book;



            }
            catch (Exception ex)
            {
                //To Do: Handle Exception
            }

            return null ;
            //return ds;
        }





        #endregion


      
    }
}