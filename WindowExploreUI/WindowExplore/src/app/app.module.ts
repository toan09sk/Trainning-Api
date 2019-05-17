import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator'; 1
import { MatFormFieldModule, MatInputModule } from '@angular/material';
import { MatIconModule } from '@angular/material/icon';
import { MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import {MatGridListModule} from '@angular/material/grid-list';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DashBoardComponent } from './dash-board/dash-board.component';
import { ManageFileService } from './shared/manage-file.service';
import { DashBoardTableComponent } from './dash-board-table/dash-board-table.component';
import { DialogConfirmRemoveComponent } from './dialog-confirm-remove/dialog-confirm-remove.component';



@NgModule({
  declarations: [
    AppComponent,
    DashBoardComponent,
    DashBoardTableComponent,
    DialogConfirmRemoveComponent
  ],
  imports: [
    FormsModule,
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    HttpClientModule,
    MatTableModule,
    MatPaginatorModule,
    MatFormFieldModule,
    MatInputModule,
    MatIconModule,
    MatDialogModule,
    MatButtonModule,
    MatGridListModule
  ],
  providers: [ManageFileService],
  bootstrap: [AppComponent],
  entryComponents: [
    DialogConfirmRemoveComponent
  ]
})
export class AppModule { }
