import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { ManageFileService } from '../shared/manage-file.service';

export interface FileDelete {
  name: string;
  path: string;
}

@Component({
  selector: 'app-dialog-confirm-remove',
  templateUrl: './dialog-confirm-remove.component.html',
  styleUrls: ['./dialog-confirm-remove.component.css']
})
export class DialogConfirmRemoveComponent {


  constructor(
    public dialogRef: MatDialogRef<DialogConfirmRemoveComponent>,
    @Inject(MAT_DIALOG_DATA) public data: FileDelete,
    private service: ManageFileService
  ) { }


  onCancelClick = () => {
    this.dialogRef.close();
  }

  onDeleteClick = () => {
    this.service.deleteFile(this.data.path).subscribe();
    this.dialogRef.close();
  }

}
