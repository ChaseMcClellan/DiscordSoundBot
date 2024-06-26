using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Net.WebSocket;
using DSharpPlus.VoiceNext;
using DSharpPlus.Interactivity.Extensions;
using System.Threading.Tasks;
using System.Xml;
using System;

namespace FreddyFazbear.commands
{
    public class testCommands : BaseCommandModule
    {
        [Command("test")]
        public async Task MyFirstCommand(CommandContext cc)
        {
            await cc.TriggerTypingAsync();
            await cc.Channel.SendMessageAsync($"Hello {cc.User.Username} har har har");
        }

        [Command("bruh")]
        public async Task AnotherTest(CommandContext cc, int b)
        {
            if (cc == null || b > 1)
            {
                await cc.Channel.SendMessageAsync("Please enter a number less than four har har har");
            }
            else
            {
                for (int i = 0; i < b; i++)
                {
                    await cc.Channel.ConnectAsync();
                }
            }

        }

        [Command("join")]
        public async Task Join(CommandContext ctx)
        {
            var vnext = ctx.Client.GetVoiceNext();
            var vnc = vnext.GetConnection(ctx.Guild);
            var chn = ctx.Member?.VoiceState?.Channel;
            vnc = await vnext.ConnectAsync(chn);
            await ctx.Channel.SendMessageAsync("Connected!");


        }


        [Command("leave")]
        public async Task Leave(CommandContext ctx)
        {
            var vnext = ctx.Client.GetVoiceNext();
            var vnc = vnext.GetConnection(ctx.Guild);
            var chn = ctx.Member?.VoiceState?.Channel;
            if (vnc != null)
            {
            vnc.Disconnect();
            await ctx.Channel.SendMessageAsync("Disconnected!");
            }
            Console.WriteLine("bad! this means I have a null vnc");
            
        }
    }
}
