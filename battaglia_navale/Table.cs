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
            menu_form.Location = new Point(Location.X+Width/2- menu_form.Width/2, Location.Y+Size.Height/ 2 - menu_form.Height / 2);
            Show();
            menu_form.ShowDialog();
        }
        
        private void CreateShip(object sender, EventArgs e) {
            try { 
                string[] tag = ((Button)sender).Tag.ToString().Split('|');
                string text = ((Button)sender).Text;

                int[] coordinates = new int[] { Convert.ToInt32(tag[0]), Convert.ToInt32(tag[1]) };
                int lenght = GetLenght(text); //mappa il nome con la lunghezza della nave

                Ship new_ship = new Ship(true, lenght, coordinates, text);
            }
            catch (ArgumentException exce) {
                MessageBox.Show(exce.Message, "position error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exce) {
                MessageBox.Show(exce.Message, "generic error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private int GetLenght(string name) { 
            switch (name.ToLower()){
                case "po": //portaerei
                    return 5; 
                case "co": //corazzata
                    return 4;
                case "in": //incrociatore
                    return 3;
                case "ca": //cacciatorpediniere
                    return 3;
                case "so": //sottomarino
                    return 2;
                default:
                    throw new Exception("not recognized ship");
            }
        }
    }
}