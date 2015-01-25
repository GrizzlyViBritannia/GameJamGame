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
        int wordAlpha = 0;
        int playingState = 0;

        int walkingState = 1;

        public Ending(Texture2D PlayerTexture)
        {
            player = PlayerTexture;
        }

        public void logic()
        {
            tick++;
            if (tick > 300)
            {
                wordAlpha -= 7;
            }
            else
            {
                wordAlpha += 3;
            }
            if (wordAlpha > 255)
            {
                wordAlpha = 255;
            }
            if (tick > 350)
            {
                playingState++;
                tick = 0;                
            }

            if (playingState == 0)
            {

                walkingState = 1;
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
                walkingState = 0;
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
                walkingState = 1;
            }
            else if (playingState == 3)
            {
                walkingState = 0;
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
                    61 * walkingState,
                    38,
                    61),
                Color.White);


            Color color = Color.White;
            color.A = (byte)spotLightAlpha;
            SB.Draw(Game1.spotLight, new Rectangle((int)playerPos.X - 1180, 0, 2280, 720), color);

            if (playingState == 0 && tick < 300)
            {
                SB.Draw(Game1.text1, new Rectangle(800, 300, Game1.text1.Width, Game1.text1.Height), Color.White);
                
            }
            else if (playingState == 1 && tick < 300)
            {
                SB.Draw(Game1.text2, new Rectangle(800, 300, Game1.text2.Width, Game1.text2.Height), Color.White);
            }
            else if (playingState == 2 && tick < 300)
            {
                SB.Draw(Game1.text3, new Rectangle(0, 300, Game1.text3.Width, Game1.text3.Height), Color.White);
            }
            else if (playingState == 3 && tick > 100)
            {
                SB.Draw(Game1.text4, new Rectangle(0, 0, Game1.text4.Width, Game1.text4.Height), Color.White);
            }
        }
        

    }
}
