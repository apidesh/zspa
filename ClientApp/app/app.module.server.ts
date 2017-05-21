import { NgModule } from '@angular/core';
import { ServerModule } from '@angular/platform-server';
import { sharedConfig } from './app.module.shared';
import { FormsModule } from '@angular/forms'; // <-- NgModel lives here

@NgModule({
    bootstrap: sharedConfig.bootstrap,
    declarations: sharedConfig.declarations,
    imports: [
        FormsModule,
        ServerModule,
        ...sharedConfig.imports
    ]
})
export class AppModule {
}