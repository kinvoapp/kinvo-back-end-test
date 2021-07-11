import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CreateUserCommand, LoginCommand } from '../api/commands/create-user-command';
import { CommandResult } from '../api/models/command-result';
import { AuthenticationResponse, UserModel } from '../api/models/user-models';

const apiRoute = '/api/users'

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(
    private http: HttpClient,
  ) { }

  createUser(command: CreateUserCommand): Observable<CommandResult<UserModel>> {
    return this.http.post<CommandResult<UserModel>>(apiRoute, command);
  }

  login(command: LoginCommand): Observable<CommandResult<AuthenticationResponse>> {
    return this.http.post<CommandResult<AuthenticationResponse>>(`${apiRoute}/login`, command);
  }
}
