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
