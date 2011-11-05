using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace Flood_Control
{
    class GamePiece
    {

        public static string[] PieceTypes = 
        {
            "Left,Right",
            "Top,Bottom",
            "Left,Top",
            "Top,Right",
            "Right,Bottom",
            "Bottom,Left",
            "Empty"
        };

        public const int
            PieceHeight = 40,
            PieceWidth = 40;


        public const int
            MaxPlayablePieceIndex = 5,
            EmptyPieceIndex = 6;

        public const int
            textureOffsetX = 1,
            textureOffsetY = 1,
            texturePaddingX = 1,
            texturePaddingY = 1;

        private string
            pieceType = "",
            pieceSuffix = "";



        public string PieceType
        {
            get { return pieceSuffix; }
        }

        public string Suffix
        {
            get { return pieceSuffix; }
        }





    }
}
