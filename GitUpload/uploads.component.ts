import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { FileUploadService } from '../file-upload.service';

interface IfileUpload{
  status:string,
  message:string,
  filePath:string
}

@Component({
  selector: 'app-uploads',
  templateUrl: './uploads.component.html',
  styleUrls: ['./uploads.component.css']
})
export class UploadsComponent implements OnInit {

  profileForm: FormGroup;
  error: string;

  fileUpload = {status: '', message: '', filePath: ''};
  constructor(private fb: FormBuilder, private fileUploadService: FileUploadService) { }

  ngOnInit() {
    this.profileForm = this.fb.group({
      name: [''],
      profile: ['']
    });
  }
  onSelectedFile(event) {
    if(event.target.files.length>0){
      const profile =event.target.files[0];
      this.profileForm.get('profile').setValue(profile);
    }
  }

  onSubmit() {
    const formData = new FormData();
    formData.append('name',this.profileForm.get('name').value);
    formData.append('profile',this.profileForm.get('profile').value);

    this.fileUploadService.upload(formData).subscribe(
      res => this.fileUpload = res,
      err => this.error = err
    );
  }


}
