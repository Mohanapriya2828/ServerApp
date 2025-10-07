using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ServerApp.Model
{
    public class ChatModel
    {
        private readonly TcpListener _listener;
        private TcpClient _client;
        private NetworkStream _stream;
        public ChatModel(string ip, int port)
        {
            _listener = new TcpListener(IPAddress.Parse(ip), port);
        }

        public void StartServer()
        {
            _listener.Start();
            _client = _listener.AcceptTcpClient();
            _stream = _client.GetStream();
        }
        public string ReceiveMessage()
        {
            using (StreamReader reader = new StreamReader(_stream, Encoding.UTF8, true, 1024, true))
            {
                return reader.ReadLine();
            }
        }
        public void SendMessage(string message)
        {
            using (StreamWriter writer = new StreamWriter(_stream, Encoding.UTF8, 1024, true) { AutoFlush = true })
            {
                writer.WriteLine(message);
            }
        }
        public void Close()
        {
            _stream?.Close();
            _client?.Close();
            _listener?.Stop();
        }
    }
}
