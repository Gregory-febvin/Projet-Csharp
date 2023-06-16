using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class TCPServer
{
    static void Main()
    {
        string ipAddress = "172.18.1.62";
        int port = 8888;

        TcpListener listener = new TcpListener(IPAddress.Parse(ipAddress), port);

        try
        {
            listener.Start();
            Console.WriteLine("Server started. Waiting for connections...");

            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                Console.WriteLine("Client connected.");

                ProcessClientRequest(client);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            listener.Stop();
        }
    }

    static void ProcessClientRequest(TcpClient client)
    {
        NetworkStream stream = client.GetStream();

        byte[] buffer = new byte[1024];
        int bytesRead;

        while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
        {
            string data = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            Console.WriteLine("Received: " + data);

            string response = "Server response: " + data.ToUpper();

            byte[] responseBytes = Encoding.ASCII.GetBytes(response);
            stream.Write(responseBytes, 0, responseBytes.Length);
        }

        client.Close();
        Console.WriteLine("Client disconnected.");
    }
}
