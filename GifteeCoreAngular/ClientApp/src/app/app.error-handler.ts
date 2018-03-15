import { ErrorHandler, Inject, NgZone } from "@angular/core";
import { ToastyService, ToastyConfig } from "ng2-toasty";

export class AppErrorHandler implements ErrorHandler {
    constructor(
        //private ngZone: NgZone,
        @Inject(NgZone) private ngZone: NgZone,
        @Inject(ToastyService) private toastyService: ToastyService,
        @Inject(ToastyConfig) private toastyConfig: ToastyConfig){

    }
    handleError(error: any): void {
        console.log("ERROR");
        this.ngZone.run(() => {
            this.toastyService.error({
                title: 'Error',
                msg: 'An unexpected error happened.',
                theme: 'bootstrap',
                showClose: true,
                timeout: 5000
            }),
                this.toastyConfig.theme = 'bootstrap';
        });
    }
}
