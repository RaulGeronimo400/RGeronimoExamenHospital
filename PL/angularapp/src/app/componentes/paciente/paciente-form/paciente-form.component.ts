import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { environment } from '../../../../environments/environment.development';
import { Paciente } from '../../../modelos/Paciente';
import { TipoSangre } from '../../../modelos/TipoSangre';

@Component({
  selector: 'app-paciente-form',
  templateUrl: './paciente-form.component.html',
  styleUrls: ['./paciente-form.component.css']
})
export class PacienteFormComponent implements OnInit {
  API_URI = environment.apiUrl;
  form: FormGroup;

  prueba: any;

  paciente: Paciente = {
    idPaciente: 0,
    nombre: '',
    ap: '',
    am: '',
    fechaNacimiento: '',
    fechaIngreso: '',
    sexo: '',
    sintomas: '',
    tipo: {
      idTipoSangre: ''
    }
  };

  tipo: TipoSangre = {
    idTipoSangre: ''
  }

  edit: boolean = false;

  Tipo: any = [];

  constructor(
    private http: HttpClient,
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private fb: FormBuilder,
    private toastr: ToastrService) {
    this.form = this.fb.group({
      Tipo: [''],

      nombre: ['', Validators.required],
      ap: ['', Validators.required],
      am: ['', Validators.required],
      fechaNacimiento: ['', Validators.required],
      fechaIngreso: ['', Validators.required],
      idTipoSangre: ['', Validators.required],
      sexo: ['', Validators.required],
      sintomas: ['', Validators.required],
    });
  }

  ngOnInit(): void {
    this.TipoGetAll();
    const params = this.activatedRoute.snapshot.params;
    if (params['IdPaciente']) {
      this.http.get(this.API_URI + '/Paciente/' + params['IdPaciente']).subscribe(
        (res) => {
          console.log(res); //Muestra en consola
          this.paciente = res as Paciente; //Muestra en el navegador
          this.tipo.idTipoSangre = this.paciente.tipo.idTipoSangre;
          this.edit = true; //Asignamos que es verdadero
        },
        (err) => console.error(err)
      );
    }
  }

  Add() {
    this.paciente.tipo.idTipoSangre = this.tipo.idTipoSangre;
    this.http.post(this.API_URI + '/Paciente', this.paciente).subscribe(
      (res) => {
        console.log(res);
        console.log('El paciente fue insertado correctamente');
        this.router.navigate(['paciente']);
        this.toastr.success(
          `El paciente fue '${this.paciente.nombre}' insertado correctamente`,
          'Paciente agregado'
        );
      },
      (err) => console.error(err)
    );
  }

  Update() {
    this.paciente.tipo.idTipoSangre = this.tipo.idTipoSangre;
    const params = this.activatedRoute.snapshot.params;
    this.http.put(this.API_URI + '/Paciente/' + params['IdPaciente'], this.paciente).subscribe(
      (res) => {
        console.log(res);
        this.router.navigate(['/paciente']);
        this.toastr.info(
          `El paciente '${this.paciente.nombre}'  fue actualizado correctamente`,
          'Paciente Actualizado'
        );
      },
      (err) => console.error(err)
    );
  }

  TipoGetAll() {
    this.http.get(this.API_URI + '/TipoSangre').subscribe(
      (res) => {
        //Llena el arreglo con la respuesta que enviamos
        this.Tipo = res;
        console.log(res);
      },
      (err) => console.error(err)
    );
  }
}
