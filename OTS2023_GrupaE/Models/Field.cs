

namespace OTS2026_GrupaE.Models
{

    public enum Zone
    {
        Farm,
        Crop,
        Invalid
    }

    public enum FieldContent
    {
        Empty,
        Seed,
        PlantedCrop,
        PlantCrop
    }

    public class Field
    {
        public FieldContent Content { get; set; }
        public Zone Zone { get; set; }

        public Field(Zone zone)
        {
            Zone = zone;
            Content = FieldContent.Empty;
        }

        public Field(Zone zone, FieldContent content)
        {
            Zone = zone;
            Content = content;
        }
    }
}
