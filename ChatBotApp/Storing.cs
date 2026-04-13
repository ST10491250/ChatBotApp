using System;
using System.Collections.Generic;

namespace ChatBotApp
{
    public class Storing
    {
        // Constructor that runs the chatbot
        public Storing()
        {
            AddBotTypingEffect("******************************************************************************************\n Welcome to The Cyber Security AI \n******************************************************************************************",ConsoleColor.Blue);
           
            // Set the console color for AI prompts
            Console.ForegroundColor = ConsoleColor.Blue;

            
            AddBotTypingEffect("AI BOT - Please Enter your Name: ",ConsoleColor.Blue);
            string User_Name;
            string User_Question = string.Empty;

            // Lists to store possible responses and ignored words
            List<string> response = new List<string>();
            List<string> wordIgnor = new List<string>();

            // Fill responses and ignored words
            Store_Bot_Response(response);
            words_Ignore(wordIgnor);

            // Ask for user's name and validate it
            do
            {
               
                AddBotTypingEffect("User - ",ConsoleColor.Yellow);
                
                User_Name = Console.ReadLine();
            } while (!Validate_UserName(User_Name));

            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Blue;
            AddBotTypingEffect("AI BOT - nice to meet you " + User_Name,ConsoleColor.Blue);
            AddBotTypingEffect("AI BOT - Please Enter a Question Related to cyber Security Or enter (exit,bye,stop) to exit.",ConsoleColor.Blue);
         


            // Memory Recall Check

           
            // Loop until the user exits
            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(User_Name + " - ");
                User_Question = Console.ReadLine();

                // Check if user wants to exit
                if (Exit_AI(User_Question, User_Name))
                {
                    break;
                }
                // Validate the question
                else if (Validate_UserQuestion(User_Question))
                {
                   

                    // Try to match a keyword from the filtered question
                    bool responseMatched = Split_Search(response, wordIgnor, User_Question);

                 

                }



            } while (true); // Infinite loop until "exit" command
        }



        // Store a list of static bot responses
        public void Store_Bot_Response(List<string> Bot_Response)
        {
            
            Bot_Response.Add("Cybersecurity. Protecting computers and networks from bad actors.");
            Bot_Response.Add("Passwords. Keep them strong and never share them.");
            Bot_Response.Add("VPN. Helps keep your internet connection private.");
            Bot_Response.Add("Firewall. Blocks unwanted access to your system.");

           
            Bot_Response.Add("Phishing. When attackers trick you into giving sensitive info.");
            Bot_Response.Add("Malware. Software designed to harm your computer or steal data.");
            Bot_Response.Add("Two factor authentication. Adds a second step to secure your accounts.");
            Bot_Response.Add("Hacking. Can be good (ethical) or bad (malicious).");

            
            Bot_Response.Add("Ransomware. Malware that locks your files and asks for payment.");
            Bot_Response.Add("Encryption. Converts data into code to prevent unauthorized access.");
            Bot_Response.Add("Spyware. Software secretly monitoring your activity.");
            Bot_Response.Add("Social Engineering. Manipulating people to reveal confidential info.");
            Bot_Response.Add("DDoS Attack. Flooding a network or service to make it unusable.");
            Bot_Response.Add("Patch Management. Updating software to fix vulnerabilities.");
            Bot_Response.Add("Data Breach. When sensitive information is accessed without permission.");
        }

        // Store common ignored words (used for filtering questions)
        public void words_Ignore(List<string> ignore)
        {
            ignore.Add("tell");
            ignore.Add("what");
            ignore.Add("is");
            ignore.Add("me");
            ignore.Add("does");
            ignore.Add("why");
            ignore.Add("how");
            ignore.Add("a");
            ignore.Add("an");
            ignore.Add("the");
            ignore.Add("do");
            ignore.Add("can");
            ignore.Add("about");
            ignore.Add("for");
            ignore.Add("of");
            ignore.Add("please");
            ignore.Add("in");
            ignore.Add("to");
            ignore.Add("work");
        }

        // Check if name is valid
        private bool Validate_UserName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                AddBotTypingEffect("AI BOT: Please enter a valid name, name cannot be empty.",ConsoleColor.Red);
             
                return false;
            }
            return true;
        }

        // Check if question is valid
        private bool Validate_UserQuestion(string question)
        {
            if (string.IsNullOrEmpty(question) || question.Trim().Length < 3)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
               
                AddBotTypingEffect("AI BOT: Please enter a valid question.",ConsoleColor.Red);
                return false;
            }
            return true;
        }

        // Search for matching keywords and respond
        private bool Split_Search(List<string> response, List<string> ignore, string question)
        {
            string[] filtered_q = question.ToLower().Split(' ');
            List<string> correct_filtered = new List<string>();
            bool found = false;

            foreach (string word in filtered_q)
            {
                if (!ignore.Contains(word))
                {
                    correct_filtered.Add(word);
                    found = true;
                }
            }

            if (!found || correct_filtered.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                AddBotTypingEffect("AI BOT - Your question seems unclear or unrelated to cybersecurity. Please try asking a valid question.",ConsoleColor.Red);
               
                Console.ResetColor();
                return true;
            }

            bool responseFound = false;

            foreach (string res in response)
            {
                string[] responseParts = res.Split('.');
                if (responseParts.Length > 1)
                {
                    string keyword = responseParts[0].Trim().ToLower();
                    string description = responseParts[1].Trim();

                    foreach (string word in correct_filtered)
                    {
                        if (keyword.Contains(word))
                        {
                            AddBotTypingEffect("AI BOT - " + description, ConsoleColor.Cyan);
                            AddBotTypingEffect("AI BOT - Let me know if you need further assistance or enter (exit/stop) to exit.", ConsoleColor.Cyan);
                            
                            responseFound = true;
                            break;
                        }
                    }
                }
                if (responseFound) break;
            }

            if (!responseFound)
            {
                // Check if gibberish or totally off-topic
                bool matchedTopic = false;
                string lowerQ = question.ToLower();
                List<string> knownTopics = new List<string> {
                    "cybersecurity", "phishing", "malware", "firewall", "ransomware",
                    "vpn", "hacking", "passwords", "authentication", "encryption",
                    "spyware", "data breach", "social engineering"
                };

                foreach (string topic in knownTopics)
                {
                    if (lowerQ.Contains(topic))
                    {
                        matchedTopic = true;
                        break;
                    }
                }

                if (!matchedTopic)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    AddBotTypingEffect("AI BOT - Sorry, I couldn’t understand your question. Please ask something related to cybersecurity.",ConsoleColor.Red);
                  
                    Console.ResetColor();
                    return true; // Prevent random response
                }

              
            }

            return true;
        }


        // Exit logic — returns true if user wants to stop
        public bool Exit_AI(string question, string nameofUser)
        {
            List<string> stop_words = new List<string> { "stop", "exit", "goodbye", "bye" };

            foreach (string s in stop_words)
            {
                if (question.ToLower().Contains(s))
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    AddBotTypingEffect("__________________________________________________________________________________________",ConsoleColor.Cyan);
                    AddBotTypingEffect("AI BOT: Goodbye " + nameofUser + " I hope I was able to help, looking forward to helping you again", ConsoleColor.Cyan);
                    AddBotTypingEffect("__________________________________________________________________________________________", ConsoleColor.Cyan);
                    return true;
                }
            }
            return false;
        }

        //created a method that changes the Bot typing effect, making it more user friendly
        //passed the message,message color and the speed of the message as parameters
        public void AddBotTypingEffect(string BotMessage, ConsoleColor textcolor, int text_speed = 30)
        {
            Console.ForegroundColor = textcolor;
            foreach (char messages in BotMessage)
            {
                Console.Write(messages);
                System.Threading.Thread.Sleep(text_speed); // Adjusting the speed for effect
            }
            Console.WriteLine();
            Console.ResetColor();
        }
    }
}