import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CreateUserCommand, LoginCommand } from '../api/commands/create-user-command';
import { RequestResult } from '../api/models/request-result';
import { AuthenticationResponse, UserModel } from '../api/models/user-models';

const apiRoute = '/api/users'

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(
    private http: HttpClient,
  ) { }

  createUser(command: CreateUserCommand): Observable<RequestResult<UserModel>> {
    return this.http.post<RequestResult<UserModel>>(apiRoute, command);
  }

  login(command: LoginCommand): Observable<RequestResult<AuthenticationResponse>> {
    return this.http.post<RequestResult<AuthenticationResponse>>(`${apiRoute}/login`, command);
  }
}
