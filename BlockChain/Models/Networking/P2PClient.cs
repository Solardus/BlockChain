﻿using System;
using System.Net;
using System.Net.Sockets;


namespace BlockChain.Models.Networking
{
    public class P2PClient
    {

        public TcpClient client;
        int port;

        public P2PClient()
        { }

        public P2PClient(int port)
        {
            this.port = port;
        }


        public void Start()
        {
            if (client == null)
                client = new TcpClient();

            client.Connect(IPAddress.Loopback, port);
            StartReceiving();
        }

        public void StartReceiving()
        {
            Byte[] buffer = new Byte[256];
            while (client.Connected)
            {
                int bytesRead;
                while ((bytesRead = client.GetStream().Read(buffer, 0, buffer.Length)) != 0)
                {
                    // Convert message into ASCII
                    string data = System.Text.Encoding.ASCII.GetString(buffer, 0, bytesRead);

                    // Do stuff with received buffer


                    // Let calling programme know a message was received
                    OnMessageReceived?.Invoke();
                }
            }
        }

        /// <summary>
        /// Writes bytes to the TCP Networking stream
        /// </summary>
        public void Send(string data)
        {
            Byte[] buffer = new Byte[256];
            buffer = System.Text.Encoding.ASCII.GetBytes(data);
            client.GetStream().Write(buffer, 0, buffer.Length);
        }

        public delegate void MessageReceivedEventHandler();
        public event MessageReceivedEventHandler OnMessageReceived;
    }
}
