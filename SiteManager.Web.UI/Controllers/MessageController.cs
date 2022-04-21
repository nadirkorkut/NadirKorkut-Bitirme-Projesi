using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiteManager.Business.Abstract;
using SiteManager.Business.DTOs;
using System.Linq;
using System.Threading.Tasks;

namespace SiteManager.Web.UI.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMessageService _messageService;

        public MessageController(IUserService userService, IMessageService messageService)
        {
            _userService = userService;
            _messageService = messageService;
        }

        public async Task<IActionResult> InBox()
        {
            var user = _userService.GetUserSession();
            var messages = await _messageService.GetAll();

            if(messages.Data != null)
            {
                var messageList = messages.Data.Where(i => i.Receiver == user.Email).ToList();
                return View(messageList);
            }

            return View();
        }
        public async Task<IActionResult> OutBox()
        {
            var user = _userService.GetUserSession();
            var messages = await _messageService.GetAll();

            if (messages.Data != null)
            {
                var messageList = messages.Data.Where(i => i.Sender == user.Email).ToList();
                return View(messageList);
            }

            return View();
        }
        public IActionResult DeleteMessageInBox(int id)
        {
            _messageService.Delete(id);
            return RedirectToAction("InBox");
        }

        public IActionResult DeleteMessageOutBox(int id)
        {
            _messageService.Delete(id);
            return RedirectToAction("OutBox");
        }
        public IActionResult SendMessage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(MessageDto message)
        {
            var user = _userService.GetUserSession();
            message.Sender = user.Email;
            await _messageService.Add(message);
            return RedirectToAction("OutBox");
        }
    }
}
