string[][] default_contacts = new string[][]
{
    new string[3] { "Nicat", "Qurbanov", "0554585858" },
    new string[3] { "Eltun", "Memmedli", "0704255540" },
    new string[3] { "Cavid", "Memmedli", "0772771460" },
    new string[3] { "Aysel", "Ehmedov", "0558563625" }
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
for (int i = 0; i < default_contacts.Length; i++)
{
    if (Secim == 1)
    {
        Console.WriteLine($"ID: {i + 1},\n" +
                     $" Name: {default_contacts[i][0]},\n" +
                     $" Surname: {default_contacts[i][1]},\n" +
                     $" Phone number: {default_contacts[i][2]}\n\n");

    }
}
Console.WriteLine("==================================");

if (Secim == 1)
{
    Thread.Sleep(2000);
    Console.WriteLine("Press 'f' to return to the start or any other key to exit...");

    string Kec = Console.ReadLine();

    if (Kec.ToLower() == "f")
    {
        Console.Clear();
        goto Start;
    }
};

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

            if (contacts[k][2].All(char.IsDigit))
            {
                validNumber = true;
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
    Console.WriteLine("Which property will you edit in contacts?");
    string Choose = Console.ReadLine().ToLower();

    Console.WriteLine("Which contact will you edit? ");
    string new_contact = Console.ReadLine().ToLower();

    // Burada for each ile sen contacts adlarini daxil edilen contacts ile yoxlanmalisan 
    // eger daxil etdiyi ad movcud deilse hec asagidaki hisseye dusmemelidir!

    Console.WriteLine("Write new property");
    string new_property = Console.ReadLine();


    bool contactFound = false;

    for (int i = 0; i < default_contacts.Length; i++)
    {
        if (Choose == "name")
        {
            if (default_contacts[i][0].ToLower() == new_contact.ToLower())
            {
                default_contacts[i][0] = new_property;
                contactFound = true;
                Console.WriteLine("Name updated successfully.");
                break;
            }
            else { Console.WriteLine("Name Cannot Find!!"); }
        }
        else if (Choose == "Surname" && default_contacts[i][1].ToLower() == new_contact.ToLower())
        {
            default_contacts[i][1] = new_property;
            contactFound = true;
            Console.WriteLine("Surname updated successfully.");
            break;
        }
        else if (Choose == "phone number" && default_contacts[i][2] == new_contact)
        {
            default_contacts[i][2] = new_property;
            contactFound = true;
            Console.WriteLine("Phone number updated successfully.");
            break;
        }
    }
    if (!contactFound)
    {
        Console.WriteLine("Contact not found or invalid property. Please try again!");
    }

    Console.WriteLine("Press 'f' to return to the start or any other key to exit...");
    string Kec = Console.ReadLine();
    if (Kec.ToLower() == "f")
    {
        Console.Clear();
        goto Start;
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