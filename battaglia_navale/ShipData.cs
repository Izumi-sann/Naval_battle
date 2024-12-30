namespace battaglia_navale 
{ 
    internal class ShipData
    {
        public Ship[] Ships { get; set; }
        public int Counter { get; set; }

        private int _reset_counter;
        public ShipData(int counter)
        {
            this.Counter = counter;
            this._reset_counter = counter;
            this.Ships = new Ship[counter];
        }

        public void AddShip(Ship new_ship) {
            this.Ships[this._reset_counter - this.Counter] = new_ship;
            this.Counter--;
        }

        public void ModifyShipCounter(int new_counter){
            if (new_counter > 0) { 
                this.Counter = new_counter;
                this._reset_counter = new_counter;
                this.Ships = new Ship[new_counter];
            }
        }
    }
}
