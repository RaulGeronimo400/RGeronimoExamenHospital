export interface Paciente {
  idPaciente?: number;
  nombre?: string;
  ap?: string;
  am?: string;
  fechaNacimiento?: string;
  fechaIngreso?: string;
  tipo?: {
    idTipoSangre: ''
  };
  sexo?: string;
  sintomas?: string;
}
