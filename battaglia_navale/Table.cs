using System.Runtime.CompilerServices;
using System.Threading;

namespace battaglia_navale
{
    public partial class Table : Form
    {
        public static Button[,] user_board_matrix { get; set; }
        public static Button[,] computer_board_matrix { get; set; }
        public static int table_dimension { get; set; }
        private Menu menu_form;

        public static string game_phase = "preparation"; //or battle

        public Table()
        {
            InitializeComponent();
            Modifica_tabella_Click(null, EventArgs.Empty);
        }

        private void Form1_Load(object sender, EventArgs e) { }

        //metodi 

        private void Modifica_tabella_Click(object sender, EventArgs e)
        {
            menu_form = new Menu();
            menu_form.StartPosition = FormStartPosition.Manual;
            menu_form.Location = new Point(Location.X+Width/2- menu_form.Width/2, Location.Y+Size.Height/ 2 - menu_form.Height / 2);
            Show();
            menu_form.ShowDialog();
        }
        
        public static void Board_buttonClick(object sender, EventArgs e) { 
            if (game_phase == "preparation")
                CreateShip(sender, e);
            else
                HitTile(sender, e);
        }

        public static void HitTile(object sender, EventArgs e) {
            Button sender_button = (Button)sender;
            sender_button.BackColor = Color.Red;
        }
        
        public static void CreateShip(object sender, EventArgs e) {
            try { 
                string[] tag = ((Button)sender).Tag.ToString().Split('|');
                string ship_name = Ship_input.SelectedItem.ToString();

                int[] coordinates = new int[] { Convert.ToInt32(tag[0]), Convert.ToInt32(tag[1]) };
                int lenght = GetLenght(ship_name); //mappa il nome con la lunghezza della nave

                bool IsVertical = Button_vertical.Checked;
                Ship new_ship = new Ship(IsVertical, lenght, coordinates, ship_name);
            }
            catch (System.NullReferenceException exce) {
                MessageBox.Show(exce.Message, "selection error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException exce) {
                MessageBox.Show(exce.Message, "position error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exce) {
                MessageBox.Show(exce.Message, "generic error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private static int GetLenght(string name) { 
            switch (name.ToLower()){
                case "portaerei(5)": //portaerei
                    return 5; 
                case "corazzata(4)": //corazzata
                    return 4;
                case "incrociatore(3)": //incrociatore
                    return 3;
                case "cacciatorpediniere(3)": //cacciatorpediniere
                    return 3;
                case "sottomarino(2)": //sottomarino
                    return 2;
                default:
                    throw new Exception("not recognized ship");
            }
        }
    }
}