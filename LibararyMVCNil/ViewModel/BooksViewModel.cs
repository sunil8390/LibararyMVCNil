using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using LibararyMVCNil.DAL;

namespace LibararyMVCNil.ViewModel


{
    public class BooksViewModel
    {
       




        #region Properties


        public int BookId
        {
            get; set;
        }

        
        public string BookName
        {
            get; set;
        }
        

        public int CategoryId
        {
            get; set;
        }
       

        public int PublisherId
        {
            get; set;
        }


        public String CategoryName
        {
            get; set;
        }
        

        public String PublisherName
        {
            get; set;
        }

        public List<BooksViewModel> booklist
        {
            get; set;
        }

        public int booklistfull
        {
            get; set;
        }


        public List<Categories> categorylist
        {
            get; set;
        }
        public List<Publishers> publisherlist
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

        public List<int> PageRange

        {
            get; set;
        }

      

        public int Quantity
        {
            get; set;
        }

        
        public bool IsActive
        {
            get; set;
        }

       
        public int CreatedBy
        {
            get; set;
        }

        
        public DateTime CreatedOn
        {
            get; set;
        }

       
        public int ModifiedBy
        {
            get; set;
        }

        
        public DateTime ModifiedOn
        {
            get; set;
        }

        public int TotalPages
        {
            get; set;
        }

        public int RowCounts
        
        { 
            get;  set;
        }
        public int TotalRecords 
        { 
            get;  set;
        }



        #endregion

    }
}