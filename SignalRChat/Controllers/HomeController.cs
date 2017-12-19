using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SignalRChat.Models;
using SignalRChat.Hubs;
using Microsoft.AspNetCore.SignalR;
using SignalRChat.Helpers;

namespace SignalRChat.Controllers
{
    public class HomeController : Controller
    {
        private IHubContext<ChatHub> _chatHub;
        public HomeController(IHubContext<ChatHub> chatHub)
        {
            _chatHub = chatHub;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ChooseChatRoom(int chatRoom)
        {
            if(chatRoom == 1)
            {
                return View("ChatRoom1");
            }
            else if(chatRoom == 2)
            {
                return View("ChatRoom2");
            }

            return NotFound();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
