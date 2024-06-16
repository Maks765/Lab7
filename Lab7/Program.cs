using System;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsTextEditor
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Створення та запуск головної форми програми
            Application.Run(new MainForm());
        }
    }

    public class MainForm : Form
    {
        private TextBox textBox;
        private MenuStrip menuStrip;
        private ToolStripMenuItem fileMenu;
        private ToolStripMenuItem openMenuItem;
        private ToolStripMenuItem saveMenuItem;
        private ToolStripMenuItem exitMenuItem;

        public MainForm()
        {
            // Ініціалізація компонентів форми
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            textBox = new TextBox();
            textBox.Multiline = true;
            textBox.Dock = DockStyle.Fill;

            menuStrip = new MenuStrip();
            fileMenu = new ToolStripMenuItem("File");
            openMenuItem = new ToolStripMenuItem("Open");
            saveMenuItem = new ToolStripMenuItem("Save");
            exitMenuItem = new ToolStripMenuItem("Exit");

            // Обробники подій для пунктів меню
            openMenuItem.Click += OpenMenuItem_Click;
            saveMenuItem.Click += SaveMenuItem_Click;
            exitMenuItem.Click += ExitMenuItem_Click;

            // Додавання пунктів меню до меню "File"
            fileMenu.DropDownItems.Add(openMenuItem);
            fileMenu.DropDownItems.Add(saveMenuItem);
            fileMenu.DropDownItems.Add(exitMenuItem);

            // Додавання меню до головного меню
            menuStrip.Items.Add(fileMenu);

            // Додавання елементів у форму
            Controls.Add(textBox);
            Controls.Add(menuStrip);

            // Налаштування розташування меню
            MainMenuStrip = menuStrip;

            // Налаштування розмірів форми
            Size = new System.Drawing.Size(800, 600);
        }

        private void OpenMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void SaveMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, textBox.Text);
            }
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
