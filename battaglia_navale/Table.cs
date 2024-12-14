using System.Threading;

namespace battaglia_navale
{
    public partial class Table : Form
    {

        public static Button[,] user_board_matrix { get; set; }
        public static Button[,] computer_board_matrix { get; set; }
        public static int table_dimension { get; set; }
        private Menu menu_form;

        public Table()
        {
            InitializeComponent();
            Modifica_tabella_Click(null, EventArgs.Empty);
        }

        private void Form1_Load(object sender, EventArgs e) { }

        //metodi 
        public static void HitTile(object sender, EventArgs e) {
            Button sender_button = (Button)sender;
            sender_button.BackColor = Color.Red;
        }

        private void Modifica_tabella_Click(object sender, EventArgs e)
        {
            menu_form = new Menu();
            menu_form.StartPosition = FormStartPosition.Manual;
            menu_form.Location = new Point(Location.X+Size.Width/2, Location.Y+Size.Height/2);
            Show();
            menu_form.ShowDialog();
        }
    }
}