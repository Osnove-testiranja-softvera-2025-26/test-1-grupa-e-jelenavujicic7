

using OTS2026_GrupaE.Exceptions;
using OTS2026_GrupaE.Models;

namespace OTS2026_GrupaE
{

    public enum Move
    {
        Up,
        Down,
        Left,
        Right,
        Back,
        Forward
    }

    public enum Income
    {
        Bad,
        Average,
        Good
    }

    public class Game
    {
        public Player Player { get; set; }
        public Space Map { get; set; }


        public Game(Position playerPosition)
        {
            Map = new Space();
            Map.InitializeMap();

            int playerX = playerPosition.X;
            int playerY = playerPosition.Y;
            int playerZ = playerPosition.Z;
          
            if (!ValidatePositionInsideValidZones(playerPosition) || !Map.Fields[playerX, playerY, playerZ].Zone.Equals(Zone.Farm))
            {
                throw new InvalidPlayerPositionException("Player must be in the Farm zone!");
            }
     
            Player = new Player(playerPosition);
        }

        public void MovePlayer(Move move)
        {
            Position playerPositionAfterMove = Player.GetPositionAfterMove(move);
            
            if (ValidatePosition(playerPositionAfterMove))
            {
                Player.MakeMove(move);
            }
        }

        public bool ValidatePosition(Position position)
        {

            if (position == null)
                return false;

            int x = position.X;
            int y = position.Y;
            int z = position.Z;

            if (!ValidatePositionInsideValidZones(position))
            {
                return false;
            }
            if (Map.Fields[x, y, z].Content.Equals(FieldContent.PlantedCrop))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool ValidatePositionInsideValidZones(Position position)
        {

            if (position == null)
                return false;

            int x = position.X;
            int y = position.Y;
            int z = position.Z;

            if (x < 0 || x >= Space.MapSize || y < 0 || y >= Space.MapSize)
            {
                return false;
            }
            if (Map.Fields[x, y, z].Zone.Equals(Zone.Invalid))
            {
                return false;
            }
            return true;
        }

        public void ResolvePlayerPosition()
        {
            FieldContent fieldContent = Map.Fields[Player.Position.X, Player.Position.Y, Player.Position.Z].Content;
            Zone fieldZone = Map.Fields[Player.Position.X, Player.Position.Y, Player.Position.Z].Zone;

            if (fieldContent.Equals(FieldContent.Seed))
            {
                Player.AmountOfSeed++;
                Map.EmptyTileOnPosition(Player.Position);
            }
            else if (fieldContent.Equals(FieldContent.PlantCrop))
            {
                if(Player.AmountOfSeed > 0)
                {
                    Player.PlantSeed();
                    Map.AddContentToFieldOnPosition(FieldContent.PlantedCrop, Player.Position);
                }
            }
            if (fieldZone.Equals(Zone.Crop))
            {
                Player.VisitedCrop = true;
            }
            
        }


        public Income CalculateIncome()
        {
            if (Player.AmountOfPlants > 10)
            {
                return Income.Good;
            }
            if (Player.AmountOfSeed >= 15 && Player.VisitedCrop)
            {
                if (Player.AmountOfPlants > 6)
                {
                    return Income.Good;
                }
                else
                {
                    return Income.Average;
                }
            }
            return Income.Bad;
        }

    }
}
