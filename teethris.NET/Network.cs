using System;
using Quobject.SocketIoClientDotNet.Client;

namespace teethris.NET
{
    public class Network
    {
        public Network(){
            var socket = IO.Socket("http://borisjeltsin.azurewebsites.net/");
            socket.On(Socket.EVENT_CONNECT, () =>
            {
                socket.Emit("chat message", "hi");
            });

            socket.On("chat message", (data) =>
                {
                    Console.WriteLine(data);
                    socket.Disconnect();
                });
        }
    }
}