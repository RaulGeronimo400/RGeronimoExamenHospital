import { LOCALE_ID, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

//Cambiar el idioma
//import localeEsMX from '@angular/common/locales/es-MX';
//import { registerLocaleData } from '@angular/common';
//registerLocaleData(localeEsMX);

//Importamos el modulo de http
import { HttpClientModule } from '@angular/common/http';

//Importamos el modulo de FormModule que va enlazar los input
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';

import { NavigationComponent } from './componentes/navigation/navigation.component';
import { FooterComponent } from './componentes/footer/footer.component';
import { PacienteListComponent } from './componentes/paciente/paciente-list/paciente-list.component';
import { PacienteFormComponent } from './componentes/paciente/paciente-form/paciente-form.component';

//Importamos los modulos de los formularios
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';



@NgModule({
  declarations: [
    AppComponent,
    NavigationComponent,
    FooterComponent,
    PacienteListComponent,
    PacienteFormComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot({
      timeOut: 10000,
      positionClass: 'toast-bottom-right',
      preventDuplicates: true,
    })
  ],
  providers: [{ provide: LOCALE_ID, useValue: 'es-MX' }],
  bootstrap: [AppComponent]
})
export class AppModule { }
