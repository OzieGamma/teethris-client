using System;
using Quobject.SocketIoClientDotNet.Client;

namespace teethris.NET
{
    public static class Network
    {
        public static Socket socket = IO.Socket("http://borisjeltsin.azurewebsites.net/");
        
        public static void init(){
            socket.On(Socket.EVENT_CONNECT, () =>
            {
                socket.Emit("chat message", "hi");
            });
            
            socket.On("chat message", (data) =>
            {
                Console.WriteLine(data);
                //socket.Disconnect();
            });
        }
        
        public static void send(String message){
            socket.Emit("chat message", message);
        }
    }
}