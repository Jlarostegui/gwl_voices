import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { FilesService } from 'src/app/services/files.service';

@Component({
  selector: 'app-files',
  templateUrl: './files.component.html',
  styleUrls: ['./files.component.scss']
})
export class FilesComponent implements OnInit {

  uploadForm: FormGroup;

  constructor(
    private fileService: FilesService,
    private fctrl: FormBuilder

  ) {

    this.uploadForm = this.fctrl.group({
      name: ['', Validators.required],
      // date: ['', Validators.required],
      description: ['', Validators.required],
      // file: ['', Validators.required],
    });

  }


  ngOnInit(): void {
  }

  onSubmit(uploadform: AbstractControl) {
    console.log(uploadform.value);


  }

}
