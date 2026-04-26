using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prompito.Prompito.Classes;
using slothhtml.src.Utils;

namespace slothhtml.src.Commands
{
    internal class InfoActionCommand : ActionCommand
    {
        private readonly Dictionary<string, Dictionary<string, (string,string)>> infoItens = new Dictionary<string, Dictionary<string, (string,string)>>
        {
            {
                "commits", new Dictionary<string, (string,string)>
                {
                    { "init",
                        (
                        "Iniciando o projeto",
                        "Emojis - :tada: (Commit inicial)"
                        )
                    },
                    { "feat", 
                        (
                        "Commits do tipo feat indicam que seu trecho de código está incluindo um novo recurso (se relaciona com o MINOR do versionamento semântico).",
                        "Emojis - :sparkles: (Novo recurso) e :lipstick: (Estilização de interface)"
                        ) 
                    },
                    { "fix", 
                        (
                        "Commits do tipo fix indicam que seu trecho de código commitado está solucionando um problema (bug fix), (se relaciona com o PATCH do versionamento semântico).",
                        "Emojis - :bug: (Bugfix) e :boom: (Revertendo mudanças)"
                        )
                    },
                    { "docs", 
                        (
                        "Commits do tipo docs indicam que houveram mudanças na documentação, como por exemplo no Readme do seu repositório. (Não inclui alterações em código).",
                        "Emojis - :books: (Documentação)"
                        )
                    },
                    { "tests", 
                        (
                        "Commits do tipo test são utilizados quando são realizadas alterações em testes, seja criando, alterando ou excluindo testes unitários. (Não inclui alterações em código)",
                        "Emojis - :white_check_mark: (Acionando um teste), :heavy_check_mark: (Teste de aprovação) e :test_tube: (Testes)"
                        )
                    },
                    { "build", 
                        (
                        "Commits do tipo build são utilizados quando são realizadas modificações em arquivos de build e dependências.",
                        "Emojis - :heavy_plus_sign: (Add dependência), :package: (Package.json) e :heavy_minus_sign: (Remove dependência)"
                        )
                    },
                    { "perf", 
                        (
                        "Commits do tipo perf servem para identificar quaisquer alterações de código que estejam relacionadas a performance.",
                        "Emojis - :zap: (Performance)"
                        )
                    },
                    { "style", 
                        (
                        "Commits do tipo style indicam que houveram alterações referentes a formatações de código, semicolons, trailing spaces, lint... (Não inclui alterações em código).",
                        "Emojis - :ok_hand: (Alterações revisão do código)"
                        )
                    },
                    { "refactor", 
                        (
                        "Commits do tipo refactor referem-se a mudanças devido a refatorações que não alterem sua funcionalidade, como por exemplo, uma alteração no formato como é processada determinada parte da tela, mas que manteve a mesma funcionalidade, ou melhorias de performance devido a um code review.",
                        "Emojis - :recycle: (Refatoração)"
                        )
                    },
                    { "chore",
                        (
                        "Commits do tipo chore indicam atualizações de tarefas de build, configurações de administrador, pacotes... como por exemplo adicionar um pacote no gitignore. (Não inclui alterações em código)",
                        "Emojis - :wrench: (Configuração) e :truck: (Move/Renomear)"
                        )
                    },
                    { "ci", 
                        (
                        "Commits do tipo ci indicam mudanças relacionadas a integração contínua (continuous integration).",
                        "Emojis - :bricks: (Infraestrutura)"
                        )
                    },
                    { "raw",
                        (
                        "Commits do tipo raw indicam mudanças relacionadas a arquivos de configurações, dados, features, parâmetros.",
                        "Emojis - :card_file_box: (Dados)"
                        )
                    },
                    { "cleanup", 
                        (
                        "Commits do tipo cleanup são utilizados para remover código comentado, trechos desnecessários ou qualquer outra forma de limpeza do código-fonte, visando aprimorar sua legibilidade e manutenibilidade.",
                        "Emojis - :broom: (Limpeza de código)"
                        ) 
                    },
                    { "remove", 
                        (
                        "Commits do tipo remove indicam a exclusão de arquivos, diretórios ou funcionalidades obsoletas ou não utilizadas, reduzindo o tamanho e a complexidade do projeto e mantendo-o mais organizado.",
                        "Emojis - :wastebasket: (Removendo arquivo)"
                        )
                    }
                }
            }
        };
       
        public InfoActionCommand()
        {
        
        }

        public override void Run(ArgsMapper argsMapper)
        {
            try
            {
                MappedLineTester(argsMapper, "arg1", () => {
                    Help();
                    Console.WriteLine("Comando info");
                });

                MappedLineTester(argsMapper, "arg1 arg2 arg3", () => {
                    if (infoItens.ContainsKey(argsMapper.GetArgs("arg2"))) 
                    {
                        
                        if (infoItens[argsMapper.GetArgs("arg2")].ContainsKey(argsMapper.GetArgs("arg3"))) 
                        {
                            
                            var info = infoItens[argsMapper.GetArgs("arg2")][argsMapper.GetArgs("arg3")];
                            
                            var showMessage = new ScreenMessageShow(
                                new {
                                    title = argsMapper.GetArgs("arg3"),
                                    message = $"{info.Item1}\n{info.Item2}",
                                    color = Console.ForegroundColor
                                }
                            );
                        }
                        
                    }
                    
                });
            }
            catch (Exception error)
            {
                Console.WriteLine($"Error: {error.Message}");
            }
        }
    }
}
