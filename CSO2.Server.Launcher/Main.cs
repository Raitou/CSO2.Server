﻿/***
 * Base Launcher can be anything so long as you reference the C# Library
 */

/***
 *  TODO: Use command line arguments to specifically only run certain application as the launcher will provide different types of services.
 *  When no commands given run all services.
 */

namespace CSO2.Server.Launcher
{
    internal class Launcher
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Counter-Strike Online 2 Server");
            Thread TCPThread = new Thread(new ThreadStart(
                TCPServer
                .Startup
                .Startup
                .Start)
                );


            // Start TCP Server
            TCPThread.Start();


            TCPThread.Join();

        }
    }
}
