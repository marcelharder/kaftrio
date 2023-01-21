import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { Route, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
    selector: 'app-login',
    templateUrl: './Login.component.html',
    styleUrls: ['./Login.component.css']
})
export class LoginComponent implements OnInit {
    model: any = {};
    adminLogged: boolean;
    normalLogged: boolean;
    specialLogged: boolean;
    companyAdminLogged: boolean;
    companyHQLogged: boolean;
    loginFailed: boolean;
    Blogin = 1;
    HeaderText = 'Login';
    npw1 = '';
    npw2 = '';

    constructor(private auth: AuthService, private alertify: ToastrService, private router: Router) { }

    ngOnInit(): void {

    }
    login() {
        this.auth.login(this.model).subscribe(next => {
            this.alertify.success('Logged in successfully');
            this.loginFailed = false;

            this.auth.changeCurrentRole(this.auth.decodedToken.role);

          //  if (this.auth.decodedToken.role === 'admin') {this.router.navigate(['/users']);}
          //  else {this.router.navigate(['/listOfRegistries']);}
        },
            error => {
                // say log in failed, show register button
                this.alertify.error(error);
                this.loginFailed = true;
            }
        );
    }

    changePassword() {
        if (this.npw1 !== this.npw2) {
            this.alertify.error('passwords are not equal');
            this.npw1 = '';
            this.npw2 = '';
        } else {
            this.Blogin = 2;
            this.HeaderText = 'Changing the password for ' + this.model.username;
            this.model.password = this.npw1;
            this.auth.updatePassword(this.model).subscribe((next) => {
                // go to the list of procedures
                this.router.navigate(['/listOfRegistries']);
                this.alertify.show('password changed');
            })

        }
    }

    passwordDialoque() { if (this.Blogin === 1) {return true;} else {return false;} }

    checkLogin() {
        this.alertify.show('Checking credentials ...');
        this.auth.login(this.model).subscribe(next => {
            this.alertify.success('Credentials OK');
            this.loginFailed = false;
        }, (error) => {
            this.alertify.error(error);
            this.loginFailed = true;
        })

    }

    isLoggedIn() { return !this.loginFailed }

}

