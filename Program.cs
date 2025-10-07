using ServerApp.Model;
using ServerApp.View;
using ServerApp.Controller;

namespace ServerApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            string ip = "127.0.0.1";
            int port = 8888;
            ChatModel model = new ChatModel(ip, port);
            ChatView view = new ChatView();
            ChatController controller = new ChatController(model, view);
            controller.Start();
        }
    }
}
