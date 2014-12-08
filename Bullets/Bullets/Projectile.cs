using System;

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
		public static float pVelocity = 10.0f;
			
		public Projectile ()
		{
			pSprite = new SpriteUV();
			pTextureInfo = new TextureInfo("/Application/textures/player.png");
			pSprite			= new SpriteUV(pTextureInfo);
			
			pSprite.Quad.S	= pTextureInfo.TextureSizef;
			pSprite.Position = new Vector2(Director.Instance.GL.Context.GetViewport().Width/2, Director.Instance.GL.Context.GetViewport().Height/2);
			//sprite.Scale = new Vector2(Director.Instance.GL.Context.Screen.Width, Director.Instance.GL.Context.Screen.Height);
			
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

