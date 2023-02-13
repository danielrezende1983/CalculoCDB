import { NgModule } from '@angular/core';
import { ServerModule } from '@angular/platform-server';
import { AppComponent } from './app.component';
import { AppModule } from './app.module';
//import { MatInputModule } from '@angular/material/input'; 

@NgModule({
  imports: [AppModule, ServerModule],
    bootstrap: [AppComponent]
})
export class AppServerModule { }
