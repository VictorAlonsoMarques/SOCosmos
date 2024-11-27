using System;
using System.Text;
using Sys = Cosmos.System;
using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.VFS;
using Cosmos.System.Audio;

namespace CosmosKernel1
{
    public class Kernel : Sys.Kernel
    {
        private CosmosVFS vfs;

        protected override void BeforeRun()
        {
            vfs = new CosmosVFS();
            VFSManager.RegisterVFS(vfs);
            Console.WriteLine("Cosmos iniciado.");
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
                case "list":
                    ListarArchivos();
                    break;
                case "create":
                    CrearArchivo();
                    break;
                case "delete":
                    EliminarArchivo();
                    break;
                case "playaudio":
                    ReproducirAudio(); 
                    break;
                default:
                    Console.WriteLine("Comando desconocido.");
                    break;
            }
        }

        private void MostrarAyuda()
        {
            Console.WriteLine("Comandos: help, about, reboot, shutdown, list, create, delete, playaudio");
        }

        private void MostrarInformacion()
        {
            Console.WriteLine("Sistema v1.0, Victor Alonso.");
        }

        private void ReiniciarSistema()
        {
            Console.WriteLine("Reiniciando...");
            Sys.Power.Reboot();
        }

        private void ApagarSistema()
        {
            Console.WriteLine("Apagando...");
            Sys.Power.Shutdown();
        }

        private void ListarArchivos()
        {
            try
            {
                var root = VFSManager.GetDirectoryListing(@"0:\");
                foreach (var file in root)
                {
                    Console.WriteLine(file.mName + (file.mEntryType == Cosmos.System.FileSystem.Listing.DirectoryEntryTypeEnum.Directory ? " [DIR]" : ""));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        private void CrearArchivo()
        {
            try
            {
                Console.Write("Nombre del archivo: ");
                var fileName = Console.ReadLine();
                var path = @"0:\" + fileName;

                using (var stream = VFSManager.GetFileStream(path))
                {
                    byte[] content = Encoding.ASCII.GetBytes("Archivo creado.");
                    stream.Write(content, 0, content.Length);
                }

                Console.WriteLine("Archivo creado: " + path);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        private void EliminarArchivo()
        {
            try
            {
                Console.Write("Nombre del archivo a eliminar: ");
                var fileName = Console.ReadLine();
                var path = @"0:\" + fileName;
                VFSManager.DeleteFile(path);

                Console.WriteLine("Archivo eliminado: " + path);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        private void ReproducirAudio()
        {
            try
            {
                Console.Beep(1000, 500);
                Console.WriteLine("Reproduciendo sonido...");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al reproducir audio: " + e.Message);
            }
        }
    }
}
