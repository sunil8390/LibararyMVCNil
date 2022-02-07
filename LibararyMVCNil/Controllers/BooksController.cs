using LibararyMVCNil.DAL;
using LibararyMVCNil.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;





namespace LibararyMVCNil.Controllers
{
    public class BooksController : Controller
    {
        ////GET: Books
        //public ActionResult Index()
        //{
        //    Books obj = new Books();
        //    var a = obj.GetList();

        //    return View(a);


        //}

        
        public ActionResult Index()// simple convert data and show in table format 
        {


            //Books db = new Books();
            //List<Books> BookLists = new List<Books>();

            //DataSet dt = db.GetList();
            //BookLists = (from DataRow dr in dt.Tables[0].Rows
            //             select new Books()
            //             {
            //                 BookId = Convert.ToInt32(dr["BookId"]),
            //                 BookName = dr["BookName"].ToString(),
            //                 CategoryName = dr["CategoryName"].ToString(),

            //                 PublisherName = dr["PublisherName"].ToString()

            //             }).ToList();

            return View(/*BookList*/);





        }

        public ActionResult SearchBook() // using view bag 
        {
            
     //book dropdown using viewbag
            //    Books db = new Books();
            //    DataSet ds = db.GetList();

            //    var Bklist = (from DataRow dr in ds.Tables[0].Rows 
            //                 select new Books() 
            //                  {
            //                      BookId = Convert.ToInt32(dr["bookid"]),
            //                      BookName = dr["bookname"].ToString(),
                                
                                  

            //                  }).ToList();


            //ViewBag.booklist = new SelectList(Bklist, "BookId", "BookName");

     //Categories dropdown using viewbag
            //Categories cdb = new Categories();
            //DataSet cds = cdb.GetList();

            //var Ctlist = (from DataRow dr in cds.Tables[0].Rows
            //              select new Categories()
            //              {
                              
            //                  CategoryId = Convert.ToInt32(dr["CategoryId"]),
            //                  CategoryName = dr["CategoryName"].ToString(),


            //              }).ToList();


            //ViewBag.categorylist = new SelectList(Ctlist, "CategoryId", "CategoryName");



     //Publishers dropdown using viewbag
            //Publishers pdb = new Publishers();
            //DataSet pds = pdb.GetList();

            //var plist = (from DataRow dr in pds.Tables[0].Rows
            //              select new Publishers()
            //              {

            //                  PublisherId = Convert.ToInt32(dr["PublisherId"]),
            //                  PublisherName = dr["PublisherName"].ToString(),


            //              }).ToList();

            //ViewBag.Publisherlist = new SelectList(plist, "PublisherId", "PublisherName");


            return View();






        }

        //public List<Books> DataConversion()
        //{
        //    Books db = new Books();
        //    //List<Books> bklist = new List<Books>();
        //    DataSet ds_bk = db.GetList();

        //    var book = (from DataRow dr in ds_bk.Tables[0].Rows
        //                select new Books()
        //                {
        //                    BookId = Convert.ToInt32(dr["BookId"]),
        //                    BookName = dr["BookName"].ToString(),
        //                    CategoryId = Convert.ToInt32(dr["CategoryId"]),
        //                    CategoryName = dr["CategoryName"].ToString(),
        //                    PublisherId = Convert.ToInt32(dr["PublisherId"]),
        //                    PublisherName = dr["PublisherName"].ToString()

        //                }).ToList();

        //    return book;




        //}

        public ActionResult SearchBook1() //using model serach book catgeories and publisher 

        {
            BooksViewModel model =new BooksViewModel();
           
            Books Books = new Books();
            model.booklist = Books.GetList();

            model.PageNumber = model.PageNumber;
            model.RowsOfPage = model.RowsOfPage;





            //var book = (from DataRow dr in ds_bk.Tables[0].Rows
            //                select new BooksViewModel()
            //                {
            //                    BookId = Convert.ToInt32(dr["BookId"]),
            //                    BookName = dr["BookName"].ToString(),
            //                   CategoryId = Convert.ToInt32(dr["CategoryId"]),
            //                    CategoryName = dr["CategoryName"].ToString(), 
            //                    PublisherId = Convert.ToInt32(dr["PublisherId"]),
            //                    PublisherName = dr["PublisherName"].ToString()

            //                }).ToList();
            //var book = db.DataConversion();

            //model.booklist = book;



            //categories
            // DataSet cds = db.GetList();
            Categories categories = new Categories();
            model.categorylist = categories.GetList();

            //var category = (from DataRow dr in ds_cat.Tables[0].Rows
            //                select new Categories()
            //                {
            //                    CategoryId = Convert.ToInt32(dr["CategoryId"]),
            //                    CategoryName = dr["CategoryName"].ToString()
            //                }).ToList();

            //model.categorylist = category;




      //Publishers

            ///DataSet pds = db.GetList();
            Publishers Publisher = new Publishers();
            //DataSet ds_pub = Publisher.GetList();
            model.publisherlist = Publisher.GetList();

            //var Publishers = (from DataRow dr in ds_pub.Tables[0].Rows
            //                  select new Publishers()
            //                  {
            //                      PublisherId = Convert.ToInt32(dr["PublisherId"]),
            //                      PublisherName = dr["PublisherName"].ToString()
            //                  }).ToList();
            //model.publisherlist = Publishers;


            return View(model);

           
        }

    
        [HttpPost]
        public ActionResult SearchBook1(BooksViewModel Model) /* string Searching*/
        {
           

            //BooksViewModel model = new BooksViewModel();
            //Categories db = new Categories();
            //DataSet pds = db.GetList();
            //var category = category.Include(s => )




            Books db = new Books();
            db.BookName = Model.BookName;
            db.CategoryId = Model.CategoryId;
            db.PublisherId = Model.PublisherId;


            db.PageNumber = Model.PageNumber;
            db.RowsOfPage = Model.RowsOfPage;


            //Model.PageNumber = Model.PageNumber;
            //Model.RowsOfPage = Model.RowsOfPage;

            //db.CategoryName = Model.CategoryName;
            //db.PublisherName = Model.PublisherName;


            // var a = db.GetList();

            //book
            //  Books Books = new Books();
            //DataSet ds_bk = Publisher.GetList();
            Model.booklist = db.GetList();  //a;



            //var book = (from DataRow dr in ds_bk.Tables[0].Rows
            //                 select new BooksViewModel()
            //                 {
            //                     BookId = Convert.ToInt32(dr["BookId"]),
            //                     BookName = dr["BookName"].ToString(),
            //                     CategoryId = Convert.ToInt32(dr["CategoryId"]),
            //                     CategoryName = dr["CategoryName"].ToString(), 
            //                     PublisherId = Convert.ToInt32(dr["PublisherId"]),
            //                     PublisherName = dr["PublisherName"].ToString()

            //                 }).ToList();

            

    //categories
            Categories categories = new Categories();
            //DataSet ds_cat = Publisher.GetList();
            Model.categorylist = categories.GetList();

            //var category = (from DataRow dr in ds_cat.Tables[0].Rows
            //                select new Categories()
            //                {
            //                    CategoryId = Convert.ToInt32(dr["CategoryId"]),
            //                    CategoryName = dr["CategoryName"].ToString()
            //                }).ToList();

            //Model.categorylist = category;



    //Publishers
            Publishers Publisher = new Publishers();
            //DataSet ds_pub = Publisher.GetList();
            Model.publisherlist = Publisher.GetList();

            //var Publishers = (from DataRow dr in ds.Tables[0].Rows
            //                  select new Publishers()
            //                  {
            //                      PublisherId = Convert.ToInt32(dr["PublisherId"]),
            //                      PublisherName = dr["PublisherName"].ToString()
            //                  }).ToList();
            //Model.publisherlist = Publishers;


            


            return View(Model);


        }
       


        public ActionResult SearchBook2( )

        {




            

           


                return View();



        }//empty 








    }

}