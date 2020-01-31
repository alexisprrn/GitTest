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
using Microsoft.Xna.Framework.Input;

namespace GameTest2.Entities
{
    class Player
    {
        #region Fields

        private Vector2 _position;

        public Vector2 Velocity;

        public float FixedPositionX;

        public AnimationManager AnimationManager;

        public Dictionary<string, Animation> AnimationList;

        public Background Background;

        public List<Terrain> TerrainList;

        public bool NoKeyPressed;

        #region CharacterProperties

        public float Speed;

        public float Weight;

        public Input Input;

        public float Jumpheight;

        public bool IsFacingLeft;

        public bool Running;

        public enum Action
        {
            Moving,
            Jumping,
            Attacking,
            Falling,
            Nothing,
        }

        public Action action;

        public int AttackNum;

        #endregion

        #endregion

        #region Properties

        public Texture2D Texture
        {
            get { return AnimationManager.Animation.Texture; }
        }

        public Rectangle HitBox
        {
            get {
                return new Rectangle(
              (int)Position.X,
              (int)Position.Y,
              AnimationManager.Animation.FrameWidth,
              AnimationManager.Animation.FrameHeight);
            }
        }

        public Vector2 Position
        {
            get {
                return _position;
            }
            set
            {
                if (AnimationManager != null)
                {
                    AnimationManager.Position = value;
                }
                _position = value;
            }
        }

        #endregion

        #region Constructor

        public Player(Dictionary<string,Animation> animationList, Vector2 position)
        {
            AnimationList = animationList;

            Position = position;

            AnimationManager = new AnimationManager(AnimationList.First().Value);
        }

        #endregion

        #region Methods

        public void CheckAction()
        {
            if (Keyboard.GetState().IsKeyDown(Input.Jump))
            {

            }
            else if (Keyboard.GetState().IsKeyDown(Input.Left))
            {
                if(Keyboard.GetState().IsKeyDown(Input.Jump))
                if(Keyboard.GetState().IsKeyDown(Input.Jump))
                if(Keyboard.GetState().IsKeyDown(Input.Jump))
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            AnimationManager.Draw(spriteBatch);
        }

        public void GetKeyboardState()
        {

        }

        public void Move()
        {
            if (Keyboard.GetState().IsKeyDown(Input.Left))
            {
                Velocity.X -= Speed;
            }
            else if (Keyboard.GetState().IsKeyDown(Input.Right))
            {
                Velocity.X += Speed;
            }
        }

        public void Update(GameTime gameTime)
        {
            GetKeyboardState();
            Move();

            SetAnimation();

            AnimationManager.Update(gameTime);


            Position += Velocity;
            Velocity = Vector2.Zero;
        }

        public void SetAnimation()
        {

        }



        #endregion
    }
}
