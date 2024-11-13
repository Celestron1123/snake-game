// <authors> Elijah Potter and William Ngo </authors>
// <date> 11/13/2024 </date>

namespace GUI.Client.Models
{
    /// <summary>
    ///     Represents the world of the game. Holds
    ///     all objects in the game
    /// </summary>
    public class World
    {
        /// <summary>
        ///     A dictionary to hold all the snakes in the game
        /// </summary>
        public Dictionary<int, Snakes> Snakes;

        /// <summary>
        ///     A dictionary to hold all the power ups in the game
        /// </summary>
        public Dictionary<int, PowerUp> PowerUps;

        /// <summary>
        ///     A dictionary to hold all the walls in the game
        /// </summary>
        public Dictionary<int, Walls> Walls;

        /// <summary>
        /// The size of a single side of the square world
        /// </summary>
        public int Size { get; private set; }

        /// <summary>
        ///     Creates a new world with a given size
        /// </summary>
        /// <param name="size"> The length of one side of the world </param>
        public World(int size)
        {
            Snakes = new Dictionary<int, Snakes>();
            PowerUps = new Dictionary<int, PowerUp>();
            Walls = new Dictionary<int, Walls>();
            Size = size;
        }

        /// <summary>
        ///     Creates a copy of the world
        /// </summary>
        /// <param name="world"> The world to copy </param>
        public World(World world)
        {
            Snakes = new(world.Snakes);
            PowerUps = new(world.PowerUps);
            Walls = new(world.Walls);
            Size = world.Size;
        }
    }
}
