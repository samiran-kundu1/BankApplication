import { Component } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { ApiService } from 'src/Services/service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'BankApp';
  users : any[] = [];
  accounts:any[] = []; 
  AmountToBeDeposited:string = ""
  IsVisible:boolean = false
  constructor(private apiService: ApiService) {}

  ngOnInit() {
    this.apiService.getPosts().subscribe((data: any[]) => {
      console.log("data:",data);
      
      this.users = data;
    });
  }

  public GetAccount(userId:number)
  {
    this.apiService.getPostById(userId).subscribe((data: any[]) => {
      console.log("data:",data);
      
      this.accounts = data;
    });
  }
  
  public DePositAmountInAccount(acct:any)
  {
    console.log(acct,acct.AmountToBeDepositedOrWithdrawn);
    
    if(acct.AmountToBeDepositedOrWithdrawn>10000)
    {
      window.alert("AmountTo Be Deposited Cannot be greater than 10,000$")
    }

    else
    {
      this.apiService.DepositAmount(acct).subscribe((data: number) => {
        console.log("data:",data);
        window.alert("Amount Deposited Successfully")  
        acct.balance=data
        acct.AmountToBeDepositedOrWithdrawn = ""
        console.log("data:",data);
        // this.accounts = data;
      });
    }
  }
  
  public WithDrawAmountInAccount(acct:any)
  {
    console.log(acct,acct.AmountToBeDepositedOrWithdrawn);
    
    if( acct.AmountToBeDepositedOrWithdrawn> (acct.balance*.9))
    {
      window.alert("AmountTo Be Withdrawn Cannotmore than 90% of their total balance from the account in a single transaction")
    }
    
    if(acct.balance - acct.AmountToBeDepositedOrWithdrawn <100)
    {
      window.alert("An account cannot have less than $100 at any time")
    }

    else
    {
      this.apiService.WithdrawAmount(acct).subscribe((data: number) => {
        console.log("data:",data);
        window.alert("Amount Withdrawn Successfully")  
        acct.balance=data
        acct.AmountToBeDepositedOrWithdrawn = ""
        console.log("data:",data);
        // this.accounts = data;
      });
    }
    
    
  }

  public CreateAccount(userId:number)
  {
    // this.apiService.addPost(userId).subscribe((data: any[]) => {
    //   console.log("data:",data);
    //   this.accounts = data;
    // });
    this.IsVisible = true;
  }
  
  public OnSubmit(user:any)
  {
    if(user.AmountToBeDepositedOrWithdrawn<100)
    {
      window.alert("Amount cannot be less than 100$!!!")
    }
    else
    {
    this.apiService.addPost(user).subscribe((data: any[]) => {
      console.log("data:",data);
      this.accounts = data;
      window.alert("Account created succesfully for user:{user.userId}")
      this.IsVisible = false;
      user.AmountToBeDepositedOrWithdrawn = ""
    });
  }
  }

  public DeleteAccount(acct:any)
  {
    console.log("account:",acct);
    this.apiService.deleteAccount(acct).subscribe((data: any[]) => {
      console.log("data:",data);
      this.accounts = data;
    });
  }
}
