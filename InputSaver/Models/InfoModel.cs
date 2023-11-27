namespace InputSaver.Models
{
    class InfoModel
    {
        public InfoModel(string patientId, string tissueType, string remarks)
        {
            PatientId = patientId;
            TissueType = tissueType;
            Remarks = remarks;
        }

        public string PatientId { get; set; }
        public string TissueType { get; set; }
        public string Remarks { get; set; }
    }
}
