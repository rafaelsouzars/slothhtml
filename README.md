# Sloth Html

Inicializador de projetos HTML5.

![Version](https://img.shields.io/badge/version-1.0-green) ![Status](https://img.shields.io/badge/status-development-yellow)


## Introdução

O Sloth Html é uma ferramenta CLI para inicialização rápida de projetos HTML5. Tem como objetivo facilitar a criação das estruturas de pastas e arquivos para pequenos projetos de estudo em HTML5.
Nota: A ideia final é emular o funcionamento do `composer PHP`, gerenciando via CLI as bibliotecas do projeto.

### **Comando:** _init_

Inicia uma pasta com arquivo _index.html_ e o diretorio de recursos _assets_ com seus respectivos subdiretórios: _css_, _font_, _img_ e _js_.

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
