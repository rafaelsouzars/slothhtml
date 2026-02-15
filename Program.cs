using prompito.Prompito;
using slothhtml.src.Commands;

// Cria um Executer
var app = new Executer();

// Ativa o letreito
app.ScreenAbout(true);

// Insere as informações do app
app.InsertAppData(new
{
    AppName = "slothhtml",
    Version = "v1.1.0",
    Description = "Inicializador de projetos HTML5.",
    ProfileURL = "https://github.com/rafaelsouzars",
    RepositorieURL = "https://github.com/rafaelsouzars/slothhtml"
});

app.AddCommand("create", "Inicia um projeto HTML.", new CreateActionCommand());
app.AddCommand("search", "Pesquisar bibliotecas JS no repositório cdnjs.", new SearchActionCommand());
app.AddCommand("lib", "Requisita uma biblioteca JS do repositório do cdnjs.", new LibActionCommand());


// Recebe o array de argumentos do app
app.ExecuteCommands(args);
