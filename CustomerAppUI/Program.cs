
using CustomerAppBLL;
using System;
using CustomerAppBLL.BusinessObjects;

namespace CustomerAppUI
{
    class Program
    {
        static BLLFacade bllFacade = new BLLFacade();
        public static void Main(string[] args)
        {
            CustomerBO cos1 = new CustomerBO()
            {
                
                FirstName = "Joshep",
                LastName = "Hopkins",
                Address = "21st street"
            };

            bllFacade.CustomerService.Create(cos1);
            bllFacade.CustomerService.Create(new CustomerBO()
            {
                
                FirstName = "John",
                LastName = "Travolta",
                Address = "GreaseStreet 21-2nd"
            });




            string[] menuItems =
             {
                "List All Customers",
                "Add Customer",
                "Delete Customer",
                "Edit Customer",
                "Exit"
            };



            Console.WriteLine(" ");

            int selection = ShowMenu(menuItems);
            while (selection != 5)
            {


                switch (selection)
                {
                    case 1:


                        ListCustomers();
                        break;
                    case 2:

                        AddCustomers();
                        break;
                    case 3:

                        DeleteCustomers();
                        break;
                    case 4:
                        EditCustomer();
                        break;
                    
                    default:
                        Console.WriteLine("Write number available on the menu");
                        break;
                }
                selection = ShowMenu(menuItems);
            }
            Console.WriteLine("Thanks for using the program");

            Environment.Exit(1);
            

        }

        private static void EditCustomer()
        {
            var customer = FindCustomerById();
            if (customer != null)
            {
                Console.WriteLine("FirstName: ");
                customer.FirstName = Console.ReadLine();
                Console.WriteLine("LastName: ");
                customer.LastName = Console.ReadLine();
                Console.WriteLine("Address: ");
                customer.Address = Console.ReadLine();
                bllFacade.CustomerService.Update(customer);
                Console.WriteLine($"Customer with id: {customer.Id} has beeen edited!");
            }
            else
            {
                Console.WriteLine("Customer not Found!");
            }
            
        }

        private static CustomerBO FindCustomerById()
        {
            Console.WriteLine("Insert customer Id: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Insert Number");
            }


            return bllFacade.CustomerService.Get(id);
        }

        private static void DeleteCustomers()
        {
            var customerFound = FindCustomerById();
            

            bllFacade.CustomerService.Delete(customerFound.Id);
            
            var respons = customerFound == null ? "Id doesn't exist" : "Deleted";
            Console.WriteLine(respons);
                        
        }

        private static void AddCustomers()
        {
            Console.WriteLine("FirstName: ");
            var firstName = Console.ReadLine();

            Console.WriteLine("LastName: ");
            var lastName = Console.ReadLine();

            Console.WriteLine("Address: ");
            var address = Console.ReadLine();

            bllFacade.CustomerService.Create(new CustomerBO()
            {
                
                FirstName = firstName,
                LastName = lastName,
                Address = address
6
            });
        }

        private static void ListCustomers()
        {
            
            Console.WriteLine("\nList Costumers\n");
            foreach (var customer in bllFacade.CustomerService.GetAll())
            {
                Console.WriteLine($"Id: {customer.Id} Name: {customer.FullName} Address: {customer.Address}");
                Console.WriteLine(""); 
            }
            Console.WriteLine("\n");
        }

        private static int ShowMenu(string[] menuItems)
        {

            Console.WriteLine("Select an option:\n");

            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine($"{ (i + 1)}: {menuItems[i]}");
                Console.WriteLine("");
                
            }
            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection) || selection > 5 || selection < 1)
            {
                Console.WriteLine("You need to select a number between 1-5");

            }



            return selection;

        }

    }
}
