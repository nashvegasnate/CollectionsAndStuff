using System;
using System.Collections.Generic;

namespace CollectionsAndStuff
{
    class Program
    {
        static void Main(string[] args)
        {
            //***ALL of these methods mutate the original collection***

            //List<T> is a generic type parameter - it requires me to tell it what type of stuff it does/uses
            //in this caser 'string' is a type parameter used to tell the List<T> how to work
            var e14Names = new List<string>();

            //add a single item
            //works like .push = appends to the end of the list
            e14Names.Add("Martin");
            e14Names.Add("Chie");
            e14Names.Add("Holly");

            //'Insert' adds item to list to specific place - this will add Chris just after Martin
            e14Names.Insert(1, "Chris");

            //collection initializer - curly braces with elements inside
            var teacherNames = new List<string> { "Nathan", "Jameka", "Dylan", "Tom" };

            //add one collection to the other
            e14Names.AddRange(teacherNames);

            //removes item (Tom) from list - uses a thing called reference equality 
            e14Names.Remove("Tom");

            //removes item from list using the index. In this case, Martin would be removed.
            e14Names.RemoveAt(0);

            //remove by expression - this would remove Nathan because it starts with N
            e14Names.RemoveAll(name => name.StartsWith("N"));

            //normal foreach loop in C#
            foreach (var name in e14Names)
            {
                Console.WriteLine($"{name} is in e14");
            }

            // OR (the above and below line of code both basically do the same thing

            //this is a list specific loop, takes in an Action<T> - like fat arrow function
            e14Names.ForEach(name => Console.WriteLine($"{name} is in e14 again"));
            
            //get the item at the index of 0
            var firstStudent = e14Names[0];


            //Dictionary<TKey, TValue> -- "Open Generic" - no one has told them how to behave yet
            //**Arity (`2) -> how many generic type parameters a type has. Dictionary takes `2**
            //like a physical dictionary, sorta
            //keys have to be unique
            //our dictionary is keyed by strings and has string values
            //Good for: infrequently updated but often read data
            //Good for: loading information at startup or in the background and fast retrueval on demand
            var dictionary = new Dictionary<string, string>(); //"Closed Generic" - we have told it how to behave 

            //adding things required a key and a value
            dictionary.Add("Penultimate", "second to last");
            dictionary.Add("Jib", "The triangular sail on the front of a boat");
            dictionary.Add("Arbitrary", "Someone who doesn't like Arby's");

            //case sensitive - takes "arbitrary" and stores it as definition
            //get one thing based on its key
            var definition = dictionary["Arbitrary"];

            //this won't work; dictionaries require each key to be unique
            //dictionary.Add("Penultimate", "Thing said too many times at the Olympics.");
        
            //try methods return a boolean indicating success or failure. This example writes the line below if it failed to add the definition of penultimate
            //kind of expensice just to find out if the key exists
            if (!dictionary.TryAdd("Penultimate", "Thing said too many times at the Olympics."))
            {
                Console.WriteLine("It's already in the dictionary; I couldn't add it");
            }

           
            if (dictionary.ContainsKey("Penultimate"))
            {
                dictionary["Penultimate"] = "Thing said too many times at the Olympics.";
            }

            //give me all the keys in a collection
            //var allTheWords = dictionary.Keys;
            //OR
            //give me all the values in a collection
            //var allTheWords = dictionary.Values;
        
            //foreach (var item in dictionary)
            //{
            //   Console.WriteLine($"{item.Key}'s definition is {item.Value}");
            //}
            
            //C# destructuring
            foreach (var (word, def) in dictionary)
            {
                Console.WriteLine($"{word}'s definition is {def}");
            }

            var complicatedDictionary = new Dictionary<string, List<string>>();

            complicatedDictionary.Add("Soup", new List<string> { "Hot or cold liquid you eat." });
            var soupDefinitions = complicatedDictionary["Soup"];
            soupDefinitions.Add("This is a definition of soup");

            complicatedDictionary.Add("Arity", new List<string> { "A definition of arity" });

            foreach (var (word, definitions) in complicatedDictionary)
            {
                Console.WriteLine(word);
                foreach (var def in definitions)
                {
                    Console.WriteLine($"\t{def}");
                }
            }

            //Hashset<T>
            //Like a list in that they store a value at an index
            //Like a dictionary in that the value has to be unique
            //Completely different in that it eliminates non-unique stuff without errors
            //pretty slow at adding data
            //super fast at getting data out, comparing data
            //uses Hashcodes to figure out uniqueness

            var uniqueNames = new HashSet<string>();
            //no matter how many times Jameka is listed here, it will only print her name once
            //because hashsets are only good for storing one copy of a thing
            uniqueNames.Add("Jameka");
            uniqueNames.Add("Jameka"); 
            uniqueNames.Add("Jameka"); 
            uniqueNames.Add("Jameka"); 
            uniqueNames.Add("Dylan"); 
            uniqueNames.Add("Dylan"); 
            uniqueNames.Add("Dylan");

            uniqueNames.Remove("Dylan");

            foreach (var name in uniqueNames)
            {
                Console.WriteLine($"{name} is unique");
            }

            //Queue<T>
            //FIFO - first in, first out - the main tenet of queues
            //queues are a FIFO based collection
            //things that have to be done in order

            var queue = new Queue<int>();
            queue.Enqueue(3);
            queue.Enqueue(1);
            queue.Enqueue(5);
            queue.Enqueue(7);
            queue.Enqueue(6);
            queue.Enqueue(102);

            while(queue.Count > 0)
            {
                Console.WriteLine($"dequeuing {queue.Dequeue()}");
            }

            //Stack<T>
            //LIFO-based collection - last in, first out
            //things done in order, but with a bias towards recency
            var stack = new Stack<int>();

            stack.Push(2);
            stack.Push(34);
            stack.Push(6);
            stack.Push(512);
            stack.Push(9);
            stack.Push(202);

            while(stack.Count > 0)
            {
                Console.WriteLine($"popping {stack.Pop() }");
            }

        }
    }
}
