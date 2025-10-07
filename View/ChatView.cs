using System;

namespace ServerApp.View
{
    public class ChatView
    {
        public void ShowMessage(string msg) => Console.WriteLine(msg);

        public string GetInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}
