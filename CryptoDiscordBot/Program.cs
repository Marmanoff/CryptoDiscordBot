using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Net;

namespace CryptoDiscordBot
{
    class Program
    {
        static void Main(string[] args)
        {
            DiscordBot Disc = new DiscordBot();
            Disc.RunBotAsync().GetAwaiter().GetResult();
        }
    }
}
