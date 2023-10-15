import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

//Importamos el archivo que viene en la ruta sig.
import { RouterModule, Routes } from '@angular/router';
import { PacienteListComponent } from './componentes/paciente/paciente-list/paciente-list.component';
import { PacienteFormComponent } from './componentes/paciente/paciente-form/paciente-form.component';

const routes: Routes = [
  //CREACION DE OBJETOS
  //Índice
  {
    path: '',
    redirectTo: '/paciente',
    pathMatch: 'full'
  },
  //Lista de Pscientes
  {
    path: 'paciente',
    component: PacienteListComponent
  },
  //Formulario de Pacientes
  {
    path: 'paciente/agregar',
    component: PacienteFormComponent
  },
  {
    path: 'paciente/actualizar/:IdPaciente',
    component: PacienteFormComponent
  },

  //404
  {
    path: '**',
    redirectTo: '/paciente',
    pathMatch: 'full'
  }
];

@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
