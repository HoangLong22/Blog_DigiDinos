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
                
        [HttpGet]
        public ActionResult Edit(int ID)
        {
            Blog objBlog = new Blog();
            DataAccessLayer objDB = new DataAccessLayer(); //calling class DBdata  
            ViewBag.objCategory = objDB.SelectCategory();
            ViewBag.objPositionCate = objDB.SelectPositionCate();
            ViewBag.objPosition = objDB.SelectPosition(ID);
            ViewBag.objBlog = objDB.Selectalldata();
            return View(objDB.SelectDatabyID(ID));
        }

        [HttpPost]
        public ActionResult Edit(Blog objBlog)
        {
            DataAccessLayer objDB = new DataAccessLayer(); //calling class DBdata 
            if (ModelState.IsValid)
            {
                objDB.UpdateData(objBlog);
                foreach (var position in objBlog.Position)
                {
                    objDB.InsertPosition(objBlog.ID, position);
                }
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");
                ViewBag.objCategory = objDB.SelectCategory();
                ViewBag.objPositionCate = objDB.SelectPositionCate();
                ViewBag.objPosition = objDB.SelectPosition(objBlog.ID);
                return View(objBlog);
            }
        }

        [HttpGet]
        public ActionResult Delete(String ID)
        {
            DataAccessLayer objDB = new DataAccessLayer();
            objDB.DeleteData(ID);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Search(string Title)
        {
            DataAccessLayer objDB = new DataAccessLayer();
            List<Blog> data = new List<Blog>();
            if (string.IsNullOrEmpty(Title))
            {
                data = objDB.Selectalldata();
            }
            else
            {
                data = objDB.Search(Title);
            }
            return View(data);
        }
    }
}