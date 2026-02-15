using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prompito.Prompito.Classes;
using slothhtml.src;

namespace slothhtml.src.Commands
{
    internal class SearchActionCommand : ActionCommand
    {
        public SearchActionCommand() {
            AddFlag(
                "-h",
                "--help",
                "Ajuda do comando Search"
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

                MappedLineTester(argsMapper, "arg1 arg2", () => {
                    //Console.WriteLine("Primeiro argumento: {0}", argsMapper.GetArgs("arg1"));
                    Procedimentos.LibsSearch(argsMapper.GetArgs("arg2")).Wait();
                });

                MappedLineTester(argsMapper, "arg1 flag1", "flag1=-h", () => {
                    Help();
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(" [ ERROR ]\n\t{0}", e.Message);
            }
            

        }
    }
}
