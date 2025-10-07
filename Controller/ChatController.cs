using ServerApp.Model;
using ServerApp.View;
using System;

namespace ServerApp.Controller
{
    public class ChatController
    {
        private readonly ChatModel _model;
        private readonly ChatView _view;

        public ChatController(ChatModel model, ChatView view)
        {
            _model = model;
            _view = view;
        }

        public void Start()
        {
            try
            {
                _model.StartServer();
                _view.ShowMessage("[SERVER] Waiting for messages...");

                while (true)
                {
                    string clientMsg = _model.ReceiveMessage();
                    if (clientMsg == null) break;

                    _view.ShowMessage($"[CLIENT]: {clientMsg}");

                    if (clientMsg.Equals("exit", StringComparison.OrdinalIgnoreCase))
                        break;

                    string reply = _view.GetInput("[SERVER]: ");
                    _model.SendMessage(reply);

                    if (reply.Equals("exit", StringComparison.OrdinalIgnoreCase))
                        break;
                }
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"[SERVER ERROR] {ex.Message}");
            }
            finally
            {
                _model.Close();
            }
        }
    }
}
