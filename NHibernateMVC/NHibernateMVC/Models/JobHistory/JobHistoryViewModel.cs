namespace NHibernateMVC.Models.JobHistory
{
    public class JobHistoryViewModel
    {
        public JobHistoryForm JobHistoryForm { get; set; }

        public JobHistoryViewModel(JobHistoryForm jobHistoryForm)
        {
            JobHistoryForm = new JobHistoryForm(jobHistoryForm);
        }
    }
}