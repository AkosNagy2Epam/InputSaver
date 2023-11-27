using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Data;

namespace InputSaver.ViewModels
{
    class AcquisitionViewModel : ViewModelBase
    {
        public AcquisitionViewModel()
        {
            ScanType[] scanOptions = Enum.GetValues<ScanType>();
            ScanValues = new CollectionView(scanOptions);
            IEnumerable<int> voltageOptions = Enum.GetValues<VoltageType>().Select(v => (int)v);
            VoltageValues = new CollectionView(voltageOptions);
        }

        public event Action ReconstructionEnabledChanged;

        public CollectionView ScanValues { get; private set; }
        public ScanType SelectedScan => (ScanType)ScanValues.CurrentItem;

        public int FramesPerProjection { get; set; } = 1;
        public int ExposureTime { get; set; } = 1;

        public CollectionView VoltageValues { get; private set; }
        public VoltageType SelectedVoltage => (VoltageType)VoltageValues.CurrentItem;

        private bool enableReconstruction;
        public bool EnableReconstruction
        {
            get { return enableReconstruction; }
            set
            {
                enableReconstruction = value;
                ReconstructionEnabledChanged?.Invoke();
            }
        }
    }
}
