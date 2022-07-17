import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { WgService } from 'src/app/services/wg.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-create-wg',
  templateUrl: './create-wg.component.html',
  styleUrls: ['./create-wg.component.scss']
})
export class CreateWgComponent implements OnInit {



  wgForm: FormGroup;
  constructor(
    private fctrl: FormBuilder,
    private wgservice: WgService
  ) {

    this.wgForm = this.fctrl.group(
      {
        name: ['', Validators.required],
      });
  }

  ngOnInit(): void {
  }

  onSubmit(wgForm: AbstractControl) {
    let response = this.wgservice.addWorkingNewWorkingGroup(wgForm.value)
    this.wgForm.reset()

    const alert = Swal.mixin({
      // toast: false,
      showConfirmButton: false,
      timer: 2000,
      timerProgressBar: true,
      didOpen: (alert) => {
        alert.addEventListener('mouseenter', Swal.stopTimer)
        alert.addEventListener('mouseleave', Swal.resumeTimer)
      }

    });

    alert.fire({
      icon: 'success',
    });
  };

}

