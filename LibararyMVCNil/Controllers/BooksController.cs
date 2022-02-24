using LibararyMVCNil.DAL;
using LibararyMVCNil.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;





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

            return View(/*BookLists*/);





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

        public ActionResult SearchBook1() // int pager = 1  for paging //using model serach book catgeories and publisher 

        {

            BooksViewModel model =new BooksViewModel();
           
            Books Books = new Books();
  

            model.PageNumber = 1;
            model.RowsOfPage =10;

            //session 


            //(BooksViewModel) model = Session["record"];

            //Session["record"] = BooksViewModel model;


            




            //model.booklist = Books.GetList(model);

            model.PageRange = new List<int>()
            {
                3,
                5,
                10
            };

            model = (BooksViewModel)Session["records"];




            //Categories

            Categories categories = new Categories();
            model.categorylist = categories.GetList();


     //Publishers

            
            Publishers Publisher = new Publishers();
           
            model.publisherlist = Publisher.GetList();

            



            return View(model);

           
        }

    //Post
        [HttpPost]
        public ActionResult SearchBook1(BooksViewModel Model) /* string Searching*/
        {


          


            Books db = new Books();

            //Model.PageRange = new List<int>()
            //{
            //    3,
            //    5,
            //    10
            //};




            Model.booklist = db.GetList(Model);


           

     //categories
            Categories categories = new Categories();
         
            Model.categorylist = categories.GetList();


    //Publishers
            Publishers Publisher = new Publishers();
            
            Model.publisherlist = Publisher.GetList();


            //  Model.TotalPages = 10 / Model.RowsOfPage;  //count


     //session 


            Session["records"] = Model;


            //return View(Model);
            return PartialView("_SearchBookPartial", Model);


        }



        public ActionResult get_data(BooksViewModel model)    //partial view search book 
        {

            //Books Books = new Books();

            //model.booklist = Books.GetList(model);

            // var json = JsonConvert.SerializeObject(model.booklist);
            //return PartialView("_SearchBookPartial", model);

            return View();


        }


        public ActionResult AddBook(int Id = 0)          /*int Id=0*/                              //add book and update 
        {
           
            BooksViewModel Model = new BooksViewModel();
            Books book = new Books();
            book.BookId = Id;

            book.Load();

            Model.BookId = book.BookId;
            Model.BookName = book.BookName;
            Model.CategoryId = book.CategoryId;
            Model.PublisherId = book.PublisherId;
            Model.Quantity = book.Quantity;
            Model.IsActive = book.IsActive;



            //Categories

            Categories categories = new Categories();
            Model.categorylist = categories.GetList();


            //Publishers


            Publishers Publisher = new Publishers();

            Model.publisherlist = Publisher.GetList();


            //session 

            //Session["Message"] = "Hello MVC!";


            return View(Model);
        }

        [HttpPost]
        public ActionResult AddBook(BooksViewModel Model)
        {

           

            Books books = new Books();



            books.BookId = Model.BookId;
            books.BookName = Model.BookName;
            books.CategoryId = Model.CategoryId;
            books.PublisherId = Model.PublisherId;
            books.Quantity = Model.Quantity;
            books.IsActive = Model.IsActive;

            //Categories

            Categories categories = new Categories();
            Model.categorylist = categories.GetList();


            //Publishers


            Publishers Publisher = new Publishers();

            Model.publisherlist = Publisher.GetList();


            books.Save();


            //return View(Model);

            return RedirectToAction("SearchBook1");
        }






       






    }

}