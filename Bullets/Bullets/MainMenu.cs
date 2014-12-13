using System;
using System.Collections.Generic;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;
using Sce.PlayStation.HighLevel.UI;

namespace Bullets
{
	public class MainMenu : Sce.PlayStation.HighLevel.GameEngine2D.Scene
	{
		public MainMenu ()
		{
			Sce.PlayStation.HighLevel.UI.Panel panel = new Panel();
            panel.Width = Director.Instance.GL.Context.GetViewport().Width;
            panel.Height = Director.Instance.GL.Context.GetViewport().Height;
			
			Button button1 = new Button();
            button1.Name = "btnPlay";
            button1.Text = "Play Game";
            button1.Width = 300;
            button1.Height = 100;
            button1.SetPosition(Director.Instance.GL.Context.GetViewport().Width/2 - 150,Director.Instance.GL.Context.GetViewport().Height/5*2);
            button1.TouchEventReceived += (sender, e) => {Director.Instance.ReplaceScene(AppMain.gameScene);
            };
			
			panel.AddChildLast(button1);
			AppMain._menuScene = new Sce.PlayStation.HighLevel.UI.Scene();
			AppMain._menuScene.RootWidget.AddChildLast(panel);
			UISystem.SetScene(AppMain._menuScene);
			Scheduler.Instance.ScheduleUpdateForTarget(this,0,false);
		}
		public override void Update (float dt)
        {
            base.Update (dt);
            UISystem.Update(Touch.GetData(0));
            
        }
        
        public override void Draw ()
        {
            base.Draw();
            UISystem.Render ();
        }
	}
}

