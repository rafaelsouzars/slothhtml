using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prompito.Prompito.Classes;
using slothhtml.src;

namespace slothhtml.src.Commands
{
    internal class CreateActionCommand : ActionCommand
    {
        public CreateActionCommand() {
            AddFlag(
                "-h",
                "--help",
                "Ajuda do comando create."
                );

            AddFlag(
                "-e",
                "--extension",
                "Create browser extension."
                );

        }

        public override void Run(ArgsMapper argsMapper)
        {
            base.Run(argsMapper);

            try
            {
                MappedLineTester(argsMapper, "arg1", () => {
                    //Console.WriteLine("Primeiro argumento: {0}", argsMapper.GetArgs("arg1"));
                    Procedimentos.CreateHtmlProject(null);
                });

                MappedLineTester(argsMapper, "arg1 arg2", () => {
                    //Console.WriteLine("Primeiro argumento: {0}", argsMapper.GetArgs("arg1"));
                    Procedimentos.CreateHtmlProject(argsMapper.GetArgs("arg2"));
                });

                MappedLineTester(argsMapper, "arg1 flag1", "flag1=-e", () => {
                    //Console.WriteLine("Primeiro argumento: {0}", argsMapper.GetArgs("arg1"));
                    Procedimentos.CreateBrowserExtensionProject();
                });

                MappedLineTester(argsMapper, "arg1 flag1 arg2", "flag1=-e",() => {
                    //Console.WriteLine("Primeiro argumento: {0}", argsMapper.GetArgs("arg1"));
                    Procedimentos.CreateBrowserExtensionProject(argsMapper.GetArgs("arg2"));
                });

                MappedLineTester(argsMapper, "arg1 flag1", "flag1=-h", () => {
                    Help();
                });
            }
            catch (Exception exception)
            {
                Console.WriteLine(" [ ERROR ]\n\t{0}", exception.ToString());
            }            
        }
    }
}
