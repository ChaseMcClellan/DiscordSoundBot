using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Extensions;
using FreddyFazbear.commands;
using DSharpPlus.VoiceNext;
using System;
using System.Threading.Tasks;
namespace FreddyFazbear
{
    public class Program
    {
        private static DiscordClient dc { get; set; }
        private static VoiceNextExtension voice { get; set; }
        private static CommandsNextExtension cne { get; set; }
        static async Task Main(string[] args)
        {
            var JSONreader = new JSONreader();
            await JSONreader.ReadJSON();
            var discordConfig = new DiscordConfiguration()
            {
                Intents = DiscordIntents.All,
                Token = JSONreader.token,
                TokenType = TokenType.Bot,
                AutoReconnect = true

            };

            dc = new DiscordClient(discordConfig);

            dc.Ready += Dc_Ready;
            var commandsConfig = new CommandsNextConfiguration()
            {
                StringPrefixes = new string[] { JSONreader.prefix },
                EnableMentionPrefix = true,
                EnableDms = false,
                EnableDefaultHelp = false
            };

            cne = dc.UseCommandsNext(commandsConfig);

            cne.RegisterCommands<testCommands>();
            voice = dc.UseVoiceNext();
            await dc.ConnectAsync();
            await Task.Delay(-1);
            
            dc = new DiscordClient(discordConfig);
            dc.UseInteractivity(new InteractivityConfiguration()
            {
                Timeout = TimeSpan.FromMinutes(5)
            });


        }

         

        private static System.Threading.Tasks.Task Dc_Ready(DiscordClient sender, DSharpPlus.EventArgs.ReadyEventArgs args)
        {
            return Task.CompletedTask;
        }
    }
}
  