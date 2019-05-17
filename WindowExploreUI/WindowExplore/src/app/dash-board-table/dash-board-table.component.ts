import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { IFile } from '../Interfaces/IFile';
import { ManageFileService } from '../shared/manage-file.service';
import { MatPaginator, MatTableDataSource } from '@angular/material';
import { MatDialog } from '@angular/material';
import { DialogConfirmRemoveComponent } from '../dialog-confirm-remove/dialog-confirm-remove.component';



@Component({
  selector: 'app-dash-board-table',
  templateUrl: './dash-board-table.component.html',
  styleUrls: ['./dash-board-table.component.css']
})
export class DashBoardTableComponent implements OnInit, AfterViewInit {

  @ViewChild(MatPaginator) paginator: MatPaginator;

  dataSource = new MatTableDataSource<IFile>();
  elementData: IFile[] = [];
  displayedColumns: string[] = ['number', 'name', 'path', 'dateCreate', 'dateModify', 'type', 'size', 'control'];
  pageSizeOptions: number[] = [5, 10, 25];
  pageSize = 10;

  selectedFile:File=null;

  constructor(
    private service: ManageFileService,
    public dialog: MatDialog
  ) { }

  ngOnInit() {
    this.service.fetchFiles()
      .subscribe((files: IFile[]) => this.dataSource.data = files);
  }

  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
  }

  public applyFilter = (filterValue: string) => {
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  public onFileSelected = (event) => {
    console.log(event);
    this.selectedFile=event.target.files[0];    
  }

  public onUploadClick =()=>{
    this.service.postFile(this.selectedFile);
  }

  public redirectToUpdate = (file: IFile) => {


  }

  public redirectToDelete = (file: IFile) => {
    const configDialog = { width: '700px', data: { name: file.Name, path: file.Path } }
    this.dialog.open(DialogConfirmRemoveComponent, configDialog);
  }
}
