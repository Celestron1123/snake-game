using GUI.Client.Models;
using System.Text.RegularExpressions;

namespace ModelTests
{
    [TestClass]
    public class SnakeTests
    {
        [TestMethod]
        public void SnakeConstructor_BasicInputs_Pass()
        {
            List<Point2D> body = [new Point2D(0, 0), new Point2D(10, 0)];
            Snakes snake = new(2, "Giardia", body, new Point2D(1, 0));

            Assert.AreEqual("{'snake':2,'name':'Giardia','body':[{'X':0,'Y':0},{'X':10,'Y':0}],'dir':{'X':1,'Y':0},'score':0,'died':false,'alive':true,'dc':false,'join':false}", Regex.Replace(snake.GetJson(), @"[\r\n\s\\]", "").Replace("\"", "'"));
        }

        [TestMethod]
        public void UpdateJson_BasicInputs_Pass()
        {
            List<Point2D> body = [new Point2D(0, 0), new Point2D(10, 0)];
            List<Point2D> body2 = [new Point2D(-21, 7), new Point2D(5, 8), new Point2D(32, 9)];

            Snakes snake = new(2, "Giardia", body, new Point2D(1, 0));
            Snakes snake2 = new(3, "Bingus", body2, new Point2D(-1, 0));

            string json = snake.GetJson();

            snake2.UpdateJson(json);

            Assert.AreEqual("{'snake':2,'name':'Giardia','body':[{'X':0,'Y':0},{'X':10,'Y':0}],'dir':{'X':1,'Y':0},'score':0,'died':false,'alive':true,'dc':false,'join':false}", Regex.Replace(snake2.GetJson(), @"[\r\n\s\\]", "").Replace("\"", "'"));
        }
    }
}