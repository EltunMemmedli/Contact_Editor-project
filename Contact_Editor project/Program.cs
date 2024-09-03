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
int Secim = int.Parse(Console.ReadLine());
Console.Clear();


#region Default_Contacts


// Default Kontaktların göstərilməsi
if(Secim == 1)
{
    for (int i = 0; i < default_contacts.Length; i++)
    {

        Console.WriteLine($"ID: {i + 1},\n" +
                     $" Name: {default_contacts[i][0]},\n" +
                     $" Surname: {default_contacts[i][1]},\n" +
                     $" Phone number: {default_contacts[i][2]}\n\n");




    }
    Console.WriteLine("==================================");




    Thread.Sleep(2000);
    Console.WriteLine("Press 'f' to return to the start or any other key to exit...");

    string Kec = Console.ReadLine();

    if (Kec.ToLower() == "f")
    {
        Console.Clear();
        goto Start;
    }
}

#endregion


#region Add Contacts
// Yeni Kontaktlar əlavə etmək
if (Secim == 2)
{
    Console.Write("How many contacts will you save?: ");
    int count = int.Parse(Console.ReadLine());
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


}

if (Secim == 1)
{
    foreach (var item in default_contacts)
    {
        Console.WriteLine(item);
    }

}


if (Secim == 2)
{
    Thread.Sleep(2000);
    Console.WriteLine("Press 'f' to return to the start or any other key to exit...");

    string Kec_1 = Console.ReadLine();

    if (Kec_1.ToLower() == "f")
    {
        Console.Clear();
        goto Start;
    }
};

#endregion


#region Search
if (Secim == 3)
{
    Console.WriteLine("Which Property would you like to search by? (Name / Surname / Phone number): ");
    string option = Console.ReadLine().Trim();  // İstifadəçinin daxil etdiyi dəyəri oxuyur və boşluqları təmizləyir

Baslangic:
    Console.WriteLine($"Please enter the {option}: ");
    string searchValue = Console.ReadLine().Trim();  // Axtarış üçün istifadə olunan dəyəri oxuyur

    bool found = false;  // Heç bir nəticə tapılmadığını yoxlamaq üçün bayraq

    for (int i = 0; i < default_contacts.Length; i++)
    {
        if ((option == "Name" && default_contacts[i][0] == searchValue) ||
            (option == "Surname" && default_contacts[i][1] == searchValue) ||
            (option == "Phone number" && default_contacts[i][2] == searchValue))
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

    Thread.Sleep(2000);

    Console.WriteLine("Press 'f' to return to the start or any other key to exit...");
    string returnToStart = Console.ReadLine();

    if (returnToStart.ToLower() == "f")
    {
        Console.Clear();
        goto Start;
    }
}
#endregion


#region Editing

if (Secim == 4)
{
Edit:
    Console.WriteLine("Which contact will you edit?"); // Kontakt seçimi
    string choosenContact = Console.ReadLine();
    bool contactFound = false; // Kontaktın tapılıb-tapılmadığını yoxlamaq üçün
    int choosenIndex = -1; // Seçilmiş kontaktın indeksini saxlamaq üçün

    string[] Choosen_Range = new string[3]; // Seçilmiş kontaktın məlumatlarını saxlayacaq massiv

    for (int i = 0; i < default_contacts.Length; i++)
    {
        if (choosenContact == default_contacts[i][0])
        {
            // "Choosen_Range" massivinə seçilmiş kontaktın məlumatlarını kopyalayırıq
            Choosen_Range[0] = default_contacts[i][0]; // Ad
            Choosen_Range[1] = default_contacts[i][1]; // Soyad
            Choosen_Range[2] = default_contacts[i][2]; // Telefon nömrəsi və ya digər məlumat

            contactFound = true; // Əgər kontakt tapılıbsa, dövrü dayandır
            choosenIndex = i; // İndeksi saxlamaq
            break;
        }
    }

    if (!contactFound)
    {
        Console.WriteLine("Contact not found. Try again!");

        Thread.Sleep(3000);
        Console.Clear();
        goto Edit; // Əgər kontakt tapılmayıbsa, yenidən cəhd etmək üçün
    }
    else
    {
        Console.WriteLine("Which property will you edit?"); // Kontaktın hansı xüsusiyyəti redaktə ediləcək
        string choosenProperty = Console.ReadLine();

    Choose:
        bool Changcontact = false;

        if (choosenProperty.ToLower() == "Name".ToLower())
        {
            Console.WriteLine("Write new Name:");
            string new_contact = Console.ReadLine();
            Choosen_Range[0] = new_contact;
            Changcontact = true;
        }
        else if (choosenProperty.ToLower() == "Surname".ToLower())
        {
            Console.WriteLine("Write new Surname:");
            string new_contact = Console.ReadLine();
            Choosen_Range[1] = new_contact;
            Changcontact = true;
        }
        else if (choosenProperty.ToLower() == "Phone number".ToLower())
        {
            Console.WriteLine("Write new Phone number:");
            string new_contact = Console.ReadLine();
            Choosen_Range[2] = new_contact;
            Changcontact = true;
        }
        else
        {
            Console.WriteLine("Invalid property. Try again!");
            Thread.Sleep(2000);
            goto Choose; // Əgər xüsusiyyət düzgün deyilse, yenidən cəhd etmək üçün
        }

        if (Changcontact)
        {
            Console.WriteLine("Contact has successfully changed!");

            // Yenilənmiş məlumatları default_contacts massivində müvafiq indeksdə yeniləyirik
            default_contacts[choosenIndex][0] = Choosen_Range[0];
            default_contacts[choosenIndex][1] = Choosen_Range[1];
            default_contacts[choosenIndex][2] = Choosen_Range[2];

            Console.WriteLine("Press 'f' to return to the start or any other key to exit...");
            string returnToStart = Console.ReadLine();

            if (returnToStart.ToLower() == "f")
            {
                Console.Clear();
                goto Start; // Başlanğıca qayıtmaq üçün
            }
        }
    }
}






#endregion


#region Deleting
if (Secim == 5)
{

    Console.WriteLine("Which property do you want to use to remove the contact? (Name/Surname/Phone number)");
    string property = Console.ReadLine().Trim().ToLower();

    Console.Write("Enter the value to search: ");
    string searchValue = Console.ReadLine().Trim();


    string[][] newContacts = new string[default_contacts.Length - 1][];

    int newIndex = 0;
    bool found = false;

    for (int i = 0; i < default_contacts.Length; i++)
    {
        bool match = false;

        if (property == "name" && default_contacts[i][0].ToLower() == searchValue.ToLower())
        {
            match = true;
        }
        else if (property == "surname" && default_contacts[i][1].ToLower() == searchValue.ToLower())
        {
            match = true;
        }
        else if (property == "phone number" && default_contacts[i][2] == searchValue)
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

    Thread.Sleep(2000);

    Console.WriteLine("Press 'f' to return to the start or any other key to exit...");
    string returnToStart = Console.ReadLine();

    if (returnToStart.ToLower() == "f")
    {
        Console.Clear();
        goto Start;
    }

}
#endregion