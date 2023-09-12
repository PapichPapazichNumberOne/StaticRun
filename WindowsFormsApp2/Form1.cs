using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private Label fleeingStatic;
        private Random random;

        public Form1()
        {
            InitializeComponent();
            InitializeFleeingStatic();
            random = new Random();
            Timer timer = new Timer();
            timer.Interval = 50; // Интервал обновления позиции статика (ms)
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void InitializeFleeingStatic()
        {
            fleeingStatic = new Label();
            fleeingStatic.Text = "Статик";
            fleeingStatic.BackColor = Color.Blue;
            fleeingStatic.ForeColor = Color.White;
            fleeingStatic.Size = new Size(40, 40); // Размер фигуры(статик)
            fleeingStatic.Location = new Point(ClientSize.Width / 2 - fleeingStatic.Width / 2, ClientSize.Height / 2 - fleeingStatic.Height / 2);
            Controls.Add(fleeingStatic);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Тут мы проверяем чтоб мышка реагировола на фигуры и фигура передвигалось в другое место.
            Point cursorPosition = PointToClient(Cursor.Position);
            Rectangle staticRect = new Rectangle(fleeingStatic.Location, fleeingStatic.Size);

            if (staticRect.Contains(cursorPosition))
            {
                // Генирация новых кординат
                int newX = random.Next(0, ClientSize.Width - fleeingStatic.Width);
                int newY = random.Next(0, ClientSize.Height - fleeingStatic.Height);

                fleeingStatic.Location = new Point(newX, newY);
            }
        }
    }
}