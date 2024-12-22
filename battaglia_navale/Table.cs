using System.Runtime.CompilerServices;
using System.Threading;
using System.Xml.Linq;
/*log1: what was i thinking when first created the program structure not to add 2 separate classes for user and computer board? you stupid donkey*/
/*sviluppo computer board:
 -algoritmo per inserire le navi **difficult --> done
 -decidere quando fare il caricamento delle navi **easy --> done
 -creare la funzione per iniziare il gioco(per debug) **easy --> done
 */
namespace battaglia_navale
{
    public partial class Table : Form
    {
        public static Button[,] user_board_matrix { get; set; }
        public static Button[,] computer_board_matrix { get; set; }
        public static int table_dimension { get; set; }

        private Menu menu_form;

        public static string game_phase = "preparation"; //or battle

        internal static Dictionary<string, (ShipData user, ShipData computer)> ships_counter = new Dictionary<string, (ShipData user, ShipData computer)>
        {
            { "portaerei(5)", (new ShipData(1), new ShipData(1)) },
            { "corazzata(4)", (new ShipData(1), new ShipData(1)) },
            { "incrociatore(3)", (new ShipData(2), new ShipData(2)) },
            { "cacciatorpediniere(3)", (new ShipData(1), new ShipData(1)) },
            { "sottomarino(2)", (new ShipData(1), new ShipData(1)) }
        };

        public Table()
        {
            InitializeComponent();
            Modifica_tabella_Click(null, EventArgs.Empty);
        }

        private void Form1_Load(object sender, EventArgs e) { }

        //metodi 
        private void Start_game_Click(object sender, EventArgs e)
        {
            game_phase = "battle";
            MessageBox.Show("Destry your enemy float!", "Game start", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //insert the ships
            foreach (string key in Table.ships_counter.Keys)
                for (int i = 0; i < Table.ships_counter[key].computer.Counter; i++)
                    new Menu().create_computer_ship(key);

        }

        private void Modifica_tabella_Click(object sender, EventArgs e)
        {
            menu_form = new Menu();
            menu_form.StartPosition = FormStartPosition.Manual;
            menu_form.Location = new Point(Location.X + Width / 2 - menu_form.Width / 2, Location.Y + Size.Height / 2 - menu_form.Height / 2);
            Show();
            menu_form.ShowDialog();
        }

        public static void Board_buttonClick(object sender, EventArgs e)
        { //i'm using this method just to centralize the process
            if (game_phase == "preparation")
                CreateShip(sender, e);
            else
                HitTile(sender, e);
        }

        public static void HitTile(object sender, EventArgs e)
        {
            if (((Button)sender).Tag.ToString() == "ship tile")
                ((ShipTile)sender).SetDestroyed();
            else { 
                ((SeaTile)sender).HitTile();
            }
                
        }

        public static void CreateShip(object sender, EventArgs e)
        {
            //devi inserire la nave in ship_counter
            try
            {
                //data
                string[] tag = ((Button)sender).Tag.ToString().Split('|');
                string ship_name = Ship_input.SelectedItem.ToString();

                int[] coordinates = new int[] { Convert.ToInt32(tag[0]), Convert.ToInt32(tag[1]) };
                int lenght = GetLenght(ship_name); //mappa il nome con la lunghezza della nave
                bool IsVertical = Button_vertical.Checked;

                //create the ship
                Ship new_ship = new Ship(IsVertical, lenght, coordinates, ship_name, "user");
                VerifyShipAvailability(ship_name);
                ships_counter[ship_name.ToLower()].user.AddShip(new_ship);
            }
            catch (NullReferenceException exce)
            {
                MessageBox.Show("you haven't selected the ship or it's orientation", "selection error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException exce)
            {
                MessageBox.Show(exce.Message, "position error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exce)
            {
                MessageBox.Show($"you can't perform this action; {exce.Message} ", "generic error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private static void VerifyShipAvailability(string name) { 
            name = name.ToLower();
            if (ships_counter[name].user.Counter == 0) {
                ships_counter[name].user.Ships[ships_counter[name].user.Ships.Length - 1].RemoveShip();
                ships_counter[name].user.Counter++;
            }
        }

        public static int GetLenght(string name)//devi decrementare il contatore
        {
            switch (name.ToLower())
            {
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