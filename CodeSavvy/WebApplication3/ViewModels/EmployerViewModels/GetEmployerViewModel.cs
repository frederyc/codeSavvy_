namespace CodeSavvy.WebUI.ViewModels.EmployerViewModels
{
    public class GetEmployerViewModel
    {
        public int Id { get; set; }
        public int CredentialsId { get; set; }
        public string CompanyName { get; set; }
        public string Image { get; set; } // Learn about blobs
    }
}
