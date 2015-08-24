#region Using Statements
using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
#endregion
namespace Hero
{
    public class Font
    {
        List<Letter> letters = new List<Letter>();

        public Font()
        {
            loadLetters();
        }

        private void loadLetters()
        {
            letters.Add(new Letter('a', new Rectangle(8*0, 161, 6, 8)));
            letters.Add(new Letter('b', new Rectangle(8*1, 161, 5, 8)));
            letters.Add(new Letter('c', new Rectangle(8*2, 161, 5, 8)));
            letters.Add(new Letter('d', new Rectangle(8*3, 161, 5, 8)));
            letters.Add(new Letter('e', new Rectangle(8*4, 161, 5, 8)));
            letters.Add(new Letter('f', new Rectangle(8*5, 161, 5, 8)));
            letters.Add(new Letter('g', new Rectangle(8*6, 161, 5, 8)));
            letters.Add(new Letter('h', new Rectangle(8*7, 161, 5, 8)));
            letters.Add(new Letter('i', new Rectangle(8*8, 161, 3, 8)));
            letters.Add(new Letter('j', new Rectangle(8*9, 161, 4, 8)));
            letters.Add(new Letter('k', new Rectangle(8*10, 161, 5, 8)));
            letters.Add(new Letter('l', new Rectangle(8*11, 161, 3, 8)));
            letters.Add(new Letter('m', new Rectangle(8*12, 161, 7, 8)));
            letters.Add(new Letter('n', new Rectangle(8*13, 161, 5, 8)));
            letters.Add(new Letter('o', new Rectangle(8*14, 161, 5, 8)));
            letters.Add(new Letter('p', new Rectangle(8*15, 161, 5, 8)));
            letters.Add(new Letter('q', new Rectangle(8*16, 161, 5, 8)));
            letters.Add(new Letter('r', new Rectangle(8*17, 161, 5, 8)));
            letters.Add(new Letter('s', new Rectangle(8*18, 161, 5, 8)));
            letters.Add(new Letter('t', new Rectangle(8*19, 161, 5, 8)));
            letters.Add(new Letter('u', new Rectangle(8*20, 161, 5, 8)));
            letters.Add(new Letter('v', new Rectangle(8*21, 161, 5, 8)));
            letters.Add(new Letter('w', new Rectangle(8*22, 161, 7, 8)));
            letters.Add(new Letter('x', new Rectangle(8*23, 161, 5, 8)));
            letters.Add(new Letter('y', new Rectangle(8*24, 161, 5, 8)));
            letters.Add(new Letter('z', new Rectangle(8*25, 161, 5, 8)));
            letters.Add(new Letter(' ', new Rectangle(8 * 26, 152, 5, 8)));
            letters.Add(new Letter('1', new Rectangle(2, 169, 3, 8)));
            letters.Add(new Letter('2', new Rectangle(10, 169, 4, 8)));
            letters.Add(new Letter('3', new Rectangle(18, 169, 4, 8)));
            letters.Add(new Letter('4', new Rectangle(26, 169, 5, 8)));
            letters.Add(new Letter('5', new Rectangle(34, 169, 5, 8)));
            letters.Add(new Letter('6', new Rectangle(42, 169, 5, 8)));
            letters.Add(new Letter('7', new Rectangle(50, 169, 4, 8)));
            letters.Add(new Letter('8', new Rectangle(58, 169, 5, 8)));
            letters.Add(new Letter('9', new Rectangle(66, 169, 5, 8)));
            letters.Add(new Letter('0', new Rectangle(74, 169, 5, 8)));
           // letters.Add(new Letter(':', new Rectangle(232, 152, 5, 8)));
        }
        public void DrawString(SpriteBatch sprite, string text, Vector2 position, Color color)
        {
            List<Letter> textWrite = new List<Letter>();
            int dist = 0;
            foreach (char t in text)
            {
                foreach (Letter l in letters)
                {
                    if (t == l.name)
                    {
                        textWrite.Add(l);
                    }
                }
            }
            for (int i = 0; i < textWrite.Count; i++)
            {
                if (i == 0)
                    sprite.Draw(Global.fontTex, new Vector2(((int)position.X ), ((int)position.Y)), textWrite[i].rec, color, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                else
                {
                    sprite.Draw(Global.fontTex, new Vector2(((int)position.X) + (dist ) + (textWrite[i - 1].rec.Width ), (int)position.Y ), textWrite[i].rec,color, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                    dist += textWrite[i - 1].rec.Width;
                }
            }
        }
        public int getDistanceLetters(String text)
        {
            int dis = 0;
            foreach (char t in text)
            {
                foreach (Letter l in letters)
                {
                    if (t == l.name)
                    {
                        dis += l.rec.Width;
                    }
                }
            }
            return dis;
        }
        public List<Letter> GetLetters(String text)
        {
            List<Letter> textWrite = new List<Letter>();
            foreach (char t in text)
            {
                foreach (Letter l in letters)
                {
                    if (t == l.name)
                    {
                        textWrite.Add(l);
                    }
                }
            }
            return textWrite;
        }
        public void DrawString(SpriteBatch sprite, string text, Vector2 position,int ix)
        {
            List<Letter> textWrite = new List<Letter>();
            int dist = 0;
            foreach (char t in text)
            {
                foreach (Letter l in letters)
                {
                    if (t == l.name)
                    {
                        textWrite.Add(l);
                    }
                }
            }
            for (int i = 0; i < textWrite.Count; i++)
            {
                if (i == 0)
                    sprite.Draw(Global.fontTex, new Vector2(((int)position.X), ((int)position.Y)), textWrite[i].rec, Color.White, 0f, Vector2.Zero, 1f*ix, SpriteEffects.None, 0f);
                else
                {
                    sprite.Draw(Global.fontTex, new Vector2(((int)position.X) + ((dist) + (textWrite[i - 1].rec.Width))*ix, (int)position.Y), textWrite[i].rec, Color.White, 0f, Vector2.Zero, 1f*ix, SpriteEffects.None, 0f);
                    dist += textWrite[i - 1].rec.Width;
                }
            }
        }
        public void DrawString(SpriteBatch sprite, string text, Vector2 position)
        {
            List<Letter> textWrite = new List<Letter>();
            int dist = 0;
            foreach (char t in text)
            {
                foreach (Letter l in letters)
                {
                    if (t == l.name)
                    {
                        textWrite.Add(l);
                    }
                }
            }
            for (int i = 0; i < textWrite.Count; i++)
            {
                if (i == 0)
                    sprite.Draw(Global.fontTex, new Vector2(((int)position.X ), ((int)position.Y )), textWrite[i].rec, Color.White, 0f, Vector2.Zero,1f, SpriteEffects.None, 0f);
                else
                {
                    sprite.Draw(Global.fontTex, new Vector2(((int)position.X ) + (dist ) + (textWrite[i - 1].rec.Width), (int)position.Y ), textWrite[i].rec, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                    dist += textWrite[i - 1].rec.Width;
                }
                }
        }
        public void DrawStringOutHud(SpriteBatch sprite, string text, Vector2 position)
        {
            List<Letter> textWrite = new List<Letter>();
            int dist = 0;
            foreach (char t in text)
            {
                foreach (Letter l in letters)
                {
                    if (t == l.name)
                    {
                        textWrite.Add(l);
                    }
                }
            }
            for (int i = 0; i < textWrite.Count; i++)
            {
                if (i == 0)
                    sprite.Draw(Global.fontTex, new Vector2(((int)position.X), ((int)position.Y)), textWrite[i].rec, Color.White, 0f, Vector2.Zero,1f, SpriteEffects.None, 0f);
                else
                {
                    sprite.Draw(Global.fontTex, new Vector2(((int)position.X) + (dist) + (textWrite[i - 1].rec.Width ), (int)position.Y), textWrite[i].rec, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                    dist += textWrite[i - 1].rec.Width;
                }
            }
        }
        public void DrawStringOutHud(SpriteBatch sprite, string text, Vector2 position, Color color)
        {
            List<Letter> textWrite = new List<Letter>();
            int dist = 0;
            foreach (char t in text)
            {
                foreach (Letter l in letters)
                {
                    if (t == l.name)
                    {
                        textWrite.Add(l);
                    }
                }
            }
            for (int i = 0; i < textWrite.Count; i++)
            {
                if (i == 0)
                    sprite.Draw(Global.fontTex, new Vector2(((int)position.X), ((int)position.Y)), textWrite[i].rec, color, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                else
                {
                    sprite.Draw(Global.fontTex, new Vector2(((int)position.X) + (dist) + (textWrite[i - 1].rec.Width), (int)position.Y), textWrite[i].rec,color, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                    dist += textWrite[i - 1].rec.Width;
                }
            }
        }
    }
}
