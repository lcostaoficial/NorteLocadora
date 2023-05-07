using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;

namespace Locadora.Controllers
{
    public enum MessageType
    {
        success,
        info,
        warning,
        error
    }

    public class Alert
    {
        public string Message { get; set; }
        public string Type { get; set; }
    }

    public abstract class BaseController : Controller
    {
        public MessageType MessageType { get; private set; }

        public BaseController()
        {
            MessageType = MessageType.info;
        }

        private void SaveMessage(string message)
        {
            if (TempData.ContainsKey("msg") && TempData["msg"] != null && !string.IsNullOrEmpty((string)TempData["msg"]))
            {
                var list = JsonSerializer.Deserialize<List<Alert>>(TempData["msg"].ToString());
                list.Add(new Alert { Message = message, Type = MessageType.ToString() });
                TempData["msg"] = JsonSerializer.Serialize(list);
            }
            else
            {
                var list = new List<Alert> {
                    new Alert{ Message = message, Type = MessageType.ToString() }
                };

                TempData["msg"] = JsonSerializer.Serialize(list);
            }
        }

        public void Message(string message, MessageType messageType)
        {
            MessageType = messageType;
            SaveMessage(message);
        }
    }
}