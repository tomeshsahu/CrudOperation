using ADOConnection;
using System;

Console.WriteLine("----------Sql database Program---------");
ADO obj = new ADO();
bool check= true;
while(check)
{
    Console.WriteLine("1.Insert Data\n2.Dispay Data\n3.Update Data\n4.Delete Date");
    Console.WriteLine("Enter Number To Execute Program");
    int option =Convert.ToInt32(Console.ReadLine());
    switch(option)
    {
        case 1:
            obj.Insertion();
            break;
        case 2:
            obj.Display();
            break;
        case 3:
            obj.Update();
            break;
        case 4:
            obj.Delete();
            break;
       
    }

}
