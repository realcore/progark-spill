﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace progarkspill
{
    interface IGameState
    {
        public void render(Renderer r);
        
        public void tick(GameTime timedelta);
    }
}