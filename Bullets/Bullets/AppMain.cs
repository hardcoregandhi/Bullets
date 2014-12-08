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
	public class AppMain
	{
		private static Sce.PlayStation.HighLevel.GameEngine2D.Scene 	gameScene;
		private static Sce.PlayStation.HighLevel.UI.Scene				uiScene;
		private static Sce.PlayStation.HighLevel.UI.Label				scoreLabel;
		private static Obstacle[]	obstacles;
		public static Player 		player;
		public static Enemy 		enemy;
		private static Background 	background;
		public static List<Projectile>		proj;
		//Possible future implementation
		//private static Powerup 		powerup;
		
		public static void Main (string[] args)
		{
			Initialize ();
			
			//Game Loop
			bool quitGame = false;
			while (!quitGame) {				
				Director.Instance.Update ();
				Director.Instance.Render ();
				UISystem.Render ();
				
				Update ();
				Director.Instance.GL.Context.SwapBuffers ();
				Director.Instance.PostSwap ();

			}
		}

		public static void Initialize ()
		{
			//Set up director and UISystem
			Director.Initialize ();
			UISystem.Initialize (Director.Instance.GL.Context);
			
			//Set game scene
			gameScene = new Sce.PlayStation.HighLevel.GameEngine2D.Scene ();
			gameScene.Camera.SetViewFromViewport ();
			
			//Create background
			background = new Background (gameScene);
			
			//Set the ui Scene
			uiScene = new Sce.PlayStation.HighLevel.UI.Scene ();
			
			//Score implementation goes here (Milestone 2)
			
	
			player = new Player (gameScene);
			
			enemy = new Enemy (gameScene);
			
			proj = new List<Projectile> ();
			
			//Run the scene.
			Director.Instance.RunWithScene (gameScene, true);
		}

		public static void Update ()
		{	
			
			//Determine whether the player tapped the screen
			var touches = Touch.GetData (0);
			
			//If tapped, inform the player.
			if (touches.Count > 0) 
			{
				float newX = (touches [0].X + 0.5f) * 960 - 5;
				float newY = 544 - (touches [0].Y + 0.5f) * 544 - 10;
				
				Player.sprite.Position = new Vector2 (newX, newY);
				
			}
			
			var buttons = GamePad.GetData (0);
			
			
			//DEBUGGING PURPOSES
			if (buttons.Buttons != 0) {
				if ((buttons.Buttons & GamePadButtons.Cross) != 0) 
				{
					Projectile test = new Projectile();
					proj.Add(test);
				}
			}
			//END
			
			
			//Update the player.
			Player.Update ();
			
			//Update the Enemy
			Enemy.Update ();
			
			//Update Projectiles
			for (int i = proj.Count; i>0; i--) 
			{
				proj[i].pSprite.Position = proj [i].pSprite.Position + Projectile.pVelocity;
				
				if ((proj[i].pSprite.Position.X > Director.Instance.GL.Context.GetViewport().Width) || 
					(proj[i].pSprite.Position.X < -0.5) ||
				    (proj[i].pSprite.Position.Y > Director.Instance.GL.Context.GetViewport().Height) ||
				    (proj[i].pSprite.Position.Y < -0.5))		
				{
					proj[i].Delete();
				}
			}
		}
	}
}
