using GerTarefas.Domain.Entities;
using GerTarefas.Domain.Enum;

namespace GerTarefas.Test;
public class LogTaskTests
{
    [Test]
    public void Construtor_DeveLancarExcecaoQuandoDateInvalido()
    {
        // Arrange & Act & Assert
        Assert.Throws<ArgumentException>(() => new LogTask(default(DateTime), "Histórico", "Comentário", StatusEnum.PENDENTE, "usuario", 1));
    }

    [Test]
    public void Construtor_DeveLancarExcecaoQuandoHistoryInvalido()
    {
        // Arrange & Act & Assert
        Assert.Throws<ArgumentException>(() => new LogTask(DateTime.Now, "", "Comentário", StatusEnum.PENDENTE, "usuario", 1));
    }

    [Test]
    public void Construtor_DeveLancarExcecaoQuandoCommentInvalido()
    {
        // Arrange & Act & Assert
        Assert.Throws<ArgumentException>(() => new LogTask(DateTime.Now, "Histórico", "", StatusEnum.PENDENTE, "usuario", 1));
    }

    [Test]
    public void Construtor_DeveLancarExcecaoQuandoStatusTaskInvalido()
    {
        // Arrange & Act & Assert
        Assert.Throws<ArgumentException>(() => new LogTask(DateTime.Now, "Histórico", "Comentário", (StatusEnum)100, "usuario", 1));
    }

    [Test]
    public void Construtor_DeveLancarExcecaoQuandoUserNameInvalido()
    {
        // Arrange & Act & Assert
        Assert.Throws<ArgumentException>(() => new LogTask(DateTime.Now, "Histórico", "Comentário", StatusEnum.PENDENTE, "", 1));
    }

    [Test]
    public void Construtor_DeveLancarExcecaoQuandoTaskIDInvalido()
    {
        // Arrange & Act & Assert
        Assert.Throws<ArgumentException>(() => new LogTask(DateTime.Now, "Histórico", "Comentário", StatusEnum.PENDENTE, "usuario", 0));
    }

    [Test]
    public void Construtor_NaoDeveLancarExcecaoQuandoDadosValidos()
    {
        // Arrange & Act & Assert
        Assert.DoesNotThrow(() => new LogTask(DateTime.Now, "Histórico", "Comentário", StatusEnum.PENDENTE, "usuario", 1));
    }
}