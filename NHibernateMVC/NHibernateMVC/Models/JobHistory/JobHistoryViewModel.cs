namespace NHibernateMVC.Models.JobHistory
{
    /// <summary>
    /// View model for jobhistory editing and creation
    /// </summary>
    public class JobHistoryViewModel
    {
        public JobHistoryForm JobHistoryForm { get; set; }
        public PositionModel PositionModel { get; set; }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="jobHistoryForm"></param>
        public JobHistoryViewModel(JobHistoryForm jobHistoryForm)
        {
            JobHistoryForm = new JobHistoryForm(jobHistoryForm);
        }
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="positionModel"></param>
        public JobHistoryViewModel(PositionModel positionModel)
        {
            JobHistoryForm = new JobHistoryForm();
            PositionModel = positionModel;
        }
    }
}