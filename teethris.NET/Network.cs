using System;
using Quobject.SocketIoClientDotNet.Client;

namespace teethris.NET
{
    public static class Network
    {
        public static Socket socket = IO.Socket("http://borisjeltsin.azurewebsites.net/");
        private static Game game;
        
        public static void init(Game game){
            Network.game = game;
            
            socket.On(Socket.EVENT_CONNECT, () =>
            {
                socket.Emit("chat message", "hi");
            });
            
            socket.On("chat message", (data) =>
            {
                Console.WriteLine(data);
                Network.game.KeyReceived((String)data);
                //socket.Disconnect();
            });
        }
        
        public static void send(String message){
            socket.Emit("chat message", message);
        }
    }
}