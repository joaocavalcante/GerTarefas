using GerTarefas.Domain.Entities;

namespace GerTarefas.Test;
public class ProjectTests
{
    [Test]
    public void Construtor_DeveLancarExcecaoQuandoNomeInvalido()
    {
        // Arrange & Act & Assert
        Assert.Throws<ArgumentException>(() => new Project("", DateTime.Now, "usuario"));
    }

    [Test]
    public void Construtor_DeveLancarExcecaoQuandoDataInvalida()
    {
        // Arrange & Act & Assert
        Assert.Throws<ArgumentException>(() => new Project("Projeto Teste", default(DateTime), "usuario"));
    }

    [Test]
    public void Construtor_DeveLancarExcecaoQuandoUserNameInvalido()
    {
        // Arrange & Act & Assert
        Assert.Throws<ArgumentException>(() => new Project("Projeto Teste", DateTime.Now, ""));
    }

    [Test]
    public void Update_DeveLancarExcecaoQuandoNomeInvalido()
    {
        // Arrange
        var project = new Project("Projeto Teste", DateTime.Now, "usuario");

        // Act & Assert
        Assert.Throws<ArgumentException>(() => project.Update("", DateTime.Now, "usuario"));
    }

    [Test]
    public void Update_DeveLancarExcecaoQuandoDataInvalida()
    {
        // Arrange
        var project = new Project("Projeto Teste", DateTime.Now, "usuario");

        // Act & Assert
        Assert.Throws<ArgumentException>(() => project.Update("Projeto Teste", default(DateTime), "usuario"));
    }

    [Test]
    public void Update_DeveLancarExcecaoQuandoUserNameInvalido()
    {
        // Arrange
        var project = new Project("Projeto Teste", DateTime.Now, "usuario");

        // Act & Assert
        Assert.Throws<ArgumentException>(() => project.Update("Projeto Teste", DateTime.Now, ""));
    }

    [Test]
    public void Construtor_NaoDeveLancarExcecaoQuandoDadosValidos()
    {
        // Arrange & Act & Assert
        Assert.DoesNotThrow(() => new Project("Projeto Teste", DateTime.Now, "usuario"));
    }

    [Test]
    public void Update_NaoDeveLancarExcecaoQuandoDadosValidos()
    {
        // Arrange
        var project = new Project("Projeto Teste", DateTime.Now, "usuario");

        // Act & Assert
        Assert.DoesNotThrow(() => project.Update("Projeto Atualizado", DateTime.Now.AddDays(1), "usuario"));
    }
}