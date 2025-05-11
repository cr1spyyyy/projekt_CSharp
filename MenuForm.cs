using System;
using Microsoft.Extensions.DependencyInjection;

namespace projekt_CSharp
{
    public partial class MenuForm : Form
    {
        private readonly IServiceProvider _serviceProvider;
        public MenuForm(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private void kursyBtn_Click(object sender, EventArgs e)
        {
            var kursyForm = _serviceProvider.GetRequiredService<KursyForm>();
            kursyForm.Show();
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
