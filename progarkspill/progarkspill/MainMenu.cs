﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using progarkspill.GameObjects;

namespace progarkspill
{
    class MainMenu : IGameState
    {
        private GameStateStack states;
        private List<Entity> players;
        private List<SharedContent.LevelModel> levelProtos;
        private List<PlayerIndex> controllers;

        public bool tickDown { get { return false; } }
        public bool renderDown { get { return false; } }

        public MainMenu(GameStateStack gamestates, ContentManager Content)
        {
            states = gamestates;
            List<String> levels = Content.Load<List<String>>("Levels/Levels");
            levelProtos = new List<SharedContent.LevelModel>();
            foreach (String name in levels)
                levelProtos.Add(Content.Load<SharedContent.LevelModel>("Levels/" + name));
            
            controllers = new List<PlayerIndex>();
            if (GamePad.GetState(PlayerIndex.One).IsConnected) controllers.Add(PlayerIndex.One);
            if (GamePad.GetState(PlayerIndex.Two).IsConnected) controllers.Add(PlayerIndex.Two);
            if (GamePad.GetState(PlayerIndex.Three).IsConnected) controllers.Add(PlayerIndex.Three);
            if (GamePad.GetState(PlayerIndex.Four).IsConnected) controllers.Add(PlayerIndex.Four);
        }
        public void render(Renderer r) {
            r.beginScreen();
            Vector2 pos = 50 * Vector2.One;
            foreach (PlayerIndex p in controllers)
            {
                r.renderText(String.Format("Player {0} is connected", p), pos, Color.White, false);
            }
            r.end();
        }

        public void tick(float timedelta) {
            if (GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.Start))
                states.push(new GameState(states, levelProtos[0]));
            if (GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.Back))
                states.pop();
        }

    }
}
