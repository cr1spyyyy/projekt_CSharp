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
            var uczestnicyForm = _serviceProvider.GetRequiredService<UczestnicyForm>();
            uczestnicyForm.Show();
        }
        private void wyjdzBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void rejestracjaBtn_Click(object sender, EventArgs e)
        {
            var rejestracjaForm = _serviceProvider.GetRequiredService<RejestracjaForm>();
            rejestracjaForm.Show();
        }
    }
}
