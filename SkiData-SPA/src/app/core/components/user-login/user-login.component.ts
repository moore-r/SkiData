import { Component, OnInit } from '@angular/core';
import { UserLoginServiceService } from '../../services/user-login-service.service';
import { registrationDataModel } from 'src/app/models/registrationDataModel';

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.css']
})
export class UserLoginComponent implements OnInit {
  private data: registrationDataModel = new registrationDataModel();
  private SkiDataSuccessMessage: string;

  constructor(private loginService: UserLoginServiceService) { }

  ngOnInit() {
  }

  // Call the function to validate the fields, then call service to send data to back end.
  // Subscribe to the response and display the results.
  // Simple windows alert for the errors.
  onSubmit() {
    if(this.validateInput()) {
      // Send info to backend
      this.loginService.postRegistrationData(this.data).subscribe((message: string) => {
        this.SkiDataSuccessMessage = this.ParseReturnMessage(message);
      },
      (errorMessage: string) => {
        window.alert(`Error completing request : ${errorMessage}`);
      });
    }
  }

  // Validation for the fields, null checking and regex for the email.
  validateInput(): boolean {
    if(!this.data.email || !this.data.name || !this.data.password) {
      window.alert("Please fill out all fields.");
      return false;
    }

    // Regex to make sure the email has a valid format
    if(!/\S+@\S+\.\S+/.test(this.data.email)) {
      window.alert("Invalid email format.");
      return false;
    }

    return true;
  }

  // The data received from the call to the back end is the enter response content
  // Parsing it here for the UserID and adding a friendly message
  ParseReturnMessage(SkiDataResponse: string): string {
    var response = JSON.parse(SkiDataResponse);
    return `Hooray! You have successfully registered an account to the SkiData Test Portal. Your new user id is: ${response.userId}`;
  }

}
