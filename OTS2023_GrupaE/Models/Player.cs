

namespace OTS2026_GrupaE.Models
{
    public class Player
    {
        public Position Position { get; set; }
        public int AmountOfSeed { get; set; }
        public int AmountOfPlants { get; set; }
        public bool VisitedCrop { get; set; }

        public Player()
        {
        }

        public Player(Position position)
        {
            Position = position;
        }

        public void PlantSeed()
        {
            AmountOfSeed--;
            AmountOfPlants++;
        }


        public void MakeMove(Move move)
        {
            switch (move)
            {
                case Move.Up:
                    MoveUp();
                    break;
                case Move.Down:
                    MoveDown();
                    break;
                case Move.Left:
                    MoveLeft();
                    break;
                case Move.Right:
                    MoveRight();
                    break;
                case Move.Back:
                    MoveBack();
                    break;
                case Move.Forward:
                    MoveForward();
                    break;
                default:
                    break;
            }
        }

        public void MoveUp()
        {
            Position.Y--;
        }

        public void MoveDown()
        {
            Position.Y++;
        }

        public void MoveLeft()
        {
            Position.X--;
        }

        public void MoveRight()
        {
            Position.X++;
        }

        public void MoveBack()
        {
            Position.Z--;
        }

        public void MoveForward()
        {
            Position.Z++;
        }

        public Position GetPositionAfterMove(Move move)
        {
            int x = Position.X;
            int y = Position.Y;
            int z = Position.Z;
            switch (move)
            {
                case Move.Up:
                    return new Position(x, y - 1, z);
                case Move.Down:
                    return new Position(x, y + 1, z);
                case Move.Left:
                    return new Position(x - 1, y, z);
                case Move.Right:
                    return new Position(x + 1, y, z);
                case Move.Back:
                    return new Position(x, y, z - 1);
                case Move.Forward:
                    return new Position(x, y, z + 1);
                default:
                    return null;
            }
        }
    }
}
