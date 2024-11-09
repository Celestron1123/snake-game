// <authors> Elijah Potter and William Ngo </authors>
// <date> whatever </date>

namespace GUI.Client.Models
{
    /// <summary>
    ///     Represents snake objects in the game
    /// </summary>
    public class Snakes
    {
        /// <summary>
        ///     The snake's unique ID
        /// </summary>
        public int Snake { get; private set; }

        /// <summary>
        ///     The username of the snake
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        ///     A list of points representing the shape
        ///     and position of the snake
        /// </summary>
        public List<Point2D> Body { get; private set; }

        /// <summary>
        ///     The orientation of the snake as a
        ///     2D vector
        /// </summary>
        public Point2D Dir { get; private set; }

        /// <summary>
        ///     The number of powerups eaten
        /// </summary>
        public int Score { get; private set; } = 0;

        /// <summary>
        ///     A bool telling if the snake is dead
        /// </summary>
        public bool Died { get; private set; } = false;

        /// <summary>
        ///     A bool telling if the snake is alive
        /// </summary>
        public bool Alive { get; private set; } = true;

        /// <summary>
        ///     A bool telling if the user disconnected
        /// </summary>
        public bool Dc { get; private set; } = false;

        /// <summary>
        ///     A bool telling if the user just joined
        /// </summary>
        public bool Join { get; private set; } = true;

        /// <summary>
        ///     A default constructor for JSON 
        /// </summary>
        public Snakes()
        {
            Snake = 0;
            Name = string.Empty;
            Body = [];
            Dir = new(1, 0);
            Score = 0;
            Died = false;
            Alive = true;
            Dc = false;
            Join = true;
        }

        public Snakes(int snake, string name, List<Point2D> body, Point2D dir)
        {
            Snake = snake;
            Name = name;
            Body = body;
            Dir = dir;
        }
    }
}
