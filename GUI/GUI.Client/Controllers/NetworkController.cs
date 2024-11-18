using System.Data;
using System.Diagnostics;
using CS3500.Networking;
using GUI.Client.Models;

namespace GUI.Client.Controllers
{
    /// This class should handle the connection to the server, sending the players name. It should also
    /// send the direction of the snake to the server by serializing it in JSON format.
    /// It should listen for updates from the server. And i think it should deserialize each message into
    /// a GameStateUpdate object, which is like the updates to the positions of the snakes, powerups and walls.
    /// Should also handle the connection closing.
    /// </summary>
    public class NetworkController
    {
        private readonly NetworkConnection _NetworkConnection = new NetworkConnection();


        public void SendCommand(Commands command)
        {
            _NetworkConnection.Send(command.GetJson());
        }


        Commands command = new Commands();
        public void HandleKeyPress(string key)
        {
            // Change snake direction based on key press
            switch (key)
            {
                case "ArrowUp":
                    command.moving = "up";

                    break;
                case "ArrowDown":
                    command.moving = "down";
                    break;
                case "ArrowLeft":
                    command.moving = "left";
                    break;
                case "ArrowRight":
                    command.moving = "right";
                    break;
            }

        }
    }
}