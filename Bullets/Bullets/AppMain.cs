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
		public static Sce.PlayStation.HighLevel.GameEngine2D.Scene 	gameScene;
		private static Sce.PlayStation.HighLevel.UI.Scene				uiScene;
		private static Sce.PlayStation.HighLevel.UI.Label				scoreLabel;
		private static Obstacle[]	obstacles;
		public static Player 		player;
		public static Enemy 		enemy;
		private static Background 	background;
		public static List<Projectile>		proj;
		public static Projectile testProjectile;
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
			
//			Vector2 testPos = new Vector2(500f, Director.Instance.GL.Context.GetViewport().Height*0.5f);
//			testProjectile = new Projectile(gameScene, testPos);
			
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
					//Vector2 testPos = new Vector2(500f, Director.Instance.GL.Context.GetViewport().Height*0.5f);
					//testProjectile = new Projectile(testPos);
					

	                Projectile test = new Projectile(enemy.sprite.Position);
					
					proj.Add(test);
				}
			}
			//END
			
			
			//Update the player.
			Player.Update ();
			
			//Update the Enemy
			Enemy.Update ();
			
			//Update Projectiles
			for (int i =0; i<proj.Count; i++) 
			{
				//proj[i].pSprite.Position = proj [i].pSprite.Position + Projectile.pVelocity;
				
				//proj[i].pSprite.Position
				//Player.sprite.Position
				
				proj[i].pSprite.Position += proj[i].direction * Projectile.pVelocity;
				
				int tuaystd = Director.Instance.GL.Context.GetViewport().Width;
				
				// if(proj[i] is off screen, delete
				if ((proj[i].pSprite.Position.X > Director.Instance.GL.Context.GetViewport().Width) || 
					(proj[i].pSprite.Position.X < 0) ||
				    (proj[i].pSprite.Position.Y > Director.Instance.GL.Context.GetViewport().Height) ||
				    (proj[i].pSprite.Position.Y < 0))		
				{
					proj.Remove(proj[i]);
					
				}
				
				//TrackPlayer(); 
			}
		}
//		public static void TrackPlayer()
//		{
//			float xDiff = (Player.sprite.X + (Player.sprite.Quad.S.X/2)) - (sprite().Position.X + (player().Quad.S.X/2));			
		
//			float yDiff = (sprite.Position.Y + (sprite.Quad.S.Y/2)) - (sprite().Position.Y + (sprite().Quad.S.Y/2));
//		
//			if(!(xDiff == 0 || yDiff == 0))
//			{
//				if(yDiff > 0)
//				{					
//					float angle = FMath.PI - FMath.Atan(xDiff/yDiff);				
//				 	Move(-3.0f * FMath.Sin(angle), -3.0f * -FMath.Cos(angle));			
//				}
//				else
//				{
//					float angle = FMath.Atan(xDiff/-yDiff);				
//				 	Move(-3.0f * FMath.Sin(angle), -3.0f * -FMath.Cos(angle));	
//				}	
//				Rotate(-xDiff, -yDiff);			
//			}		
//		}
	}
}
