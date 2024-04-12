namespace atm2
{
    public partial class Form1 : Form
    {
        public string pass = "01010";
        public string inputPass = " ";
        public Form1()
        {
            InitializeComponent();
        }






        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Form3 Form3 = new Form3();
            this.Hide();
            Form3.ShowDialog();
        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
