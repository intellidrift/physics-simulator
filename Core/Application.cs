using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhysicsSimulator.Core {

    internal class Application {

        private static readonly string title = "PhysicsSimulator";

        private VideoMode mode;
        private RenderWindow window;

        public Application() {
            mode = new(new Vector2u(2550, 1440));
            window = new(mode, title);
            Console.WriteLine("hello world");
        }

        public void Run() {
            while (window.IsOpen) {
                window.DispatchEvents();
                
                window.Clear();
                window.Display();
            }
        }
        
    }
}
