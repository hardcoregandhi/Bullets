using System;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace Bullets
{
	public class Enemy
	{
		//Private variables
		public SpriteUV	sprite;
		private static TextureInfo textureInfo;
		private static bool alive;
		public int rotation;
		public Vector2 direction;
		
		
		public bool Alive {get{return alive;} set{alive = value;}}
		
		//Public functions
		public Enemy (Vector2 pos, Vector2 rot)
		{
			textureInfo = new TextureInfo("/Application/textures/enemy.png");		
			sprite			= new SpriteUV(textureInfo);
			sprite.Quad.S	= textureInfo.TextureSizef;
			sprite.Position = pos;//new Vector2(900.0f,Director.Instance.GL.Context.GetViewport().Height*0.5f);
			//sprite.Rotate(rot);//sprite.Rotate = new Vector2(180.0f);
			
			
			
			//Add to the current scene.
			AppMain.gameScene.AddChild(sprite);
		}

		public void update()
		{
			direction= Player.sprite.Position- sprite.Position;
			direction.Normalize();
			
			sprite.Angle=FMath.Atan2(direction.X,-direction.Y) -90;
		}
	}
}

