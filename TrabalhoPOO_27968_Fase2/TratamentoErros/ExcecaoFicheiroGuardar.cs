using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TratamentoErros
{
    public class ExcecaoFicheiroGuardar : ApplicationException
    {
        public ExcecaoFicheiroGuardar() : base ("100") { }

        public ExcecaoFicheiroGuardar(string msg) 
        {
           throw new Exception(msg);
        }

        public ExcecaoFicheiroGuardar(Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}
