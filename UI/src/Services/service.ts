import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

//   apiUrl = 'https://jsonplaceholder.typicode.com';
  apiUrl = 'https://localhost:7134';

  constructor(private http: HttpClient) { }

  getPosts(): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/Bank`);
  }

  getPostById(id: number): Observable<any> {
    let params = new HttpParams()
    params.append('userId',id);
    return this.http.get<any>(`${this.apiUrl}/Bank/GetUserAccount/?userId=${id}`,{params:params });
  }

  addPost(post: any): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/Bank/CreateAccount?userId=${post.userId}&amount=${post.AmountToBeDepositedOrWithdrawn}`, post);
  }

  updatePost(id: number, post: any): Observable<any> {
    return this.http.put<any>(`${this.apiUrl}/posts/${id}`, post);
  }

  deleteAccount(acct:any): Observable<any> {
    return this.http.delete<any>(`${this.apiUrl}/Bank/DeleteAccount/`,{body: acct});
  }
  
  DepositAmount(acct:any): Observable<any> {
    return this.http.put<any>(`${this.apiUrl}/TranSaction/Deposit?userId=${acct.userId}&acctId=${acct.accountId}&amount=${acct.AmountToBeDepositedOrWithdrawn}`,{body: acct});
  }
  
  WithdrawAmount(acct:any): Observable<any> {
    return this.http.put<any>(`${this.apiUrl}/TranSaction/WithDraw?userId=${acct.userId}&acctId=${acct.accountId}&amount=${acct.AmountToBeDepositedOrWithdrawn}`,{body: acct});
  }
}