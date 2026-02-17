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
                "-w",
                "--webpage",
                "Create webpage. Ex: slothhtml create [-w or --webpage] [<project_name> or null]"
                );

            AddFlag(
                "-e",
                "--extension",
                "Create browser extension. Ex: slothhtml create [-e or --extension] [<project_name> or null]"
                );

        }

        public override void Run(ArgsMapper argsMapper)
        {
            //base.Run(argsMapper);

            try
            {
                MappedLineTester(argsMapper, "arg1", () => {
                    Help();
                });

                MappedLineTester(argsMapper, "arg1 flag1", "flag1=-w", () => {                    
                    Procedimentos.CreateHtmlProject();
                });

                MappedLineTester(argsMapper, "arg1 flag1 arg2", "flag1=-w", () => {                    
                    Procedimentos.CreateHtmlProject(argsMapper.GetArgs("arg2"));
                });

                MappedLineTester(argsMapper, "arg1 flag1", "flag1=-e", () => {                    
                    Procedimentos.CreateBrowserExtensionProject();
                });

                MappedLineTester(argsMapper, "arg1 flag1 arg2", "flag1=-e",() => {                    
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
