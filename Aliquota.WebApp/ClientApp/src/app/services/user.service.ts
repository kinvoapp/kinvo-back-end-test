import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CreateUserCommand } from '../api/commands/create-user-command';
import { UserModel } from '../api/models/user-models';

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
}
