// <authors> Elijah Potter and William Ngo </authors>
// <date> 11/13/2024 </date>

using System.Text.Encodings.Web;
using System.Text.Json;

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
        public int snake { get; set; }

        /// <summary>
        ///     The username of the snake
        /// </summary>
        public string name { get; set; }

        /// <summary>
        ///     A list of points representing the shape
        ///     and position of the snake
        /// </summary>
        public List<Point2D> body { get; set; }

        /// <summary>
        ///     The orientation of the snake as a
        ///     2D vector
        /// </summary>
        public Point2D dir { get; set; }

        /// <summary>
        ///     The number of powerups eaten
        /// </summary>
        public int score { get; set; } = 0;

        /// <summary>
        ///     A bool telling if the snake is dead
        /// </summary>
        public bool died { get; set; } = false;

        /// <summary>
        ///     A bool telling if the snake is alive
        /// </summary>
        public bool alive { get; set; } = true;

        /// <summary>
        ///     A bool telling if the user disconnected
        /// </summary>
        public bool dc { get; set; } = false;

        /// <summary>
        ///     A bool telling if the user just joined
        /// </summary>
        public bool join { get; set; } = false;

        /// <summary>
        ///     JSON options settings
        /// </summary>
        private readonly JsonSerializerOptions options = new()
        {
            WriteIndented = false,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        /// <summary>
        ///     A default constructor for JSON 
        /// </summary>
        public Snakes()
        {
            snake = 0;
            name = string.Empty;
            body = [];
            dir = new(1, 0);
            score = 0;
            died = false;
            alive = true;
            dc = false;
            join = false;
        }

        /// <summary>
        ///     Constructor for a snake object
        /// </summary>
        /// <param name="snake"> The snake's ID </param>
        /// <param name="name"> The snake's username </param>
        /// <param name="body"> The shape of the snake </param>
        /// <param name="dir"> The orientation of the snake </param>
        public Snakes(int snake, string name, List<Point2D> body, Point2D dir)
        {
            this.snake = snake;
            this.name = name;
            this.body = body;
            this.dir = dir;
        }

        /// <summary>
        ///     Returns the JSON stringform of the snake
        /// </summary>
        public string GetJson()
        {
            return JsonSerializer.Serialize(this, options);
        }

        /// <summary>
        ///     Updates the snake's data with a given JSON string
        /// </summary>
        public void UpdateJson(string json)
        {
            Snakes? newSnake = JsonSerializer.Deserialize<Snakes>(json, options);

            if (newSnake is not null)
            {
                this.snake = newSnake.snake;
                this.name = newSnake.name;
                this.body = newSnake.body;
                this.dir = newSnake.dir;
                this.score = newSnake.score;
                this.died = newSnake.died;
                this.alive = newSnake.alive;
                this.dc = newSnake.dc;
                this.join = newSnake.join;
            }
        }
    }
}
