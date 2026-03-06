import { HttpClient } from '@angular/common/http';
import { Component, inject } from '@angular/core';
import { FormGroup, ReactiveFormsModule, UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { environment } from '../../../environments/environment';
import { AuthServiceService } from '../../auth-service.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {

  loginForm!: UntypedFormGroup

  submit!: boolean
  public fb = inject(UntypedFormBuilder)

  constructor(private authService: AuthServiceService){}

  ngOnInit(): void{
    this.loginForm = this.fb.group({
      username: ['', [Validators.required]],
      password: ['', [Validators.required]],
    })
  }

 
  http = inject(HttpClient);

  router = inject(Router)

  login(){
   const formValue = this.loginForm.value;
    this.http.post(`${environment.apiUrl}/Auth/login`,formValue).subscribe({
      next:(response:any)=>{
        if(response.result)
        {
          this.authService.login(response.token);
          alert("Login Success")
          this.router.navigateByUrl("/dashboard")
        } else {
          alert(response.message)
        }
      },
      error:(error)=>{
        if(error.status == 0 || error.status >= 500){
          this.router.navigateByUrl('/error-500');
        } else {
    const errMsg = error?.error?.message || error?.message || "Wrong password or Username!";
    alert(errMsg);
  }
      }
    })
  }

}
