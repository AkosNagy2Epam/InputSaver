using InputSaver.Models;
using InputSaver.ViewModels;
using System;
using System.Windows.Input;

namespace InputSaver.Commands
{
    class SaveCommand : ICommand
    {
        private readonly InfoViewModel infoViewModel;
        private readonly AcquisitionViewModel acquisitionViewModel;
        private readonly ReconstructionViewModel reconstructionViewModel;
        private readonly UserInputViewModel userInputViewModel;
        private readonly FileOperator fileOperator;

        public SaveCommand(InfoViewModel infoViewModel, AcquisitionViewModel acquisitionViewModel, ReconstructionViewModel reconstructionViewModel,
                            UserInputViewModel userInputViewModel, FileOperator fileOperator)
        {           
            this.infoViewModel = infoViewModel;
            this.acquisitionViewModel = acquisitionViewModel;
            this.reconstructionViewModel = reconstructionViewModel;
            this.userInputViewModel = userInputViewModel;
            this.fileOperator = fileOperator;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            InfoModel infoModel= new InfoModel(infoViewModel.PatientId, infoViewModel.TissueType, infoViewModel.Remarks);
            AcquisitionModel acquisitionModel = new AcquisitionModel(acquisitionViewModel.SelectedScan,
                    acquisitionViewModel.FramesPerProjection, acquisitionViewModel.ExposureTime, acquisitionViewModel.SelectedVoltage,
                    acquisitionViewModel.EnableReconstruction);
            ReconstructionModel reconstructionModel;

            if (acquisitionModel.EnableReconstruction)
            {
                reconstructionModel = new ReconstructionModel(reconstructionViewModel.SizeX, reconstructionViewModel.SizeY,
                    reconstructionViewModel.SizeZ, reconstructionViewModel.OffsetX, reconstructionViewModel.OffsetY,
                    reconstructionViewModel.OffsetZ, reconstructionViewModel.WaxLevel, reconstructionViewModel.Stride);
            }
            else reconstructionModel = null;

            string resultMsg = "";

            try
            {
                if (userInputViewModel.SavePrettyYaml) fileOperator.WriteUserInputToPrettyYaml(infoModel, acquisitionModel, reconstructionModel);
                else fileOperator.SerializeUserInput(infoModel, acquisitionModel, reconstructionModel);

                resultMsg = "The file has been saved successfully!";
            }
            catch (Exception e)
            {
                resultMsg = "Error: "+e.Message;
            }

            userInputViewModel.Message = resultMsg;
        }
    }
}
