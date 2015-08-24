using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hero;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SwordSlayerREWork
{
    public class Camera
    {
        protected float _zoom; //Camera Zoom Value
        protected Matrix _transform; //Camera Transform Matrix
        protected Matrix _inverseTransform; //Inverse of Transform Matrix
        public Vector2 _pos; //Camera Position
        protected float _rotation; //Camera Rotation Value (Radians)
       public  Viewport _viewport; //Cameras Viewport
        protected MouseState _mState; //Mouse state
        protected KeyboardState _keyState; //Keyboard state
        protected Int32 _scroll; //Previous Mouse Scroll Wheel Value
        public bool isInGame=false;
        public bool isTransitioning;
        //	protected const speed=;
        public float Zoom
        {
            get { return _zoom; }
            set { _zoom = value; }
        }
        /// <summary>
        /// Camera View Matrix Property
        /// </summary>
        public Matrix Transform
        {
            get { return _transform; }
            set { _transform = value; }
        }
        /// <summary>
        /// Inverse of the view matrix, can be used to get objects screen coordinates
        /// from its object coordinates
        /// </summary>
        public Matrix InverseTransform
        {
            get { return _inverseTransform; }
        }
        public Vector2 Pos
        {
            get { return _pos; }
            set { _pos = value; }
        }
        public Camera(Viewport viewport)
        {
            _zoom = Global.zoom;
            _scroll = 1;
            _rotation = 0.0f;
            _pos = new Vector2(0, 0);
            _viewport = viewport;
        }
        public Rectangle recCamera()
        {
            return new Rectangle((int)_posto.X, (int)_posto.Y,256 , 176);
        }
        bool active;
        public bool wait;
        public void UpdateView(WorldScreen screen)
        {
            if (active == false)
            {
                _pos = screen.currentlay.position;
                _posto = _pos;
                active = true;
            }
            else
            {
                if (isTransitioning)
                {
                    _posto = screen.currentlay.position;
                    oldpos = _pos;
                    wait = false;
                }
            }
        }
        Vector2 oldpos;
        public void Update(  GameTime time)
        {
           if(_posto.X> _pos.X)
           {
               _pos.X += 8;
           }
           else if (_posto.X < _pos.X)
           {
               _pos.X -=  8;
           }
          else if (_posto.Y < _pos.Y)
           {
               _pos.Y-=8;
           }
           else if (_posto.Y > _pos.Y)
           {
               _pos.Y+=8;
           }
       if(_pos==_posto)
               if (wait == false)
               {
                   isTransitioning = false;             
               }
           
               if (isInGame)
            {
                _transform = Matrix.CreateRotationZ(_rotation) *
                    Matrix.CreateScale(new Vector3(_zoom, _zoom, 1)) *
                    Matrix.CreateTranslation((((int)-_pos.X)) * Global.zoom, ((int)-_pos.Y + 64) * Global.zoom, 0) *
                    Matrix.CreateTranslation(new Vector3(_viewport.X * 0.5f, _viewport.Y * 0.5f, 0));
            }
            else
            {
                _transform = Matrix.CreateRotationZ(_rotation) *
                    Matrix.CreateScale(new Vector3(_zoom, _zoom, 1)) *
                    Matrix.CreateTranslation((((int)-_pos.X)) * Global.zoom, ((int)-_pos.Y ) * Global.zoom, 0) *
                    Matrix.CreateTranslation(new Vector3(_viewport.X * 0.5f, _viewport.Y * 0.5f, 0));
            }
        }


        public Vector2 _posto { get; set; }
    }

}