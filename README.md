# Sloth Html

HTML5 project starter.

![Version](https://img.shields.io/badge/version-1.0.0-green) ![Status](https://img.shields.io/badge/status-development-yellow) ![GitHub Tag](https://img.shields.io/github/v/tag/rafaelsouzars/slothhtml) ![GitHub Release](https://img.shields.io/github/v/release/rafaelsouzars/slothhtml) ![GitHub top language](https://img.shields.io/github/languages/top/rafaelsouzars/slothhtml?color=green)

#### README Languages:
#### - [Versão em português-BR do README](https://github.com/rafaelsouzars/slothhtml/blob/master/README_PT-BR.md)

## Introduction

Sloth Html is a CLI tool for quickly starting HTML5 projects. Its purpose is to facilitate the creation of folder and file structures for small HTML5 study projects.
Note: The final idea is to emulate the operation of `composer PHP`, managing the project libraries via CLI.

### **Command:** _init_

Initializes a folder with the _index.html_ file, the _vendor_ directory _(for third-party resources)_ and the _assets_ resource directory with their respective subdirectories: _css_, _font_, _img_, scss and _js_.

>**slothhtml init** _or_ **slothhtml init 'name-project'**

### **Command:** _help_

Shows the application's command list.

>**slothhtml help**

### **Command:** _search_

Searches for a library in [cdnjs](https://www.cdnjs.com).

>**slothhtml search 'lib-name'**

## Task list:

- [x] Develop the project's base interpreter
- [x] Create a basic command library
- [ ] Create a project configuration file
- [ ] Create library management functionality
