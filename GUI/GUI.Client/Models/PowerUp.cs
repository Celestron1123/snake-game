//<authors> Elijah Ptter and William Ngo </authors>
//<date> 11/13/2024 </date>

using System.Text.Encodings.Web;
using System.Text.Json;

namespace GUI.Client.Models
{
    public class PowerUp
    {
        
        /// <summary>
        /// This is the id of the powerup.
        /// </summary>
        public int power { get; set; }

        /// <summary>
        /// This is the location of the powerup.
        /// </summary>
        public Point2D loc { get; set; }

        /// <summary>
        /// Boolean that tells if the powerup has been eaten.
        /// </summary>
        public bool died { get; set; }

        /// <summary>
        ///     JSON options settings
        /// </summary>
        private readonly JsonSerializerOptions options = new()
        {
            WriteIndented = false,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        /// <summary>
        /// Default Constructor for Json.
        /// </summary>
        public PowerUp()
        {
            power = 0;
            loc = new Point2D(0,0);
            died = false;
        }

        /// <summary>
        /// Constructor for a power up object.
        /// </summary>
        /// <param name="power"></param>
        /// <param name="loc"></param>
        public PowerUp(int power, Point2D loc)
        {
            this.power = power;
            this.loc = loc;
            died = false;
        }




    }
}
