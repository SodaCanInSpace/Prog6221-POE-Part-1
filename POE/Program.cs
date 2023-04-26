

namespace Sanele
{
    class Compile //Class that will compile the program code
    {
        public static void Main(string[] args)
        {
            Store s = new Store(); //References the Store class
            Store.Display();//References the Display method in the Store class
        }
    }
    class Store //The store class holds the code that displays and fill the recipe program. (Named Store as it stores the recipe)
    {
        public static int count { get; set; } //The count automatic property is to keep track of the number of ingredients in the recipe

        public static int countSteps { get; set; } // The countSteps automatic property is to keep track of the number of steps the recipe goes through
        public static string[] food {get; set;} // The food automatic property holds the names of the ingredients in the recipe
        public static string[] quadType {get; set;} // The quadType automatic property holds the type of measurement of an ingredient is, e.g tablespoon, liters

        public static double[] amountOfFood {get; set;} //The amountOfFood automatic property holds the amount of a ingredient in the recipe

        public static string[] directions {get; set;} //The directions automatic property holds the description of the steps in the recipe

        public static int mathIngredients {get; set;} //The mathIngredients automatic property is used to store the users input on what ingredient to scale

        public static double[] storeAmountOfFood {get; set;} // The storeAmountOfFood automatic property holds the amount of a ingredient in the recipe, just like amountOfFood, but it is used to keep the default value so it can be used to reset the values 

        public static string[] storeQuadType {get; set;} // The storeQuadType automatic property holds the type of measurement of an ingredient, like quadtype, but used to keep the default value
        public static void Display()
        {
            int choice; //Will be initialized by the users input, and will be used to navigate the menu

         
            Boolean flag = false;// Used within while loop to continue and stop the loop 
        try { //The try and catch exception method, will catch any exceptions in the loop
            while ( flag == false) // The loop holds the menu of the program and will only end when flag is true
            {
                 Console.WriteLine("Please enter:\n1 to create a recipe\n2 to view current recipes\n3 to scale recipe\n4 to reset values\n5 to exit program"); //Layout of the menu for the user
                
                choice = Convert.ToInt32(Console.ReadLine()); //Choice is initialized by the user

                 switch (choice) //Depending on the users input, it will go to one of the cases
                {
                    case 1: //This case is to create a new recipe
                    fill(); //Calling the fill() which is used to get data from the user to create and store the recipe 

                Console.WriteLine("\nRecipe has been created\n");
                Console.WriteLine("\n----------------------------------------------------------------------");

                        break;
                    case 2: //This case, is used to display the recipe user has previously created
                    Console.WriteLine("Recipe\n----------------------------------------------------------------");

                for (var i = 0; i < count; i++) // Will loop, displaying the ingredient name, the amount and measurement type 
            {
                Console.Write("\ningredient: {0} ",food[i]);//ingredient
                Console.Write("\nquantity: {0} ",amountOfFood[i]);// amount
                Console.Write("{0}\n\n",quadType[i]);//measurement
            }
            Console.Write("Steps:");
            for (var i = 0; i < countSteps; i++) // Will loop, displaying the steps and description
            {
                Console.WriteLine("\nStep {0}\n",i+1); //Step number
                Console.WriteLine("{0}\n",directions[i]); //Step description
            }
                Console.WriteLine("\n----------------------------------------------------------------------");

                    break;

                    case 3: //This case, is used to scale the ingredient amounts

                     for (var i = 0; i < 1; i++) // used to display the current recipe amounts and options to scale 
                {
                    Console.WriteLine("Scale\n----------------------------------------------------------------");
                    Console.WriteLine("Please pick the ingredient you wish to scale:\n");
                    for (int l = 0; l < count; l++) //Displays the current recipe and amounts
                    {
                    
                    Console.Write("{0}: ",l);
                    Console.WriteLine("\nIngredient:\n");
                    Console.WriteLine("{0}", food[l]);
                    Console.Write("\nquantity: {0} ",amountOfFood[l]);
                    Console.Write("{0}\n\n",quadType[l]);
                    }
                    
                    int ingredientChoice = Convert.ToInt32(Console.ReadLine()); //The user will input which ingredient they want to scale
                    double ingredientScale = amountOfFood[ingredientChoice]; //The amount of the recipe the user chose will be given to ingredientScale
                    mathIngredients = ingredientChoice; //Stores users input, so it can ber used in the mathematics()

                    amountOfFood[ingredientChoice] = mathematics(ingredientScale); // initializies the return value from the mathematics class to the amountOfFood Array
                    Console.WriteLine("\nThe recipe has been scaled\n----------------------------------------------------------------------");
                }
                    break;
                    case 4: //This case, resets the scaled values of ingredients to the default
                    Console.WriteLine("\nReset\n-------------------------------------------------");
                        for (int i = 0; i < count; i++)// Loops till ingredients are reset
                        {
                            amountOfFood[i] = storeAmountOfFood[i];// replaces the scaled amounts[amountOfFood] for the default amounts [storeAmountOfFood]
                            quadType[i] = storeQuadType[i];
                            Console.WriteLine(storeQuadType[i]);

                        }
                        Console.Write("Reseted");
                        Console.WriteLine("\n-----------------------------------------------------");
                    break;
                    case 5: // this case, is used to exit the program
                    flag = true;
                    break;
                    default: 
                        break;
                }
            }
        
        


                
            }catch(System.Exception ex) //Will catch a System.Exception
            {
                Console.WriteLine("\nPlease Enter again\n"); 
                Display();// will run the display() again
            }  
            }
            

            
            

            




                
            

            
        
       

        public static void fill() // This class, handles and stores data to create the recipe, names, amounts, types and steps
        {
            //----------------------------------------------------------------------------------------
            //This section handles the number of ingredients and names of ingredients
             int countScore  = 0;
            Console.WriteLine("Please enter the number of ingredients\n");
            countScore = Convert.ToInt32(Console.ReadLine());
            count = countScore;
            string [] ingredients = new string[count];
            Console.WriteLine("Please enter the ingredient names\n");
            for (var i = 0; i < countScore ;i++)
            {
                string raw;
                 raw = Console.ReadLine();
                ingredients[i] = raw;
            }
            food = ingredients;
            //----------------------------------------------------------------------------------------
            //This section handles the ingredient amounts and measurement types
            double[] numAmount = new double[count]; //used to store the amount, so it can be stored into a automatic property
            double[] amount = new double[count];//used to store the amount, so it can be stored into a automatic property
            string[] quantityType = new string[count]; //used to store the measurement type, so it can be stored into the quadType automatic property
            string[] storeQuantityType = new string[count];// also used to store measurement type, it is stored in the storeQuadType automatic property
            
            
            for (int i = 0; i < count; i++)
            {
                int quat;// will hold user input, of quantity of ingredients
                string type; // will hold user input, of measurement type
                Console.WriteLine("Please enter the quantity of the ingredient\n");

                Console.WriteLine("Ingredient: {0} ",ingredients[i]+"\n");
                quat = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\nPlease enter the quantity type:\nPlease enter the letter corresponding to the type"+"\n"+"t: teaspoon , g: grams, m: milliliters");
                type = Console.ReadLine();


                if(type == "t")
                {
                    
                    if (quat >= 3)
                    {
                        quat = quat / 3;
                        quantityType[i] = "tablespoons";
                        storeQuantityType[i] = "tablespoons";
                    }
                    else
                    {
                         quantityType[i] = "teaspoon";
                         storeQuantityType[i] = "teaspoon";
                    }
                }
                if (type == "g")
                {
                    if (quat >= 1000)
                    {
                        quat = quat / 1000;
                        quantityType[i] = "Kilograms";
                        storeQuantityType[i] = "Kilograms";
                    }
                    else
                    {
                         quantityType[i] = "grams";
                         storeQuantityType[i] = "grams";
                    }
                   
                }

                 if(type == "m")
                {
                    if(quat > 1000)
                    {
                        quat = quat/1000;
                        quantityType[i] = "Liters";
                        storeQuantityType[i] = "Liters";
                        
                    }else
                    {
                        quantityType[i] = "milliliters";
                        storeQuantityType[i] = "milliliters";
                    }

                    
                }
                if(type != "t" && type != "g" && type != "m")
                {
                    Console.WriteLine("\nPlease enter the correct value:\nType:\nt : tablespoon\ng : grams\nm : milliliters\n");
                    Display();
                }

            
            

                amount[i] = quat;
                numAmount[i] = quat;
               
            }
            quadType = quantityType; // stores the names of the measurement type
            amountOfFood = amount; //Stores the amount 
            storeAmountOfFood = numAmount; // Stores the amount as well
            storeQuadType = storeQuantityType; // Stores the names of the measurement type as well
            //----------------------------------------------------------------------------------------
            //This sections handles the number of steps and description of the steps

            int stepCount;// Will hold the number of steps the users requests
            Console.WriteLine("\nPlease enter the number of steps need for the recipe:\n");
            stepCount = Convert.ToInt32(Console.ReadLine());

            string[] steps = new string[stepCount]; 

            for (int i = 0; i < stepCount; i++)
            {
                string note;// Will hold the user's description of the step 
                Console.WriteLine("Please write the instructions for:\n\nstep {0}\n",i+1);
                note = Console.ReadLine();
                steps[i] = note;
            }

            directions = steps; //stores the description
            countSteps = stepCount; // stores the amount of steps
            
           
           //---------------------------------------------------------------------------------------- 
        }

        public static double mathematics(double c) //This class handles the scaling of the ingredient amounts
        {
            //tablespoon
            double num1 = 0.5; // Used to scale by half
            double num2 = 2; //Used to scale by double
            double num3 = 3;//Used to scale by triple
//--------------------------------------------------------------------------------------------------------------------------------------------------            //Scales ingredients that are measured by tablespoons and teaspoons
             if(quadType[mathIngredients] == "tablespoons" || quadType[mathIngredients] == "teaspoon")
                {
                    Console.WriteLine("Please choose which factor to scale the recipe:\n1: 0.5 (half)\n2: 2 (double)\n3: 3 (Triple)");
                    int multiple = Convert.ToInt32(Console.ReadLine());
            
                    if(multiple == 1)// Does this code if the user picks to scale by half
                    {
                        
                        double multi = c*num1;
                        if(quadType[mathIngredients] == "tablespoons")// since the value was previously divided, it will be multiplied again to give the orginal value again
                        {
                           multi = multi*3;
                        }
                        if (multi >= 3) 
                        {
                        multi = multi / 3;
                        quadType[mathIngredients] = "tablespoons";
                        }
                        else
                        {
                         quadType[mathIngredients] = "teaspoon";
                        }
                        return multi; 

                    }else
                    {
                        if(multiple == 2)// Does this code if the user picks to scale by double
                            {
                                double multi = c*num2;
                                if(quadType[mathIngredients] == "tablespoons")
                                {
                                    multi = multi*3;
                                }
                                if (multi >= 3)
                                {
                                    multi = multi / 3;
                                    quadType[mathIngredients] = "tablespoons";
                                }
                                else
                                {
                                    quadType[mathIngredients] = "teaspoon";
                                }
                                return multi;
                            }else
                            {
                                if(multiple == 3)// Does this code if the user picks to scale by triple
                                    {
                                        double multi = c*num3;
                                        if(quadType[mathIngredients] == "tablespoons")
                                        {
                                            multi = multi*3;
                                        }
                                        if (multi >= 3)
                                        {
                                            multi = multi / 3;
                                            quadType[mathIngredients] = "tablespoons";
                                        }
                                        else
                                        {
                                            quadType[mathIngredients] = "teaspoon";
                                        }
                                        return multi;
                                    }

                            }

                    }
                    return c;
                }else
//--------------------------------------------------------------------------------------------------------------------------------------------------
                //Scales ingredients that are measured by grams and kilograms
                {
                    if (quadType[mathIngredients] == "grams" || quadType[mathIngredients] == "Kilograms")
                        {
                            Console.WriteLine("Please choose which factor to scale the recipe:\n1: 0.5 (half)\n2: 2 (double)\n3: 3 (Triple)");
                            int multiple = Convert.ToInt32(Console.ReadLine());
                        if(multiple == 1)// Does this code if the user picks to scale by half
                            {
                                double multi = c*num1;
                                if(quadType[mathIngredients] == "Kilograms")// since the value was previously divided, it will be multiplied again to give the orginal value again
                                {
                                    multi = multi*1000;
                                }
                                if (multi >= 1000)
                                {
                                    multi = multi / 1000;
                                    quadType[mathIngredients] = "Kilograms";
                                }
                                else
                                {
                                quadType[mathIngredients] = "grams";
                                }
                                return multi;

                            }else
                            {
                                if(multiple == 2)// Does this code if the user picks to scale by double
                                    {
                                        double multi = c*num2;
                                        if(quadType[mathIngredients] == "Kilograms")
                                        {
                                            multi = multi*1000;
                                        }
                                        if (multi >= 1000)
                                        {
                                            multi = multi / 1000;
                                            quadType[mathIngredients] = "Kilograms";
                                        }
                                        else
                                        {
                                            quadType[mathIngredients] = "grams";
                                        }
                                
                                        return multi;
                                    }else
                                    {
                                        if(multiple == 3) // Does this code if the user picks to scale by triple
                                            {
                                                double multi = c*num3;
                                                if(quadType[mathIngredients] == "Kilograms")
                                                {
                                                 multi = multi*1000;
                                                }
                                                if(quadType[mathIngredients] == "Kilograms")
                                                {
                                                    multi = multi*1000;
                                                }
                                                if (multi >= 1000)
                                                {
                                                    multi = multi / 1000;
                                                    quadType[mathIngredients] = "Kilograms";
                                                }
                                                else
                                                {
                                            quadType[mathIngredients] = "grams";
                                                }
                                                return multi;
                                            }

                                    }

                            }
                            return c;
                            }else
                           
//--------------------------------------------------------------------------------------------------------------------------------------------------
                             //Scales ingredients that are measured by grams and kilograms
                                        {
                                         if (quadType[mathIngredients] == "milliliters" || quadType[mathIngredients] == "Liters")
                                                {
                                                Console.WriteLine("Please choose which factor to scale the recipe:\n1: 0.5 (half)\n2: 2 (double)\n3: 3 (Triple)");
                                                int multiple = Convert.ToInt32(Console.ReadLine());
                                                if(multiple == 1)// Does this code if the user picks to scale by half
                                                    {
                                                        double multi = c*num1;
                                                        if(quadType[mathIngredients] == "Liters")// since the value was previously divided, it will be multiplied again to give the orginal value again
                                                            {
                                                                multi = multi*1000;
                                                            }
                                                         if(multi > 1000)
                                                            {
                                                                multi = multi/1000;
                                                                quadType[mathIngredients] = "Liters";
                        
                                                            }else
                                                            {
                                                                quadType[mathIngredients] = "milliliters";
                                                            }

                                                        return multi;

                                                    }else
                                                    {
                                                        if(multiple == 2)// Does this code if the user picks to scale by double
                                                            {
                                                                double multi = c*num2;
                                                                if(quadType[mathIngredients] == "Liters")
                                                                {
                                                                    multi = multi*1000;
                                                                }

                                                                if(multi > 1000)
                                                            {
                                                                multi = multi/1000;
                                                                quadType[mathIngredients] = "Liters";
                        
                                                            }else
                                                            {
                                                                quadType[mathIngredients] = "milliliters";
                                                            }
                                                                return multi;
                                                            }else
                                                            {
                                                                if(multiple == 3)// Does this code if the user picks to scale by triple
                                                                    {
                                                                        double multi = c*num3;
                                                                        
                                                                        if(quadType[mathIngredients] == "Liters")
                                                                        {
                                                                            multi = multi*1000;
                                                                        }
                                                                        if(multi > 1000)
                                                                            {
                                                                                multi = multi/1000;
                                                                                quadType[mathIngredients] = "Liters";
                        
                                                                             }else
                                                                            {
                                                                                quadType[mathIngredients] = "milliliters";
                                                                            }
                                                                        return multi;
                                                                    }
                                                             return c;
                                                            }
                                                        
                                                    }   

                                                 
                                                }
                                         return c;
                                        }
                            }
                }
        }
}