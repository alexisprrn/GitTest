using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTest2.Models
{
    class Animation
    {
        #region Fields

        public Texture2D Texture;

        public int FrameCount;

        public int CurrentFrame;

        public float FrameSpeed;

        public bool AutoFinish;

        #endregion

        #region Properties

        public int FrameWidth
        {
            get
            {
                return (Texture.Width / FrameCount);
            }
        }

        public int FrameHeight
        {
            get
            {
                return (Texture.Height);
            }
        }

        #endregion

        #region Constructor

        public Animation(Texture2D texture, int frameCount, float frameSpeed, bool autoFinish)
        {
            Texture = texture;

            FrameCount = frameCount;

            FrameSpeed = frameSpeed;

            AutoFinish = autoFinish;
        }

        #endregion

        #region Methods

        //none

        #endregion
    }
}
