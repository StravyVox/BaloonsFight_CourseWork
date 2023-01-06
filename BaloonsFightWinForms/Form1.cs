using GameNetLibrary;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using GameNetLibrary;
using System.Runtime.InteropServices;

namespace BaloonsFightWinForms
{
    /// <summary>
    /// Class Form1.
    /// Implements the <see cref="System.Windows.Forms.Form" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class Form1 : Form
    {
        /// <summary>
        /// Allocs the console.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }



        /// <summary>
        /// Handles the Click event of the button1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void button1_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start(@"cmd.exe", @"/k D:\repos\BaloonsFightWinForms\BaloonsFightWinForms\bin\Debug\net6.0-windows\BaloonsFightWinForms.exe");
            var nativeWindowSettings = new NativeWindowSettings()
            {
                Size = new Vector2i(1600, 900),
                Title = "Host",
                // This is needed to run on macos
                Flags = ContextFlags.ForwardCompatible,
            };
            if (checkBox1.Checked)
            {
                var window = new Game(textBox1.Text.Length>0?textBox1.Text:"127.0.0.1", textBox2.Text.Length > 0 ? textBox2.Text : "8888", checkBox1.Checked,GameWindowSettings.Default, nativeWindowSettings);
                window.Closed = (value) => { CloseForm(value); };
                window.Run();

            }
            else
            {
                nativeWindowSettings.Title = "Client";
                var window = new Game(textBox1.Text.Length > 0 ? textBox1.Text : "127.0.0.1", textBox2.Text.Length > 0 ? textBox2.Text : "8888", checkBox1.Checked, GameWindowSettings.Default, nativeWindowSettings);
                window.Closed = (value) => { CloseForm(value); };
                window.Run();
            }
        }
        /// <summary>
        /// Closes the form.
        /// </summary>
        private void CloseForm(int winPlayer)
        {
            if (winPlayer == -1)
            {
                Invoke(() => Close());
            }
            else
            {
                Invoke(() =>
                {
                    textBox1.Visible = false;
                    textBox2.Visible = false;
                    button1.Visible = false;
                    button2.Visible = false;
                    label1.Visible = false;
                    label2.Visible = false;
                    label3.Visible = true;
                    label3.Text = String.Format("Игрок {0} выиграл", winPlayer);
                });
            }
        }
        /// <summary>
        /// Handles the Click event of the button2 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button2_Click(object sender, EventArgs e)
        {

            ServerLogic server = new ServerLogic(textBox1.Text.Length > 0 ? textBox1.Text : "127.0.0.1", textBox2.Text.Length > 0 ? textBox2.Text : "8888");
            server.RunServer();
            Console.WriteLine("Server started");
        }

        /// <summary>
        /// Handles the CheckedChanged event of the checkBox2 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            AllocConsole();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}