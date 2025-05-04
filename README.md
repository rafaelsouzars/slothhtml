# Sloth Html

Inicializador de projetos HTML5.

![Version](https://img.shields.io/badge/version-1.0.0-green) ![Status](https://img.shields.io/badge/status-development-yellow) ![GitHub Tag](https://img.shields.io/github/v/tag/rafaelsouzars/slothhtml) ![GitHub Release](https://img.shields.io/github/v/release/rafaelsouzars/slothhtml) ![GitHub top language](https://img.shields.io/github/languages/top/rafaelsouzars/slothhtml?color=green)



## Introdução

O Sloth Html é uma ferramenta CLI para inicialização rápida de projetos HTML5. Tem como objetivo facilitar a criação das estruturas de pastas e arquivos para pequenos projetos de estudo em HTML5.
Nota: A ideia final é emular o funcionamento do `composer PHP`, gerenciando via CLI as bibliotecas do projeto.

### **Comando:** _init_

Inicia uma pasta com arquivo _index.html_, o diretorio _vendor_ _(para recursos de terceiros)_ e o diretorio de recursos _assets_ com seus respectivos subdiretórios: _css_, _font_, _img_, scss e _js_.

>**slothhtml init** _ou_ **slothhtml init 'name-project'**


### **Comando:** _help_

Mostra a lista de comando do aplicativo.

>**slothhtml help**


### **Comando:** _search_

Procura por uma biblioteca no [cdnjs](https://www.cdnjs.com).

>**slothhtml search 'nome-da-lib'**

## Lista de tarefas:

- [ ] Desenvolver o interpretador base do projeto
- [ ] Criar arquivo de configuração do projeto
- [ ] Criar biblioteca básica de comandos
- [ ] Criar funcionalidade de gerenciamento de bibliotecas
