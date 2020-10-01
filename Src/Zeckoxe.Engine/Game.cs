﻿using System;
using Zeckoxe.Desktop;
using Zeckoxe.Games;
using Zeckoxe.Graphics;

namespace Zeckoxe.Engine
{
    public class Game : GameBase
    {
        public Game() : base()
        {
            Window = new Window("Zeckoxe Engine", 1200, 800)
            {
                //StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen,
            };


            Parameters = new PresentationParameters()
            {
                BackBufferWidth = Window.Width,
                BackBufferHeight = Window.Height,
                Win32Handle = Window.Win32Handle,
                Settings = new Settings()
                {
                    Validation = true,
                    Fullscreen = false,
                    VSync = false,
                },
            };

        }
        public PresentationParameters Parameters { get; set; }

        public GraphicsAdapter Adapter { get; set; }

        public GraphicsDevice? Device { get; set; }

        public Framebuffer Framebuffer { get; set; }

        public GraphicsContext Context { get; set; }

        public Window? Window { get; set; }


        public override void Initialize()
        {
            base.Initialize();

            Adapter = new GraphicsAdapter(Parameters);

            Device = new GraphicsDevice(Adapter);

            Framebuffer = new Framebuffer(Device);

            Context = new GraphicsContext(Device);
        }

        public override void BeginRun()
        {
            base.BeginRun();

            Window?.Show();


            Window.RenderLoop(() =>
            {
                OnTickRequested();
            });
        }

        public override void BeginDraw()
        {
            Device.WaitIdle();
            Context.CommandBuffer.Begin();


            base.BeginDraw();
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }


        public override void EndDraw()
        {
            base.EndDraw();


            Context.CommandBuffer.Close();
            Context.CommandBuffer.Submit();

            Device.NativeSwapChain.Present();
        }

        public override void EndRun()
        {
            base.EndRun();

            if (Window != null)
            {
                //Window.Dispose();
            }
        }

        public override void ConfigureServices()
        {

        }

        internal void OnTickRequested()
        {
            Tick();
        }
    }
}
