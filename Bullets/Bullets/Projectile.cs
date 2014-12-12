using System;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace Bullets
{
	public class Projectile
	{
		SpriteUV pSprite;
		TextureInfo	pTextureInfo;
		bool alive;
		
			
		public Projectile ()
		{
//			sprite = new SpriteUV();
//			textureInfo = new TextureInfo("/Application/textures/player.png");
//			sprite			= new SpriteUV(textureInfo);
//			
//			sprite.Quad.S	= textureInfo.TextureSizef;
//			sprite.Position = new Vector2(Director.Instance.GL.Context.GetViewport().Width/2, Director.Instance.GL.Context.GetViewport().Height/2);
//			sprite.Scale = new Vector2(Director.Instance.GL.Context.Screen.Width, Director.Instance.GL.Context.Screen.Height);
			
		}
		
		public void Create()
		{
		}
		
		public void Update()
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

