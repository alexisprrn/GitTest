using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameTest2.Globals;
using GameTest2.Managers;
using GameTest2.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameTest2.Managers
{
    class AnimationManager
    {
        #region Fields

        public Animation Animation;

        public Animation DefaultAnimation;

        public float Timer;

        #endregion

        #region Properties

        public Vector2 Position { private get; set; }

        #endregion

        #region Constructor

        public AnimationManager(Animation animation)
        {
            Animation = animation;

            DefaultAnimation = animation;
        }

        #endregion

        #region Methods

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                Animation.Texture,
                Position,
                new Rectangle(Animation.CurrentFrame * Animation.FrameWidth,
                0,
                Animation.FrameWidth,
                Animation.FrameHeight),
                Color.White);
        }

        public void Play(Animation animation)
        {
            if (Animation == animation)
                return;
            else
                Animation = animation;

            Animation.CurrentFrame = 0;

            Timer = 0;

        }

        public void Update(GameTime gameTime)
        {
            Timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (Timer >= Animation.FrameSpeed)
            {
                Animation.CurrentFrame++;
                Timer = 0;
            }

            if (Animation.CurrentFrame >= Animation.FrameCount)
            {
                if (!Animation.AutoFinish)
                {
                    Animation.CurrentFrame = 0;
                    Timer = 0;
                }
            }
        }

        public void Restart()
        {
            Animation.CurrentFrame = 0;

            Timer = 0;
        }

        public void Stop()
        {
            Play(DefaultAnimation);

            Timer = 0;
        }

        #endregion
    }
}
