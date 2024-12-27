using Microsoft.VisualBasic.Devices;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Xml.Linq;
/*log1: what was i thinking when first created the program structure not to add 2 separate classes for user and computer board? you stupid donkey*/
/*log2 23-12-24 : troppe variabili di gestione (es: user_board_matrix) in questo file. non va bene.*/
/*log3 24-12-24 : continuo a maledirmi per non aver creato le due classi per computer e user. fa male.*/
/*log4 24-12-24 : non ce la faccio piùù cribbio! come cavolo hai mai pensato ad usare la form per tutto. diamine. voglio spararmi. mi odio COSI' tanto che non ho idea. voglio una macchina del tempo per prendermi a sberle. */
/*sviluppo_gameplay
-funzione di reset con aggiunta di appostito tasto **medium --> done
-opzione di reset in messagebox quando la partita termina **easy --> done
-algoritmo di attacco per computer **difficult --> in progress
-verifica presenza di una nave prima di poter iniziare **easy --> done
-disattiva i bottoni non necessari nella varie fasi **easy --> done
-disattiva la board nemica in preparazione e la board user in battaglia **easy
 */
namespace battaglia_navale
{
    public partial class Table : Form
    {
//attributi
        private Menu menu_form;
        public static int table_dimension { get; set; }

        public static (int user, int computer) Remaining_ship_tiles = (0, 0);

        internal static Dictionary<string, (ShipData user, ShipData computer)> ships_counter = new Dictionary<string, (ShipData user, ShipData computer)>
        {
            { "portaerei(5)", (new ShipData(1), new ShipData(1)) },
            { "corazzata(4)", (new ShipData(1), new ShipData(1)) },
            { "incrociatore(3)", (new ShipData(2), new ShipData(2)) },
            { "cacciatorpediniere(3)", (new ShipData(1), new ShipData(1)) },
            { "sottomarino(2)", (new ShipData(1), new ShipData(1)) }
        };

        public static string game_phase = "preparation"; //or battle
        private static bool IsUserTurn = true;
        public static Button[,] user_board_matrix { get; set; }

        //computer variables
        public static Button[,] computer_board_matrix { get; set; }
        private struct lastShipHit
        {
            public static int[] first = new int[] { -1, -1 };
            public static int[] last = new int[] { -1, -1 };
            public static bool shipHoocked = false;
            public static bool isVertical = false;
            public static int counter = 0;
            public static int shipDestroyed = 0;
            public static int failed = 0;
            public static (bool bottom, bool top, bool left, bool right) direction = (false, false, false, false);

            public static void StandardValue() {
                first = new int[] { -1, -1 };
                last = new int[] { -1, -1 };
                shipHoocked = false;
                isVertical = false;
                counter = 0;
                shipDestroyed = 0;
                failed = 0;
                direction = (false, false, false, false);
            }
        }

//costruttore e inizializzazione form
        public Table()
        {
            InitializeComponent();
            Modifica_tabella_Click(null, EventArgs.Empty);
            EnableButtons();
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
                    create_computer_ship(key);

            EnableButtons();
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
            {
                if (IsUserTurn)
                    HitTile(sender, e);
                while (!IsUserTurn)
                    AttackUser();
            }
        }

        public static bool HitTile(object sender, EventArgs e)
        {
            if (((Button)sender).Tag.ToString() == "ship tile")
            {
                if (!((ShipTile)sender).IsDestroyed)
                {
                    DestroyShip(sender);
                    VerifyWinner();
                    IsUserTurn = !IsUserTurn;
                    return true;
                }
            }
            else if (!((SeaTile)sender).isHit)
            {
                ((SeaTile)sender).HitTile();
                IsUserTurn = !IsUserTurn;
                return true;
            }

            return false;
        }

        private static void DestroyShip(object sender)
        {
            ((ShipTile)sender).SetDestroyed();

            if (((ShipTile)sender).Parent == Computer_board)
                Remaining_ship_tiles.computer--;
            else
                Remaining_ship_tiles.user--;

        }

        private static void VerifyWinner()
        {
            DialogResult result = DialogResult.None;

            if (Remaining_ship_tiles.user == 0)
                result = MessageBox.Show("GAME OVER! IL VINCITORE è Computer!", "sconfitta", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            else if (Remaining_ship_tiles.computer == 0)
                result = MessageBox.Show("THE WINNER IS User! YOU HAVE BEATEN Computer!", "vittoria", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

            if (result == DialogResult.Retry)
                ResetTable_click();

        }

        private static void ResetTable_click(object sender = null, EventArgs e = null)
        {
            User_board.Controls.Clear();
            Computer_board.Controls.Clear();
            user_board_matrix = null;
            computer_board_matrix = null;
            Remaining_ship_tiles = (0, 0);

            table_dimension = 0;

            game_phase = "preparation";
            ships_counter = new Dictionary<string, (ShipData user, ShipData computer)>
            {
                { "portaerei(5)", (new ShipData(1), new ShipData(1)) },
                { "corazzata(4)", (new ShipData(1), new ShipData(1)) },
                { "incrociatore(3)", (new ShipData(2), new ShipData(2)) },
                { "cacciatorpediniere(3)", (new ShipData(1), new ShipData(1)) },
                { "sottomarino(2)", (new ShipData(1), new ShipData(1)) }
            };

            new Menu().ShowDialog();
            EnableButtons();
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
                Remaining_ship_tiles.user += lenght;
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

            EnableButtons(defult: false);
        }

        private void create_computer_ship(string key)
        {
            Random generatore = new Random();
            Ship new_ship;

            //define parameters
            bool IsVertical = generatore.Next(0, 2) == 0 ? false : true;
            int lenght = Table.GetLenght(key);
            while (true)
            {
                //define coordinates until they're accepted
                int x = generatore.Next(0, IsVertical ? table_dimension : table_dimension - lenght + 1);//get the second value considering the ship's lenght and table dimension
                int y = generatore.Next(0, IsVertical ? table_dimension - lenght + 1 : table_dimension);
                int[] coordinates = new int[] { x, y };

                try
                {
                    if (Table.Computer_board.InvokeRequired)
                        Table.Computer_board.Invoke((MethodInvoker)delegate {
                            new_ship = new Ship(IsVertical, lenght, coordinates, key, "computer");
                        });
                    else
                        new_ship = new Ship(IsVertical, lenght, coordinates, key, "computer");
                    break;// if the ship is created, exit the loop  
                }
                catch (Exception)
                {
                    continue; //else , try again
                }
            }
            Table.Remaining_ship_tiles.computer += lenght;
        }

        private static void VerifyShipAvailability(string name)
        {
            name = name.ToLower();
            if (ships_counter[name].user.Counter == 0)
            {
                ships_counter[name].user.Ships[ships_counter[name].user.Ships.Length - 1].RemoveShip();
                ships_counter[name].user.Counter++;
                Remaining_ship_tiles.user -= GetLenght(name);

            }
        }

        public static int GetLenght(string name)
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

        private static void AttackUser()
        {
            Random generatore = new Random();
            int[] coordinates;

            coordinates = Get_coordinates();

            if (coordinates.Contains(-1))
                return;

            /*MessageBox.Show($"coordinates: [{coordinates[0]}, {coordinates[1]}]\n" +
                    $"first: [{lastShipHit.first[0]}, {lastShipHit.first[1]}]\n" +
                    $"last: [{lastShipHit.last[0]}, {lastShipHit.last[1]}]\n" +
                    $"shipHoocked: {lastShipHit.shipHoocked}\n" +
                    $"isVertical: {lastShipHit.isVertical}\n" +
                    $"counter: {lastShipHit.counter}\n" +
                    $"shipDestroyed: {lastShipHit.shipDestroyed}\n" +
                    $"failed: {lastShipHit.failed}\n" +
                    $"direction: (bottom: {lastShipHit.direction.bottom}, top: {lastShipHit.direction.top}, left: {lastShipHit.direction.left}, right: {lastShipHit.direction.right})");*/

            bool hit = HitTile(user_board_matrix[coordinates[0], coordinates[1]], EventArgs.Empty);

            //if you hit ship
            if (hit && user_board_matrix[coordinates[0], coordinates[1]].Tag.ToString() == "ship tile")
            {
                if (lastShipHit.shipDestroyed == 0)
                {
                    lastShipHit.first = new int[] { coordinates[0], coordinates[1] };
                    lastShipHit.shipHoocked = true;
                }
                lastShipHit.last = new int[] { coordinates[0], coordinates[1] };
                lastShipHit.direction = (false, false, false, false);
                lastShipHit.counter++;
                lastShipHit.shipDestroyed++;

                lastShipHit.failed = 0;
            }
            //if you hit sea
            else if (hit)
            {
                lastShipHit.direction = (false, false, false, false);
                lastShipHit.last = new int[] { lastShipHit.first[0], lastShipHit.first[1] };
                lastShipHit.counter++;
                lastShipHit.failed = 0;
            }
            //nothing is hit
            else { lastShipHit.failed++; }
                
                

            /*MessageBox.Show($"first: [{lastShipHit.first[0]}, {lastShipHit.first[1]}]\n" +
                $"coordinates: [{coordinates[0]}, {coordinates[1]}]\n" +
                $"last: [{lastShipHit.last[0]}, {lastShipHit.last[1]}]\n" +
                $"shipHoocked: {lastShipHit.shipHoocked}\n" +
                $"isVertical: {lastShipHit.isVertical}\n" +
                $"counter: {lastShipHit.counter}\n" +
                $"shipDestroyed: {lastShipHit.shipDestroyed}\n" +
                $"failed: {lastShipHit.failed}\n" +
                $"direction: (bottom: {lastShipHit.direction.bottom}, top: {lastShipHit.direction.top}, left: {lastShipHit.direction.left}, right: {lastShipHit.direction.right})\n" +
                $"hit: {hit}\n" +
                $"tag: {user_board_matrix[coordinates[0], coordinates[1]].Tag.ToString()}"

                );*/
            
            //if the choosen tile is already hit it repeat the selection

            int[] Get_coordinates()
            {
                int[] coordinates = new int[] { -1, -1 };

                if (lastShipHit.shipHoocked)//target the ship
                {
                    if (!lastShipHit.isVertical)//is horizontal
                    {

                        if (!lastShipHit.direction.right) { //indica se si ha già provato ad andare a destra 

                            if (lastShipHit.last[0] + 1 < table_dimension) //se è una casella valida
                                coordinates = TryHitRight();
                            else
                                lastShipHit.failed++;
                            lastShipHit.direction.right = true;
                        }//right
                        else if (!lastShipHit.direction.left) {

                            if (lastShipHit.last[0] - 1 >= 0)
                                coordinates = TryHitLeft();/*problema: 1. first viene modificato da qualche parte. 2. viene passata la coordinata con valori < 0 con left*/
                            else
                                lastShipHit.failed++;
                            lastShipHit.direction.left = true;
                        }//left

                        if (lastShipHit.counter == 2 && lastShipHit.shipDestroyed == 1 && user_board_matrix[coordinates[0], coordinates[1]].Tag.ToString() == "sea tile")
                            lastShipHit.isVertical = true;

                        if (coordinates.Contains(-1)) {//riparti da first
                            if (lastShipHit.failed == 2) {

                                lastShipHit.failed++;
                                lastShipHit.last = new int[] { lastShipHit.first[0], lastShipHit.first[1] };
                                lastShipHit.direction = (false, false, false, false);
                                return coordinates;
                                //coordinates = Get_coordinates();
                            }
                            else if (lastShipHit.failed >= 4) {

                                lastShipHit.StandardValue();
                                coordinates = HitRandom();
                            }

                        }
                        
                        return coordinates;
                    }
                    else if (lastShipHit.isVertical)
                    {
                        if (!lastShipHit.direction.bottom && lastShipHit.last[1] + 1 < table_dimension)
                            return TryHitBottom();
                        else if (!lastShipHit.direction.top && lastShipHit.last[1] - 1 >= 0)
                            return TryHitTop();
                    }//is vertical

                    lastShipHit.StandardValue();
                }


                return HitRandom();
            }

            int[] HitRandom()
            {
                int x = generatore.Next(0, table_dimension);
                int y = generatore.Next(0, table_dimension);
                return new int[] { x, y };
            }

            int[] TryHitLeft()
            {
                int x = lastShipHit.last[0] -1;
                int y = lastShipHit.last[1];
                lastShipHit.direction.left = true;
                return new int[] { x, y };
            }

            int[] TryHitRight()
            {
                int x = lastShipHit.last[0] + 1;
                int y = lastShipHit.last[1];
                lastShipHit.direction.right = true;
                return new int[] { x, y };
            }

            int[] TryHitTop()
            {
                int x = lastShipHit.last[0];
                int y = lastShipHit.last[1] -1;
                lastShipHit.direction.top = true;
                return new int[] { x, y };
            }

            int[] TryHitBottom()
            {
                int x = lastShipHit.last[0];
                int y = lastShipHit.last[1] + 1;
                lastShipHit.direction.bottom = true;
                return new int[] { x, y };
            }
        }

        private static void EnableButtons(bool defult = true)
        {
            if (game_phase == "preparation" && defult)
            {//initial situation
                Cambia_tabella.Enabled = true;
                Button_horizontal.Enabled = true;
                Button_vertical.Enabled = true;
                Ship_input.Enabled = true;
                button_StartGame.Enabled = false;
                Button_resetGame.Enabled = false;
                EnableBoard(computer_board_matrix, false);
                EnableBoard(user_board_matrix, true);

            }
            else if (game_phase == "battle" && defult)//after entering the battle phase
            {
                Button_horizontal.Enabled = false;
                Cambia_tabella.Enabled = false;
                Button_vertical.Enabled = false;
                Ship_input.Enabled = false;
                button_StartGame.Enabled = false;
                Button_resetGame.Enabled = true;
                EnableBoard(computer_board_matrix, true);
                EnableBoard(user_board_matrix, false);
            }

            else if (game_phase == "preparation" && !defult) //when at least one ship is placed
            {
                button_StartGame.Enabled = true;
                Button_resetGame.Enabled = true;
                EnableBoard(computer_board_matrix, false);
                EnableBoard(user_board_matrix, true);

            }

            void EnableBoard(Button[,] board_matrix, bool state) {
                try { 
                    foreach (Button tile in board_matrix) { 
                        tile.Enabled = state;
                    }
                }
                catch { return; }
            }


        }

    }
}