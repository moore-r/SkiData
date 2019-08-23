import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs';
import { registrationDataModel } from 'src/app/models/registrationDataModel';

@Injectable({
  providedIn: 'root'
})
// Class that holds back end connection services for the Skidata controller
export class UserLoginServiceService {

  constructor( private http: HttpClient) { }

  // Function that posts to the back end. It also jsonifys the data model.
  // Added multiple headers as I had to deal with some CORs stuff.
  postRegistrationData(data: registrationDataModel): Observable<any> {
    const registerData = JSON.stringify(data);

    return this.http.post("http://localhost:1980/api/SkiData/CreateAccount", registerData, {
      headers: new HttpHeaders({
        'Content-Type' : 'application/json',
        "Access-Control-Allow-Origin" : "*",
        'Access-Control-Allow-Methods' :'POST',
        'Access-Control-Allow-Headers' : 'Content-Type',
        accept: 'application/json'
      }),
      observe: 'body',
      responseType: 'json',
    });
  }
}
