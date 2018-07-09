using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Promocoes.Domain
{
    public class DefinicaoTipos
    {
        public SelectList ListaPromocoes = new SelectList(
                                                new List<object>{
                                                        new { value = 0 , text = "Nenhuma"  },
                                                        new { value = 1 , text = "Pague 1 e Leve 2"  },
                                                        new { value = 2 , text = "3 por 10 reais"  }
                                                    },
                                                    "value",
                                                    "text");
        public string RetornarDescPromocao(int idPromo)
        {
            string descPromo = "";

            foreach (var item in ListaPromocoes)
            {
                if (Int32.Parse(item.Value) == idPromo)
                {
                    descPromo = item.Text;
                    break;
                }
            }

            return descPromo;
        }
    }
}
