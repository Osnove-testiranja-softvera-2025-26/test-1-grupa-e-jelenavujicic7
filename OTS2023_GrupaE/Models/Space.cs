

namespace OTS2026_GrupaE.Models
{
    public class Space
    {
        public Field[,,] Fields { get; set; }
        public static readonly int MapSize = 30;

        public Space()
        {
            Fields = new Field[MapSize, MapSize, MapSize];
        }

        public void InitializeMap()
        {
            for (int i = 0; i < MapSize; i++)
            {
                for (int j = 0; j < MapSize; j++)
                {
                    for (int k = 0; k < MapSize;)
                    {
                        Fields[i, j, k] = new Field(Zone.Invalid);
                    }
                }
            }

            CreateRectangleZone(Zone.Farm, 0, 0, 0, 10, 10, 10);
            CreateRectangleZone(Zone.Farm, 20, 0, 0, 10, 10, 10);
            CreateRectangleZone(Zone.Crop, 5, 10, 0, 20, 20, 20);
         
        }


        private void CreateRectangleZone(Zone zone, int upperLeftCornerX, int upperLeftCornerY, int upperLeftCornerZ, int width, int height, int length)
        {
            for (int i = upperLeftCornerX; i < upperLeftCornerX + width; i++)
            {
                for (int j = upperLeftCornerY; j < upperLeftCornerY + height; j++)
                {
                    for (int k = upperLeftCornerZ; k < upperLeftCornerZ + length; k++)
                    {
                        Fields[i, j, k].Zone = zone;
                    }
                }
            }
        }

        public void AddContentToFieldOnPosition(FieldContent content, Position position)
        {
            Field field = Fields[position.X, position.Y, position.Z];

            if (!field.Zone.Equals(Zone.Invalid))
            {
                if (field.Zone.Equals(Zone.Farm) && (content.Equals(FieldContent.PlantedCrop) || content.Equals(FieldContent.PlantCrop)))
                    return;
                else
                    field.Content = content;
            }
        }

        public void EmptyTileOnPosition(Position position)
        { 
            int x = position.X;
            int y = position.Y;
            int z = position.Z;
            Fields[x, y, z].Content = FieldContent.Empty;

        }
    }
}
