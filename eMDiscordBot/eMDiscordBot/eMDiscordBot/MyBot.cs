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
        CommandService commands;
        


        public MyBot()
        {

            setUpConsole();

            discord = new DiscordClient(x =>
                {
                    x.LogLevel = LogSeverity.Info;
                    x.LogHandler = log;

                });


            //Sets up commands
            discord.UsingCommands(x =>
            {
                x.PrefixChar = '!';
                x.AllowMentionPrefix = true;


            });
            commands = discord.GetService<CommandService>();

            //Registers commands
            hcommands();
            ip();
            hello();
            website();
            vote();


            //Connects bot to discord app
            discord.ExecuteAndWait(async () =>
            {
                await discord.Connect("MzE1ODAxMjA1MDg5NjMyMjU4.DAMBLQ.K3QR5CwMy2_QQp6mObLb5qoLPOM", TokenType.Bot);
            });

            }


        #region Commands

        
        private void hcommands()
        {
                        commands.CreateCommand("commands")
                .Do(async(e) =>
               { 
                 await e.Channel.SendMessage("!commands - Shows a list of all commands " +
                     "\r\n!ip - Shows the current server IP " +
                     "\r\n!website - Shows our website link" +
                     "\r\n!hello - Greets you" +
                     "\r\n!vote - Shows our voting links");
    
               });
        }

        private void ip()
        {
            commands.CreateCommand("ip")
                .Do(async (e) =>
                {

                    await e.Channel.SendMessage("The server IP is - eg-mc.xyz");
                });
        }

        private void hello()
        {

            commands.CreateCommand("Hello")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("Hello! " + e.User.Mention + "! Type !commands to view a list of all commands.");

                   

                });

        }

        private void website()
        {
            commands.CreateCommand("website")
                            .Do(async (e) =>
                            {
                                await e.Channel.SendMessage("Check out our website at - http://www.exhibit-minecraft.com");
                            });
        }


        private void vote()
        {
            commands.CreateCommand("vote")
                                        .Do(async (e) =>
                                        {
                                            await e.Channel.SendMessage("We appreciate all the votes we can get, it really has a huge impact on the server!" +
                                        "\r\n-----------" +
                                        "\r\nVoting Site 1 - http://minecraft-server-list.com/server/331452/vote/" +
                                        "\r\nVoting Site 2 - http://minecraft-mp.com/server/108491/vote/" +
                                        "\r\nVoting Site 3 - http://minecraftservers.org/server/330550" +
                                        "\r\n-----------" +
                                        "\r\nPlanet Minecraft - http://www.planetminecraft.com/server/exhibit-minecraft/vote" +
                                        "\r\nNote that Planet Minecraft is an Unlinked voting site.");

                                         
                                        });

        }


        #endregion

        #region ConsoleSetUp

        private void setUpConsole()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.Title = "Exhibit Minecraft Bot";
            Console.ForegroundColor = ConsoleColor.Blue;


        }


        #endregion

        private void log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }

        }
    }

