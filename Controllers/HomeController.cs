using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TestOSKI.Models;
using TestOSKI.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace TestOSKI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        ApplicationContext context;
        
        public int score;
        public string LoggedInUser => User.Identity.Name;


        public HomeController(ILogger<HomeController> logger, ApplicationContext context)
        {
            this.logger = logger;
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        //[HttpGet]
        //public IActionResult CreateQuestion()
        //{
        //    ViewBag.Quiz = new SelectList(context.Quizzes.ToList(), "Id", "Name");
        //    return View();
        //}
        //[HttpPost]
        //public  IActionResult CreateQuestion( Question question)
        //{

        //    Quiz quiz = quizzes.FirstOrDefault(qui => qui.Id==question.QuizId);
        //    context.Quiz.Add(quiz);
        //    return View();
        //}


        //[HttpGet]
        //public IActionResult CreatQuiz()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public async Task<IActionResult> CreatQuiz(Quiz quiz)
        //{
        //    context.Quizzes.Add(quiz);
        //    await context.SaveChangesAsync();
        //    return RedirectToAction("Index", "Home");
        //}

        public IActionResult Privacy()
        {
            return View("StartPage");
        }
        public IActionResult QuizPage(int id)
        {
            Quiz quiz = context.Quizzes.FirstOrDefault(qui => qui.Id == id);
            return View(quiz);
        }
        public IActionResult ListOfQuiz()

        {
            return View(context.Quizzes.ToList());
        }
        public IActionResult TestPage(int id, int page = 1)
        {

            int pageSize = 1;
            
            Quiz quiz = context.Quizzes
                .FirstOrDefault(qui => qui.Id == id);
            List<Question> tempQuestions = context.Questions.Where(q => q.QuizId == id).ToList();
            int count = tempQuestions.Count();
            List<Question> questions = tempQuestions.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);

            QuizQuestionsViewModel quizQuestionsViewModel = new QuizQuestionsViewModel
            {
                Quiz = quiz,
                Questions = questions,
                PageViewModel = pageViewModel

            };
            return View("TestPage", quizQuestionsViewModel);
        }

      

        [HttpPost]
        public void AddPoint( string selectedValue, string questionId)

        {
            Result userResult = context.Results.FirstOrDefault(r => r.UserName == LoggedInUser);
            
            if(userResult == null)
            {
                context.Results.Add(new Result { UserName = LoggedInUser, TotalPoint = 1 });
                context.SaveChanges();
            }
            else
            {
                if (context.Questions.FirstOrDefault(q => q.Id == Convert.ToInt32(questionId)).WrightAnswer == selectedValue)
                {
                    userResult.TotalPoint++;
                    context.SaveChanges();
                    
                }

            }
            context.SaveChanges();

        }
        
        
        public IActionResult CurrentUserResult() 
        {
            ViewData["Message"] = context.Results.FirstOrDefault(r => r.UserName == LoggedInUser).TotalPoint;
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
