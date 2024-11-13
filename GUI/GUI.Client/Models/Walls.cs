// <authors> Elijah Potter and William Ngo </authors>
// <date> 11/13/2024 </date>

using System.Text.Encodings.Web;
using System.Text.Json;

namespace GUI.Client.Models
{
    /// <summary>
    ///     Represents wall objects in the game
    /// </summary>
    public class Walls
    {
        /// <summary>
        ///     An int representing the wall's ID
        /// </summary>
        public int wall { get; set; }

        /// <summary>
        ///     A point representing one endpoint of the wall
        /// </summary>
        public Point2D p1 { get; set; }

        /// <summary>
        ///     A point representing one endpoint of the wall
        /// </summary>
        public Point2D p2 { get; set; }

        /// <summary>
        ///     JSON options settings
        /// </summary>
        private readonly JsonSerializerOptions options = new()
        {
            WriteIndented = false,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        /// <summary>
        ///     Default constructor for a wall
        /// </summary>
        public Walls()
        {
            wall = 0;
            p1 = new(0, 0);
            p2 = new(0, 0);
        }

        /// <summary>
        ///     Wall constructor
        /// </summary>
        /// <param name="wall"> The wall's ID </param>
        /// <param name="p1"> An endpoint of the wall </param>
        /// <param name="p2"> An endpoint of the wall </param>
        public Walls(int wall, Point2D p1, Point2D p2)
        {
            this.wall = wall;
            this.p1 = p1;
            this.p2 = p2;
        }

        /// <summary>
        ///     Returns the JSON stringform of the wall
        /// </summary>
        public string GetJson()
        {
            return JsonSerializer.Serialize(this, options);
        }

        /// <summary>
        ///     Updates the wall's data with a given JSON string
        /// </summary>
        public void UpdateJson(string json)
        {
            Walls? newWall = JsonSerializer.Deserialize<Walls>(json, options);

            if (newWall is not null)
            {
                this.wall = newWall.wall;
                this.p1 = newWall.p1;
                this.p2 = newWall.p2;
            }
        }
    }
}
