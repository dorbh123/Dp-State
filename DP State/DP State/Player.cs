using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_State
{
    public class Player
    {
        private PlayerState _state;

        public Player(PlayerState state)
        {
            _state = state;
        }

        public void PressB()
        {
            _state.PressB(this);
        }

        public void PressDown()
        {
            _state.PressDown(this);
        }
        public void PressDownAndHold()
        {
            _state.PressDownAndHold(this);
        }
        public PlayerState CurrentState
        {
            get { return _state; }
            set { _state = value; }
        }
    }


    public abstract class PlayerState
    {
        public abstract void PressB(Player player);

        public abstract void PressDown(Player player);
        public abstract void PressDownAndHold(Player player);
        

    }


    public class StandingState : PlayerState
    {
        public StandingState()
        {
            Console.WriteLine("STANDBY");
        }

        public override void PressDown(Player player)
        {
            player.CurrentState = new DuckingState();
            System.Threading.Thread.Sleep(1000);
            player.CurrentState = this;
        }

        public override void PressB(Player player)
        {
            player.CurrentState = new JumpingState();
        }
        public override void PressDownAndHold(Player player)
        {
            player.CurrentState = new DuckingState();
        }
    }


    public class JumpingState : PlayerState
    {
        public JumpingState()
        {
            Console.WriteLine("Jumping");
        }

        public override void PressB(Player player)
        {
            Console.WriteLine("No Double jumps");
        }

        public override void PressDown(Player player)
        {
            player.CurrentState = new DivingState();
        }

        public override void PressDownAndHold(Player player)
        {
            Console.WriteLine("No WayZ Dude");
        }
    }


    public class DivingState : PlayerState
    {
        public DivingState()
        {
            Console.WriteLine("Diving");
            
        }

        public override void PressB(Player player)
        {
            System.Threading.Thread.Sleep(1000);
            player.CurrentState = new StandingState();
        }

        public override void PressDown(Player player)
        {
            System.Threading.Thread.Sleep(1000);
            player.CurrentState = new StandingState();
        }

        public override void PressDownAndHold(Player player)
        {
            Console.WriteLine("No!");
        }
    }


    public class DuckingState : PlayerState
    {
        public DuckingState()
        {
            Console.WriteLine("Quack");
        }

        public override void PressB(Player player)
        {
            Console.WriteLine("No way jose");
        }

        public override void PressDown(Player player)
        {
            player.CurrentState = new DuckingState();
            System.Threading.Thread.Sleep(1000);
            player.CurrentState = new StandingState();
        }
        public override void PressDownAndHold(Player player)
        {
            player.CurrentState = new DuckingState();
        }
    }
}
