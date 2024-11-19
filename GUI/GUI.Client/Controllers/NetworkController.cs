// <authors> Elijah Potter and Willy Ngo </authors>
// <date> November 19, 2024 </date>

using System.Data;
using System.Diagnostics;
using CS3500.Networking;
using GUI.Client.Models;

namespace GUI.Client.Controllers
{
    /// <summary>
    /// Controls all network communications between the snake client and server.
    /// Handles connection establishment, world updates, and sending player commands.
    /// </summary>
    public class NetworkController
    {
        /// <summary>
        /// The underlying network connection to the server
        /// </summary>
        private readonly NetworkConnection _connection = new();

        /// <summary>
        /// The current state of the game world
        /// </summary>
        private World? _world;

        /// <summary>
        /// Event that fires whenever the world state is updated from the server
        /// </summary>
        public event Action<World>? OnWorldUpdate;

        /// <summary>
        /// Establishes a connection to the snake server and begins receiving world updates
        /// </summary>
        /// <param name="hostname">The server's hostname (e.g., "localhost")</param>
        /// <param name="port">The server's port number</param>
        /// <param name="username">The player's chosen username</param>
        /// <exception cref="InvalidOperationException">Thrown if connection fails</exception>
        public void ConnectToServer(string hostname, int port, string username)
        {
            _connection.Connect(hostname, port);
            _connection.Send(username);

            // Receive and parse initial setup data from server
            int playerId = int.Parse(_connection.ReadLine());
            int worldSize = int.Parse(_connection.ReadLine());

            _world = new World(worldSize);
            new Thread(NetworkLoop).Start();
        }

        /// <summary>
        /// Continuously receives and processes world updates from the server.
        /// Runs in a separate thread to prevent blocking the game loop.
        /// </summary>
        private void NetworkLoop()
        {
            while (true)
            {
                string update = _connection.ReadLine();
                if (_world == null) continue;

                if (update[2] == 'w')
                {
                    Walls wall = new();
                    wall.UpdateJson(update);
                    _world.Walls[wall.wall] = wall;
                }
                else if (update[2] == 's')
                {
                    if (_world.Snakes.ContainsKey(int.Parse("" + update[9])))
                    {
                        _world.Snakes[int.Parse("" + update[9])].UpdateJson(update);
                    }
                    else
                    {
                        Snakes snake = new();
                        snake.UpdateJson(update);
                        _world.Snakes.Add(snake.snake, snake);
                    }
                }
                else if (update[2] == 'p')
                {
                    PowerUp power = new();
                    power.UpdateJson(update);

                    // Only add new powerups or update existing ones if they haven't been marked as dead
                    if (!power.died)
                    {
                        _world.PowerUps[power.power] = power;
                    }
                    // Remove dead powerups
                    else if (_world.PowerUps.ContainsKey(power.power))
                    {
                        _world.PowerUps.Remove(power.power);
                    }
                }

                OnWorldUpdate?.Invoke(_world);
            }
        }

        /// <summary>
        /// Processes keyboard input and sends the corresponding movement commands to the server
        /// </summary>
        /// <param name="key">The key that was pressed (should be 'w', 'a', 's', or 'd')</param>
        public void HandleKeyPress(string key)
        {
            switch (key.ToLower())
            {
                case "w":
                    _connection.Send("{\"moving\":\"up\"}");
                    break;
                case "s":
                    _connection.Send("{\"moving\":\"down\"}");
                    break;
                case "a":
                    _connection.Send("{\"moving\":\"left\"}");
                    break;
                case "d":
                    _connection.Send("{\"moving\":\"right\"}");
                    break;
            }
        }
    }
}