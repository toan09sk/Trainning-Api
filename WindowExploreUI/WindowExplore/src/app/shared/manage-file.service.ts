import { Injectable } from '@angular/core';
import { Observable, throwError, observable } from 'rxjs';
import { HttpClient, HttpHeaders, HttpParams, HttpErrorResponse, HttpEventType } from '@angular/common/http';
import { tap, catchError, map } from 'rxjs/operators';
import { IFile } from '../Interfaces/IFile';
import { CompileShallowModuleMetadata } from '@angular/compiler';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class ManageFileService {

  private url: string = "http://localhost:49869/api/Management";

  constructor(private http: HttpClient) { }

  fetchFiles(): Observable<IFile[]> {
    return this.http.get<IFile[]>(this.url, httpOptions)
      .pipe(
        tap({
          next: val => console.log(val),
          error: err => {
            console.log(err.status);
            console.log(err.message);
          },
          complete: () => console.log('on complete')
        })
      );
  }

  deleteFile(path: string): Observable<string> {
    return this.http.delete<string>(`${this.url}?path=${path}`, httpOptions)
      .pipe(
        tap({
          next: val => console.log(val),
          error: err => {
            console.log(err.status);
            console.log(err.message);
          },
          complete: () => console.log('on complete')
        })
      );
  }

  postFile(fileToUpload: File) {
    const formData: FormData = new FormData();
    formData.append('fileKey', fileToUpload, fileToUpload.name);
    this.http.post(this.url, formData, {
      reportProgress: true,
      observe: 'events'
    })
      .subscribe(event => {
        if (event.type === HttpEventType.UploadProgress) {
          console.log(`Upload Progress ${Math.round(event.loaded / event.total) * 100} %`)
        }
        else if (event.type == HttpEventType.Response) {
          console.log(event);
        }

      });
  }
}
