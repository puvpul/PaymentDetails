import { Http, Response, Headers, RequestOptions } from "@angular/http";
import { Injectable } from "@angular/core";


@Injectable()

export class PaymentService{
  private registerUrl: string = "http://localhost:5912/api/payment";
    constructor(private http: Http) { }
    submitPayment(model){
      let headers = new Headers({ 'Content-Type': 'application/json' });
      let options = new RequestOptions({ headers: headers });
      return this.http.post(this.registerUrl, model,options);
    }
}