import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private auth: AuthService) { }

  ngOnInit() { if (this.auth.decodedToken === undefined) {localStorage.removeItem('token'); }  }

  linkToCSD() { window.location.href = "https://csd-website.azurewebsites.net"; }
}
