using System;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System.Net.Http;
using Astarte.Models;
namespace Astarte.Controllers
{
	[Authorize(Roles = "admin,user")]
	public class TelegramController : Controller
	{
        string photourl = "https://e7.pngegg.com/pngimages/340/226/png-clipart-purple-and-white-logo-c-computer-programming-software-development-programmer-marklogic-coder-miscellaneous-purple.png";
        string chatId = "@memes_for_coders";

        string UrlCaption = "<a href='https://t.me/memes_for_coders'>CODE memes and News</a>";

        public async Task<IActionResult> Posting(TPost model)
        {
            return View(model);
        }

        public void SendPhoto(string _apiToken, string _photoUrl, string _chatID, string _caption, string _mode)
        {
            using (var httpClient = new HttpClient())
            {
                var res = httpClient.GetAsync(
                    $"https://api.telegram.org/bot{_apiToken}/sendPhoto?chat_id={_chatID}&photo={_photoUrl}&caption={_caption}&parse_mode={_mode}"
                    ).Result;

            }
        }

        public void SendText(string _apiToken, string _text, string _chatID, string _mode)
        {
            using (var httpClient = new HttpClient())
            {
                var res = httpClient.GetAsync(
                    $"https://api.telegram.org/bot{_apiToken}/sendMessage?chat_id={_chatID}&text={_text}&parse_mode={_mode}"
                    ).Result;

            }
        }

        public void SendDocument(string _apiToken, string _document, string _chatID, string _caption, string _mode)
        {
            using (var httpClient = new HttpClient())
            {
                var res = httpClient.GetAsync(
                    $"https://api.telegram.org/bot{_apiToken}/sendDocument?chat_id={_chatID}&document={_document}&caption={_caption}&parse_mode={_mode}"
                    ).Result;

            }
        }

        public void SendAudio(string _apiToken, string _audio, string _chatID, string _caption, string _mode)
        {
            using (var httpClient = new HttpClient())
            {
                var res = httpClient.GetAsync(
                    $"https://api.telegram.org/bot{_apiToken}/sendAudio?chat_id={_chatID}&audio={_audio}&caption={_caption}&parse_mode={_mode}"
                    ).Result;

            }
        }

        public void SendVideo(string _apiToken, string _video, string _chatID, string _caption, string _mode)
        {
            using (var httpClient = new HttpClient())
            {
                var res = httpClient.GetAsync(
                    $"https://api.telegram.org/bot{_apiToken}/sendVideo?chat_id={_chatID}&video={_video}&caption={_caption}&parse_mode={_mode}"
                    ).Result;

            }
        }

        public async Task<IActionResult> Post(TPost model)
        {
            string post_type = model.PostType;
            string img_url = model.ImageUrl;
            string chatID = model.ChatID;
            string img_caption = model.ImageCaption;
            string apiToken = model.ApiToken;
            string mode = model.Mode;
            string text_content = model.TextField;
            string DocumentUrl = model.DocumentUrl;
            string DocumentCaption = model.DocumentCaption;
            string AudioUrl = model.AudioUrl;
            string AudioCaption = model.AudioCaption;
            string VideoUrl = model.VideoUrl;
            string VideoCaption = model.VideoCaption;

            switch (post_type)
            {
                case "image":
                    SendPhoto(apiToken, img_url, chatID, img_caption, mode);
                    break;
                case "text":
                    SendText(apiToken, text_content, chatID, mode);
                    break;
                case "document":
                    SendDocument(apiToken, DocumentUrl, chatID, DocumentCaption, mode);
                    break;
                case "audio":
                    SendAudio(apiToken,AudioUrl,chatID,AudioCaption,mode);
                    break;
                case "video":
                    SendVideo(apiToken,VideoUrl,chatID,VideoCaption,mode);
                    break;

            }

            return RedirectToAction("Posting");
        }
    }
}

