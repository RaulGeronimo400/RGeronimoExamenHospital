using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Paciente
    {
        public static ML.Result Add(ML.Paciente paciente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.RgeronimoHospitalContext context = new DL.RgeronimoHospitalContext())
                {
                    DL.Paciente pacienteDL = new DL.Paciente();

                    pacienteDL.Nombre = paciente.Nombre;
                    pacienteDL.Ap = paciente.AP;
                    pacienteDL.Am = paciente.AM;
                    pacienteDL.FechaNacimiento = DateTime.Parse(paciente.FechaNacimiento);
                    pacienteDL.FechaIngreso = DateTime.Parse(paciente.FechaIngreso);
                    pacienteDL.IdTipoSangre = paciente.Tipo.IdTipoSangre;
                    pacienteDL.Sexo = paciente.Sexo;
                    pacienteDL.Sintomas = paciente.Sintomas;

                    context.Pacientes.Add(pacienteDL);
                    context.SaveChanges();

                    result.Correct = true;

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
        public static ML.Result Update(ML.Paciente paciente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.RgeronimoHospitalContext context = new DL.RgeronimoHospitalContext())
                {
                    var query = (from pacienteLQ in context.Pacientes
                                 where pacienteLQ.IdPaciente == paciente.IdPaciente
                                 select pacienteLQ).SingleOrDefault();

                    if (query != null)
                    {
                        query.Nombre = paciente.Nombre;
                        query.Ap = paciente.AP;
                        query.Am = paciente.AM;
                        query.FechaNacimiento = DateTime.Parse(paciente.FechaNacimiento);
                        query.FechaIngreso = DateTime.Parse(paciente.FechaIngreso);
                        query.IdTipoSangre = paciente.Tipo.IdTipoSangre;
                        query.Sexo = paciente.Sexo;
                        query.Sintomas = paciente.Sintomas;

                        context.SaveChanges();
                        result.Correct = true;
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
        public static ML.Result Delete(int IdPaciente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.RgeronimoHospitalContext context = new DL.RgeronimoHospitalContext())
                {
                    var query = (from pacienteLQ in context.Pacientes
                                 where pacienteLQ.IdPaciente == IdPaciente
                                 select pacienteLQ).First();

                    context.Pacientes.Remove(query);
                    context.SaveChanges();
                    result.Correct = true;
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
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.RgeronimoHospitalContext context = new DL.RgeronimoHospitalContext())
                {
                    var query = (from pacienteLQ in context.Pacientes
                                 join tipoSangre in context.TipoSangres
                                 on pacienteLQ.IdTipoSangre equals tipoSangre.IdTipoSangre
                                 orderby pacienteLQ.Nombre ascending
                                 select new
                                 {
                                     pacienteLQ,
                                     tipoSangre
                                 }).ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var item in query)
                        {
                            ML.Paciente paciente = new ML.Paciente();
                            paciente.Tipo = new ML.TipoSangre();

                            paciente.IdPaciente = item.pacienteLQ.IdPaciente;
                            paciente.Nombre = item.pacienteLQ.Nombre;
                            paciente.AP = item.pacienteLQ.Ap;
                            paciente.AM = item.pacienteLQ.Am;
                            paciente.FechaNacimiento = item.pacienteLQ.FechaNacimiento.Value.ToString("dd / MMMM / yyyy");
                            paciente.FechaIngreso = item.pacienteLQ.FechaIngreso.Value.ToString("dd / MMMM / yyyy tt");
                            paciente.Tipo.IdTipoSangre = item.pacienteLQ.IdTipoSangre.Value;
                            paciente.Tipo.Nombre = item.tipoSangre.Nombre;
                            paciente.Sexo = item.pacienteLQ.Sexo;
                            paciente.Sintomas = item.pacienteLQ.Sintomas;

                            result.Objects.Add(paciente);
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
        public static ML.Result GetById(int IdPaciente)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.RgeronimoHospitalContext context = new DL.RgeronimoHospitalContext())
                {
                    var query = (from pacienteLQ in context.Pacientes
                                 where pacienteLQ.IdPaciente == IdPaciente
                                 select pacienteLQ).Single();

                    if (query != null)
                    {
                        ML.Paciente paciente = new ML.Paciente();
                        paciente.Tipo = new ML.TipoSangre();

                        paciente.IdPaciente = query.IdPaciente;
                        paciente.Nombre = query.Nombre;
                        paciente.AM = query.Ap;
                        paciente.AP = query.Am;
                        paciente.FechaNacimiento = query.FechaNacimiento.Value.ToString("yyyy/MM/dd");
                        paciente.FechaIngreso = query.FechaIngreso.Value.ToString("yyyy/MM/dd hh:mm:ss");
                        paciente.Tipo.IdTipoSangre = query.IdTipoSangre.Value;
                        paciente.Sexo = query.Sexo;
                        paciente.Sintomas = query.Sintomas;

                        result.Object = paciente;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontro el paciente";
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
