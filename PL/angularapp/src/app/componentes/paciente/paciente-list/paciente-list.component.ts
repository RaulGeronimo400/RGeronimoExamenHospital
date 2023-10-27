import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from '../../../../environments/environment.development';

//ALERTAS
import { ToastrService } from 'ngx-toastr';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-paciente-list',
  templateUrl: './paciente-list.component.html',
  styleUrls: ['./paciente-list.component.css']
})
export class PacienteListComponent implements OnInit {
  Pacientes: any = [];
  API_URI = environment.apiUrl;
  constructor(private http: HttpClient, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.GetAll();
  }

  GetAll() {
    this.http.get(this.API_URI + '/Paciente').subscribe(
      (res) => {
        console.log(res); //Muestra en consola
        //Llena el arreglo con la respuesta que enviamos
        this.Pacientes = res;
      },
      (err) => console.error(err)
    );
  }

  Delete(IdPaciente: string) {
    Swal.fire({
      title: '¿Estas seguro de eliminar el registro?',
      text: '¡No podrás revertir esto!',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: '¡Sí, bórralo!',
      cancelButtonText: 'Cancelar',
    }).then((result) => {
      if (result.isConfirmed) {
        this.http.delete(this.API_URI + '/Paciente/' + IdPaciente).subscribe(
          (res) => {
            //Llena el arreglo con la respuesta que enviamos
            console.log(res);
            console.log('El paciente fue eliminado con éxito');
            this.GetAll();
            this.toastr.warning(
              'El paciente fue eliminado con éxito',
              'Paciente eliminado'
            );
          },
          (err) => console.error(err)
        );
      }
    });
  }
}
