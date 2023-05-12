namespace BinaryClock
{
    public class HatState
    {
        public int dx = 0;
        public int dy = 0;
        public bool holding = false;

        public HatState()
        {

        }

        public HatState(int dx, int dy, bool holding)
        {
            this.dx = dx;
            this.dy = dy;
            this.holding = holding;
        }
    }
}