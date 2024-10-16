using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace CosmosKernel1
{
    public class Kernel : Sys.Kernel
    {
        protected override void BeforeRun()
        {
            Console.WriteLine("Cosmos ha iniciado correctamente. Escribe 'help' para ver los comandos disponibles.");
        }

        protected override void Run()
        {
            Console.Write("Entrada: ");
            var input = Console.ReadLine().ToLower();

            switch (input)
            {
                case "help":
                    MostrarAyuda();
                    break;
                case "about":
                    MostrarInformacion();
                    break;
                case "reboot":
                    ReiniciarSistema();
                    break;
                case "shutdown":
                    ApagarSistema();
                    break;
                default:
                    Console.WriteLine("Comando desconocido. Escribe 'help' para ver una lista de comandos.");
                    break;
            }
        }

        private void MostrarAyuda()
        {
            Console.WriteLine("Comandos disponibles:");
            Console.WriteLine("help     - Muestra este mensaje de ayuda");
            Console.WriteLine("about    - Muestra información sobre el sistema operativo");
            Console.WriteLine("reboot   - Reinicia el sistema");
            Console.WriteLine("shutdown - Apaga el sistema");
        }

        private void MostrarInformacion()
        {
            Console.WriteLine("Sistema Operativo Simple v1.0");
            Console.WriteLine("Desarrollado por Victor Alonso.");
            Console.WriteLine("Construido utilizando el framework Cosmos.");
        }

        private void ReiniciarSistema()
        {
            Console.WriteLine("Reiniciando sistema...");
            Sys.Power.Reboot();
        }

        private void ApagarSistema()
        {
            Console.WriteLine("Apagando sistema...");
            Sys.Power.Shutdown();
        }
    }
}
