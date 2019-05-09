using Discord;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoDiscordBot.Classes
{
    public class MessageEmbed
    {
        public MessageEmbed(DateTime date, double hours, double minutes)
        {
            CultureInfo newCulture;
            newCulture = new CultureInfo("en-US");
            _newCulture = newCulture;
            _pumpDate = date.AddHours(hours).AddMinutes(minutes);
            _timeSpan = _pumpDate - DateTime.Now;
            _hour = _timeSpan.Hours.ToString();
            _minute = _timeSpan.Minutes.ToString();
            _day = _timeSpan.Days.ToString();
            _london = _london = DateTime.Parse(_pumpDate.AddHours(-1).ToString(), NewCulture);
            _newYork = _newYork = DateTime.Parse(_pumpDate.AddHours(-6).ToString(), NewCulture);
            _sweden = _sweden = DateTime.Parse(_pumpDate.ToString(), NewCulture);
            _seoul = _seoul = DateTime.Parse(_pumpDate.AddHours(8).ToString(), NewCulture);
        }

        const string exchange = "Kucoin";
        const string exchangeReferralLink = "https://www.kucoin.com/#/?r=2gsJM";

        private TimeSpan _timeSpan;
        private string _hour;
        private string _minute;
        private string _day;
        private DateTime _date;
        private DateTime _london;
        private DateTime _newYork;
        private DateTime _sweden;
        private DateTime _seoul;
        private DateTime _pumpDate;
        private CultureInfo _newCulture;

        public EmbedBuilder BuildEmbed()
        {
            var eb = new EmbedBuilder
            {
                Title = "Sign up to " + exchange
            };
            if (TimeSpan.Days == 0 && TimeSpan.Hours != 0 || TimeSpan.Days == 0 && TimeSpan.Minutes != 0)
            {
                eb.WithAuthor("Pump will be in " + TimeSpan.Hours + " hours and " + TimeSpan.Minutes + " minutes.");
            }
            else
            {
                eb.WithAuthor("Pump will be in " + TimeSpan.Days + " days, " + TimeSpan.Hours + " hours and " + TimeSpan.Minutes + " minutes.");
            }

            eb.Url = exchangeReferralLink;
            eb.ThumbnailUrl = "https://puu.sh/zbrt1/01c3a7da72.png";
            eb.Description = "**" +
                London.ToString("HH:mm" + " ") + London.DayOfWeek.ToString().Substring(0, 3) + London.ToString(", MMM d tt") + "GMT (London)\n" +
                NewYork.ToString("HH:mm" + " ") + NewYork.DayOfWeek.ToString().Substring(0, 3) + NewYork.ToString(", MMM d tt") + "EST (New York)\n" +
                Sweden.ToString("HH:mm" + " ") + Sweden.DayOfWeek.ToString().Substring(0, 3) + Sweden.ToString(", MMM d tt") + "CET (Sweden)\n" +
                Seoul.ToString("HH:mm" + " ") + Seoul.DayOfWeek.ToString().Substring(0, 3) + Seoul.ToString(", MMM d tt") + "GMT+9 (Seoul)" + "**";
            eb.WithFooter("Countdown can be found on my status, on the right side bar. \n Pump will be on " + exchange + ". Make sure to sign up and transfer funds. We will trade using BTC Pairing.");
            eb.WithColor(10957198);
            return eb;
        }

        public TimeSpan TimeSpan
        {
            get { return _timeSpan; }
            set { _timeSpan = value; }
        }
        public string Hour
        {
            get
            {
                _hour = _timeSpan.ToString(@"hh");
                return _hour;
            }
            set { _hour = value; }
        }
        public string Minute
        {
            get
            {
                _minute = _timeSpan.ToString(@"mm");
                return _minute;
            }
            set { _minute = value; }
        }
        public string Day
        {
            get
            {
                _day = _timeSpan.ToString(@"%d");
                return _day;
            }
            set { _day = value; }
        }
        public CultureInfo NewCulture
        {
            get { return _newCulture; }
            set { _newCulture = value; }
        }
        public DateTime London
        {
            get { return _london; }
            set { _london = value; }
        }
        public DateTime NewYork
        {
            get { return _newYork; }
            set { _newYork = value; }
        }
        public DateTime Sweden
        {
            get { return _sweden; }
            set { _sweden = value; }
        }
        public DateTime Seoul
        {
            get { return _seoul; }
            set { _seoul = value; }
        }
        public DateTime PumpDate
        {
            get { return _pumpDate; }
            set { _pumpDate = value; }
        }
    }
}
