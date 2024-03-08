using System.ComponentModel;

namespace GerTarefas.Domain.Enum;

public enum StatusEnum
{
    [Description("Pendente")]
    PENDENTE = 1,
    [Description("Em andamento")]
    EMANDAMENTO = 2,
    [Description("Concluída")]
    CONCLUIDA = 3
}
