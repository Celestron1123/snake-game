// <copyright file="NetworkConnection.cs" company="UofU-CS3500">
// Copyright (c) 2024 UofU-CS3500. All rights reserved.
// </copyright>

//<authors> William Ngo and Elijah Potter </authors>
//<date> 2024-11-7 </date>

using System.Net.Sockets;
using System.Text;
namespace CS3500.Networking;

/// <summary>
///   Wraps the StreamReader/Writer/TcpClient together so we
///   don't have to keep creating all three for network actions.
/// </summary>
public sealed class NetworkConnection : IDisposable
{
    /// <summary>
    ///   The connection/socket abstraction
    /// </summary>
    private TcpClient _tcpClient = new();

    /// <summary>
    ///   Reading end of the connection
    /// </summary>
    private StreamReader? _reader = null;

    /// <summary>
    ///   Writing end of the connection
    /// </summary>
    private StreamWriter? _writer = null;

    /// <summary>
    /// Just locks for the reader and writer. (send and receive)
    /// </summary>
    private readonly object _writeLock = new();
    private readonly object _readLock = new();

    /// <summary>
    ///   Initializes a new instance of the <see cref="NetworkConnection"/> class.
    ///   <para>
    ///     Create a network connection object.
    ///   </para>
    /// </summary>
    /// <param name="tcpClient">
    ///   An already existing TcpClient
    /// </param>
    public NetworkConnection(TcpClient tcpClient)
    {
        _tcpClient = tcpClient;
        if (IsConnected)
        {
            // Only establish the reader/writer if the provided TcpClient is already connected.
            _reader = new StreamReader(_tcpClient.GetStream(), Encoding.UTF8);
            _writer = new StreamWriter(_tcpClient.GetStream(), Encoding.UTF8) { AutoFlush = true };
        }
    }

    /// <summary>
    ///   Initializes a new instance of the <see cref="NetworkConnection"/> class.
    ///   <para>
    ///     Create a network connection object.  The tcpClient will be unconnected at the start.
    ///   </para>
    /// </summary>
    public NetworkConnection()
        : this(new TcpClient())
    {
    }

    /// <summary>
    /// Gets a value indicating whether the socket is connected.
    /// </summary>
    public bool IsConnected
    {
        get
        {
            try
            {
                if (_tcpClient?.Client == null) return false;
                if (!_tcpClient.Client.Connected) return false;

                // Check if client disconnected
                if (_tcpClient.Client.Poll(0, SelectMode.SelectRead))
                {
                    byte[] buffer = new byte[1];
                    if (_tcpClient.Client.Receive(buffer, SocketFlags.Peek) == 0)
                        return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

    /// <summary>
    ///   Try to connect to the given host:port. 
    /// </summary>
    /// <param name="host"> The URL or IP address, e.g., www.cs.utah.edu, or  127.0.0.1. </param>
    /// <param name="port"> The port, e.g., 11000. </param>
    public void Connect(string host, int port)
    {

        if (_tcpClient.Connected)
        {
            throw new InvalidOperationException("You are already connected to a server.");
        }
        try
        {
            _tcpClient.Connect(host, port);
            _reader = new StreamReader(_tcpClient.GetStream(), Encoding.UTF8);
            _writer = new StreamWriter(_tcpClient.GetStream(), Encoding.UTF8) { AutoFlush = true };
        }
        catch (SocketException ex)
        {
            throw new InvalidOperationException("Could not connect to the specified host and port.", ex);
        }
    }


    /// <summary>
    ///   Send a message to the remote server.  If the <paramref name="message"/> contains
    ///   new lines, these will be treated on the receiving side as multiple messages.
    ///   This method should attach a newline to the end of the <paramref name="message"/>
    ///   (by using WriteLine).
    ///   If this operation can not be completed (e.g. because this NetworkConnection is not
    ///   connected), throw an InvalidOperationException.
    /// </summary>
    /// <param name="message"> The string of characters to send. </param>
    public void Send(string message)
    {

        if (!IsConnected || _writer == null)
        {
            throw new InvalidOperationException("You cannot send a message yet. Your network connection is not established.");
        }

        lock (_writeLock)
        {
            try
            {
                //Split the message by newline characters and send each part separately
                string[] lines = message.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                foreach (string line in lines)
                {
                    _writer.WriteLine(line);
                }

            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to send message.", ex);
            }
        }
    }


    /// <summary>
    ///   Read a message from the remote side of the connection.  The message will contain
    ///   all characters up to the first new line. See <see cref="Send"/>.
    ///   If this operation can not be completed (e.g. because this NetworkConnection is not
    ///   connected), throw an InvalidOperationException.
    /// </summary>
    /// <returns> The contents of the message. </returns>
    public string ReadLine()
    {

        if (!IsConnected || _reader == null)
        {
            throw new InvalidOperationException("You cannot receive a message yet. Your network connection is not established.");
        }
        lock (_readLock)
        {
            try
            {
                return _reader.ReadLine() ?? throw new InvalidOperationException("Failed to read message. The connection might have been closed.");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to read message.", ex);
            }
        }

    }

    /// <summary>
    ///   If connected, disconnect the connection and clean 
    ///   up (dispose) any streams.
    /// </summary>
    public void Disconnect()
    {
        _reader?.Dispose();
        _reader = null;

        _writer?.Dispose();
        _writer = null;

        _tcpClient?.Close();
    }

    /// <summary>
    ///   Automatically called with a using statement (see IDisposable)
    /// </summary>
    public void Dispose()
    {
        Disconnect();
    }
}
