import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CreateUserCommand, LoginCommand } from '../api/commands/create-user-command';
import { AuthenticationResponse, UserModel } from '../api/models/user-models';

const apiRoute = '/api/users'

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(
    private http: HttpClient,
  ) { }

  createUser(command: CreateUserCommand): Observable<UserModel> {
    return this.http.post<UserModel>(apiRoute, command);
  }

  login(command: LoginCommand): Observable<AuthenticationResponse> {
    return this.http.post<AuthenticationResponse>(`${apiRoute}/login`, command);
  }
}
