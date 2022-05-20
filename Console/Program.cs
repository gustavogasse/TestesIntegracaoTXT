// See https://aka.ms/new-console-template for more information

using Domain.Repository;
using Domain.Services;


var importacaoService = new ImportacaoService();
importacaoService.Executar(new ArquivoSaidaRepository(), caminhoArquivo);


Console.WriteLine("Hello, World!");
