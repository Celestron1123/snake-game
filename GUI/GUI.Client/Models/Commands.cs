// <authors> Elijah Potter and William Ngo </authors>
// <date> 11/13/2024 </date>

using System.Text.Encodings.Web;
using System.Text.Json;

namespace GUI.Client.Models
{
    /// <summary>
    ///     A class to represent commands to the server
    /// </summary>
    public class Commands
    {
        /// <summary>
        ///     The direction the snake is going
        /// </summary>
        public string moving { get; set; }

        /// <summary>
        ///     JSON options settings
        /// </summary>
        private readonly JsonSerializerOptions options = new()
        {
            WriteIndented = false,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        /// <summary>
        ///     Default constructor for a movement
        /// </summary>
        public Commands()
        {
            moving = "none";
        }

        /// <summary>
        ///     Constructor for a movement
        /// </summary>
        /// <param name="moving"> The direction of the movement </param>
        public Commands(string moving)
        {
            this.moving = moving;
        }

        /// <summary>
        ///     Returns the JSON stringform of the command
        /// </summary>
        public string GetJson()
        {
            return JsonSerializer.Serialize(this, options);
        }

        /// <summary>
        ///     Updates the command's data with a given JSON string
        /// </summary>
        public void UpdateJson(string json)
        {
            Commands? newCommand = JsonSerializer.Deserialize<Commands>(json, options);

            if (newCommand is not null)
            {
                this.moving = newCommand.moving;
            }
        }
    }
}
