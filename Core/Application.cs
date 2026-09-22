using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhysicsSimulator.Core {

    internal class Application {

        private static readonly string title = "PhysicsSimulator";
        private static readonly uint width = 2550;
        private static readonly uint height = 1440;

        private VideoMode mode;
        private readonly RenderWindow window;
        private readonly Clock timer;

        private float dt;
        private List<CircleShape> objects;

        public Application() {
            mode = new(new Vector2u(width, height));
            window = new(mode, title);
            timer = new();
            dt = 0;
            
            window.Closed += (sender, args) => window.Close();
            window.KeyPressed += WindowKeyPressed;

            objects = [
                new CircleShape(50) {
                    Position = new Vector2f(100, 100),
                    FillColor = Color.Yellow
                },
                new CircleShape(35) {
                    Position = new Vector2f(500, 500),
                    FillColor = Color.Yellow
                }
            ];
        }

        private void WindowKeyPressed(object? sender, KeyEventArgs e) {
            if (e.Code == Keyboard.Key.Enter) {
                window.Close();
            }
        }

        public void Run() {

            while (window.IsOpen) {
                TickApp();

                // Event dispatching
                window.DispatchEvents();
                
                // TODO: Update State

                // Drawing
                window.Clear(Color.Blue);
                
                foreach (var obj in objects) {
                    window.Draw(obj);
                }

                window.Display();
            }
        }

        private void TickApp() {
            dt = timer.Restart().AsSeconds();
            if (dt > 0.1) {
                dt = 0;
            }
        }

    }
}
