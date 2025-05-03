namespace TaskHub.Model
{
    public class TaskModel
    {
        public int taskID { get; set; }
        public string task { get; set; }
        public string estimateStartDate { get; set; }
        public string estimateEndDate { get; set; }
        public string actualStartDate { get; set; }
        public string actualEndDate { get; set; }
        public int assigneeID { get; set; }
        public string status { get; set; }
        public string completedPercentage { get; set; }
        public int projectID { get; set; }
        public int isActive { get; set; }
    }
}
