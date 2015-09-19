/*************************************************************************/
/**                                                                     **/
/**                                                                     **/
/**    Student Name                :  Shane Egan                        **/
/**    EMail Address               :  egan0049@algonquinlive.com        **/
/**    Student Number              :  040 695 345                       **/
/**    Course Number               :  CST 8253                          **/
/**    Lab Section Number          :  011                               **/
/**    Professor Name              :  Wei Gong                          **/
/**    Assignment Name/Number/Date :  Lab 3 - Sorting (Jan 18 2015)     **/
/**    Optional Comments           :                                    **/
/**                                                                     **/
/**                                                                     **/
/*************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EganShane_Lab3
{
    class Program
    {
        private int userNum;

        static Program sorter = new Program();

        static int[] intArray = {17,  166,  288,  324,  531,  792,  946,  157,  276,  441, 533, 355, 228, 879, 100, 421, 23, 490, 259, 227,
                            216, 317, 161, 4, 352, 463, 420, 513, 194, 299, 25, 32, 11, 943, 748, 336, 973, 483, 897, 396,
                            10, 42, 334, 744, 945, 97, 47, 835, 269, 480, 651, 725, 953, 677, 112, 265, 28, 358, 119, 784,
                            220, 62, 216, 364, 256, 117, 867, 968, 749, 586, 371, 221, 437, 374, 575, 669, 354, 678, 314, 450,
                            808, 182, 138, 360, 585, 970, 787, 3, 889, 418, 191, 36, 193, 629, 295, 840, 339, 181, 230, 150 };


        public Program()
        {
            userNum = 0;
        }

        static void Main(string[] args)
        {
            /****************************************/
            /* SearchIntArray                       */
            /****************************************/

            Console.WriteLine("\n----------------------------------");
            Console.WriteLine(" + Search the Array:");
            Console.WriteLine("----------------------------------");

            // Print the unsorted array
            Console.WriteLine("\nThe unsorted array:\n");
            PrintArray(intArray);

            // Prompt the user for input
            sorter.promptUser();

            // SearchIntArray
            int numComparisons = 0;
            int numIndex = SearchIntArray(intArray, sorter.getValidInt(), ref numComparisons);

            // Display the results of the search
            if (numIndex == -1)
            {
                Console.WriteLine("\nMade " + numComparisons + " comparisons to find " + sorter.getValidInt() + " is not in the unsorted array");
            }
            else
            {
                Console.WriteLine("\nMade " + numComparisons + " comparisons to find " + sorter.getValidInt() + " is at index " + numIndex + " in the unsorted array");
            }
            


            /****************************************/
            /* BubbleSort                           */
            /****************************************/

            Console.WriteLine("\n----------------------------------");
            Console.WriteLine(" + BubbleSort the Array:");
            Console.WriteLine("----------------------------------");

            int numSwaps = BubbleSort(intArray);

            // Output the sorted array
            Console.WriteLine("\nThe sorted array:\n");
            PrintArray(intArray);

            Console.WriteLine("\nIn total, swapped " + numSwaps + " times to sort this array");


            /****************************************/
            /* BinarySearch                         */
            /****************************************/

            Console.WriteLine("\n----------------------------------");
            Console.WriteLine(" + Binary Search the Array:");
            Console.WriteLine("----------------------------------");

            sorter.promptUser();
            // Prompt the user for input

            // SearchIntArray
            numComparisons = 0;
            numIndex = BinarySearch(intArray, sorter.getValidInt(), ref numComparisons);

            // Display the results of the search
            if (numIndex == -1)
            {
                Console.WriteLine("\nMade " + numComparisons + " comparisons to find " + sorter.getValidInt() + " is not in the sorted array using binary search");
            }
            else
            {
                Console.WriteLine("\nMade " + numComparisons + " comparisons to find " + sorter.getValidInt() + " is at index " + numIndex + " in the sorted array using binary search");
            }
            

            // Exit the console window
            Console.WriteLine("\nPress Enter to exit...");
            Console.Read();
        }

        void promptUser()
        {
            String userInput = "";

            do
            {
                // Display when input is invalid
                if (sorter.getValidInt() == -1)
                {
                    Console.Write("You must enter an integer.\n\n");
                    Console.Write("Enter an Integer: ");
                }
                else
                {
                    Console.Write("\nEnter an Integer: ");
                }

                // Store the user entered value
                userInput = Console.ReadLine();

                // Pass the saved value to the validator
                sorter.setValidInt(userInput);

            } while (sorter.getValidInt() == -1); // Loop until valid
        }

        void setValidInt(String input)
        {
            try
            {
                // Parse to an int
                userNum = Convert.ToInt32(input);
            }
            catch (FormatException e)
            {
                userNum = -1;
            }
        }

        int getValidInt()
        {
            return userNum;
        }

        static int SearchIntArray(int[] haystack, int niddle, ref int numOfComparison)
        {
            int niddleIndex = -1;

            numOfComparison = 0;

            // Loop through the array
            for (int index = 0; index < haystack.Length; index++)
            {
                // Increment the comparison count
                numOfComparison++;

                // If number is found in the array return the index
                if (niddle == haystack[index])
                {
                    niddleIndex = index;
                    break;
                }
            }

            return niddleIndex;
        }
   
        static int BubbleSort(int[] arr)
        {
            int numOfSwaps = 0;
            int temp;
            int arrayLength = arr.Length - 1;
            int comparisons = 0;

            bool swapped = true;

            do
            {
                // Potential for numbers to be swapped
                swapped = false;

                // Loop through the array
                for (int i = 0; i < arrayLength; i++)
                {
                    // Increment the comparison count
                    comparisons++;

                    // Compare adjacent elements, if they are in reverse order swap them
                    if (arr[i] > arr[i + 1])
                    {
                        temp = arr[i];

                        // Swap
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                        swapped = true;

                        // Increment swap count
                        numOfSwaps++;
                    }
                }

                // Shorten the array length each time a swap is performed
                arrayLength--;

            } while (swapped);

            // Output the number of comparisons and the newly sorted array
            Console.WriteLine("\nNumber of Comparisons: " + comparisons);

            return numOfSwaps;
        }

        static int BinarySearch(int[] haystack, int niddle, ref int numOfComparison)
        {
            int niddleIndex = -1;

            //Here you implement the binary search to find the niddle in the haystack.

            int minPoint = 0;
            int maxPoint = haystack.Length - 1;

            numOfComparison = 0;

            while (minPoint <= maxPoint)
            {
                // Find the mid way point in the array
                int midPoint = (minPoint + maxPoint) / 2;

                // Increment comparison count
                numOfComparison++;

                // If the niddle was found
                if (niddle == haystack[midPoint])
                {
                    return midPoint;
                }

                // Lower bounds of the array
                else if (niddle < haystack[midPoint])
                {
                    maxPoint = midPoint -1;
                }

                // Upper bounds of the array
                else
                {
                    minPoint = midPoint + 1;
                }
            }

            return niddleIndex;
        }

        //call this method to print an integer array to the console.
        static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (i != arr.Length - 1)
                {
                    Console.Write("{0}, ", arr[i]);
                }
                else
                {
                    Console.Write("{0} ", arr[i]);
                }
            }
            Console.WriteLine();
        }

    }
}
