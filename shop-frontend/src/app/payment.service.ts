import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { Payment } from './payment';
import { CompletedPayment } from './completed-payment';
// import { MessageService } from './message.service';

const httpOptions = {
  headers: new HttpHeaders({ 
    'Content-Type': 'application/json',
    'Authorization': 'Basic ' + btoa('technologines:platformos')
  }),
  observe: "response" as "body"
};


@Injectable({
  providedIn: 'root'
})
export class PaymentService {
  
  private paymentUrl = 'https://mock-payment-processor.appspot.com/v1/payment';

  constructor(
    private http: HttpClient,
    // private messageService: MessageService
  ) { }

  /** POST: add a new payment to the payment-service */
  addPayment (payment: Payment) {
    return this.http.post<HttpResponse<CompletedPayment>>(this.paymentUrl, this.processPayment(payment), httpOptions);
  }

  processPayment(payment: Payment): Payment {
    let processedPayment = new Payment();
    processedPayment.amount = Math.round(payment.amount * 100); // turn into cents
    processedPayment.number = payment.number.replace(/ /g, ''); // remove whitespace
    processedPayment.holder = payment.holder;
    processedPayment.exp_month = +payment.exp_month; // turn into number
    processedPayment.exp_year = +payment.exp_year; // turn into number
    processedPayment.cvv = payment.cvv;
    return processedPayment;
  }

  /**
 * Handle Http operation that failed.
 * Let the app continue.
 * @param operation - name of the operation that failed
 * @param result - optional value to return as the observable result
 */

  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      // this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

  // /** Log a HeroService message with the MessageService */
  // private log(message: string) {
  //   this.messageService.add('HeroService: ' + message);
  // }
}
