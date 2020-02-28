using System.Drawing;
using Cosmos.System.Graphics;

namespace GOS
{
    class Sprites
    {
        Canvas canvas;

        public void canvasSetup()
        {
            canvas = FullScreenCanvas.GetFullScreenCanvas();
            canvas.Clear(Color.White);
        }

        public void DrawSprite()
        {
            //Pacman sprite
            Pen pacpen = new Pen(Color.Gold);
            canvas.DrawPoint(pacpen, 54, 31);
            canvas.DrawPoint(pacpen, 55, 31);
            canvas.DrawPoint(pacpen, 56, 31);
            canvas.DrawPoint(pacpen, 57, 31);
            //
            canvas.DrawPoint(pacpen, 52, 32);
            canvas.DrawPoint(pacpen, 53, 32);
            canvas.DrawPoint(pacpen, 54, 32);
            canvas.DrawPoint(pacpen, 55, 32);
            canvas.DrawPoint(pacpen, 56, 32);
            canvas.DrawPoint(pacpen, 57, 32);
            canvas.DrawPoint(pacpen, 58, 32);
            canvas.DrawPoint(pacpen, 59, 32);
            //
            canvas.DrawPoint(pacpen, 51, 33);
            canvas.DrawPoint(pacpen, 52, 33);
            canvas.DrawPoint(pacpen, 53, 33);
            canvas.DrawPoint(pacpen, 54, 33);
            canvas.DrawPoint(pacpen, 55, 33);
            canvas.DrawPoint(pacpen, 56, 33);
            canvas.DrawPoint(pacpen, 57, 33);
            canvas.DrawPoint(pacpen, 58, 33);
            canvas.DrawPoint(pacpen, 59, 33);
            canvas.DrawPoint(pacpen, 60, 33);
            //
            canvas.DrawPoint(pacpen, 50, 34);
            canvas.DrawPoint(pacpen, 51, 34);
            canvas.DrawPoint(pacpen, 52, 34);
            canvas.DrawPoint(pacpen, 53, 34);
            canvas.DrawPoint(pacpen, 54, 34);
            canvas.DrawPoint(pacpen, 55, 34);
            canvas.DrawPoint(pacpen, 56, 34);
            canvas.DrawPoint(pacpen, 57, 34);
            canvas.DrawPoint(pacpen, 58, 34);
            canvas.DrawPoint(pacpen, 59, 34);
            canvas.DrawPoint(pacpen, 60, 34);
            //
            canvas.DrawPoint(pacpen, 50, 35);
            canvas.DrawPoint(pacpen, 51, 35);
            canvas.DrawPoint(pacpen, 52, 35);
            canvas.DrawPoint(pacpen, 53, 35);
            canvas.DrawPoint(pacpen, 54, 35);
            canvas.DrawPoint(pacpen, 55, 35);
            canvas.DrawPoint(pacpen, 56, 35);
            //
            canvas.DrawPoint(pacpen, 50, 36);
            canvas.DrawPoint(pacpen, 51, 36);
            canvas.DrawPoint(pacpen, 52, 36);
            canvas.DrawPoint(pacpen, 53, 36);
            canvas.DrawPoint(pacpen, 54, 36);
            //
            canvas.DrawPoint(pacpen, 50, 37);
            canvas.DrawPoint(pacpen, 51, 37);
            canvas.DrawPoint(pacpen, 52, 37);
            canvas.DrawPoint(pacpen, 53, 37);
            canvas.DrawPoint(pacpen, 54, 37);
            canvas.DrawPoint(pacpen, 55, 37);
            canvas.DrawPoint(pacpen, 56, 37);
            //
            canvas.DrawPoint(pacpen, 50, 38);
            canvas.DrawPoint(pacpen, 51, 38);
            canvas.DrawPoint(pacpen, 52, 38);
            canvas.DrawPoint(pacpen, 53, 38);
            canvas.DrawPoint(pacpen, 54, 38);
            canvas.DrawPoint(pacpen, 55, 38);
            canvas.DrawPoint(pacpen, 56, 38);
            canvas.DrawPoint(pacpen, 57, 38);
            canvas.DrawPoint(pacpen, 58, 38);
            canvas.DrawPoint(pacpen, 59, 38);
            canvas.DrawPoint(pacpen, 60, 38);
            //
            canvas.DrawPoint(pacpen, 51, 39);
            canvas.DrawPoint(pacpen, 52, 39);
            canvas.DrawPoint(pacpen, 53, 39);
            canvas.DrawPoint(pacpen, 54, 39);
            canvas.DrawPoint(pacpen, 55, 39);
            canvas.DrawPoint(pacpen, 56, 39);
            canvas.DrawPoint(pacpen, 57, 39);
            canvas.DrawPoint(pacpen, 58, 39);
            canvas.DrawPoint(pacpen, 59, 39);
            canvas.DrawPoint(pacpen, 60, 39);
            //
            canvas.DrawPoint(pacpen, 52, 40);
            canvas.DrawPoint(pacpen, 53, 40);
            canvas.DrawPoint(pacpen, 54, 40);
            canvas.DrawPoint(pacpen, 55, 40);
            canvas.DrawPoint(pacpen, 56, 40);
            canvas.DrawPoint(pacpen, 57, 40);
            canvas.DrawPoint(pacpen, 58, 40);
            canvas.DrawPoint(pacpen, 59, 40);
            //
            canvas.DrawPoint(pacpen, 54, 41);
            canvas.DrawPoint(pacpen, 55, 41);
            canvas.DrawPoint(pacpen, 56, 41);
            canvas.DrawPoint(pacpen, 57, 41);
        }
    }
}
