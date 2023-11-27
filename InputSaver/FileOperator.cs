using InputSaver.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace InputSaver
{
    /// <summary>
    /// Takes care of file operations.
    /// </summary>
    class FileOperator
    {
        public void SerializeUserInput(InfoModel infoModel, AcquisitionModel acquisitionModel)
        { 
            SerializeUserInput(infoModel, acquisitionModel, null); 
        }
        public void SerializeUserInput(InfoModel infoModel, AcquisitionModel acquisitionModel, ReconstructionModel reconstructionModel) 
        {
            object[] instancesToFile = { infoModel, acquisitionModel, reconstructionModel };

            string fileName = "SavedInput.yaml";

            if (File.Exists(fileName)) File.Delete(fileName);
            Stream serializingStream = File.Create(fileName);
            StreamWriter streamWriter = new StreamWriter(serializingStream);

            foreach (object instance in instancesToFile)
            {                
                if (instance != null)
                {
                    Type instanceType = instance.GetType();
                    List<PropertyInfo> properties =  instanceType.GetProperties().ToList();
                    
                    streamWriter.WriteLine($"{instanceType.Name}:");

                    foreach (PropertyInfo prop in properties)
                    {
                        streamWriter.WriteLine($"  {prop.Name}: {prop.GetValue(instance)}");
                    }
                }                    
            }

            streamWriter.Flush();
            serializingStream.Close();             
        }

        public void WriteUserInputToPrettyYaml(InfoModel infoModel, AcquisitionModel acquisitionModel)
        {
            WriteUserInputToPrettyYaml(infoModel, acquisitionModel, null);
        }
        public void WriteUserInputToPrettyYaml(InfoModel infoModel, AcquisitionModel acquisitionModel, ReconstructionModel reconstructionModel)
        {
            string yamlTxt = $"Info:" +
                                    $"\n  patient ID: {infoModel.PatientId}" +
                                    $"\n  tissue type: {infoModel.TissueType}" +
                                    $"\n  remarks: {infoModel.Remarks}" +
                                $"\nAcquisition:" +
                                    $"\n  scan: {acquisitionModel.Scan.ToString().ToLower()}" +
                                    $"\n  frames per projection: {acquisitionModel.FramesPerProjection}" +
                                    $"\n  exposure time: {acquisitionModel.ExposureTime}" +
                                    $"\n  voltage: {(int)acquisitionModel.Voltage}" +
                                    $"\n  enable reconstruction: {acquisitionModel.EnableReconstruction.ToString().ToLower()}";

            if (reconstructionModel!=null) 
            {
                string yamlTxt_Reconstruction = $"Reconstruction:" +
                                                    $"\n  sizeX: {reconstructionModel.SizeX}" +
                                                    $"\n  sizeY: {reconstructionModel.SizeY}" +
                                                    $"\n  sizeZ: {reconstructionModel.SizeZ}" +
                                                    $"\n  offsetX: {reconstructionModel.OffsetX}" +
                                                    $"\n  offsetY: {reconstructionModel.OffsetY}" +
                                                    $"\n  offsetZ: {reconstructionModel.OffsetZ}" +
                                                    $"\n  wax level: {reconstructionModel.WaxLevel}" +
                                                    $"\n  stride: {reconstructionModel.Stride}";

                yamlTxt += "\n" + yamlTxt_Reconstruction;
            }

            File.WriteAllText("SavedInputPretty.yaml", yamlTxt);
        }
    }
}
