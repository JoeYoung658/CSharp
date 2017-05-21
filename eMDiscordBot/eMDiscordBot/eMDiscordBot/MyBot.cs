using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;

namespace eMDiscordBot
{
    class MyBot
    {

        DiscordClient discord;

        public MyBot()
        {
            discord = new DiscordClient(x =>
                {
                    x.LogLevel = LogSeverity.Info;
                    x.LogHandler = log;

                });


            discord.UsingCommands(x =>
            {
                x.AllowMentionPrefix = true;


            });

            var commands = discord.GetService<CommandService>();

            commands.CreateCommand("Hello")
                .Do(async (e) =>
                {

                    await e.Channel.SendMessage("Hello, yes this is all that I do.");
                });


            discord.ExecuteAndWait(async () =>
            {
                await discord.Connect("MzE1ODAxMjA1MDg5NjMyMjU4.DAMBLQ.K3QR5CwMy2_QQp6mObLb5qoLPOM", TokenType.Bot);
            });

            }

        private void log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }

        }
    }

