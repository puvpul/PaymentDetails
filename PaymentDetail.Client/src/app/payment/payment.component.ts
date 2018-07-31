import { Component, OnInit } from "@angular/core";
import { NgForm } from "@angular/forms";
import { PaymentService } from '../services/payment.service';
@Component({
selector: 'payment-component',
templateUrl: './payment.component.html'
})

export class PaymentComponent implements OnInit{
    payment: any;
    showErrors: boolean;
    constructor(private paymentService:PaymentService) {
        
    }
    public ngOnInit() {
        this.payment = {};
        this.showErrors = false;
      }
    onSubmit(formData) {
      this.paymentService.submitPayment(formData)
            .subscribe(
                (data) => console.log(data),
                (error) => console.log(error)
            );
    }
}

