﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


class Sprite
{
    public string AssetName;

    //The size of the Sprite 
    public Rectangle Size;

    public float Scale = 1.0f;

    public Vector2 Position = new Vector2(0, 0);

    private Texture2D mSpriteTexture;


    public void LoadContent(ContentManager theContentManager, string theAssetName)
    {
        mSpriteTexture = theContentManager.Load<Texture2D>(theAssetName);
        AssetName = theAssetName;
        Size = new Rectangle(0, 0, (int)(mSpriteTexture.Width * Scale), (int)(mSpriteTexture.Height * Scale));
    }


    public void Draw(SpriteBatch theSpriteBatch)
    {
        if (mSpriteTexture != null)
        {
            theSpriteBatch.Draw(mSpriteTexture, Position,
                new Rectangle(0, 0, mSpriteTexture.Width, mSpriteTexture.Height),
                Color.White, 0.0f, Vector2.Zero, Scale, SpriteEffects.None, 0);
        }
    }

    public void Update(GameTime theGameTime, float theSpeed, Vector2 theDirection)
    {
        Position += theDirection * theSpeed * (float)theGameTime.ElapsedGameTime.TotalSeconds;
    }
}
   

