import { TipoSangre } from "./TipoSangre";

export interface Paciente {
  idPaciente?: number;
  nombre?: string;
  ap?: string;
  am?: string;
  fechaNacimiento?: string;
  fechaIngreso?: string;
  tipo: TipoSangre;
  sexo?: string;
  sintomas?: string;
}
