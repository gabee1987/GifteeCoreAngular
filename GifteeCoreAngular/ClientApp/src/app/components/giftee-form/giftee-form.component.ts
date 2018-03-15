import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { ToastyService, ToastyConfig, ToastOptions, ToastData } from 'ng2-toasty';

import { GifteeFormService } from '../../services/giftee-form.service';
import { UserListService } from '../../services/userList.service';
import { SaveGiftee, Giftee } from '../../models/giftee';

@Component({
  selector: 'app-giftee-form',
  templateUrl: './giftee-form.component.html',
  styleUrls: ['./giftee-form.component.css']
})
export class GifteeFormComponent implements OnInit {

  //ngForm: FormGroup;
  users: any[];
  user: any = {};
  giftees: any[];
  giftee: SaveGiftee = {
    id: 0,
    email: '',
    firstName: '',
    lastName: '',
    nickName: '',
    userId: 0
  };

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private gifteeFormService: GifteeFormService,
    private userListService: UserListService,
    private toastyService: ToastyService) {

    
    this.route.params.subscribe(p => {
        if (p['id'])
          this.giftee.id = +p['id'];
      });
  }


  ngOnInit() {
    if (this.giftee.id) {
      this.gifteeFormService.getGiftee(this.giftee.id)
        .subscribe(g => {
          this.giftee = g;
          //}, err => {
          //    if (err.status == 404) {
          //        this.router.navigate(['/home']);
          //    }
        });
      this.setGiftee(this.giftee);
    }

    this.userListService.getUsers().subscribe(users =>
      this.users = users);
    console.log("USERS", this.users);
  }

  private setGiftee(g: Giftee) {
    this.giftee.id = g.id;
    this.giftee.email = g.email;
    this.giftee.firstName = g.firstName;
    this.giftee.lastName = g.lastName;
    this.giftee.nickName = g.nickName;
    this.giftee.userId = g.userId;
  }

  onUserChange() {
    console.log("GIFTEE", this.user.giftees);
    var selectedUser = this.users.find(u => u.id == this.user)
    this.giftees = selectedUser ? selectedUser.giftees : [];
    this.giftee.userId = selectedUser ? selectedUser.id : undefined;
  }

  submit() {
    if (this.giftee.id) {
      this.gifteeFormService.updateGiftee(this.giftee)
        .subscribe(x => {
          this.toastyService.success({
            title: 'Success',
            msg: 'The giftee was sucessfully updated.',
            theme: 'bootstrap',
            showClose: true,
            timeout: 5000
          });
        });
      this.router.navigate(['/giftees/new']);
    }
    else {
      this.gifteeFormService.createGiftee(this.giftee)
        .subscribe(x => {
          this.toastyService.success({
            title: 'Success',
            msg: 'The giftee was sucessfully created.',
            theme: 'bootstrap',
            showClose: true,
            timeout: 5000
          });
        });
      //this.ngForm.reset();
      this.router.navigate(['/giftees/new']);
    }
  }

  //initToast() {
  //    this.toastyConfig.theme = 'bootstrap';
  //    this.toastyConfig.position = "top-right";
  //    this.toastOptions = {
  //        title: "",
  //        msg: "",
  //        showClose: true,
  //        timeout: 5000,
  //        theme: "bootstrap",
  //        onAdd: (toast: ToastData) => {
  //            console.log('Toast ' + toast.id + ' has been added!');
  //        },
  //        onRemove: function (toast: ToastData) {
  //            console.log('Toast ' + toast.id + ' has been removed!');
  //        }
  //    };
  //}
}
