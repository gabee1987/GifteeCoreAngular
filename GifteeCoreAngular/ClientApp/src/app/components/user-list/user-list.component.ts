import { Component, OnInit } from '@angular/core';
import { UserListService } from '../../services/userList.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {
  users: any = [];
  giftee: any = {};

  constructor(private userListService: UserListService) { }

  ngOnInit() {
    this.userListService.getUsers().subscribe(users =>
      this.users = users);
    console.log("USERS", this.users);
  }

}
