using Blasphemous.CheatConsole;
using System;
using System.Collections.Generic;

namespace Blasphemous.DeathCounter
{
    public class DeathCounterCommand : ModCommand
    {
        protected override string CommandName => "deathcounter";

        protected override bool AllowUppercase => true;

        protected override Dictionary<string, Action<string[]>> AddSubCommands()
        {
            return new Dictionary<string, Action<string[]>>()
            {
                { "help", Help },
                { "current", Current },
                { "set", Set },
                { "reset", Reset }
            };
        }

        private void Help(string[] parameters)
        {
            if (!ValidateParameterList(parameters, 0)) return;

            Write("Available DEATHCOUNTER commands:");
            Write("deathcounter help: Show this list");
            Write("deathcounter current: Show current death count");
            Write("deathcounter set NUMBER: Set death count manually");
            Write("deathcounter reset: Reset death count to zero");
        }

        private void Current(string[] parameters)
        {
            if (!ValidateParameterList(parameters, 0)) return;

            if (Main.DeathCounter.Deaths == 0)
            {
                Write("You have not died yet!");
            }
            else
            {
                Write("You have died " + Main.DeathCounter.Deaths + " times!");
            }
        }

        private void Set(string[] parameters)
        {
            if (!ValidateParameterList(parameters, 1) || !ValidateIntParameter(parameters[0], 1, 10000, out int newDeaths)) return;

            Write("Setting death count to " + newDeaths);
            Main.DeathCounter.Deaths = newDeaths;
        }

        private void Reset(string[] parameters)
        {
            if (!ValidateParameterList(parameters, 0)) return;

            Write("Resetting death count to zero. Your death count was " + Main.DeathCounter.Deaths);
            Main.DeathCounter.Deaths = 0;
        }
    }
}