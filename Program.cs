using System;
using UserInterface;
using Utilities;
using Entities;
using Iinterfaces;
using System.Collections.Generic;

namespace BankSimulator{
    class BankSimulator : IUserLogin{

        private List<UserAccount> UserList;
        private UserAccount CurrentUser;
        private long UserCount;

        public static void Main(string[] args){
            BankSimulator appInstance = new BankSimulator();
            appInstance.InitializeData();

            UI.WelcomeUI();
            Console.ReadLine();
            int choice = 0;

            while(true){  //3 significa sair do loop login || registro || cancelar
                UI.LoginUI();
                choice = Utility.Convert<int>(Console.ReadLine()); // first use of the input validator function Convert<>()
            
                if(choice == 1){  //Login, usuario entra com numero ATM e senha, entao procuramos na lista de cadastrados
                    Console.Clear();
                    Console.WriteLine("----------------------");
                    Console.WriteLine("LOGIN");
                    Console.WriteLine("----------------------");

                    if(appInstance.CheckUserLogin()) {
                        appInstance.CurrentUser.isLogged = true;
                    }  //if login goes correctly, then isLogged property receives true value
                    
                    if(appInstance.CurrentUser.isLogged == true) {
                    /*This piece of code will be another loop in which the user will be able to
                        perform different kinds of operations to his bank account*/
                    int menChoice = 0;

                        while(menChoice != 6){
                            Console.Clear();
                            UI.MainMenuUI();
                            menChoice = Utility.Convert<int>(Console.ReadLine());

                            switch(menChoice){
                            case 1:
                                Console.WriteLine("CURRENT BALANCE : R$"+appInstance.CurrentUser.Balance);//Convert.ToString(appInstance.CurrentUser.Balance)
                                Console.WriteLine("Press any key to continue.");
                                Console.ReadLine();
                            break;

                            case 2:
                                long wthAmount;
                                Console.WriteLine("WITHDRAWAL AMOUNT : R$");
                                wthAmount = Utility.Convert<long>(Console.ReadLine());
                                if(wthAmount<= appInstance.CurrentUser.Balance){
                                    appInstance.CurrentUser.Balance -= wthAmount;
                                    Console.WriteLine("SUCESS. Press any key to continue");
                                    Console.ReadLine();
                                }else{
                                    Console.WriteLine("You don't have that amount of money into your account. Press any key to continue.");
                                    Console.ReadLine();
                                }
                            break;

                            case 3:
                                long dpsAmount;
                                Console.WriteLine("DEPOSIT VALUE : R$");
                                dpsAmount = Utility.Convert<long>(Console.ReadLine());
                                appInstance.CurrentUser.Balance += dpsAmount;
                                Console.WriteLine("SUCESS. Press any key to continue.");
                                Console.ReadLine();
                                break;
                            
                            case 4:
                                long rcverCardNumber;
                                long transferedMoney;
                                UserAccount? receiver;
                                Console.WriteLine("RECEIVER'S CARD NUMBER : ");
                                rcverCardNumber = Utility.Convert<long>(Console.ReadLine());
                                receiver = appInstance.UserExists(rcverCardNumber);

                            if(receiver != null){
                                Console.WriteLine("DEPOSIT AMOUNT: R$");
                                transferedMoney = Utility.Convert<long>(Console.ReadLine());
                                receiver.Balance += transferedMoney;
                                appInstance.CurrentUser.Balance -= transferedMoney;
                                Console.WriteLine("SUCESS. Press any key to continue.");
                                Console.ReadLine();
                            }
                            else{
                                Console.WriteLine("ERROR, User not found. Press any key to continue");
                                Console.ReadLine();
                            }
                            break;

                            case 5:

                            break;

                            case 6:
                                Console.WriteLine("You exited your account. Press any key to redirect to the login menu.");
                                Console.ReadLine();
                            break;
                            default:
                            break;
                            }
                        }

                    }else{ 
                        Console.WriteLine("Sorry, either Card Number or Password is incorrect");
                    }

                }else if(choice == 2){ //Usuario entra com numero ATM e senha, se nao existir numero ATM nos cadastrados, adicionamos o registro
                    Console.Clear();
                    int cardNumber, password;
                    bool i;
                    Console.WriteLine("----------------------");
                    Console.WriteLine("CADASTRO");
                    Console.WriteLine("----------------------");
                    i = appInstance.UserSignUp();
                    if(i == false){
                        Console.WriteLine("ERROR. Press any key to redirect to login menu.");
                        Console.ReadLine();
                    }
                    if(i == true){
                        Console.WriteLine("SUCESS. The account was sucessfully created");
                        Console.WriteLine("Please type any key to continue");
                        Console.ReadLine();
                    }
                    
                }else if(choice == 3) { //encerra a funcao Main, assim encerrando o programa de vez
                    Console.WriteLine("Already? You're fast!");
                    return;
                }  
                
                else Console.WriteLine("ERROR. Type an valid option.");   

            }
    }

public void InitializeData(){
    UserList = new List<UserAccount>{
        new UserAccount{CPF = 71014884128,Name = "Hanyel", CardNum = 123456789, AccountNumber=0, Balance = 12000, PIN = 123} 
    };
    CurrentUser = new UserAccount();
    CurrentUser.isLogged = false;
    UserCount = 1;
}

public bool CheckUserLogin(){
    bool isLogged = false;
    int i = 0;
    UserAccount user;
    UserAccount current = new UserAccount();
    Console.Write("\nPlease enter the Card Number >>>_");
    current.CardNum = Utility.Convert<long>(Console.ReadLine());
    Console.Write("\nPlease enter the password >>>_ ");
    current.PIN = Utility.Convert<long>(Console.ReadLine());

    /*Now we check if there is an user account in the UserList list that has this card number and
    password*/
   
    for(user = UserList[0]; i<UserList.Count; i++){
        user = UserList[i];
        if(user.CardNum == current.CardNum && user.PIN == current.PIN){
            CurrentUser = user;
            isLogged = true;
            break;
        }
    }

        return isLogged;
}

public UserAccount UserExists(long cardNumber){
    int i = 0;
    UserAccount current = UserList[0];

    /* while(current != null){
        if(current.CardNum == cardNumber) return current;
        else{
            i++;
            current = UserList[i];
        }
    }*/

    for(current = UserList[0]; i<UserList.Count; i++){
        current = UserList[i];
        if(current.CardNum == cardNumber) return current;
    }
        return null;

}

public bool UserSignUp(){
    /*First we check to see if the card number is not yet registered*/
    Console.Write("\nPlease enter the Card Number >>>_");
    long cardNumber, pin1, pin2, cpf; 
    string name;
    cardNumber = Utility.Convert<long>(Console.ReadLine());

    if(UserExists(cardNumber) == null){
        Console.Write("Enter your full name: ");
            name = Utility.Convert<string>(Console.ReadLine());
        Console.Write("Enter your CPF: ");
            cpf = Utility.Convert<long>(Console.ReadLine());
        Console.Write("Enter your password :");
            pin1 = Utility.Convert<long>(Console.ReadLine());
        Console.Write("Confirm your password :");
            pin2 = Utility.Convert<long>(Console.ReadLine());

        if(pin1 == pin2){
            UserCount++;
            UserAccount newUser = new UserAccount();
            newUser.Name = name;
            newUser.CardNum = cardNumber;
            newUser.CPF = cpf;
            newUser.PIN = pin1;
            newUser.AccountNumber = UserCount;
            newUser.isLogged = false;
            UserList.Add(newUser); 
            return true;
        }else{
            Console.WriteLine("Error. Typed password must match.");
            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();
            return false;
        }
    }
    else return false; //there is already someone registered with this card number
}

 }
}