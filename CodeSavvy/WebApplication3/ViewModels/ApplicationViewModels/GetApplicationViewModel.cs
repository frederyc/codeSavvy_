namespace CodeSavvy.WebUI.ViewModels.ApplicationViewModels
{
    public class GetApplicationViewModel
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public int EmployeeId { get; set; }
        public string Resume { get; set; }     // blob file
    }
}
