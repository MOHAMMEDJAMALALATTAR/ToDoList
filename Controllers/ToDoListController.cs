using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Task1.Models;

namespace WebApp.Task1.Controllers
{

    public class ToDoListController : Controller
    {
       
         static List<ToDoListModel> MyList = new List<ToDoListModel>
        {
            new ToDoListModel()
            {
                Id=10,
               
                WhatToDo="HomeWork",
                WhenToDo=new DateTime(2021, 6, 1, 7, 47, 0),
               InsertDate=new DateTime(2021,12,5),
               Notes="Plese Do HomeWork "
            }
         
        };
        public IActionResult Index()
        {
            return View( );
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create([Bind] ToDoListModel valuee)
        {
            valuee.Id = ToDoListModel.currId++;
            valuee.InsertDate = DateTime.Now;
            MyList.Add(valuee);
            return Index();
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var model = MyList.FirstOrDefault(x => x.Id == Id);
            if (model == null)
                return NotFound();
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(int Id, [Bind] ToDoListModel valuee)
        {
            var model = MyList.FirstOrDefault(x => x.Id == Id);
            if (model == null)
                return NotFound();
            model.WhatToDo = valuee.WhatToDo;
            model.Notes = valuee.Notes;
            model.WhenToDo = valuee.WhenToDo;
            return Index();
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var model = MyList.FirstOrDefault(x => x.Id == Id);
            if (model == null)
                return NotFound();
            return View();
        }
        [HttpPost("[Controller]/Delete/{Id}")]
        public IActionResult PostDelete(int Id)
        {
            var model = MyList.FirstOrDefault(x => x.Id == Id);
            if (model == null)
                return NotFound();
            MyList.Remove(model);
            return Index();
        }
    }
}
