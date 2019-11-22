using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace World_Editor
{
    public class Transform
    {
        #region Fields
        private Vector2 position = new Vector2(0, 0);
        private Vector2 origin = new Vector2(0, 0);
        private Vector2 scale = new Vector2(1, 1);
        private float rotation = 0;
        #endregion

        #region Properties
        public Vector2 Position { get { return position; } set { position = value; } }
        public Vector2 Origin { get { return origin; } set { origin = value; } }
        public Vector2 Scale { get { return scale; } set { scale = value; } }
        public float Rotation { get { return rotation; } set { rotation = value; } }
        #endregion
    }
}
