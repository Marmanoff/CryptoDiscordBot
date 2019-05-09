using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;
using Discord;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Discord.Net.Providers.WS4Net;

namespace CryptoDiscordBot
{
    class DiscordBot
    {
        private DiscordSocketClient client;
        private CommandService commands;
        private IServiceProvider services;

        public async Task RunBotAsync()
        {
            client = new DiscordSocketClient(new DiscordSocketConfig
            {
                WebSocketProvider = WS4NetProvider.Instance
            });
            commands = new CommandService();
            services = new ServiceCollection().AddSingleton(client).AddSingleton(commands).BuildServiceProvider();

            string token = "discord nyckel här";

            //event subscription
            client.Log += Log;

            //
            await RegisterCommandsAsync();

            var x = client.LoginAsync(TokenType.Bot, token);

            var z = client.StartAsync();

            await Task.Delay(-1);
        }

        private Task Log(LogMessage arg)
        {
            Console.WriteLine(arg);
            return Task.CompletedTask;
        }

        public async Task RegisterCommandsAsync()
        {
            client.MessageReceived += HandleCommandAsync;
            await commands.AddModulesAsync(Assembly.GetEntryAssembly(), services);
        }

        private async Task HandleCommandAsync(SocketMessage arg)
        {
            var message = arg as SocketUserMessage;
            if (message is null || message.Author.IsBot) return;
            int argPos = 0;

            if (message.HasStringPrefix("!", ref argPos) || message.HasMentionPrefix(client.CurrentUser, ref argPos))
            {
                var context = new SocketCommandContext(client, message);
                var result = await commands.ExecuteAsync(context, argPos, services);

                if (!result.IsSuccess)
                    Console.WriteLine(result.ErrorReason);
            }
        }
    }
}
