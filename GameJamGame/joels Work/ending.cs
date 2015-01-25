using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace GameJamGame.joels_Work
{
    class Ending
    {
        int tick = 0;
        int animationTick = 0;

        bool walking = true;

        int BGTick = 0;
        Texture2D player;
        Vector2 playerPos = new Vector2(50,600);

        int spotLightAlpha = 255;

        int playingState = 0;

        int state = 1;

        public Ending(Texture2D PlayerTexture)
        {
            player = PlayerTexture;
        }

        public void logic()
        {
            tick++;
            if (tick > 350)
            {
                playingState++;
                tick = 0;
            }
            if (playingState == 0)
            {

                state = 1;
                playerPos.X += 1;
                if (tick % 7 == 0)
                {
                    animationTick++;
                    if (animationTick > 2)
                        animationTick = 0;
                    BGTick++;
                }
            }
            else if (playingState == 1)
            {
                state = 0;
            }
            else if (playingState == 2)
            {
                playerPos.X += 1;
                if (tick % 7 == 0)
                {
                    animationTick++;
                    if (animationTick > 2)
                        animationTick = 0;
                    BGTick++;
                }
                state = 1;
            }
            else if (playingState == 3)
            {
                state = 0;
            }
            if (playingState >= 3 && spotLightAlpha > 5 && tick > 50)
            {
                spotLightAlpha -= 3;
            }
        }

        public void draw(SpriteBatch SB)
        {
            SB.Draw(Game1.endingScreen, new Rectangle(0, 0, 1280, 720), Color.White);

            SB.Draw(
                this.player,
                new Rectangle(
                    (int)playerPos.X,
                    (int)playerPos.Y,
                    (int)(38*1.5f),
                    (int)(61*1.5f)),
                //new Vector2(38, 61),
                new Rectangle(
                    this.animationTick * 38,
                    61 * state,
                    38,
                    61),
                Color.White);


            Color color = Color.White;
            color.A = (byte)spotLightAlpha;
            SB.Draw(Game1.spotLight, new Rectangle((int)playerPos.X - 1180, 0, 2280, 720), color);
        }
    }
}
