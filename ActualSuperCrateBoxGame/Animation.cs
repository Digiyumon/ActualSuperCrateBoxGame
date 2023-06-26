using Microsoft.Xna.Framework.Graphics;
using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActualSuperCrateBoxGame
{
    internal class Animation
    {
        private readonly Texture2D _texture;
        private readonly List<Rectangle> _sourceRectangles = new();
        private readonly int _frames;
        private int _frame;
        private readonly float _frameTime;
        private float _frameTimeLeft;
        private bool _active = true;

        public Animation(Texture2D texture, int frames, float frameTime)
        {
            _texture = texture;
            _frames = frames;
            _frameTime = frameTime;
            _frameTimeLeft = frameTime;
            var frameWidth = _texture.Width / frames;
            var frameHeight = _texture.Height;

            for (int i = 0; i < _frames; i++)
            {
                _sourceRectangles.Add(new(i * frameWidth, 0, frameWidth, frameHeight));
            }
        }

        //this stops the animation
        public void Stop()
        {
            _active = false;
        }
        //this starts the animation back up again
        public void Start()
        {
            _active = true;
        }
        //this resets the animation by setting it back to zero
        public void Reset()
        {
            _frame = 0;
            _frameTimeLeft = _frameTime;
        }

        //this is going to update which frame that we are showing 
        public void Update()
        {
            if (!_active) return;

            _frameTimeLeft -= Globals.TotalSeconds;

            if(_frameTimeLeft <= 0)
            {
                _frameTimeLeft += _frameTime;
                _frame = (_frame + 1) % _frames;
            }
        }

        //this draws the frame at the pos given as the parameter
        public void Draw(Vector2 pos)
        {
            Globals.SpriteBatch.Draw(_texture, pos, _sourceRectangles[_frame], Color.White, 0, Vector2.Zero, Vector2.One, SpriteEffects.None, 1);
        }
    }
}
