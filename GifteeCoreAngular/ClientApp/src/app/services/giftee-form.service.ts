import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map'

@Injectable()
export class GifteeFormService {

  constructor(private http: Http) { }

  getUsers() {
    return this.http.get('/api/users')
      .map(res => res.json());
  }

  createGiftee(giftee) {
    return this.http.post('/api/giftees', giftee)
      .map(res => res.json());
  }

  getGiftee(id) {
    return this.http.get('/api/giftees/' + id)
      .map(res => res.json());
  }

  updateGiftee(giftee) {
    return this.http.put('/api/giftees/' + giftee.id, giftee)
      .map(res => res.json());
  }
}
