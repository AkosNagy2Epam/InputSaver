using InputSaver.Commands;
using System.Windows.Input;

namespace InputSaver.ViewModels
{
    class UserInputViewModel : ViewModelBase
    {
        public UserInputViewModel(FileOperator fileOperator)
        {
            InfoViewModel = new InfoViewModel();
            AcquisitionViewModel = new AcquisitionViewModel();
            AcquisitionViewModel.ReconstructionEnabledChanged += OnReconstructionEnabledChanged;
            ReconstructionViewModel = new ReconstructionViewModel();
            SaveCommand = new SaveCommand(InfoViewModel, AcquisitionViewModel, ReconstructionViewModel, this, fileOperator);
        }        

        private void OnReconstructionEnabledChanged()
        {
            OnPropertyChanged(nameof(IsReconstructionEnabled));
        }

        public void Dispose()
        {
            AcquisitionViewModel.ReconstructionEnabledChanged -= OnReconstructionEnabledChanged;
        }

        public InfoViewModel InfoViewModel { get; }
        public AcquisitionViewModel AcquisitionViewModel { get; }
        public ReconstructionViewModel ReconstructionViewModel { get; }

        public bool IsReconstructionEnabled => AcquisitionViewModel.EnableReconstruction;

        private string message = "";
        public string Message
        {
            get => message;
            set
            {
                message = value;
                OnPropertyChanged(nameof(Message));
                OnPropertyChanged(nameof(Color));
            }
        }

        public string Color => Message.StartsWith("Error") ? "Red" : "Blue";

        public ICommand SaveCommand { get; }

        public bool SavePrettyYaml { get; set; } = true;
    }
}
