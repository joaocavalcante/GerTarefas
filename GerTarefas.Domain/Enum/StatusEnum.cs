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

public static class StatusEnumExtensions
{
    public static string ToDescriptionString(this StatusEnum val)
    {
        DescriptionAttribute[] attributes = (DescriptionAttribute[])val
           .GetType()
           .GetField(val.ToString())
           .GetCustomAttributes(typeof(DescriptionAttribute), false);
        return attributes.Length > 0 ? attributes[0].Description : string.Empty;
    }
}
