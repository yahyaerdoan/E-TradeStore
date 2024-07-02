using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TradeStore.Application.Features.Cqrs.Commands.Category
{
    public class CreateCategoryCommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
