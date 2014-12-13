using System;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;
namespace Bullets
{
	public class Blip
	{
		public static SpriteUV		sprite;
		private static TextureInfo	textureInfo;
		public bool 		alive;
		public Bounds2 bounds;
		public Rectangle boundsRect;
		
		//Public functions
		public Blip ()
		{
			textureInfo = new TextureInfo("/Application/textures/blip.png");
			sprite			= new SpriteUV(textureInfo);
			sprite.Quad.S	= textureInfo.TextureSizef;
			bounds = sprite.Quad.Bounds2();
			
					
			Random random = new Random();
				int randomNumberX = random.Next(100, 900);
				int randomNumberY = random.Next(50, 544);
			Vector2 randomLocation = new Vector2(randomNumberX,randomNumberY);
			sprite.Position = randomLocation;
			boundsRect = new Rectangle(sprite.Position.X, sprite.Position.Y, textureInfo.Texture.Width, textureInfo.Texture.Height);
			//Add to the current scene.
			AppMain.gameScene.AddChild(sprite);
		}
		public bool getAlive(){
			return this.alive;
		}
		public void Update()
		{
			// if(projectile is off screen, delete
				if ((sprite.Position.X > Director.Instance.GL.Context.GetViewport().Width - 35) || 
					(sprite.Position.X < 25) ||
					(sprite.Position.Y > Director.Instance.GL.Context.GetViewport().Height - 55) ||
					(sprite.Position.Y < 55))
				{
						this.alive = false;
						AppMain.gameScene.RemoveChild(sprite, true);
				}
			
			
			//
			//READ ON FOR HILARIOUS COLLISION DETECTION FAILURES
			//
			
			//BOUNDS2 ATTEMPT
//			if( Player.sprite.Quad.Bounds2().Overlaps(this.bounds))
//				Console.WriteLine("SUPER HIT");
//			if (Player.sprite.Quad.X == Player.sprite.Quad.Y );
//			{
//				Console.WriteLine("Hit");
//				this.alive = false;
//				AppMain.gameScene.RemoveChild(sprite, true);
//			}
			//if (sprite.Quad.Center
			 // boundsRect.Intersects  
			
			//MIN AND MAX ATTEMPT
//			if ((sprite.Quad.Point11 < Player.sprite.Position.Min) 
//				|| (sprite.Position.Min > Player.sprite.Position.Max) 
//				|| (sprite.Position.Max < Player.sprite.Position.Min) 
//				|| (sprite.Position.Min >Player.sprite.Position.Max))
//			{
//				Console.WriteLine ("HIT");
//			}
			
			//ATTEMPTING WITH HAVING IT PUT THROUGH ANOTHER CLASS
			if(Overlaps(boundsRect, Player.boundsRect) == true)
			{
				Console.WriteLine("Hit");
				//this.alive = false;
				//AppMain.gameScene.RemoveChild(sprite, true);
			}
		}
		
		//RECTANGLE BOUNDING BOX ATTEMPT
		public static bool Overlaps(Rectangle rect1, Rectangle rect2)
		{
			if(rect1.X + rect1.Width < rect2.X)
				return false;
			if (rect1.X > rect2.X + rect2.Width)
				return false;
			if(rect1.Y + rect1.Height < rect2.Y)
				return false;
			if(rect1.Y > rect2.Y + rect2.Height)
				return false;
			
			return true;
			
			
		}
	}
}

