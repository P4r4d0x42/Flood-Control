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

        private const int
            textureOffsetX = 1,
            textureOffsetY = 1,
            texturePaddingX = 1,
            texturePaddingY = 1;

        private string
            pieceType = "",
            pieceSuffix = "";



        // Properties 
        public string PieceType
        {   // Get Blocks -- These make the read only mode to anything outside this class
            get { return pieceType; }
        }

        public string Suffix
        {
            get { return pieceSuffix; }
        }



        // Constructor(s)
        // A constructor is run when an instance of the GamePiece class is created. 
        // By specifying two constructors, we will allow future code to create a GamePiece by specifying a piece type with or without a suffix. 
        // If no suffix is specified, an empty suffix is assumed.
        public GamePiece(string type, string suffix)
        {
            pieceType = type;
            pieceSuffix = suffix;
        }

        public GamePiece(string type)
        {
            pieceType = type;
            pieceSuffix = "";
        }

        #region Updating
        //with Overloads(more than one method with the same name but with a different parameter list passed to it(?)Need to check this)
        public void SetPiece(string type, string suffix)
        {
            pieceType = type;
            pieceSuffix = suffix;
        }

        public void SetPiece(string type)
        {
            SetPiece(type, "");
        }

        public void AddSuffix(string suffix)
        {
            if (!pieceSuffix.Contains(suffix))
                pieceSuffix += suffix;
        }

        public void RemoveSuffix(string suffix)
        {
            pieceSuffix = pieceSuffix.Replace(suffix, "");
        }
        #endregion

        #region Rotation
        /// <summary>
        /// Rotation Switch
        /// The only information the RotatePiece() method needs is a rotation direction. 
        /// For straight pieces, rotation direction doesn't matter (a left/right piece will always become a top/bottom piece and vice versa).
        /// For angled pieces, the piece type is updated based on the rotation direction and the diagram above.
        /// </summary>
        /// <param name="Clockwise">True or False, what's it going to be?</param>
        public void RotatePiece(bool Clockwise)
        {
            switch (pieceType)
            {
                // Flips the --- piece to |
                case "Left,Right":
                    pieceType = "Top,Bottom";
                    break;
                // Flips the | piece to ---
                case "Top,Bottom":
                    pieceType = "Left,Right";
                    break;
                // 
                case "Left,Top":
                    if (Clockwise)
                        pieceType = "Top,Right";
                    else
                        pieceType = "Bottom,Left";
                    break;
                // 
                case "Top,Right":
                    if (Clockwise)
                        pieceType = "Right,Bottom";
                    else
                        pieceType = "Left,Top";
                    break;
                // 
                case "Right,Bottom":
                    if (Clockwise)
                        pieceType = "Bottom,Left";
                    else
                        pieceType = "Top,Right";
                    break;
                // 
                case "Bottom,Left":
                    if (Clockwise)
                        pieceType = "Left,Top";
                    else
                        pieceType = "Right,Bottom";
                    break;
                // 
                case "Empty":
                    break;


                /* Why all the strings?  	
                 *
                 *   It would certainly be reasonable to create constants that represent the various piece positions instead of fully spelling out things like Bottom, Left as strings. 
                 *   However, because the Flood Control game is not taxing on the system, the additional processing time required for string manipulation will not impact the game negatively 
                 *   and helps clarify how the logic works.
                 */
            }
        }
        #endregion
        #region Connection MethodS
        /// <summary>
        /// 
        /// </summary>
        /// <param name="startingEnd"></param>
        /// <returns></returns>
        public string[] GetOtherEnds(string startingEnd)
        {
            // TODO: Look this up and figure out how it works
            List<string> opposites = new List<string>();

            foreach (string end in pieceType.Split(','))
            {
                if (end != startingEnd)
                    opposites.Add(end);
            }
            return opposites.ToArray();
        }
        
        public bool HasConnector(string direction)
        {
            return pieceType.Contains(direction);
        }
        
        #endregion




        
















    }
}
