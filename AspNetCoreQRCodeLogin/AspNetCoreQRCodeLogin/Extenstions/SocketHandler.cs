using System;
using System.Threading.Tasks;

using System.Net.WebSockets;
using System.Threading;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Caching.Distributed;

namespace AspNetCoreQRCodeLogin.Extenstions
{
    public class SocketHandler
    {
        public const int BUFFER_SIZE = 4096;
        WebSocket socket;

        public SocketHandler(WebSocket socket)
        {
            this.socket = socket;
        }

        public string Key { get; set; }
        private static IDistributedCache _cache;

        public async Task ReceiveAsync()
        {
            var buffer = new byte[BUFFER_SIZE];
            var arrSeg = new ArraySegment<byte>(buffer);
            while (socket.State==WebSocketState.Open)
            {
                var incoming = await socket.ReceiveAsync(arrSeg, CancellationToken.None);
                var Key = Encoding.UTF8.GetString(buffer, 0, incoming.Count);

                await SendAsync();
            }
        }


        public async Task SendAsync()
        {
            if (!string.IsNullOrEmpty(Key))
            {
                var buffer = new byte[BUFFER_SIZE];
                var arrSeg = new ArraySegment<byte>(buffer);
                var token = _cache.GetString($"{Key}_token");
                if (!string.IsNullOrEmpty(token))
                {
                    var tokenBytes = Encoding.UTF8.GetBytes(token);
                    var message = new ArraySegment<byte>(tokenBytes);
                    await socket.SendAsync(message, WebSocketMessageType.Text, true, CancellationToken.None);
                }
            }
        }
        public static async Task Acceptor(HttpContext httpContext,Func<Task> func)
        {
            if (!httpContext.WebSockets.IsWebSocketRequest)
            {
                return;
            }
            var socket = await httpContext.WebSockets.AcceptWebSocketAsync();
            var socketHandler = new SocketHandler(socket);

            _cache= httpContext.RequestServices.GetRequiredService<IDistributedCache>();
            await socketHandler.ReceiveAsync();
        }

        public static void Map(IApplicationBuilder app)
        {
            app.UseWebSockets();

            app.Use(Acceptor);
        }
    }
}
