import { Component, EventEmitter, Input, Output } from '@angular/core';
import { EventManager } from '@angular/platform-browser';
import { AccountService } from '../_services/account.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent {
  model: any = {};

  @Output() cancelRegister = new EventEmitter();
  constructor(
    private accountService: AccountService,
    private toastr: ToastrService
  ) {}

  register() {
    console.log(this.model);
    this.accountService.register(this.model).subscribe({
      next: () => {
        this.cancel();
      },
      error: (error) => this.toastr.error(error.error),
    });
  }

  cancel() {
    console.log('cancelled');
    this.cancelRegister.emit(false);
  }
}
