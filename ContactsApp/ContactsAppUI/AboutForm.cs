using System.Windows.Forms;

namespace ContactsAppUI
{
    public partial class AboutForm : Form
    {
        /// <summary>
        /// Инициализация формы
        /// </summary>
        public AboutForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Ссылка на ГитХаб
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GitHubLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/raznikovgeorgy/NTIP_labs");
        }

        /// <summary>
        /// Написать на почту разработчику
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmailLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:biggreenelpy@gmail.com");
        }
    }
}