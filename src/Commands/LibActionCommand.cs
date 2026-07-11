using System;
using prompito.Prompito.Classes;

namespace slothhtml.src.Commands
{
    internal class LibActionCommand : ActionCommand
    {
        public LibActionCommand() {
            AddFlag(
                "-h",
                "--help",
                "Ajuda do comando Lib"
                );
        }

        public override void Run(ArgsMapper argsMapper)
        {
            //base.Run(argsMapper);

            MappedLineTester(argsMapper, "arg1", () => {
                Console.WriteLine("Primeiro argumento: {0}", argsMapper.GetArgs("arg1"));
            });

            MappedLineTester(argsMapper, "arg1 flag1", "flag1=-h", () => {
                Help();
            });
        }
    }
}
