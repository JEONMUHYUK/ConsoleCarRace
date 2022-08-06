using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromptCarRace
{
    internal class StartScene
    {

        public void Start()
        {

            Console.Title = "Prompt RPG";
            RunMainMenu();


        }

        private void RunMainMenu()                                             
        {
            string prompt = @"




   _____                                       _                   
  |  __ \                                     | |                  
  | |__) |  _ __    ___    _ __ ___    _ __   | |_                 
  |  ___/  | '__|  / _ \  | '_ ` _ \  | '_ \  | __|                
  | |      | |    | (_) | | | | | | | | |_) | | |_                 
  |_|___   |_|     \___/__|_| |_|_|_| | .__/   \__| _____   ______ 
  / ____|     /\     |  __ \  |  __ \ | |  /\      / ____| |  ____|
 | |         /  \    | |__) | | |__) ||_| /  \    | |      | |__   
 | |        / /\ \   |  _  /  |  _  /    / /\ \   | |      |  __|  
 | |____   / ____ \  | | \ \  | | \ \   / ____ \  | |____  | |____ 
  \_____| /_/    \_\ |_|  \_\ |_|  \_\ /_/    \_\  \_____| |______|
                                                                   
                                                                   


";            // 프롬프트 값
            string[] options = { "Play", "About", "Exit" };                    
            Menu mainMenu = new Menu(prompt, options);                         
            int selectedIndex = mainMenu.Run();
            switch (selectedIndex)
            {
                case 0:
                    RunFirstChoice();
                    break;
                case 1:
                    DisplayAboutInfo();
                    break;
                case 2:
                    ExitGame();
                    break;
            }
        }

        private void ExitGame()
        {
            Console.WriteLine("\nPressed any Key to exit....");
            Console.ReadKey(true);
            Environment.Exit(0);                               
        }

        private void DisplayAboutInfo()
        {
            Console.WriteLine("This is CarRace!! Try Play!");
            Console.ReadKey(true);             
            RunMainMenu();
        }

        private void RunFirstChoice()
        {
            return;
        }

 
    }
}
