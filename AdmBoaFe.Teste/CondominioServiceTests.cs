using AdmBoaFe.Business.Intefaces;
using AdmBoaFe.Business.Models;
using AdmBoaFe.Business.Models.Validations;
using AdmBoaFe.Business.Notificacoes;
using AdmBoaFe.Business.Services;
using FluentAssertions;
using Moq;
using System;
using Xunit;

namespace AdmBoaFe.Teste
{
    public class CondominioServiceTests
    {
        [Fact]
        public void Adicionar_Deve_AdicionarCondominioQuandoValido()
        {
            // Arrange
            var condominioRepositoryMock = new Mock<ICondominioRepository>();
            var proprietarioRepositoryMock = new Mock<IProprietarioRepository>();
            var notificadorMock = new Mock<INotificador>();

            var condominioService = new CondominioService(
                condominioRepositoryMock.Object,
                proprietarioRepositoryMock.Object,
                notificadorMock.Object
            );

            var condominio = new Condominio
            {
                // Preencha os campos do condomínio conforme necessário
            };

            // Act
            condominioService.Adicionar(condominio);

            // Assert
            condominioRepositoryMock.Verify(r => r.Adicionar(condominio), Times.Once);
            notificadorMock.Verify(n => n.Handle(It.IsAny<Notificacao>()), Times.Never);

        }

        [Fact]
        public void Adicionar_NaoDeveAdicionarCondominioQuandoInvalido()
        {
            // Arrange
            var condominioRepositoryMock = new Mock<ICondominioRepository>();
            var proprietarioRepositoryMock = new Mock<IProprietarioRepository>();
            var notificadorMock = new Mock<INotificador>();

            var condominioService = new CondominioService(
                condominioRepositoryMock.Object,
                proprietarioRepositoryMock.Object,
                notificadorMock.Object
            );

            var condominio = new Condominio
            {
                // Preencha os campos do condomínio de forma que seja inválido
            };

            // Act
            condominioService.Adicionar(condominio);

            // Assert
            condominioRepositoryMock.Verify(r => r.Adicionar(condominio), Times.Never);
            notificadorMock.Verify(n => n.Handle(It.IsAny<Notificacao>()), Times.Never);

        }

    }
}
