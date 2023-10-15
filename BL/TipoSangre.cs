using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class TipoSangre
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.RgeronimoHospitalContext context = new DL.RgeronimoHospitalContext())
                {
                    var query = (from tipoSangre in context.TipoSangres
                                 orderby tipoSangre.Nombre ascending
                                 select tipoSangre).ToList();
                    result.Objects = new List<object>();

                    if (query != null && query.ToList().Count > 0)
                    {
                        foreach (var item in query)
                        {
                            ML.TipoSangre tipoSangre = new ML.TipoSangre();
                            tipoSangre.IdTipoSangre = item.IdTipoSangre;
                            tipoSangre.Nombre = item.Nombre;

                            result.Objects.Add(tipoSangre);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Lista vacia";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }
}
