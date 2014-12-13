using System;
using System.Collections.Generic;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace Bullets
{
	public class Projectile
	{
		public SpriteUV pSprite;
		TextureInfo	pTextureInfo;
		public Vector2 pPosition;
		public Vector2 direction;
		public Bounds2 bounds;
		private bool alive = false;
		public static float pVelocity = 0.03f;
			
		public Projectile (Vector2 _pPosition)
		{
			this.alive = true;
			pSprite = new SpriteUV();
			pTextureInfo = new TextureInfo("/Application/textures/Projectile.png");
			pSprite			= new SpriteUV(pTextureInfo);
			
			pSprite.Quad.S	= pTextureInfo.TextureSizef;
			pSprite.Position =_pPosition;
			bounds = pSprite.Quad.Bounds2();
			//sprite.Scale = new Vector2(Director.Instance.GL.Context.Screen.Width, Director.Instance.GL.Context.Screen.Height);
			
			//travel in the direction of the player WHEN THE BULLET WAS FIRST FIRED
			direction= Player.sprite.Position- _pPosition+45;
			direction.Normalize();
			pSprite.Rotate(FMath.Atan2(direction.X,direction.Y));

			AppMain.gameScene.AddChild(pSprite);
		}
			
		public bool getAlive(){
			return this.alive;
		}
		
		
		public void update(){
			if(this.alive == true){		
				this.pSprite.Position += this.direction * Projectile.pVelocity;
		
				// if(projectile is off screen, delete
				if ((this.pSprite.Position.X > Director.Instance.GL.Context.GetViewport().Width - 35) || 
					(this.pSprite.Position.X < 25) ||
					(this.pSprite.Position.Y > Director.Instance.GL.Context.GetViewport().Height - 55) ||
					(this.pSprite.Position.Y < 55))			
				{
						this.alive = false;
						AppMain.gameScene.RemoveChild(pSprite, true);
				}	
			}
		}
	}
}
