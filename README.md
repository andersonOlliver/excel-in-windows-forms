# Teste Dotnet

Projeto escrito em Net Framework 4.5, com algumas features basicas do Excel.

A solução está organiada em 3 Aplicações:
 - Core: Todos os recursos compartilhados
 - Api: Webservice com os recursos a serem consumidos pela aplicação
 - App: Aplicação WPF

 As features implementadas foram:
  - Construção de uma massa de dados
  - Consulta a massa de dados - GET /api/operacao
  - Consulta agrupada - GET /api/operacao/{type}
  - Download dos dados em CSV - /api/file/csv/{type}
  - Download dos dados em XLS - GET /api/file/excel/{type}

Executando a API, pode se encontrar uma documentação completa através do endereço: http://localhost:61545/swagger.

O projeto está configurado para suportar multiplas inicialiações, portanto para executar a aplicação e a API (no Visual Studio) basta apertar F5.