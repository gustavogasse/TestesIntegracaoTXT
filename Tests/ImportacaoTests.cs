using Domain.DTO;
using Domain.Interfaces.Repository;
using Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class ImportacaoTests
    {
        private IArquivoSaidaRepository _saidaRepository;

        [TestMethod]
        public void DeveRetornarLista()
        {            
            var service = new ArquivoSaidaService(_saidaRepository, GerarArquivosDeEntradaParaTeste());
            service.Importar(out int quantidadeValidados, out int quantidadeComErro);

            Assert.AreEqual(2, quantidadeValidados);
            Assert.AreEqual(2, quantidadeComErro);
        }

        private List<ArquivoEntradaDTO> GerarArquivosDeEntradaParaTeste()
        {
            return new List<ArquivoEntradaDTO>()
            {
                new ArquivoEntradaDTO()
                {
                    DataDaOperacao = DateTime.Now,
                    CodigoDoClienteOuCarteira = "CARTEIRA CLIENTE A",
                    TipoDaOperacao = "Compra",
                    IdDaBolsa = "BVSP",
                    CodigoDoAtivo = "PETR4",
                    Corretora = "AGORA",
                    Quantidade = 50,
                    PrecoUnitario = 100
                },

                new ArquivoEntradaDTO()
                {
                    DataDaOperacao = DateTime.Now,
                    CodigoDoClienteOuCarteira = "CARTEIRA CLIENTE B",
                    TipoDaOperacao = "Compra",
                    IdDaBolsa = "BVSPX",
                    CodigoDoAtivo = "VALE3",
                    Corretora = "AGORA",
                    Quantidade = 150,
                    PrecoUnitario = 10
                },

                new ArquivoEntradaDTO()
                {
                    DataDaOperacao = DateTime.Now,
                    CodigoDoClienteOuCarteira = "CARTEIRA CLIENTE C",
                    TipoDaOperacao = "Venda",
                    IdDaBolsa = "BVSP",
                    CodigoDoAtivo = "PETR4",
                    Corretora = "AGORA",
                    Quantidade = 1000,
                    PrecoUnitario = 59
                },

                new ArquivoEntradaDTO()
                {
                    DataDaOperacao = DateTime.Now,
                    CodigoDoClienteOuCarteira = "CARTEIRA CLIENTE D",
                    TipoDaOperacao = "Compra",
                    IdDaBolsa = "BVSP",
                    CodigoDoAtivo = "PETR4",
                    Corretora = "AGORA",
                    Quantidade = 50,
                    PrecoUnitario = 100
                }
            };
        }
    }
}
