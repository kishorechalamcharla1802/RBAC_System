import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { User } from './models/user.model';

@Injectable({
  providedIn: 'root',
})
export class DataService {
  private userInfo = new BehaviorSubject<User>({} as User);
  userInfo$ = this.userInfo.asObservable();

  constructor() {
    const savedUser = localStorage.getItem('user');
    if (savedUser) {
      this.userInfo.next(JSON.parse(savedUser));
    }
  }

  setUserInfo(user: User) {
    this.userInfo.next(user);
  }

  isLoggedIn(): boolean {
    var token = localStorage.getItem('token');
    if (token == null || token == undefined || token == '') {
      return false;
    } else {
      return true;
    }
  }
}
