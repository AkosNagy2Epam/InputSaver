namespace InputSaver.Models
{
    class AcquisitionModel
    {
        public AcquisitionModel(ScanType scan, int framesPerProjection, int exposureTime, VoltageType voltage, bool enableReconstruction)
        {
            Scan = scan;
            FramesPerProjection = framesPerProjection;
            ExposureTime = exposureTime;
            Voltage = voltage;
            EnableReconstruction = enableReconstruction;
        }

        public ScanType Scan { get; set; }
        public int FramesPerProjection { get; set; }
        public int ExposureTime { get; set; }
        public VoltageType Voltage { get; set; }
        public bool EnableReconstruction { get; set; }
    }
}
