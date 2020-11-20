using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QL_Blogs.Models;
using QL_Blogs.DataAccess;

namespace QL_Blogs.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            Blog objBlog = new Blog();
            DataAccessLayer objDB = new DataAccessLayer(); //calling class DBdata  
            objBlog.ShowallBlog = objDB.Selectalldata();
            return View(objBlog);

        }

        [HttpGet]
        public ActionResult Category()
        {
            Categories objBlog = new Categories();
            DataAccessLayer objDB = new DataAccessLayer(); //calling class DBdata  
            objBlog.ShowallCategory = objDB.SelectCategory();
            return View(objBlog);
        }

        [HttpGet]
        public ActionResult PositionCate()
        {
            PositionCate objBlog = new PositionCate();
            DataAccessLayer objDB = new DataAccessLayer(); //calling class DBdata  
            objBlog.ShowallPositionCate = objDB.SelectPositionCate();
            return View(objBlog);
        }

        [HttpGet]
        public ActionResult Create()
        {
            DataAccessLayer objDB = new DataAccessLayer();
            ViewBag.objCategory = objDB.SelectCategory();
            ViewBag.objPositionCate = objDB.SelectPositionCate();
            return View();
        }
        [HttpPost]
        public ActionResult Create(BlogPosition objBlog)
        {
            if (ModelState.IsValid) 
            {
                DataAccessLayer objDB = new DataAccessLayer();
                var poscateid = objDB.InsertData(objBlog);
                foreach(var blogid in objBlog.Position)
                {
                    objDB.InsertPosition(poscateid, blogid);
                } 
                return RedirectToAction("Index");
            }

            return View(objBlog);
        }       
                
        public  ActionResult Search()
        {
            Blog objBlog = new Blog();
            DataAccessLayer objDB = new DataAccessLayer(); //calling class DBdata  
            objBlog.ShowallBlog = objDB.Selectalldata();
            return View(objBlog);
        }

        [HttpGet]
        public ActionResult Edit(string ID)
        {
            Blog objCustomer = new Blog();
            DataAccessLayer objDB = new DataAccessLayer(); //calling class DBdata  
            ViewBag.objCategory = objDB.SelectCategory();
            ViewBag.objPositionCate = objDB.SelectPositionCate();
            return View(objDB.SelectDatabyID(ID));
        }

        [HttpPost]
        public ActionResult Edit(Blog objBlog)
        {
            objBlog.DataPublic = Convert.ToDateTime(objBlog.DataPublic);
            if (ModelState.IsValid) //checking model is valid or not  
            {
                DataAccessLayer objDB = new DataAccessLayer(); //calling class DBdata  
                string result = objDB.UpdateData(objBlog);
                //ViewData["result"] = result;  
                TempData["result2"] = result;
                ModelState.Clear(); //clearing model  
                //return View();  
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View();
            }
        }

        [HttpGet]
        public ActionResult Delete(String ID)
        {
            DataAccessLayer objDB = new DataAccessLayer();
            int result = objDB.DeleteData(ID);
            TempData["result3"] = result;
            ModelState.Clear(); //clearing model  
                                //return View();  
            return RedirectToAction("Index");
        }
    }
}