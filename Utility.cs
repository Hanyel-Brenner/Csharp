
using System.ComponentModel;
using System;
using System.Text;

namespace Utilities{
public static class Utility
{
    public static T Convert<T>(string value){  
        
        string? input = value;

        while(true){
    
            try{
                var converter = TypeDescriptor.GetConverter(typeof(T));
                if(converter != null){
                    return (T)converter.ConvertFromString(input);
                }else{
                    return default;
                }
            }catch {
                Console.WriteLine("Invalid input. Please try again...");
            }
            Console.Write(" >>>_");
            input = Console.ReadLine();
        }
       // return default;
    }
    public static string ValidatePIN(){
        bool isPrompt = true;
        StringBuilder input = new StringBuilder();

        while(true){
            ConsoleKeyInfo key = Console.ReadKey(true);

            if(key.Key == ConsoleKey.Enter){
                if(input.Length == 8){
                    break;
                }
                else{
                    Console.WriteLine("Number of digits must be 8. Please try again >>>_");
                    isPrompt = true;
                    input.Clear();
                }
            }

            if(key.Key == ConsoleKey.Backspace && input.Length > 0){
                input.Remove(input.Length - 1, 1);
            }else if(key.Key != ConsoleKey.Backspace){
                input.Append(key.KeyChar);
                Console.Write("*");
            }
        }
        return input.ToString();
    }
}
}