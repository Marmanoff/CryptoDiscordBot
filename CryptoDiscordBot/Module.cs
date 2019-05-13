using CryptoDiscordBot.Classes;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoDiscordBot
{
    public class Module : ModuleBase<SocketCommandContext>
    {
        [Command("invites")]
        public async Task GetInvites()
        {
            if (Context.Channel.Name == "check-invites")
            {
                var invites = await Context.Guild.GetInvitesAsync();
                var getInvitesForUserFromChannel = invites.Where(x => x.ChannelName.Equals("create-invites") && x.Inviter.Username == Context.User.Username).OrderByDescending(x => x.Uses).FirstOrDefault();
                if (getInvitesForUserFromChannel == null)
                {
                    await Context.Channel.SendMessageAsync(Context.User.Mention + " **create your invite link first before checking your invites. Make sure you create your invite link through the create-invites channel and that you set the link to not expire. Not doing this will make your invites disappear/not count.**");
                }

                var myUses = (int)getInvitesForUserFromChannel.Uses;
                var user = Context.User as IGuildUser;

                var rank = new Rank(myUses, user.Username);
                var userRole = Context.Guild.Roles.FirstOrDefault(x => x.Name == rank.CurrentRank);
                await user.AddRoleAsync(userRole);

                if (myUses <= 49) await Context.Channel.SendMessageAsync("", false, rank.MessageWithRankup().Build());
                else await Context.Channel.SendMessageAsync("", false, rank.MessageWithNoRankup().Build());
            }
        }

        [Command("pumpdate")]
        public async Task PumpDate(DateTime date, double hours, double minutes)
        {
            try
            {
                int counter = 0;
                await Context.Channel.SendMessageAsync("Date for pump has been set");
                var pumpDate = date.AddHours(hours).AddMinutes(minutes);
                bool firstRun = true;
                while (pumpDate >= DateTime.Now)
                {
                    var embeds = new MessageEmbed(date, hours, minutes);
                    await SetGame(embeds);
                    await Task.Delay(15000);

                    if (counter == 1 || firstRun == true)
                    {
                        firstRun = false;
                        await SendSignalMessage(embeds);
                        counter = 0;
                    }

                    counter++;
                }
            }
            catch (Exception)
            {
                await Context.Channel.SendMessageAsync("pumpdate needs to be a date.");
            }
        }

        public async Task SetGame(MessageEmbed embeds)
        {
            if (embeds.TimeSpan.Days == 0)
            {
                await Context.Client.SetGameAsync("Pump in " + embeds.Hour + ":" + embeds.Minute);
                var shit = embeds.Minute;
            }
            else
            {
                await Context.Client.SetGameAsync("Pump in " + embeds.Day + "d" + " " + embeds.Hour + ":" + embeds.Minute);
                var shit = embeds.Minute;
            }

            if (embeds.PumpDate <= DateTime.Now)
            {
                await Context.Client.SetGameAsync("");
            }
        }


        public async Task SendSignalMessage(MessageEmbed embeds)
        {

            if (int.Parse(embeds.Day) >= 1 || int.Parse(embeds.Hour.ToString()) >= 5)
            {
                var signalChannel = (ISocketMessageChannel)Context.Client.GetChannel(400626676070875156);
                await signalChannel.SendMessageAsync("", false, embeds.BuildEmbed().Build());
            }
            else
            {
                var communityChannel = (ISocketMessageChannel)Context.Client.GetChannel(401353571498721280);
                await communityChannel.SendMessageAsync("@everyone", false, embeds.BuildEmbed().Build());
            }
        }
    }
}
