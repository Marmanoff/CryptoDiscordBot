using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoDiscordBot.Classes
{
    public class Rank
    {
        public Rank(int myUses, string userName)
        {
            MyUses = myUses;
            UserName = userName;
        }

        EmbedBuilder eb = new EmbedBuilder();

        public EmbedBuilder MessageWithRankup()
        {
            var eb = new EmbedBuilder();
            eb.WithAuthor("Stats for " + UserName);
            eb.WithDescription("**Users Invited: **" + MyUses.ToString() + "\n**Current Rank: **" + CurrentRank + "\n**Invites to Rankup: **" + InvitesNeeded + "\n**Next Rank: **" + NextRank + "\n**Voting Power: **" + VotePower);
            eb.WithColor(1042103);
            eb.ThumbnailUrl = thumbNailUrl;
            return eb;
        }

        public EmbedBuilder MessageWithNoRankup()
        {
            var eb = new EmbedBuilder();
            eb.WithAuthor("Stats for " + UserName);
            eb.WithDescription("**Users Invited: **" + MyUses + "\n" + "**Current Rank: **" + CurrentRank + "\n" + "**Voting Power: **" + VotePower);
            eb.WithColor(1042103);
            eb.ThumbnailUrl = thumbNailUrl;
            return eb;
        }
        private string _CurrentRank;
        private string _NextRank;
        private int _InvitesNeeded;
        private int _UserName;
        private int _VotePower;
        private string _thumbNailUrl;

        public int MyUses { get; set; }
        public string CurrentRank
        {
            get
            {
                if (MyUses >= 0 && MyUses <= 9)
                {
                    return "SILVER";
                }
                else if (MyUses >= 10 && MyUses <= 24)
                {
                    return "GOLD";
                }
                else if (MyUses >= 25 && MyUses <= 49)
                {
                    return "PLATINA";
                }
                else
                {
                    return "DIAMOND";
                }
            }
            set
            {
                value = _CurrentRank;
            }
        }
        public string NextRank
        {
            get
            {
                if (CurrentRank.Equals("SILVER"))
                {
                    return "GOLD";
                }
                else if (CurrentRank.Equals("GOLD"))
                {
                    return "PLATINA";
                }
                else
                {
                    return "DIAMOND";
                }
            }
            set
            {
                value = _NextRank;
            }
        }
        public int InvitesNeeded
        {
            get
            {
                if (MyUses >= 0 && MyUses <= 9)
                {
                    return 10 - MyUses;
                }
                else if (MyUses >= 10 && MyUses <= 24)
                {
                    return 25 - MyUses;
                }
                else
                {
                    return 50 - MyUses;
                }
            }
            set
            {
                value = _InvitesNeeded;
            }
        }
        public string UserName { get; set; }
        public int VotePower
        {
            get
            {
                if (CurrentRank.Equals("SILVER"))
                {
                    return 1;
                }
                else if (CurrentRank.Equals("GOLD"))
                {
                    return 2;
                }
                else if (CurrentRank.Equals("PLATINA"))
                {
                    return 3;
                }
                else
                {
                    return 4;
                }
            }
            set
            {
                value = _VotePower;
            }
        }
        public string thumbNailUrl
        {

            get
            {
                if (CurrentRank.Equals("SILVER"))
                {
                    return "https://puu.sh/zbrEy/41fbe6a765.png";
                }
                else if (CurrentRank.Equals("GOLD"))
                {
                    return "https://puu.sh/zbrFF/7ee8119a9b.png";
                }
                else if (CurrentRank.Equals("PLATINA"))
                {
                    return "https://puu.sh/zbrGO/6ebcee253c.png";
                }
                else
                {
                    return "https://puu.sh/zbrGh/88b7c13da4.png";
                }
            }
            set
            {
                value = _thumbNailUrl;
            }
        }
    }
}
