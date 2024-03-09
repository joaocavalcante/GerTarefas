using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerTarefas.Domain.Enum;

public enum PrioriryEnum
{
    [Description("Baixa")]
    BAIXA = 1,
    [Description("Média")]
    MEDIA = 2,
    [Description("Alta")]
    ALTA = 3
}

public static class PrioriryEnumExtensions
{
    public static string ToDescriptionString(this PrioriryEnum val)
    {
        DescriptionAttribute[] attributes = (DescriptionAttribute[])val
           .GetType()
           .GetField(val.ToString())
           .GetCustomAttributes(typeof(DescriptionAttribute), false);
        return attributes.Length > 0 ? attributes[0].Description : string.Empty;
    }
}
