namespace projekt_CSharp
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void kursyBtn_Click(object sender, EventArgs e)
        {
            KursyForm kursyForm = new KursyForm();
            kursyForm.ShowDialog(); 
        }
        private void uczestnicyBtn_Click(object sender, EventArgs e)
        {
            
        }
        private void wyjdzBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
