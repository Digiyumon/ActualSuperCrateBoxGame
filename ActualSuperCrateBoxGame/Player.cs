using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActualSuperCrateBoxGame
{
    internal class Player
    {
        private static Texture2D _texture;
        private Vector2 _position;
        private readonly Animation _anim;

        public Player(Vector2 pos)
        {
            _texture ??= Globals.Content.Load<Texture2D>("temporary character");
            _anim = new(_texture, 2, 0.1f);
            _position = pos;
        }

        public void Update()
        {
            _anim.Update();
        }

        public void Draw()
        {
            _anim.Draw(_position);
        }
    }
}
