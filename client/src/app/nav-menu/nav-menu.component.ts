import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { Router } from '@angular/router';

@Component({
    selector: 'app-nav-menu',
    templateUrl: './nav-menu.component.html',
    styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {
    isExpanded = false;
    model: any = {};

   
    loginFailed = false;

    constructor(public auth: AuthService, private router: Router) { }

    collapse() {
        this.isExpanded = false;
    }

    toggle() {
        this.isExpanded = !this.isExpanded;
    }
    ngOnInit() {
       
    }

    
    loggedIn() { return this.auth.loggedIn(); }

    adminLogged(){
        let currentRole = "";
        this.auth.UserRole.subscribe((next)=>{ currentRole = next; });
        if(currentRole === 'admin'){return true;} else {return false;} ;
    }

    logIn(){this.router.navigate(['/login']);}

    logOut() {
        this.router.navigate(['/home']);
        //this.alertify.message('Logged out');
        localStorage.removeItem('token');
    }

    showRegister() {
        this.loginFailed = false;
        this.router.navigate(['/register']);
    }

    showProfile() {
        this.router.navigate(['/profile/', +this.auth.decodedToken.nameid]);
    }

    loginFail() {
        if (this.loginFailed === true) { return true; } else { return false; }
    }

}
