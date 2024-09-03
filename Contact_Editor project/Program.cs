string[][] default_contacts = new string[][]
{
    new string[3] { "Nicat", "Qurbanov", "+994554585858" },
    new string[3] { "Eltun", "Memmedli", "+994704255540" },
    new string[3] { "Cavid", "Memmedli", "+994772771460" },
    new string[3] { "Aysel", "Ehmedov", "+994558563625" }
};
Start:
Console.WriteLine("Which option will you chosse? \n\n" +
                    "1. Default_Contacts \n" +
                    "2. Add New Contacts \n" +
                    "3. Searching Contacts \n" +
                    "4. Editing Contacts \n" +
                    "5. Deleting Contacts \n\n" +
                    "===============================");
string Secim = Console.ReadLine();
Console.Clear();

if (Secim.All(char.IsDigit))
{
    #region Default_Contacts


    if (Secim == "1")
    {
        for (int i = 0; i < default_contacts.Length; i++)
        {

            Console.WriteLine($"ID: {i + 1},\n" +
                         $" Name: {default_contacts[i][0]},\n" +
                         $" Surname: {default_contacts[i][1]},\n" +
                         $" Phone number: {default_contacts[i][2]}\n\n");




        }
        Console.WriteLine("==================================");



        Kec:
        Thread.Sleep(2000);
        Console.WriteLine("Press 'f' to return to the start or any other key to exit...");

        string Kec = Console.ReadLine();

        if (Kec.ToLower() == "f")
        {
            Console.Clear();
            goto Start;
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Duzgun duymeye basdiginizdan emin olun!");
            
            
            goto Kec;
        }
    }

    #endregion


    #region Add Contacts
 
    else if (Secim == "2")
    {
    Reqem:
        Console.Write("How many contacts will you save?: ");
        string input = Console.ReadLine();
        int count;

      
        if (!int.TryParse(input, out count))
        {
            Console.Clear();
            Console.WriteLine("Invalid type! Please try again!");
            Thread.Sleep(2000);
            Console.Clear();
            goto Reqem;
        }

        Console.Clear();

        string[][] contacts = new string[count][];

        for (int i = 0; i < count; i++)
        {
            contacts[i] = new string[3];
        }

        for (int k = 0; k < count; k++)
        {
            Console.Write("Name: ");
            contacts[k][0] = Console.ReadLine();

            contacts[k][0] = char.ToUpper(contacts[k][0][0]) + contacts[k][0].Substring(1).ToLower();

            Console.Write("Surname: ");
            contacts[k][1] = Console.ReadLine();

            contacts[k][1] = char.ToUpper(contacts[k][1][0]) + contacts[k][1].Substring(1).ToLower();

            bool validNumber = false;

            while (!validNumber)
            {
                Console.Write("Phone number: ");
                contacts[k][2] = Console.ReadLine();

                string plus = "+";
                bool isDigits = contacts[k][2].Substring(1).All(char.IsDigit);
                bool startsWithPlus = contacts[k][2].StartsWith(plus);

                if (isDigits && startsWithPlus)
                {
                    if (contacts[k][2].Substring(1, 3) == "994")
                    {
                        if (contacts[k][2].Substring(4, 2) == "50" || contacts[k][2].Substring(4, 2) == "51" ||
                            contacts[k][2].Substring(4, 2) == "55" || contacts[k][2].Substring(4, 2) == "70" ||
                            contacts[k][2].Substring(4, 2) == "77")
                        {
                            if (contacts[k][2].Length == 13)
                            {
                                validNumber = true;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Invalid Phone Number! Please Try Again!");
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid Phone Number! Please Try Again!");
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid Phone Number! Please Try Again!");
                    }

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid Phone Number! Please Try Again!");
                }
            }

            Console.Clear();
        }

        Array.Resize(ref default_contacts, contacts.Length + default_contacts.Length);
        contacts.CopyTo(default_contacts, 4);

        Console.WriteLine("Saved contacts:");
        for (int i = 0; i < default_contacts.Length; i++)
        {
            Console.WriteLine($"ID: {i + 1},\n" +
                              $" Name: {default_contacts[i][0]},\n" +
                              $" Surname: {default_contacts[i][1]},\n" +
                              $" Phone number: {default_contacts[i][2]}\n" +
                              $"==================================");
        }
        Kec:
        Thread.Sleep(2000);
        Console.WriteLine("Press 'f' to return to the start or any other key to exit...");

        string Kec_1 = Console.ReadLine();

        if (Kec_1.ToLower() == "f")
        {
            Console.Clear();
            goto Start;
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Duzgun duymeye basdiginizdan emin olun!");
            
            
            goto Kec;
        }
    }

    #endregion


    #region Search
    else if (Secim == "3")
    {
        option:
        Console.WriteLine("Which Property would you like to search by? (Name / Surname / Phone number): ");
        string option = Console.ReadLine().ToLower(); 

        if(option != "Name".ToLower() &&
            option != "Surname".ToLower() &&
                option != "Phone number".ToLower())
        {
            Console.WriteLine("Choose the right options!");
            Thread.Sleep(2000);
            Console.Clear();
            goto option;
        }
        else
        {
        Baslangic:
            Console.WriteLine($"Please enter the {option}: ");
            string searchValue = Console.ReadLine().Trim();

            bool found = false;

            for (int i = 0; i < default_contacts.Length; i++)
            {
                if ((option == "Name".ToLower()  && default_contacts[i][0].ToLower() == searchValue.ToLower()) ||
                    (option == "Surname".ToLower()  && default_contacts[i][1].ToLower() == searchValue.ToLower()) ||
                    (option == "Phone number".ToLower()  && default_contacts[i][2].ToLower() == searchValue.ToLower()))
                {
                    Console.WriteLine($"ID: {i + 1},\n " +
                                        $"Name: {default_contacts[i][0]},\n " +
                                        $"Surname: {default_contacts[i][1]},\n " +
                                        $"Phone number: {default_contacts[i][2]}");
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("No results found.");
            }
            Kec:
            Thread.Sleep(2000);

            Console.WriteLine("Press 'f' to return to the start or any other key to exit...");
            string returnToStart = Console.ReadLine();

            if (returnToStart.ToLower() == "f")
            {
                Console.Clear();
                goto Start;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Duzgun duymeye basdiginizdan emin olun!");
                
                
                goto Kec;
            }
        }
    }

   
    #endregion


    #region Editing

    else if (Secim == "4")
    {
    Edit:
        Console.WriteLine("Which contact will you edit?"); 
        string choosenContact = Console.ReadLine().ToLower();
        bool contactFound = false; 
        int choosenIndex = -1;

        string[] Choosen_Range = new string[3];

        for (int i = 0; i < default_contacts.Length; i++)
        {
            if (choosenContact == default_contacts[i][0].ToLower())
            {
                
                Choosen_Range[0] = default_contacts[i][0];
                Choosen_Range[1] = default_contacts[i][1]; 
                Choosen_Range[2] = default_contacts[i][2]; 

                contactFound = true;
                choosenIndex = i; 
                break;
            }
        }

        if (!contactFound)
        {
            Console.WriteLine("Contact not found. Try again!");

            Thread.Sleep(3000);
            Console.Clear();
            goto Edit; 
        }
        else
        {
        Choose:
            Console.WriteLine("Which property will you edit?"); 
            string choosenProperty = Console.ReadLine();

     
            bool Changcontact = false;

            if (choosenProperty.ToLower() == "Name".ToLower())
            {
                Console.WriteLine("Write new Name:");

                Choosen_Range[0] = Console.ReadLine();

                Choosen_Range[0] = char.ToUpper(Choosen_Range[0][0]) + Choosen_Range[0].Substring(1).ToLower();
       

                Changcontact = true;
            }
            else if (choosenProperty.ToLower() == "Surname".ToLower())
            {
                Console.WriteLine("Write new Surname:");
                Choosen_Range[1] = Console.ReadLine();

                Choosen_Range[1] = char.ToUpper(Choosen_Range[1][0]) + Choosen_Range[1].Substring(1).ToLower();


                Changcontact = true;
            }
            else if (choosenProperty.ToLower() == "Phone number".ToLower())
            {
                bool validNumber = false;

                while (!validNumber)
                {
                    Console.Write("Write phone number: ");

                    Choosen_Range[2] = Console.ReadLine();

                    string plus = "+";
                    bool isDigits = Choosen_Range[2].Substring(1).All(char.IsDigit);
                    bool startsWithPlus = Choosen_Range[2].StartsWith(plus);

                    if (isDigits && startsWithPlus)
                    {
                        if (Choosen_Range[2].Substring(1, 3) == "994")
                        {
                            if (Choosen_Range[2].Substring(4, 2) == "50" || Choosen_Range[2].Substring(4, 2) == "51" ||
                                Choosen_Range[2].Substring(4, 2) == "55" || Choosen_Range[2].Substring(4, 2) == "70" ||
                                Choosen_Range[2].Substring(4, 2) == "77")
                            {
                                if (Choosen_Range[2].Length == 13)
                                {
                                    validNumber = true;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Invalid Phone Number! Please Try Again!");
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Invalid Phone Number! Please Try Again!");
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Invalid Phone Number! Please Try Again!");
                        }

                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid Phone Number! Please Try Again!");
                    }
                }


                Changcontact = true;
            }
            else
            {
                Console.WriteLine("Invalid property. Try again!");
                Thread.Sleep(2000);
                Console.Clear();
                goto Choose;
            }

            if (Changcontact)
            {
                Console.Clear();
                Console.WriteLine("Contact has successfully changed!");

              
                default_contacts[choosenIndex][0] = Choosen_Range[0];
                default_contacts[choosenIndex][1] = Choosen_Range[1];
                default_contacts[choosenIndex][2] = Choosen_Range[2];

                Kec:
                Thread.Sleep(2000);
                Console.WriteLine("Press 'f' to return to the start or any other key to exit...");
                string returnToStart = Console.ReadLine();

                if (returnToStart.ToLower() == "f")
                {
                    Console.Clear();
                    goto Start; 
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Duzgun duymeye basdiginizdan emin olun!");
                    
                    
                    goto Kec;
                }
            }
        }
    }






    #endregion


    #region Deleting
    else if (Secim == "5")
    {
        property:
        Console.WriteLine("Which property do you want to use to remove the contact? (Name/Surname/Phone number)");
        string property = Console.ReadLine().ToLower();

        if (property != "name" && property != "surname" && property != "phone number")
        {
            Console.WriteLine("Choose the right options!");
            Thread.Sleep(2000);
            Console.Clear();
            goto property;
        }
        else
        {
            Console.Write("Enter the value to search: ");
            string searchValue = Console.ReadLine().ToLower();

            
            int matchesCount = 0;
            for (int i = 0; i < default_contacts.Length; i++)
            {
                if ((property == "name" && default_contacts[i][0].ToLower() == searchValue) ||
                    (property == "surname" && default_contacts[i][1].ToLower() == searchValue) ||
                    (property == "phone number" && default_contacts[i][2] == searchValue))
                {
                    matchesCount++;
                }
            }

            
            string[][] newContacts = new string[default_contacts.Length - matchesCount][];
            int newIndex = 0;
            bool found = false;

            for (int i = 0; i < default_contacts.Length; i++)
            {
                bool match = false;

                if ((property == "name" && default_contacts[i][0].ToLower() == searchValue) ||
                    (property == "surname" && default_contacts[i][1].ToLower() == searchValue) ||
                    (property == "phone number" && default_contacts[i][2] == searchValue))
                {
                    match = true;
                }

                if (!match)
                {
                    newContacts[newIndex] = default_contacts[i];
                    newIndex++;
                }
                else
                {
                    found = true;
                }
            }

            if (found)
            {
                default_contacts = newContacts;
                Console.WriteLine("Contact removed successfully!\n");
            }
            else
            {
                Console.WriteLine("No contact found with the specified details.");
            }

            Console.WriteLine("Updated contacts:");
            for (int i = 0; i < default_contacts.Length; i++)
            {
                Console.WriteLine($"ID: {i + 1},\n" +
                                  $" Name: {default_contacts[i][0]},\n" +
                                  $" Surname: {default_contacts[i][1]},\n" +
                                  $" Phone number: {default_contacts[i][2]}\n" +
                                  $"==================================");
            }

        }
        Kec:
        Thread.Sleep(2000);

        Console.WriteLine("Press 'f' to return to the start or any other key to exit...");
        string returnToStart = Console.ReadLine();

        if (returnToStart.ToLower() == "f")
        {
            Console.Clear();
            goto Start;
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Duzgun duymeye basdiginizdan emin olun!");


            goto Kec;
        }
    }


    #endregion

    else
    {
        Console.Clear();
        Console.WriteLine("Duzgun secim edin!");
        Thread.Sleep(2000);
        Console.Clear();
        goto Start;
    }
}

else
{
    Console.Clear();
    Console.WriteLine("Duzgun secim edin!");
    Thread.Sleep(2000);
    Console.Clear();
    goto Start;
}

