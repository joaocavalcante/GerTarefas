using GerTarefas.Domain.Entities;
using GerTarefas.Domain.Enum;

namespace GerTarefas.Test;

public class TaskProjectTests
{
    [Test]
    public void Construtor_DeveLancarExcecaoQuandoTitleInvalido()
    {
        // Arrange & Act & Assert
        Assert.Throws<ArgumentException>(() => new TaskProject("", "Descri��o", DateTime.Now, StatusEnum.PENDENTE, PrioriryEnum.ALTA, "Coment�rio", 1, "usuario"));
    }

    [Test]
    public void Construtor_DeveLancarExcecaoQuandoDescriptionInvalido()
    {
        // Arrange & Act & Assert
        Assert.Throws<ArgumentException>(() => new TaskProject("T�tulo", "", DateTime.Now, StatusEnum.PENDENTE, PrioriryEnum.ALTA, "Coment�rio", 1, "usuario"));
    }

    [Test]
    public void Construtor_DeveLancarExcecaoQuandoDueDateInvalido()
    {
        // Arrange & Act & Assert
        Assert.Throws<ArgumentException>(() => new TaskProject("T�tulo", "Descri��o", default(DateTime), StatusEnum.PENDENTE, PrioriryEnum.ALTA, "Coment�rio", 1, "usuario"));
    }

    [Test]
    public void Construtor_DeveLancarExcecaoQuandoCommentInvalido()
    {
        // Arrange & Act & Assert
        Assert.Throws<ArgumentException>(() => new TaskProject("T�tulo", "Descri��o", DateTime.Now, StatusEnum.PENDENTE, PrioriryEnum.ALTA, "", 1, "usuario"));
    }

    [Test]
    public void Construtor_DeveLancarExcecaoQuandoUserNameInvalido()
    {
        // Arrange & Act & Assert
        Assert.Throws<ArgumentException>(() => new TaskProject("T�tulo", "Descri��o", DateTime.Now, StatusEnum.PENDENTE, PrioriryEnum.ALTA, "Coment�rio", 1, ""));
    }

    [Test]
    public void Construtor_DeveLancarExcecaoQuandoProjectIDInvalido()
    {
        // Arrange & Act & Assert
        Assert.Throws<ArgumentException>(() => new TaskProject("T�tulo", "Descri��o", DateTime.Now, StatusEnum.PENDENTE, PrioriryEnum.ALTA, "Coment�rio", 0, "usuario"));
    }

    [Test]
    public void Update_DeveLancarExcecaoQuandoDescriptionInvalido()
    {
        // Arrange
        var task = new TaskProject("T�tulo", "Descri��o", DateTime.Now, StatusEnum.PENDENTE, PrioriryEnum.ALTA, "Coment�rio", 1, "usuario");

        // Act & Assert
        Assert.Throws<ArgumentException>(() => task.Update("", StatusEnum.PENDENTE, "Novo Coment�rio", "novoUsuario"));
    }

    [Test]
    public void Update_DeveLancarExcecaoQuandoStatusInvalido()
    {
        // Arrange
        var task = new TaskProject("T�tulo", "Descri��o", DateTime.Now, StatusEnum.PENDENTE, PrioriryEnum.ALTA, "Coment�rio", 1, "usuario");

        // Act & Assert
        Assert.Throws<ArgumentException>(() => task.Update("Nova Descri��o", (StatusEnum)100, "Novo Coment�rio", "novoUsuario"));
    }

    [Test]
    public void Update_DeveLancarExcecaoQuandoCommentInvalido()
    {
        // Arrange
        var task = new TaskProject("T�tulo", "Descri��o", DateTime.Now, StatusEnum.PENDENTE, PrioriryEnum.ALTA, "Coment�rio", 1, "usuario");

        // Act & Assert
        Assert.Throws<ArgumentException>(() => task.Update("Nova Descri��o", StatusEnum.PENDENTE, "", "novoUsuario"));
    }

    [Test]
    public void Update_DeveLancarExcecaoQuandoUserNameInvalido()
    {
        // Arrange
        var task = new TaskProject("T�tulo", "Descri��o", DateTime.Now, StatusEnum.PENDENTE, PrioriryEnum.ALTA, "Coment�rio", 1, "usuario");

        // Act & Assert
        Assert.Throws<ArgumentException>(() => task.Update("Nova Descri��o", StatusEnum.PENDENTE, "Novo Coment�rio", ""));
    }

    [Test]
    public void Construtor_NaoDeveLancarExcecaoQuandoDadosValidos()
    {
        // Arrange & Act & Assert
        Assert.DoesNotThrow(() => new TaskProject("T�tulo", "Descri��o", DateTime.Now, StatusEnum.PENDENTE, PrioriryEnum.ALTA, "Coment�rio", 1, "usuario"));
    }

    [Test]
    public void Update_NaoDeveLancarExcecaoQuandoDadosValidos()
    {
        // Arrange
        var task = new TaskProject("T�tulo", "Descri��o", DateTime.Now, StatusEnum.PENDENTE, PrioriryEnum.ALTA, "Coment�rio", 1, "usuario");

        // Act & Assert
        Assert.DoesNotThrow(() => task.Update("Nova Descri��o", StatusEnum.PENDENTE, "Novo Coment�rio", "novoUsuario"));
    }
}
