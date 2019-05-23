using System;
using System.Timers;

namespace TickTackToe
{
    class Messenger
    {
        private Timer timer;
        public Message message;

        public Messenger()
        {
            setTimer();
            message = new Message("");
        }

        private void setTimer()
        {
            timer = new Timer(1000);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
        }
        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            if(message.txt != "")
            {
                Clear();
            }
        }

        public void Send(string txt)
        {
            message = new Message(txt);
        }
        public void Send(string txt, char type)
        {
            message = new Message(txt, type);
        }
        public void Clear()
        {
            message = new Message("");
        }
    }

    struct Message
    {
        public char type;
        public string txt;

        public Message(string txt, char type = 'd')
        {
            this.txt = txt;
            this.type = type;
        }
    }
}
