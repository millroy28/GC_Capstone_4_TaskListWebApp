using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Threading.Tasks;
using GC_CAPSTONE4_TASKLIST.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace GC_CAPSTONE4_TASKLIST.Controllers
{
    [Authorize]
    public class TaskListController : Controller
    {
        private readonly TaskListContext _context;

        public TaskListController(TaskListContext context)
        {
            _context = context;
        }


        public IActionResult Index(string viewOption, int singleId, string keyWord)
        {


            string id = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            List<EachTask> thisUserTaskList = new List<EachTask>();
            switch (viewOption)
            {
                case "All":
                    
                    thisUserTaskList = _context.Task.Where(x => x.UserId == id).ToList();
                    return View(thisUserTaskList);

                case "Incomplete":
                   
                    thisUserTaskList = _context.Task.Where(x => x.UserId == id &&
                                                            x.Complete == false &&
                                                            x.ParentTaskId == null).ToList();
                    return View(thisUserTaskList);

                case "Expand":
                    
                    thisUserTaskList = _context.Task.Where(x => x.UserId == id &&
                                                            x.Complete == false).ToList();
                    return View(thisUserTaskList);

                case "Single":
                   
                    thisUserTaskList = _context.Task.Where(x => x.UserId == id &&
                                                            x.Id == singleId ||
                                                            x.ParentTaskId == singleId).ToList();
                    return View(thisUserTaskList);

                case "Search":

                    thisUserTaskList = _context.Task.Where(x => x.UserId == id &&
                                                            x.Title.Contains(keyWord) ||
                                                            x.Description.Contains(keyWord)).ToList();
                    return View(thisUserTaskList);

                default:
                    thisUserTaskList = _context.Task.Where(x => x.UserId == id &&
                                                               x.Complete == false &&
                                                               x.ParentTaskId == null).ToList();
                    return View(thisUserTaskList);
                    
            }
          
        }

        public IActionResult ViewAll()
        {
            string id = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var thisUserTask = _context.Task.Where(x => x.UserId == id).ToList();
            return View(thisUserTask);
        }

        [HttpGet]
        public IActionResult AddTask()
        {
            return View(); 
        }
        [HttpPost]
        public IActionResult AddTask(EachTask newTask)
        {         
            newTask.UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (ModelState.IsValid)
            {
                _context.Task.Add(newTask);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else 
            { 
                return View();
            }
        }

        [HttpGet]
        public IActionResult AddSubTask(int id)
        {
            EachTask parentTask = _context.Task.Find(id);
            
            return View(parentTask);
        }
        [HttpPost]
        public IActionResult AddSubTask(EachTask newTask)
        {
            newTask.UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (ModelState.IsValid)
            {
                EachTask newParentTask = _context.Task.Find(newTask.ParentTaskId);
                newParentTask.Parent = true;

                _context.Entry(newParentTask).State = Microsoft.EntityFrameworkCore.EntityState.Modified;  //remember to copy paste this honkin thing
                _context.Update(newParentTask);
                _context.SaveChanges();

            }


            if (ModelState.IsValid)
            {

                _context.Task.Add(newTask);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public IActionResult CompleteStatusToggle(int id)
        {
            EachTask selectedTask = _context.Task.Find(id);
            
            if (selectedTask.Complete == false)
            {
                selectedTask.Complete = true;
            }
            else
            {
                selectedTask.Complete = false;
            }
            
            if (ModelState.IsValid)
            {
                _context.Entry(selectedTask).State = Microsoft.EntityFrameworkCore.EntityState.Modified;  //remember to copy paste this honkin thing
                _context.Update(selectedTask);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditTask(int id)
        {
            EachTask taskToEdit = _context.Task.Find(id);
            return View(taskToEdit);
        }

        [HttpPost]
        public IActionResult EditTask(EachTask editedTask)
        {
            EachTask originalTask = _context.Task.Find(editedTask.Id);
            if (ModelState.IsValid)
            {
                originalTask.Title = editedTask.Title;
                originalTask.Description = editedTask.Description;
                originalTask.DueDate = editedTask.DueDate;

                _context.Entry(originalTask).State = Microsoft.EntityFrameworkCore.EntityState.Modified;  //remember to copy paste this honkin thing
                _context.Update(originalTask);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult DeleteTask(int id)
        {
            EachTask taskToDelete = _context.Task.Find(id);
            return View(taskToDelete);
        }

        [HttpPost]
        public IActionResult DeleteTask(EachTask taskToDelete)
        {
            if(taskToDelete != null)
            {
                _context.Task.Remove(taskToDelete);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
