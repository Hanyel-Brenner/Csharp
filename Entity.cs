using System;

namespace Entities{
    public class UserAccount{ 

        public long CPF {get;set;}
        public string? Name {get; set;}
        public long CardNum {get;set;}
        public long AccountNumber {get;set;}
        public long PIN {get;set;}
        public long Balance {get;set;}
        public bool isLogged {get;set;}

    }



    public class Transaction{  //object that contains all information relevant to describe a transaction
        public long CodeNumber {get;set;}   //number unique to each transaction of any client
        public string Type {get;set;} //identifies what kind of transaction it is (deposit, withdrawal, or transfer)      
        public long authorCardNumber {get;set;}
        public long receiverCardNumber {get;set;} //in the case of transfer it has the receiver's card number as well 
        public long money {get;set;} //this one just says how much money was involved in the operation
    }      

}