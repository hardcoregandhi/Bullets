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
		bool alive;
		public Vector2 pPosition;
		public Vector2 direction;
		public static float pVelocity = 0.02f;
			
		public Projectile (Vector2 _pPosition)
		{
			pSprite = new SpriteUV();
			pTextureInfo = new TextureInfo("/Application/textures/player.png");
			pSprite			= new SpriteUV(pTextureInfo);
			
			pSprite.Quad.S	= pTextureInfo.TextureSizef;
			pSprite.Position =_pPosition;
			//sprite.Scale = new Vector2(Director.Instance.GL.Context.Screen.Width, Director.Instance.GL.Context.Screen.Height);
			
			//travel in the direction of the player WHEN THE BULLET WAS FIRST FIRED
			direction= Player.sprite.Position- _pPosition;
			direction.Normalize();
			pSprite.Rotate(FMath.Atan2(direction.X,direction.Y));
			
			//scene.AddChild(pSprite);
			AppMain.gameScene.AddChild(pSprite);
			
		}
		
		public void Create()
		{
		}
		
		public static void Update()
		{
			
			     
	    }
		
		public void Draw()
		{
		}
		
		public void isOffScreen()
		{
			
		}
		
		public void Delete()
		{
			
		}
		
	}
}

