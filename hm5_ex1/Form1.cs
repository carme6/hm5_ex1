using Microsoft.VisualBasic;

namespace hm5_ex1
{
    public partial class Form1 : Form
    {
        Bitmap b;
        Graphics g;
        Rectangle rect;
        List<int> distribution =new List<int>() { 6,2,8,12,18,1,7,21};
        


        Pen penRectangle = new Pen(Color.Black);
        public Form1()
        {
            InitializeComponent();

            rect = new Rectangle(100, 100, 300, 300);
            b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(b);
            pictureBox1.Image = b;

        }
 

        private int fromXRealToXVirtual(int x, int minX, int maxX, int w)
        {
            return (w * (x - minX) / (maxX - minX));
        }

        private int fromYRealToYVirtual(int y, int minY, int maxY, int h)
        {
            return (h - h * (y - minY) / (maxY - minY));
        }

        private int find_max(List<int> list) {
            int max = 0;
            for (int i = 0; i < list.Count; i++) { 
            if (list[i]>max)
                    max = list[i];
            }
            return max + 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(Color.White);
            g.DrawRectangle(penRectangle, rect);
            int number_interval_vert = rect.Height / distribution.Count;
            drawHistogramVertical(g, rect.X, number_interval_vert, rect.Top);
            this.pictureBox1.Refresh();

        }

        private void drawHistogramVertical(Graphics g, int x, int interval,int start) {
            
            SolidBrush new_brush = new SolidBrush(Color.Red);
            for (int i = 0; i < distribution.Count; i++)
            {
                int new_height = fromXRealToXVirtual(distribution[i], 0, find_max(distribution), rect.Width);
                Rectangle inst = new Rectangle(x,start,new_height,interval-1 );
                start += interval;
                g.DrawRectangle(Pens.Black, inst);
                g.FillRectangle(new_brush, inst);
            }


        }

        private void drawHistogramHorizontal( Graphics g, int y, int interval, int start)
        {

            SolidBrush new_brush = new SolidBrush(Color.Blue);
            for (int i = 0; i < distribution.Count; i++)
            {
                int new_height = fromXRealToXVirtual(distribution[i], 0, find_max(distribution), rect.Height);
                Rectangle inst = new Rectangle(start, y + (rect.Height - new_height), interval - 1, new_height);
                start += interval;
                g.DrawRectangle(Pens.Black, inst);
                g.FillRectangle(new_brush, inst);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            var g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(Color.White);
            g.DrawRectangle(penRectangle, rect);
            int number_interval_hor = rect.Width / distribution.Count;
            drawHistogramHorizontal(g, rect.Y, number_interval_hor, rect.Left);
            this.pictureBox1.Refresh();
        }
    }
}
