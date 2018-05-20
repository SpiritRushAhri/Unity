using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {
	// Use this for initialization
   int level;
   string password;
   const string menu = "Type 'menu' to return to main menu";
   // enums are a list of possible states
   enum Screen { Menu, PasswordInput, Win };
   string [] smartphoneArr = new string [] {"apple", "samsung", "storage", "camera", "email"};
   string [] pcArr = new string [] {"windows", "graphics card", "processor", "motherboard", "hard drive"};
   string [] serverArr = new string [] {"database", "callback", "memory", "administrator", "bios"};
   Screen currentScreen;
	void Start () {
      beginHack();
                
	}
   void beginHack () {
      Terminal.ClearScreen();
      level = 0;
      currentScreen = Screen.Menu;
      Terminal.WriteLine("Loading Terminal...");
      Terminal.WriteLine("Choose target device");
      Terminal.WriteLine("1. Nearby smartphone");
      Terminal.WriteLine("2. Nearby pc");
      Terminal.WriteLine("3. Servers within a 250 mile radius");
   }
   // User input only handles the input, doesn't do it
   void OnUserInput(string input) {
      // Always able to go back to the start of the game
      if (input == "menu") {
         beginHack();
      }
      else if (currentScreen == Screen.Menu) {
         setGame(input);
      }
      else if (currentScreen == Screen.PasswordInput) {
         checkPassword(input);
      }
   }
   // Take the user input to begin the password guessing part of the game
   void setGame(string input) {
      int index;
      currentScreen = Screen.PasswordInput;
      Terminal.ClearScreen();
      switch(input) {
         case "1":
            level = 1;
            index = UnityEngine.Random.Range(0, smartphoneArr.Length);
            password = smartphoneArr[index];
            Terminal.WriteLine("Accessing nearby smartphone...");
            Terminal.WriteLine("Enter password to access data: ");
            Terminal.WriteLine("Hint: " + password.Anagram());
            break;
         case "2":
            level = 2;
            index = UnityEngine.Random.Range(0, pcArr.Length);
            password = pcArr[index];
            Terminal.WriteLine("Accessing nearby pc...");
            Terminal.WriteLine("Enter password to access data: ");
            Terminal.WriteLine("Hint: " + password.Anagram());
            break;
         case "3":
            level = 3;
            index = UnityEngine.Random.Range(0, serverArr.Length);
            password = serverArr[index];
            Terminal.WriteLine("Accessing nearby server...");
            Terminal.WriteLine("Enter password to access data: ");
            Terminal.WriteLine("Hint: " + password.Anagram());
            break;
         default:
            Terminal.WriteLine("Error in accessing nearby devices! Enter correct input.");
            break;     
      }
   }

   void checkPassword(string input) {
      if (input == password) {
         winScreen();
      }
      else {
         Terminal.WriteLine("Incorrect password! Try again...");
         Terminal.WriteLine(menu);
      }
   }
   void winScreen() {
      currentScreen = Screen.Win;
      Terminal.ClearScreen();
      reward();
   }
   void reward () {
      Terminal.WriteLine("Successfully hacked the device!");
      Terminal.WriteLine("Data stolen!");
      Terminal.WriteLine(@"
         ﺩ／|、
         (ﾟ､ 。7
         ︱ ︶ヽ     
         _U U c )ノ
      ");
      Terminal.WriteLine(menu);
   }
}