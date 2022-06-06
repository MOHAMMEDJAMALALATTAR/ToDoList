using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebApp.Task1.Models
{
    public class ToDoListModel
    {
        public static int currId { get; set; } = 1;

        public int Id { get; set; }
        public  string WhatToDo { get; set; }
        public  string Notes { get; set; }
        public  DateTime WhenToDo { get; set; }
        public  DateTime InsertDate { get; set; }


    }
}
