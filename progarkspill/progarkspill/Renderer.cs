﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace progarkspill
{
    public class Renderer
    {
        public Renderer(GraphicsDeviceManager gdm)
        {
            this.gdm = gdm;
            Vector2 screensize = new Vector2(gdm.PreferredBackBufferWidth, gdm.PreferredBackBufferHeight);
            screenspace = new Viewport(Vector2.Zero, screensize);
            sb = new SpriteBatch(gdm.GraphicsDevice);
        }

        public void preRender()
        {
            gdm.GraphicsDevice.Clear(Color.CornflowerBlue);
        }

        /*
         * Sets the current Viewport, which will affect all renerMe() calls until a following end().
         * Viewports are mappings from a game-specific space to screen-space.
         */
        public void begin(Viewport view)
        {
            currentspace = view;
        }

        public void renderMe(IRenderable entity)
        {
            Vector2 render_position = currentspace.mapTo(entity.getPosition(), screenspace);
            Vector2 scale = currentspace.scaleTo(screenspace);

            sb.Begin();
            sb.Draw(entity.getTexture(), render_position, null, Color.White, 0.0f, Vector2.Zero, scale, SpriteEffects.None, 0.0f);
            sb.End();
        }

        private GraphicsDeviceManager gdm;
        private Viewport screenspace;
        private Viewport currentspace;
        private SpriteBatch sb;
    }
}
