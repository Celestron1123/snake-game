// < authors > Elijah Potter and William Ngo </authors>
// <date> whatever </date>

namespace GUI.Client.Models
{
    /// <summary>
    ///     A class to represent a point in 2D space
    /// </summary>
    public class Point2D
    {
        /// <summary>
        ///     The x coordinate
        /// </summary>
        public int X { get; private set; }

        /// <summary>
        ///     The y coordinate
        /// </summary>
        public int Y { get; private set; }

        /// <summary>
        ///     Creates a new Point2D object
        /// </summary>
        /// <param name="x"> x coord </param>
        /// <param name="y"> y coord </param>
        public Point2D(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
