using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TratamentoErros
{
    public class ExcecaoFicheiroCarregar : ApplicationException
    {
        public ExcecaoFicheiroCarregar() : base ("150") { }

        public ExcecaoFicheiroCarregar(string msg)
        {
            throw new Exception(msg);
        }

        public ExcecaoFicheiroCarregar(Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}
