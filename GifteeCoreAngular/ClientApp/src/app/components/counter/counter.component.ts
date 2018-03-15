import { Component } from '@angular/core';
import { ToastyService, ToastyConfig, ToastOptions, ToastData } from 'ng2-toasty';

@Component({
  selector: 'app-counter-component',
  templateUrl: './counter.component.html'
})
export class CounterComponent {
  constructor(private toastyService: ToastyService) {
  }

  public currentCount = 0;

  public incrementCounter() {
    this.currentCount++;
  }

  addToast() {
    // Create the instance of ToastOptions 
    var successType: ToastOptions = {
      title: "Counter increased by",
      msg: "1",
      showClose: true,
      timeout: 5000,
      theme: 'bootstrap',
      onAdd: (toast: ToastData) => {
        console.log('Toast ' + toast.id + ' has been added!');
      },
      onRemove: function (toast: ToastData) {
        console.log('Toast ' + toast.id + ' has been removed!');
      }
    };


    this.toastyService.success(successType);

  }
}
