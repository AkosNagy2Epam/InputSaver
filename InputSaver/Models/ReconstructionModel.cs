namespace InputSaver.Models
{
    class ReconstructionModel
    {
        public ReconstructionModel(int sizeX, int sizeY, int sizeZ, int offsetX, int offsetY, int offsetZ, int waxLevel, int stride)
        {
            SizeX = sizeX;
            SizeY = sizeY;
            SizeZ = sizeZ;
            OffsetX = offsetX;
            OffsetY = offsetY;
            OffsetZ = offsetZ;
            WaxLevel = waxLevel;
            Stride = stride;
        }

        public int SizeX { get; set; }
        public int SizeY { get; set; }
        public int SizeZ { get; set; }
        public int OffsetX { get; set; }
        public int OffsetY { get; set; }
        public int OffsetZ { get; set; }
        public int WaxLevel { get; set; }
        public int Stride { get; set; }
    }
}
