// <authors> Elijah Potter and William Ngo </authors>
// <date> whatever </date>

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
        public int snake { get; private set; }

        /// <summary>
        ///     The username of the snake
        /// </summary>
        public string name { get; private set; }

        /// <summary>
        ///     A list of points representing the shape
        ///     and position of the snake
        /// </summary>
        public List<Point2D> body { get; private set; }

        /// <summary>
        ///     The orientation of the snake as a
        ///     2D vector
        /// </summary>
        public Point2D dir { get; private set; }

        /// <summary>
        ///     The number of powerups eaten
        /// </summary>
        public int score { get; private set; } = 0;

        /// <summary>
        ///     A bool telling if the snake is dead
        /// </summary>
        public bool died { get; private set; } = false;

        /// <summary>
        ///     A bool telling if the snake is alive
        /// </summary>
        public bool alive { get; private set; } = true;

        /// <summary>
        ///     A bool telling if the user disconnected
        /// </summary>
        public bool dc { get; private set; } = false;

        /// <summary>
        ///     A bool telling if the user just joined
        /// </summary>
        public bool join { get; private set; } = false;

        /// <summary>
        ///     JSON options settings
        /// </summary>
        private readonly JsonSerializerOptions options = new()
        {
            WriteIndented = true,
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
            join = true;
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
           // What to actually update:
           // body, dir, score, died, alive, dc, join

            // wtf
            this = JsonSerializer.Deserialize<Snakes>(json, options);
        }
    }
}
