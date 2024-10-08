﻿using System.Net.WebSockets;

namespace Net.Solnet.Rpc.PublicMembers.Core.Sockets
{
    public class WebSocketWrapper : IWebSocket
    {
        private readonly ClientWebSocket webSocket;

        public WebSocketWrapper(ClientWebSocket webSocket)
        {
            this.webSocket = webSocket;
        }

        public WebSocketCloseStatus? CloseStatus => webSocket.CloseStatus;

        public string CloseStatusDescription => webSocket.CloseStatusDescription;

        public WebSocketState State => webSocket.State;

        public Task CloseAsync(WebSocketCloseStatus closeStatus, string statusDescription, CancellationToken cancellationToken)
            => webSocket.CloseAsync(closeStatus, statusDescription, cancellationToken);

        public Task ConnectAsync(Uri uri, CancellationToken cancellationToken)
            => webSocket.ConnectAsync(uri, cancellationToken);

        public Task CloseAsync(CancellationToken cancellationToken)
            => webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, null, cancellationToken);

        public ValueTask<ValueWebSocketReceiveResult> ReceiveAsync(Memory<byte> buffer, CancellationToken cancellationToken)
            => webSocket.ReceiveAsync(buffer, cancellationToken);

        public ValueTask SendAsync(ReadOnlyMemory<byte> buffer, WebSocketMessageType messageType, bool endOfMessage, CancellationToken cancellationToken)
            => webSocket.SendAsync(buffer, messageType, endOfMessage, cancellationToken);

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        private void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    webSocket.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}